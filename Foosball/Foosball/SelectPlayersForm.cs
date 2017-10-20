using Foosball.Controllers;
using System;
using System.Windows.Forms;

namespace Foosball
{
    public partial class SelectPlayersForm : Form
    {
        ManagingController _managingController = new ManagingController();
        private int _teamId;

        public SelectPlayersForm(int teamId)
        {
            InitializeComponent();
            _teamId = teamId;
        }

        private void btnChangePlayers_Click(object sender, EventArgs e)
        {
            if (tbPlayerA.Text == "" || tbPlayerB.Text == "")
            {
                MessageBox.Show("Fill both player names!", "Player Names", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _managingController.ChangePlayers(_teamId, tbPlayerA.Text, tbPlayerB.Text);
                Close();
            }
        }
    }
}
