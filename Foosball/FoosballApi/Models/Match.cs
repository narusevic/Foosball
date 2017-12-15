using System;

namespace FoosballApi.Models
{
    public class Match
    {
        public int Id { get; set; }

        public static int GlobalId { get; set; } = 0;

        public int TeamA_Id { get; set; }
        public Team TeamA { get; set; }

        public int TeamB_Id { get; set; }
        public Team TeamB { get; set; }

        public int? Result { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public int AScore { get; set; }

        public int BScore { get; set; }

        public Match()
        {
            Id = GlobalId++;
            Start = DateTime.Now;
            AScore = 0;
            BScore = 0;
        }

        public Match(string playerA, string playerB)
            : this()
        {
            TeamA = new Team(playerA);
            TeamB = new Team(playerB);
        }
    }
}
