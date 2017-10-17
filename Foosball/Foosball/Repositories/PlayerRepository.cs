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
            Instance = this;
        }

        public Player Read(int id)
        {
            return _dataContext.Players.First(p => p.Id == id);
        }

        public void Create(Player player)
        {
            _dataContext.Players.Add(player);
            _dataContext.WriteChanges();
        }

        public void Update(int id, Player player)
        {
            
        }

        public void Delete(int id)
        {
            _dataContext.Players.Remove(Read(id));
            _dataContext.WriteChanges();
        }
    }
}
