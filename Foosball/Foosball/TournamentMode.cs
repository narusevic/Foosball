using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foosball
{
    public partial class TournamentMode : Form
    {
        public TournamentMode()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var load = new TournamentTeamSelection(4);
            load.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var load = new TournamentTeamSelection(8);
            load.ShowDialog();
            this.Close();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var load = new TournamentTeamSelection(16);
            load.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainUI load = new MainUI();
            load.ShowDialog();
            this.Close();
        }
    }
}
