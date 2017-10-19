using Foosball.Models;
using System;
using System.Windows.Forms;
using Foosball.Repositories;
using System.Text.RegularExpressions;

namespace Foosball
{
    public partial class InputPlayerNames : Form
    {
        private Models.Match _match;

        public InputPlayerNames(Models.Match match)
        {
            InitializeComponent();

            _match = match;
        }

        private void btPlayButton_Click(object sender, EventArgs e)
        {
            if(NameValidation(tbPlayerAName.Text, tbPlayerBName.Text))
            {
                var playerA = new Player(tbPlayerAName.Text);
                var playerB = new Player(tbPlayerBName.Text);
                PlayerRepository.Instance.Create(playerA);
                PlayerRepository.Instance.Create(playerB);

                _match.PlayerA = playerA;
                _match.PlayerB = playerB;
                MatchRepository.Instance.Create(_match);

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Incorrect Name", "Bad name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var load = new MainUI();
            load.ShowDialog();
            this.Close();
        }

        private bool NameValidation(string playerA, string playerB)
        {
            var pattern1 = @"^[a-zA-Z]+\s[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern2 = @"^[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern3 = @"^[a-zA-Z]+$";

            if((((Regex.IsMatch(playerA, pattern1)) || (Regex.IsMatch(playerA, pattern2)) || (Regex.IsMatch(playerA, pattern3))) && (((Regex.IsMatch(playerB, pattern1)) || (Regex.IsMatch(playerB, pattern2)) || (Regex.IsMatch(playerB, pattern3))))))
            {
                return true;
            }
            else return false;
        }
    }
}
