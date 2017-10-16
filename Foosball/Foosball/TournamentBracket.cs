using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Foosball.Models;

namespace Foosball
{
    public partial class TournamentBracket : Form
    {
        private int _amount;
        private List<string> _teamNames = new List<string>();
        private int _round;

        public TournamentBracket(List<String> teamNames, int round = 1)
        {
            if(round == 1) {
                var shuffledTeamNames = teamNames.OrderBy(a => Guid.NewGuid()).ToList();
                teamNames = shuffledTeamNames;
            }

            _teamNames = teamNames;
            _round = round;

            CheckIfEnded(_teamNames);
            InitializeComponent();
            _amount = AmountFinder(teamNames.Count);
            RemoveLabel();
            AddTeamNames(teamNames);
        }

        private void RemoveLabel()
        {
            var label = new Label[32];
            for(int i = _amount * 2; i < 32; i++)
            {
                label[i] = new Label();
                label[i].Name = "Label" + i;
                var textBoxToRemove = this.Controls["Label" + i];
                this.Controls.Remove(textBoxToRemove);
            }
        }

        private void AddTeamNames(List<string> teamNames)
        {
            int n = _amount * 2 - 1;
            int z = teamNames.Count - 1;
            var myLabel = Controls.OfType<Label>();
            myLabel = myLabel.OrderBy(label => label.TabIndex);
            for (int i = n - teamNames.Count; i < n; i++) {
                myLabel.ElementAt(i).Text = teamNames[z];
                if ((z == _round * 2 - 1) || (z == _round * 2 - 2))
                {
                    myLabel.ElementAt(i).BackColor = Color.Red;
                }
                z--;
            }
        }

        private int AmountFinder(int amount)
        {
            if (amount < 8)
            {
                return 4;
            }
            else if (amount < 16)
            {
                return 8;
            }
            else if (amount < 32)
            {
                return 16;
            }
            return 0;
        }

        private void CheckIfEnded(List<string> teamNames)
        {
            if(teamNames.Count == AmountFinder(teamNames.Count) * 2 - 1)
            {
                this.Hide();
                var load = new TournamentWinner(teamNames.Last());
                load.ShowDialog();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var load = new BallTracker(_teamNames, _round);
            load.ShowDialog();
            this.Close();
        }
    }
}
