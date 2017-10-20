using Foosball.Models;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Foosball.Controllers
{
    public class TournamentBracketController
    {
        private Tournament _tournament;
        private TournamentBracket _tournamentBracket;
        private int _amount;

        public TournamentBracketController(Tournament tournament, TournamentBracket tournamentBracket)
        {
            this._tournament = tournament;
            this._tournamentBracket = tournamentBracket;
        }

        public int AmountFinder()
        {
            int amount = _tournament.Players.Count();
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
            if (_tournament.Players.Count == AmountFinder() * 2 - 1)
            {
                _tournament.Winner = _tournament.Players.Last();
                _tournamentBracket.Hide();
                var load = new TournamentWinner(_tournament.Winner.Name.ToString());
                load.ShowDialog();
                _tournamentBracket.Close();
            }
        }
    }
}
