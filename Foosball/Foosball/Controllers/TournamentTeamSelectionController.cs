using Foosball.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Foosball.Controllers
{
    class TournamentTeamSelectionController
    {
        public void NameValidation(List<string> names, TournamentTeamSelection teamSelection)
        {
            var pattern1 = @"^[a-zA-Z]+\s[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern2 = @"^[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern3 = @"^[a-zA-Z]+$";
            var teamNames = new List<Player>();

            foreach (var s in names)
            {
                if ((Regex.IsMatch(s.ToString(), pattern1)) || (Regex.IsMatch(s.ToString(), pattern2)) || (Regex.IsMatch(s.ToString(), pattern3)))
                {
                    var player = new Player(s);
                    teamNames.Add(player);
                    if (s == names.Last())
                    {
                        Tournament tournament = new Tournament();
                        tournament.Players = teamNames;
                        teamSelection.Hide();
                        var load = new TournamentBracket(tournament);
                        load.ShowDialog();
                        teamSelection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Name " + s.ToString(), "Bad name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }
    }
}
