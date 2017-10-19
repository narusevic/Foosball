using Foosball.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foosball
{
    public partial class TournamentTeamSelection : Form
    {
        TournamentTeamSelectionMethods methods = new TournamentTeamSelectionMethods();
        public TournamentTeamSelection(int selectedMode)
        {
            InitializeComponent();
            methods.TextBoxRemover(selectedMode, this);
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var load = new TournamentMode();
            load.ShowDialog();
            this.Close();
        }

        private void next_Click(object sender, EventArgs e)
        {
            List<Player> teamNames = new List<Player>();
            var myTextBox = Controls.OfType<TextBox>();
            foreach(var txt in myTextBox)
            {
                teamNames.Add(new Player(txt.Text));
            }
            methods.NameValidation(teamNames, this);
        }
    }
}