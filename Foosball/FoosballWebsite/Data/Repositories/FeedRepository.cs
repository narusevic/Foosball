using FoosballWebsite.Data.Abstract;
using FoosballWebsite.Models;

namespace FoosballWebsite.Data.Repositories
{
    public class FeedRepository : EntityBaseRepository<Feed>, IFeedRepository
    {
        public FeedRepository(LiveGameContext context)
            : base(context)
        { }
    }
}
