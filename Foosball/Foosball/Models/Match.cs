using System;

namespace Foosball.Models
{
    public class Match
    {
        public int Id { get; set; }

        public static int GlobalId { get; set; } = 0;

        public Player PlayerA { get; set; }

        public Player PlayerB { get; set; }

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
            : base()
        {
            PlayerA = new Player(playerA);
            PlayerB = new Player(playerB);
        }
    }
}
