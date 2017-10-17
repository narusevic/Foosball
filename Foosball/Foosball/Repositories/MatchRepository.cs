﻿using Foosball.DataAccess;
using Foosball.Models;
using System.Linq;

namespace Foosball.Repositories
{
    public class MatchRepository : IRepository<Match>
    {
        public static MatchRepository Instance;
        private readonly DataContext _dataContext;

        public MatchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            Instance = this;
        }

        public Match Read(int id)
        {
            return _dataContext.Matches.First(m => m.Id == id);
        }
        
        public void Create(Match match)
        {
            _dataContext.Matches.Add(match);
            _dataContext.WriteChanges();
        }

        public void Update(int id, Match entity)
        {

        }

        public void Delete(int id)
        {
            _dataContext.Matches.Remove(Read(id));
            _dataContext.WriteChanges();
        }
    }
}
