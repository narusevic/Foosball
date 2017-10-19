using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Drawing;
using Foosball.Models;
namespace Foosball
{
    class MatchController
    {
        private List<Rectangle> _lastRectangles = new List<Rectangle>();
        private Match _match;

        public Player PlayerA
        {
            get { return _match.PlayerA; }
            set { _match.PlayerA = value; }
        }

        public Player PlayerB
        {
            get { return _match.PlayerB; }
            set { _match.PlayerB = value; }
        }

        public int AScore
        {
            get { return _match.AScore; }
            set {  _match.AScore = value; }
        }

        public int BScore
        {
            get { return _match.BScore; }
            set { _match.BScore = value; }
        }

        public MatchController(Match match)
        {
            _match = match;
        }

        public Rectangle FindBall(Mat m, Hsv lowerLimit, Hsv upperLimit)
        {
            
            Image<Hsv, byte> imgHSV = new Image<Hsv, byte>(m.Bitmap);
            Image<Bgr, byte> imgBGR = new Image<Bgr, byte>(m.Bitmap); ;
            Image<Gray, byte> imgHSVDest = imgHSV.InRange(lowerLimit, upperLimit);
            imgHSVDest.Erode(2);
            imgHSVDest.Dilate(2);
         
            int largestContourIndex = 0;
            double largestArea = 0;
            var contours = new VectorOfVectorOfPoint();
            
            CvInvoke.FindContours(imgHSVDest, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
            Console.WriteLine(contours.Size);
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

            Rectangle rect = CvInvoke.BoundingRectangle(contours[largestContourIndex]);
            _lastRectangles.Add(rect);
            

            return rect;
           

            
        }

        public bool SetScores(int width)
        {
            //the idea is to select 30 frames and compare if first 15 rectangle coordinates
            //are different than last 15. In that case, The user, who had the ball before
            //loosing it, has scored.
            if (_lastRectangles.Count < 20)
                return false;

            bool goal = false;

            if (IsBallLost())
            {
                if (_lastRectangles[9].X < width / 2)
                    _match.BScore++;
                else 
                    _match.AScore++;

                goal = true;
               
            }

            _lastRectangles.RemoveAt(0);

            return goal;
        }

        private bool IsBallLost()
        {
            for (var i = 0; i < 9; i++)
            {
                if (Math.Abs(_lastRectangles[i].X - _lastRectangles[i + 1].X) > 20 ||
                    Math.Abs(_lastRectangles[i].Y - _lastRectangles[i + 1].Y) > 20)
                    return false;
            }

            for (var i = 10; i < 19; i++)
            {
                if (Math.Abs(_lastRectangles[i].X - _lastRectangles[i + 1].X) > 20 ||
                    Math.Abs(_lastRectangles[i].Y - _lastRectangles[i + 1].Y) > 20)
                    return false;
            }

            if (Math.Abs(_lastRectangles[14].X - _lastRectangles[15].X) > 50 ||
                Math.Abs(_lastRectangles[14].Y - _lastRectangles[15].Y) > 50)
            {
                return true;
            }

            return false;
        }

        public bool CheckForWinner()
        { 
              
            if (_match.AScore >= 10)
            { 
                return true;
            }
            if (_match.BScore >= 10)
            {
                return true;
            }

            return false;
                    
        }

    }
}
