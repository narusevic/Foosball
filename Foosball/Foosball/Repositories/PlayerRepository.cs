using Foosball.DataAccess;
using Foosball.Models;
using System.Collections.Generic;
using System.Linq;

namespace Foosball.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        public static PlayerRepository Instance;
        private readonly DataContext _dataContext;

        public Player this[string name] => FindByName(name);

        public PlayerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            Instance = this;
        }

        public Player Read(int id)
        {
            return _dataContext.Players.First(p => p.Id == id);
        }

        public Player FindByName(string name)
        {
            return _dataContext.Players.FirstOrDefault(p => p.Name == name);
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

        public IEnumerable<Player> ReadAll()
        {
            _dataContext.Players.Add(new Player("Linas"));
            _dataContext.Players.Add(new Player("Lukas"));
            _dataContext.Players.Add(new Player("Tomas"));
            _dataContext.Players.Add(new Player("Magnus"));
            _dataContext.Players.Add(new Player("Marijus"));
            _dataContext.Players.Add(new Player("Aurimas"));
            _dataContext.Players.Add(new Player("Rokas"));
            _dataContext.Players.Add(new Player("Greta"));
            _dataContext.Players.Add(new Player("Sabina"));
            _dataContext.Players.Add(new Player("Elžbieta"));
            return _dataContext.Players;
        }
    }
}
