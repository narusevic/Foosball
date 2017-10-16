using System.Data.Entity;
using Foosball.Models;

namespace Foosball.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Match> Matches { get; set; }

        public DbSet<Player> Players { get; set; }

        public override int SaveChanges()
        {
            WriteChanges();

            return 0;
        }

        public void WriteChanges()
        {
            DataWriter.WriteFileCsv<Match>(Matches);
            DataWriter.WriteFileCsv<Player>(Players);
        }
    }
}
