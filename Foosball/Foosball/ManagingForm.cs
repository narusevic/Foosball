using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Foosball.Controllers;

namespace Foosball
{
    public partial class ManagingForm : Form
    {
        ManagingController _managingController = new ManagingController();

        public ManagingForm()
        {
            InitializeComponent();

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dgvTeams.DataSource = _managingController.GetAllTeams();
        }

        private void btnRenameTeam_Click(object sender, EventArgs e)
        {
            if (!CheckSelected())
            {
                return;
            }

            var teamId = GetSelectedId();

            if (!teamId.HasValue)
            {
                return;
            }

            var renameTeam = new RenameForm(teamId.Value);
            renameTeam.ShowDialog();

            UpdateGrid();
        }

        private void btnSelectPlayers_Click(object sender, EventArgs e)
        {
            if (!CheckSelected())
            {
                return;
            }

            var teamId = GetSelectedId();

            if (!teamId.HasValue)
            {
                return;
            }

            var selectPlayersForm = new SelectPlayersForm(teamId.Value);
            selectPlayersForm.ShowDialog();

            UpdateGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CheckSelected())
            {
                return;
            }

            var teamId = GetSelectedId();

            if (teamId.HasValue)
            {
                _managingController.RemoveTeam(teamId.Value);

                UpdateGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();

            var mainUI = new MainUI();
            mainUI.ShowDialog();

            Close();
        }

        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            var createTeam = new CreateTeam();
            createTeam.ShowDialog();

            UpdateGrid();
        }

        private bool CheckSelected()
        {
            if (dgvTeams.SelectedRows.Count != 1)
            {
                MessageBox.Show("Select one team!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private int? GetSelectedId()
        {
            var selectedTeam = dgvTeams.SelectedRows[0];
            int teamId;

            try
            {
                teamId = int.Parse(selectedTeam.Cells["Id"].Value.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return teamId;
        }
    }
}
