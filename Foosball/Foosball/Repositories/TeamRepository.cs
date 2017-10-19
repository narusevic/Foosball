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

        public TeamRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            Instance = this;
        }

        public Team Read(int id)
        {
            return _dataContext.Teams.First(p => p.Id == id);
        }

        public void Create(Team player)
        {
            _dataContext.Teams.Add(player);
            _dataContext.WriteChanges();
        }

        public void Update(int id, Team player)
        {
            
        }

        public void Delete(int id)
        {
            _dataContext.Teams.Remove(Read(id));
            _dataContext.WriteChanges();
        }

        public IEnumerable<Team> ReadAll()
        {
            var deletes = _dataContext.Teams.Where(d => d.Id > 5);
            _dataContext.Teams.RemoveRange(deletes);
            return _dataContext.Teams;
        }
    }
}
