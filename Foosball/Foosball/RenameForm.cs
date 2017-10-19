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
    public partial class RenameForm : Form
    {
        ManagingController _managingController = new ManagingController();
        private int _teamId;

        public RenameForm(int id)
        {
            InitializeComponent();
            _teamId = id;
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            var name = tbName.Text;

            if (_managingController.TeamExists(name) || name == "")
            {
                MessageBox.Show("Player or team exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _managingController.RenameTeam(_teamId, name);
                Close();
            }
        }
    }
}
