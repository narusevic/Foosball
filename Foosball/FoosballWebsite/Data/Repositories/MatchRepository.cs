using FoosballWebsite.Data.Abstract;
using FoosballWebsite.Models;

namespace FoosballWebsite.Data.Repositories
{
    public class MatchRepository : EntityBaseRepository<Match>, IMatchRepository
    {
        public MatchRepository(LiveGameContext context)
            : base(context)
        { }
    }
}
