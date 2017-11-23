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
            _matchRepository = matchRepository;
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
                bool updateHost = false;
                bool scoreUpdated = true;
                if (match.IsChangedHost || match.IsChangedGuest)
                {
                    if (match.IsChangedHost)
                    {
                        updateHost = true;
                    }
                }
                else
                {
                    scoreUpdated = false;
                }

                bool _matchEnded = false;

                var score = new MatchScore()
                {
                    HostScore = match.HostScore,
                    GuestScore = match.GuestScore
                };

                if (score.HostScore >= 10 || score.GuestScore >= 10)
                {
                    _matchEnded = true;
                }

                // Update Score for all clients
                using (var client = new HttpClient())
                {
                    await client.PutAsJsonAsync<MatchScore>(Startup.API_URL + "matches/" + match.Id, score);
                }

                // Update Feed for subscribed only clients
                if (scoreUpdated)
                {
                    var _feed = new FeedViewModel()
                    {
                        MatchId = match.Id,
                        Description = (1 + " points for " + (updateHost ? match.Host : match.Guest) + "!"),
                        CreatedAt = DateTime.Now
                    };

                    using (var client = new HttpClient())
                    {
                        await client.PostAsJsonAsync<FeedViewModel>(Startup.API_URL + "feeds", _feed);
                    }
                }

                if (_matchEnded)
                {
                    var _feed2 = new FeedViewModel()
                    {
                        MatchId = match.Id,
                        Description = "Match Ended",
                        CreatedAt = DateTime.Now
                    };

                    var _feed3 = new FeedViewModel()
                    {
                        MatchId = match.Id,
                        Description = "Winner " + ((match.HostScore >= 10) ? match.Host : match.Guest),
                        CreatedAt = DateTime.Now
                    };

                    using (var client = new HttpClient())
                    {
                        await client.PostAsJsonAsync<FeedViewModel>(Startup.API_URL + "feeds", _feed2);
                        await client.PostAsJsonAsync<FeedViewModel>(Startup.API_URL + "feeds", _feed3);
                    }
                }
            }
        }
    }
}