using Foosball.DataAccess;
using Foosball.Models;
using System.Linq;

namespace Foosball.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        public static PlayerRepository Instance;
        private readonly DataContext _dataContext;

        public PlayerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Player Get(int id)
        {
            return _dataContext.Players.First(p => p.Id == id);
        }

        public void Post(Player player)
        {
            _dataContext.Players.Add(player);
        }

        public void Update(int id, Player player)
        {
            
        }

        public void Remove(int id)
        {
            _dataContext.Players.Remove(Get(id));
        }
    }
}
