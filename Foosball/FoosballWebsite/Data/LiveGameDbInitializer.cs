using System;
using System.Collections.Generic;
using System.Linq;
using FoosballWebsite.Models;

namespace FoosballWebsite.Data
{
    public class LiveGameDbInitializer
    {
        private static LiveGameContext _context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = (LiveGameContext)serviceProvider.GetService(typeof(LiveGameContext));

            InitializeSchedules();
        }

        private static void InitializeSchedules()
        {
            if (!_context.Matches.Any())
            {
                Match match_01 = new Match
                {
                    Host = "Kartu",
                    Guest = "Hello World",
                    HostScore = 0,
                    GuestScore = 0,
                    MatchDate = DateTime.Now,
                    Type = MatchTypeEnums.Foosball,
                    Feeds = new List<Feed>
                    {
                        new Feed()
                        {
                            Description = "Match started",
                            MatchId = 1,
                            CreatedAt = DateTime.Now
                        }
                    }
                };

                Match match_02 = new Match
                {
                    Host = "Kamanes",
                    Guest = "Takeliukas",
                    HostScore = 0,
                    GuestScore = 0,
                    MatchDate = DateTime.Now,
                    Type = MatchTypeEnums.Foosball,
                    Feeds = new List<Feed>
                    {
                        new Feed()
                        {
                            Description = "Match started",
                            MatchId = 2,
                            CreatedAt = DateTime.Now
                        }
                    }
                };

                _context.Matches.Add(match_01); _context.Matches.Add(match_02);

                _context.SaveChanges();
            }
        }
    }
}