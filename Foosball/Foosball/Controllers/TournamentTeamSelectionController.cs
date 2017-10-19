using Foosball.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Foosball.Controllers
{
    class TournamentTeamSelectionController
    {
        public void NameValidation(List<Player> names, TournamentTeamSelection teamSelection)
        {
            var pattern1 = @"^[a-zA-Z]+\s[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern2 = @"^[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern3 = @"^[a-zA-Z]+$";

            foreach (Player s in names)
            {
                if ((Regex.IsMatch(s.ToString(), pattern1)) || (Regex.IsMatch(s.ToString(), pattern2)) || (Regex.IsMatch(s.ToString(), pattern3)))
                {
                    if (s == names.Last<Player>())
                    {
                        Tournament tournament = new Tournament();
                        tournament.Players = names;
                        teamSelection.Hide();
                        var load = new TournamentBracket(tournament);
                        load.ShowDialog();
                        teamSelection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Name" + s, "Bad name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }
    }
}
