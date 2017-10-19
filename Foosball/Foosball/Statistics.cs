﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Foosball.Repositories;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foosball
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
            view.DataSource = PlayerRepository.Instance.ReadAll().ToList();
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
