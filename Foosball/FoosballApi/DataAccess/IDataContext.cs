using System.Data.Entity;
using FoosballApi.Models;

namespace FoosballApi.DataAccess
{
    internal interface IDataContext
    {
        DbSet<Match> Matches { get; set; }

        DbSet<Player> Players { get; set; }

        DbSet<Team> Teams { get; set; }

        DbSet<Tournament> Tournaments { get; set; }
    }
}