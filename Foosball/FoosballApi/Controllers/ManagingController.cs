using FoosballApi.Models;
using FoosballApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FoosballApi.Controllers
{
    public class ManagingController : ApiController
    {
        public readonly ITeamRepository _teamRepository;

        public ManagingController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [Route("api/Managing/GetAllTeams")]
        [HttpGet]
        public List<Team> GetAllTeams() => _teamRepository.ReadAll().ToList();

        [Route("api/Managing/RemoveTeam/{id}")]
        [HttpDelete]
        public void RemoveTeam(int id)
        {
            _teamRepository.Delete(id);
        }

        [Route("api/Managing/TeamExists/{name}")]
        [HttpGet]
        public bool TeamExists(string name) => _teamRepository[name] != null;


        [Route("api/Managing/PlayersExists")]
        [HttpGet]
        public bool PlayersExists(string playerAName, string playerBName) 
            => _teamRepository[playerAName] != null || _teamRepository[playerBName] != null;
        
        [Route("api/Managing/GetAllTeams/{teamName}/")]
        [HttpPost]
        public void CreateTeam([FromBody] string teamName, string playerAName, string playerBName)
        {
            var playerA = new Player(playerAName);
            var playerB = new Player(playerAName);

            PlayerRepository.Instance.Create(playerA);
            PlayerRepository.Instance.Create(playerB);
            _teamRepository.Create(new Team(teamName, playerA, playerB));
        }
        
        [Route("api/Managing/RenameTeam")]
        [HttpPut]
        public void RenameTeam(int teamId, string name)
        {
            var team = TeamRepository.Instance.Read(teamId);
            team.Name = name;

            _teamRepository.Update(teamId, team);
        }
        
        [Route("api/Managing/RenameTeam/{teamId}/{playerAName}/playerBName")]
        [HttpPut]
        public void ChangePlayers(int teamId, string playerAName, string playerBName)
        {
            var playerA = PlayerRepository.Instance[playerAName] ?? new Player(playerAName);
            var playerB = PlayerRepository.Instance[playerBName] ?? new Player(playerBName);
            var team = _teamRepository.Read(teamId);

            team.PlayerA = playerA;
            team.PlayerB = playerB;

            _teamRepository.Update(teamId, team);
        }
    }
}
