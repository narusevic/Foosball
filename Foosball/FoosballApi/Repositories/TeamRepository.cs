using Foosball.DataAccess;
using Foosball.Models;
using System.Collections.Generic;
using System.Linq;

namespace Foosball.Repositories
{
    public class TeamRepository : IRepository<Team>
    {
        public static TeamRepository Instance;
        private readonly DataContext _dataContext;

        public Team this[string name] => FindByName(name);

        public TeamRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            Instance = this;
        }

        public Team Read(int id)
        {
            return _dataContext.Teams.FirstOrDefault(p => p.Id == id);
        }

        public Team FindByName(string name)
        {
            return _dataContext.Teams.FirstOrDefault(p => p.Name == name);
        }

        public void Create(Team team)
        {
            _dataContext.Teams.Add(team);
            _dataContext.WriteChanges();
        }

        public void Update(int id, Team team)
        {
            var item = _dataContext.Teams.SingleOrDefault(p => p.Id == id);

            if (item == null)
            {
                return;
            }

            item.MatchWins = team.MatchWins;
            item.MatchesPlayed = team.MatchesPlayed;
            item.PlayerA = team.PlayerA;
            item.PlayerB = team.PlayerB;
            item.TournamentWins = team.TournamentWins;
            item.Name = team.Name;

            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dataContext.Teams.Remove(Read(id));
            _dataContext.WriteChanges();
        }

        public IEnumerable<Team> ReadAll()
        {
            return _dataContext.Teams;
        }
    }
}
