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

            SortableHeaders(dgvPlayer);
            SortableHeaders(dgvTeam);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            var load = new MainUI();
            load.ShowDialog();
            Close();
        }

        private void SortableHeaders(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
    }
}
