using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FoosballApi.Models;
using FoosballApi.Repositories;

namespace FoosballApi.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;

        public StatisticsController(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
        }
        
        [Route("api/Managing/Teams")]
        [HttpGet]
        public List<Team> GetAllTeams()
        {
            return _teamRepository.ReadAll().ToList();
        }

        [Route("api/Managing/Players")]
        [HttpGet]
        public List<Player> GetAllPlayers()
        {
            return _playerRepository.ReadAll().ToList();
        }
    }
}
