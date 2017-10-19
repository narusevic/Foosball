using Foosball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foosball
{
    class TournamentTeamSelectionMethods
    {
        public void TextBoxRemover(int amount, TournamentTeamSelection teamSelection)
        {

            TextBox[] textBox = new TextBox[17];
            for (int i = amount + 1; i < 17; i++)
            {
                textBox[i] = new TextBox();
                textBox[i].Name = "textBox" + i;
                var textBoxToRemove = teamSelection.Controls["TextBox" + i];
                teamSelection.Controls.Remove(textBoxToRemove);
            }
        }

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
                    MessageBox.Show("Bad name", "Bad name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }
    }
}
