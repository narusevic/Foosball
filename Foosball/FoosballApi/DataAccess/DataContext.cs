using System.Data.Entity;
using FoosballApi.Models;

namespace FoosballApi.DataAccess
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

            SaveChanges();
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
