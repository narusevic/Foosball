using System.Collections.Generic;

namespace FoosballApi.Models
{
    public class Team
    {
        public int Id { get; set; }

        public static int GlobalId { get; set; } = 0;

        public string Name { get; set; }

        public int MatchWins { get; set; } = 0;

        public int TournamentWins { get; set; } = 0;

        public int MatchesPlayed { get; set; } = 0;

        public Player PlayerA { get; set; }

        public Player PlayerB { get; set; }
        
        public Team()
        {
            Id = GlobalId++;
        }

        public Team(string name)
            : this()
        {
            Name = name;
        }

        public Team(string name, Player playerA, Player playerB)
            : this()
        {
            Name = name;
            PlayerA = playerA;
            PlayerB = playerB;
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
