using FoosballApi.DataAccess;
using FoosballApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoosballApi.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly DataContext _dataContext;

        public MatchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Match Read(int id)
        {
            return _dataContext.Matches.First(m => m.Id == id);
        }
        
        public void Create(Match match)
        {
            _dataContext.Matches.Add(match);
            _dataContext.SaveChanges();
        }

        public void Update(int id, Match entity)
        {
            var item = _dataContext.Matches.SingleOrDefault(p => p.Id == id);

            if (item == null)
            {
                return;
            }

            item.TeamA = entity.TeamA;
            item.TeamB = entity.TeamB;
            item.AScore = entity.AScore;
            item.BScore = entity.BScore;
            item.End = entity.End;
            item.Id = entity.Id;
            item.Result = entity.Result;
            item.Start = entity.Start;

            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dataContext.Matches.Remove(Read(id));
            _dataContext.SaveChanges();
        }

        public IEnumerable<Match> ReadAll()
        {
            return _dataContext.Matches;
        }
    }
}
