﻿using Foosball.Models;
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
            this.Hide();

            Match match = new Match();

            InputPlayerNames inputPlayerNames = new InputPlayerNames(match);
            inputPlayerNames.ShowDialog();

            BallTracker ballTrackerLoad = new BallTracker(match);
            ballTrackerLoad.ShowDialog(); 

            this.Close();
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
            this.Hide();
            var load = new TournamentMode();
            load.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var load = new Statistics();
            load.ShowDialog();
            this.Close();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
