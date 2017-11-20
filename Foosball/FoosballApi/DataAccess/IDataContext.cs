using System.Data.Entity;
using Foosball.Models;

namespace Foosball.DataAccess
{
    internal interface IDataContext
    {
        DbSet<Match> Matches { get; set; }

        DbSet<Player> Players { get; set; }

        DbSet<Team> Teams { get; set; }

        DbSet<Tournament> Tournaments { get; set; }
    }
}