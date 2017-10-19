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
            return TeamRepository.Instance.ReadAll().ToList();
        }
    }
}
