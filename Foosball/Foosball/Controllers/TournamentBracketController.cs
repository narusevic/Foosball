using Foosball.Models;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Foosball.Controllers
{
    class TournamentBracketController
    {
        private Tournament _tournament;
        private TournamentBracket _tournamentBracket;
        private int _amount;

        public TournamentBracketController(Tournament tournament, TournamentBracket tournamentBracket)
        {
            this._tournament = tournament;
            this._tournamentBracket = tournamentBracket;
        }

        public void AddTeamNames()
        {
            int n = _amount * 2 - 1;
            int z = _tournament.Players.Count - 1;
            var myLabel = _tournamentBracket.Controls.OfType<Label>();
            myLabel = myLabel.OrderBy(label => label.TabIndex);
            for (int i = n - _tournament.Players.Count; i < n; i++)
            {
                myLabel.ElementAt(i).Text = _tournament.Players[z].ToString();
                if ((z == _tournament.Round * 2 - 1) || (z == _tournament.Round * 2 - 2))
                {
                    myLabel.ElementAt(i).BackColor = Color.Red;
                }
                z--;
            }
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
                var load = new TournamentWinner(_tournament.Winner.ToString());
                load.ShowDialog();
                _tournamentBracket.Close();
            }
        }
    }
}
