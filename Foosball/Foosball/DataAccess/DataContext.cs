using System.Data.Entity;
using Foosball.Models;

namespace Foosball.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Match> Matches { get; set; }

        public DbSet<Player> Players { get; set; }

        public void WriteChanges()
        {
            DataWriter.WriteFileCsv(Matches);
            DataWriter.WriteFileCsv(Players);
        }

        public void ReadChanges()
        {
            DataReader.ReadFromCsv(Matches);
            DataReader.ReadFromCsv(Players);

            SaveChanges();
        }
    }
}
