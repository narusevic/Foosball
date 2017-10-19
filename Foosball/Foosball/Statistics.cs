using Foosball.Controllers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foosball
{
    public partial class Statistics : Form
    {
        private readonly StatisticsController _statisticsController = new StatisticsController();

        public Statistics()
        {
            InitializeComponent();
            view.DataSource = _statisticsController.GetAllTeams().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var load = new MainUI();
            load.ShowDialog();
            Close();
        }
    }
}
