using FoosballApi.DataAccess;
using FoosballApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoosballApi.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext _dataContext;

        public Player this[string name] => FindByName(name);

        public PlayerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Player Read(int id)
        {
            return _dataContext.Players.First(p => p.Id == id);
        }

        public Player FindByName(string name)
        {
            return DeleteSamePlayers(name);
        }

        public Player DeleteSamePlayers(string name)
        {
            var playersCount = _dataContext.Players.Where(x => x.Name == name).Count();

            Player result = null; 

            if (playersCount > 0)
            {
                result = _dataContext.Players.Where(x => x.Name == name).Take(1).First();
                var removedPlayers = _dataContext.Players.Where(x => x.Name == name).Skip(1);
                
                foreach (var player in removedPlayers)
                {
                    _dataContext.Players.Remove(player);
                }

                _dataContext.SaveChanges();
            }

            return result;
        }

        public void Create(Player player)
        {
            _dataContext.Players.Add(player);
            _dataContext.SaveChanges();
        }

        public void Update(int id, Player player)
        {
            var item = _dataContext.Players.SingleOrDefault(p => p.Id == id);

            if (item == null)
            {
                return;
            }

            item.MatchWins = player.MatchWins;
            item.MatchPlayed = player.MatchPlayed;
            item.Name = player.Name;
            item.TournamentWins = player.TournamentWins;

            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dataContext.Players.Remove(Read(id));
            _dataContext.SaveChanges();
        }

        public IEnumerable<Player> ReadAll()
        {
            return _dataContext.Players;
        }
    }
}
