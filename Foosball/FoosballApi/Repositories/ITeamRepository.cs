using FoosballApi.Models;
using FoosballApi.Repositories;
using System.Collections.Generic;

namespace FoosballApi.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        Team this[string name] { get; }

        Team FindByName(string name);

        IEnumerable<Team> ReadAll();
    }
}
