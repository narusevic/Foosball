using System.Collections.Generic;

namespace Foosball.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        public static int GlobalId { get; set; } = 0;

        public string Name { get; set; }

		public List<Player> Players { get; set; }

        public Player Winner { get; set; }
		
        public Tournament()
        {
            Id = GlobalId++;
            Players = new List<Player>();
        }
    }
}
