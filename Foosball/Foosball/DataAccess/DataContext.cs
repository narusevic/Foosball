using System.Data.Entity;
using Foosball.Models;

namespace Foosball.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Match> Matches { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public void WriteChanges()
        {
            DataWriter.WriteFileCsv(Matches);
            DataWriter.WriteFileCsv(Players);
            DataWriter.WriteFileCsv(Teams);
            DataWriter.WriteFileCsv(Tournaments);
        }

        public void ReadChanges()
        {
            DataReader.ReadFromCsv(Matches);
            DataReader.ReadFromCsv(Players);
            DataReader.ReadFromCsv(Teams);
            DataReader.ReadFromCsv(Tournaments);

            SaveChanges();
        }
    }
}
