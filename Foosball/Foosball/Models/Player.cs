using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball.Models
{
    public class Player
    {
        public int Id { get; set; }

        public static int GlobalId { get; set; } = 0;

        public string Name { get; set; }

        public Player()
        {
            Id = GlobalId++;
        }

        public Player(string name)
            : base()
        {
            Name = name;
        }
    }
}
