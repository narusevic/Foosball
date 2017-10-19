using Foosball.Controllers;
using System;
using System.Windows.Forms;

namespace Foosball
{
    public partial class CreateTeam : Form
    {
        ManagingController _managingController = new ManagingController();

        public CreateTeam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var teamName = tbTeamName.Text;
            var playerAName = tbPlayerA.Text;
            var playerBName = tbPlayerB.Text;

            if (teamName != string.Empty || playerAName != string.Empty || playerBName != string.Empty)
            {
                if (_managingController.TeamExists(teamName) || _managingController.PlayersExists(playerAName, playerBName))
                {
                    MessageBox.Show("Player or team exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _managingController.CreateTeam(teamName, playerAName, playerBName);

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Input all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
