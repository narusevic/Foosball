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
            dgvPlayer.DataSource = _statisticsController.GetAllPlayers().ToList();
            dgvTeam.DataSource = _statisticsController.GetAllTeams().ToList();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            var load = new MainUI();
            load.ShowDialog();
            Close();
        }
    }
}
