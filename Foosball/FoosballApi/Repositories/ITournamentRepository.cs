using FoosballApi.Models;
using System.Collections.Generic;
using FoosballApi.Repositories;

namespace FoosballApi.Repositories
{
    public interface ITournamentRepository : IRepository<Tournament>
    {
        IEnumerable<Tournament> ReadAll();
    }
}
