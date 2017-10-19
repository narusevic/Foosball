using System.Collections.Generic;
using System.Linq;
using Foosball.Models;
using Foosball.Repositories;

namespace Foosball.Controllers
{
    public class StatisticsController
    {
        public List<Team> GetAllTeams()
        {
            TeamRepository.Instance.Create(new Team("Ant penkiu", 2, 1, 8));
            TeamRepository.Instance.Create(new Team("Komaliukas", 4, 1, 11));
            TeamRepository.Instance.Create(new Team("FastBall", 0, 0, 3));
            TeamRepository.Instance.Create(new Team("LeoCup", 8, 2, 21));
            TeamRepository.Instance.Create(new Team("Kepure", 2, 1, 7));

            return TeamRepository.Instance.ReadAll().ToList();
        }
    }
}
