using FoosballWebsite.Models;

namespace FoosballWebsite.Data.Abstract
{
    public interface IMatchRepository : IEntityBaseRepository<Match> { }

    public interface IFeedRepository : IEntityBaseRepository<Feed> { }

}
