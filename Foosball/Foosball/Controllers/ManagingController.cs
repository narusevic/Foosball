using Foosball.Models;
using Foosball.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Foosball.Controllers
{
    public class ManagingController
    {
        public List<Team> GetAllTeams()
        {
            return TeamRepository.Instance.ReadAll().ToList();
        }

        public void RemoveTeam(int id)
        {
            TeamRepository.Instance.Delete(id);
        }

        public bool TeamExists(string teamName)
        {
            return TeamRepository.Instance[teamName] != null;
        }

        public bool PlayersExists(string playerAName, string playerBName)
        {
            return TeamRepository.Instance[playerAName] != null || TeamRepository.Instance[playerBName] != null;
        }

        public void CreateTeam(string teamName, string playerAName, string playerBName)
        {
            var playerA = new Player(playerAName);
            var playerB = new Player(playerAName);

            PlayerRepository.Instance.Create(playerA);
            PlayerRepository.Instance.Create(playerB);
            TeamRepository.Instance.Create(new Team(teamName, playerA, playerB));
        }

        public void RenameTeam(int teamId, string name)
        {
            var team = TeamRepository.Instance.Read(teamId);
            team.Name = name;

            TeamRepository.Instance.Update(teamId, team);
        }

        public void ChangePlayers(int teamId, string playerAName, string playerBName)
        {
            var playerA = PlayerRepository.Instance[playerAName] ?? new Player(playerAName);
            var playerB = PlayerRepository.Instance[playerBName] ?? new Player(playerBName);
            var team = TeamRepository.Instance.Read(teamId);

            team.PlayerA = playerA;
            team.PlayerB = playerB;


            TeamRepository.Instance.Update(teamId, team);
        }
    }
}
