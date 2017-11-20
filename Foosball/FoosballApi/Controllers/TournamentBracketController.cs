using Foosball.Models;
using System.Drawing;
using System.Linq;
using Foosball.Repositories;

namespace FoosballApi.Controllers
{
    public class TournamentBracketController
    {
        private Tournament _tournament;
        //private TournamentBracket _tournamentBracket;
        private int _amount;

        public TournamentBracketController(Tournament tournament, TournamentBracket tournamentBracket)
        {
            _tournament = tournament;
            _tournamentBracket = tournamentBracket;
        }

        public int AmountFinder()
        {
            var amount = _tournament.Teams.Count;

            if (amount < 8)
            {
                _amount = 4;
                return 4;
            }
            else if (amount < 16)
            {
                _amount = 8;
                return 8;
            }
            else if (amount < 32)
            {
                _amount = 16;
                return 16;
            }

            return 0;
        }

        public void CheckIfEnded()
        {
            if (_tournament.Teams.Count == AmountFinder() * 2 - 1)
            {
                _tournament.Winner = _tournament.Teams.Last();
                _tournamentBracket.Hide();

                var load = new TournamentWinner(_tournament.Winner.Name.ToString());

                _tournament.Winner.TournamentWins++;
                TeamRepository.Instance.Update(_tournament.Winner.Id, _tournament.Winner);

                load.ShowDialog();
                _tournamentBracket.Close();
            }
        }
    }
}
