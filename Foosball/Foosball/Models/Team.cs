using System.Collections.Generic;

namespace Foosball.Models
{
    public class Team
    {
        public int Id { get; set; }

        public static int GlobalId { get; set; } = 0;

        public string Name { get; set; }

        public int MatchWins { get; set; } = 0;

        public int TournamentWins { get; set; } = 0;

        public int MatchesPlayed { get; set; } = 0;

        public List<Player> Players { get; set; }

        public Team()
        {
            Id = GlobalId++;
        }

        public Team(string name)
            : this()
        {
            Name = name;
        }

        public Team(string name, int mw, int tw, int mp)
            : this()
        {
            Name = name;
            MatchWins = mw;
            TournamentWins = tw;
            MatchesPlayed = mp;
        }
    }
}
