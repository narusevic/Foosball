using Foosball.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Foosball.Repositories;

namespace Foosball.Controllers
{
    class TournamentTeamSelectionController
    {
        public void NameValidation(List<string> names, TournamentTeamSelection teamSelection)
        {
            var pattern1 = @"^[a-zA-Z]+\s[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern2 = @"^[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern3 = @"^[a-zA-Z]+$";
            var teamNames = new List<Team>();

            foreach (var s in names)
            {
                if ((Regex.IsMatch(s.ToString(), pattern1)) || (Regex.IsMatch(s.ToString(), pattern2)) || (Regex.IsMatch(s.ToString(), pattern3)))
                {
                    var team = TeamRepository.Instance[s];

                    if (team == null)
                    {
                        team = new Team(s);
                        TeamRepository.Instance.Create(team);
                    }

                    teamNames.Add(team);

                    if (s == names.Last())
                    {
                        Tournament tournament = new Tournament();
                        tournament.Teams = teamNames;
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
