using FoosballApi.Repositories;
using FoosballApi.Models;
using System.Collections.Generic;

namespace FoosballApi.Repositories
{
    public interface IMatchRepository : IRepository<Match>
    {
        IEnumerable<Match> ReadAll();
    }
}
