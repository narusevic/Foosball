using FoosballApi.Models;
using FoosballApi.Repositories;
using System.Collections.Generic;

namespace FoosballApi.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player this[string name] { get; }

        Player FindByName(string name);

        IEnumerable<Player> ReadAll();
    }
}
