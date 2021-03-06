﻿using System;
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
    public partial class TournamentWinner : Form
    {
        public TournamentWinner(string winner)
        {
            InitializeComponent();

            var myLabel = Controls.OfType<Label>();
            myLabel.First().Text = winner;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var load = new MainUI();
            load.ShowDialog();
            this.Close();
        }
    }
}
