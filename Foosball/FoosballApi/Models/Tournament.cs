using System.Collections.Generic;

namespace FoosballApi.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        public static int GlobalId { get; set; } = 0;

        public string Name { get; set; }

		public List<Team> Teams { get; set; }

        public Team Winner { get; set; }

        public int Round { get; set; } = 1;
		
        public Tournament()
        {
            Id = GlobalId++;
            Teams = new List<Team>();
        }
    }
}
