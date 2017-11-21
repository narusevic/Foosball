using FoosballApi.DataAccess;
using FoosballApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoosballApi.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DataContext _dataContext;

        public TournamentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
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
            var item = _dataContext.Tournaments.SingleOrDefault(p => p.Id == id);

            if (item == null)
            {
                return;
            }

            item.Teams = tournament.Teams;
            item.Winner = tournament.Winner;
            item.Name = tournament.Name;
            item.Round = tournament.Round;

            _dataContext.SaveChanges();
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
