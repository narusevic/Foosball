namespace Foosball.Models
{
    public class Player
    {
        public int Id { get; set; }

        public static int GlobalId { get; set; } = 0;

        public string Name { get; set; }

        public int MatchWins { get; set; } = 0;

        public int TournamentWins { get; set; } = 0;

        public int MatchPlayed { get; set; } = 0;

        public Player()
        {
            Id = GlobalId++;
        }

        public Player(string name)
            : this()
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
