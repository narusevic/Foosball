using Foosball.Models;
using System;
using System.Windows.Forms;

namespace Foosball
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hide();

            Match match = new Match();

            InputPlayerNames inputPlayerNames = new InputPlayerNames(match);
            inputPlayerNames.ShowDialog();

            BallTracker ballTrackerLoad = new BallTracker(match);
            ballTrackerLoad.ShowDialog(); 

            Close();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.Close3a;
            pictureBox5.Refresh();
            pictureBox5.Visible = true;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.Close3b;
            pictureBox5.Refresh();
            pictureBox5.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            var load = new TournamentMode();
            load.ShowDialog();
            Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Hide();
            var load = new Statistics();
            load.ShowDialog();
            Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Hide();
            var load = new ManagingForm();
            load.ShowDialog();
            Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
