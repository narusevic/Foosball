using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using FoosballApi.Models;
using FoosballApi.Repositories;

namespace FoosballApi.Controllers
{
    public class MatchController
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;

        private int _counter = 25;
        private List<Rectangle> _goalAHistory = new List<Rectangle>();
        private List<Rectangle> _goalBHistory = new List<Rectangle>();

        private Match _match;

        public Team PlayerA
        {
            get { return _match.TeamA; }
            set { _match.TeamA = value; }
        }

        public Team PlayerB
        {
            get { return _match.TeamB; }
            set { _match.TeamB = value; }
        }

        public int AScore
        {
            get { return _match.AScore; }
            set { _match.AScore = value; }
        }

        public int BScore
        {
            get { return _match.BScore; }
            set { _match.BScore = value; }
        }

        public MatchController(ITeamRepository teamRepository, IMatchRepository matchRepository)
        {
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
        }

        public void SetMatch(Match match)
        {
            _match = match;
        }

        public Tuple<Rectangle,Rectangle> FindGoals(Mat m, Hsv lowerLimit, Hsv upperLimit)
        {
            var goalA = FindObject(new Mat(m, new Rectangle(new Point(0, 100), new Size(200, 100))), lowerLimit, upperLimit);
            var goalB = FindObject(new Mat(m, new Rectangle(new Point(400, 100), new Size(200, 100))), lowerLimit, upperLimit);

            goalA = new Rectangle(new Point(goalA.X, goalA.Y+100), new Size(goalA.Width, goalA.Height));
            goalB = new Rectangle(new Point(goalB.X+400, goalB.Y+100), new Size(goalB.Width, goalB.Height));
            _goalAHistory.Add(goalA);
            _goalBHistory.Add(goalB);

            if (_goalAHistory.Count > 10) _goalAHistory.RemoveAt(0);
            if (_goalBHistory.Count > 10) _goalBHistory.RemoveAt(0);

            return Tuple.Create(goalA, goalB);
        }
        public Rectangle FindObject(Mat m, Hsv lowerLimit, Hsv upperLimit)
        {

            Rectangle rect = new Rectangle(new Point(0,0), new Size(0,0));                     
            Image<Gray, byte> imgHSVDest = (new Image<Hsv, byte>(m.Bitmap)).InRange(lowerLimit, upperLimit);


            int largestContourIndex = 0;
            double largestArea = 0;
            var contours = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(imgHSVDest, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
     
            for (int i = 0; i < contours.Size; i++)
              {
                  var color = new MCvScalar(0, 0, 255);
                  double a = CvInvoke.ContourArea(contours[i], false);

                  if (a > largestArea)
                  {
                      largestArea = a;
                      largestContourIndex = i;
                  }
              }
            if (contours.Size != 0)
            {
                rect = CvInvoke.BoundingRectangle(contours[largestContourIndex]);              
            }

            return rect;
        }

        public bool SetScores(Rectangle ball)
        {
            if (_counter>24)
            {
                foreach (Rectangle g in _goalAHistory)
                {
                    if (ball.IntersectsWith(g))
                    {
                        _counter = 0;
                        _match.AScore++;
                        return true;
                    }
                }

                foreach (Rectangle g in _goalBHistory)
                {
                    if (ball.IntersectsWith(g))
                    {
                        _counter = 0;
                        _match.BScore++;
                        return true;
                    }
                }
            }
            else
            {
                _counter++;
            }
            
            return false;
        }
      
        public bool CheckForWinner()
        {
            if (_match.AScore >= 10)
            {
                _match.TeamA.MatchWins++;
                _match.TeamA.MatchesPlayed++;
                if (_match.TeamA.PlayerA != null)
                {
                    _match.TeamA.PlayerA.MatchWins++;
                    _match.TeamA.PlayerA.MatchPlayed++;
                }
                if (_match.TeamA.PlayerB != null)
                {
                    _match.TeamA.PlayerB.MatchPlayed++;
                }
                return true;
            }
            if (_match.BScore >= 10)
            {
                _match.TeamB.MatchWins++;
                _match.TeamB.MatchesPlayed++;

                if (_match.TeamA.PlayerA != null)
                {
                    _match.TeamA.PlayerA.MatchWins++;
                }

                if (_match.TeamA.PlayerB != null)
                {
                    _match.TeamA.PlayerB.MatchPlayed++;
                    _match.TeamA.PlayerB.MatchPlayed++;
                }

                return true;
            }
            return false;
        }

        public bool CheckIfPlayerAWon()
        {
            if (_match.AScore >= 10)
            {
                return true;
            }
            return false;
        }

        public void CreateMatch(Match match, string teamAName, string teamBName)
        {
            var teamA = _teamRepository[teamAName];

            if (teamA == null)
            {
                teamA = new Team(teamAName);
                _teamRepository.Create(teamA);
            }

            var teamB = _teamRepository[teamBName];

            if (teamB == null)
            {
                teamB = new Team(teamBName);
                _teamRepository.Create(teamB);
            }

            match.TeamA = teamA;
            match.TeamB = teamB;

            _matchRepository.Create(match);
        }
    }
}
