using System.Data.Entity;
using Foosball.Models;

namespace Foosball.DataAccess
{
    public class DataContext : IDataContext
    {
        public DbSet<Match> Matches { get; set; }

        public DbSet<Player> Players { get; set; }
    }
}
