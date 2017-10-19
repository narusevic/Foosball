using System.Collections;
using Foosball.DataAccess;
using Foosball.Models;
using System.Linq;
using System.Collections.Generic;

namespace Foosball.Repositories
{
    public class TournamentRepository : IRepository<Tournament>
    {
        public static TournamentRepository Instance;
        private readonly DataContext _dataContext;

        public TournamentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            Instance = this;
        }

        public Tournament Read(int id)
        {
            return _dataContext.Tournaments.First(p => p.Id == id);
        }

        public void Create(Tournament tournament)
        {
            _dataContext.Tournaments.Add(tournament);
            _dataContext.WriteChanges();
        }

        public void Update(int id, Tournament tournament)
        {
            
        }

        public void Delete(int id)
        {
            _dataContext.Tournaments.Remove(Read(id));
            _dataContext.WriteChanges();
        }

        public IEnumerable<Tournament> ReadAll()
        {
            return _dataContext.Tournaments;
        }
    }
}
