using System;
using System.Collections.Generic;
using System.Net.Http;
using FoosballWebsite.Data.Abstract;
using FoosballWebsite.Models;
using Microsoft.Extensions.Logging;
using RecurrentTasks;

namespace FoosballWebsite.Core
{
    public class FeedEngine : IRunnable
    {
        private ILogger _logger;
        IMatchRepository _matchRepository;
        public FeedEngine(IMatchRepository matchRepository,
                          ILogger<FeedEngine> logger)
        {
            _logger = logger;
            this._matchRepository = matchRepository;
        }
        public void Run(TaskRunStatus taskRunStatus)
        {
            var msg = string.Format("Run at: {0}", DateTimeOffset.Now);
            _logger.LogDebug(msg);
            UpdateScore();
        }

        private async void UpdateScore()
        {
            IEnumerable<Match> _matches = _matchRepository.GetAll();

            foreach (var match in _matches)
            {
                Random r = new Random();
                bool updateHost = r.Next(0, 2) == 1;
                int points = r.Next(2, 4);
                bool _matchEnded = false;

                if (updateHost)
                    match.HostScore += points;
                else
                    match.GuestScore += points;

                var score = new MatchScore()
                {
                    HostScore = match.HostScore,
                    GuestScore = match.GuestScore
                };

                if (score.HostScore > 80 || score.GuestScore > 76)
                {
                    score.HostScore = 0;
                    score.GuestScore = 0;
                    _matchEnded = true;
                }

                // Update Score for all clients
                using (var client = new HttpClient())
                {
                    await client.PutAsJsonAsync<MatchScore>(Startup.API_URL + "matches/" + match.Id, score);
                }

                // Update Feed for subscribed only clients
                var _feed = new FeedViewModel()
                {
                    MatchId = match.Id,
                    Description = !_matchEnded ? 
                    (points + " points for " + (updateHost ? match.Host : match.Guest) + "!") :
                    "Match started",
                    CreatedAt = DateTime.Now
                };
                using (var client = new HttpClient())
                {
                    await client.PostAsJsonAsync<FeedViewModel>(Startup.API_URL + "feeds", _feed);
                }
            }
        }
    }
}