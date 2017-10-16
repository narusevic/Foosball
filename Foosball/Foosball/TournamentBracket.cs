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
    public partial class TournamentBracket : Form
    {
        private int _amount;

        public TournamentBracket(List<String> teamNames, int round = 1)
        {
            if(round == 1) {
                var shuffledTeamNames = teamNames.OrderBy(a => Guid.NewGuid()).ToList();
                teamNames = shuffledTeamNames;
            }
            CheckIfEnded(teamNames);
            InitializeComponent();
            _amount = AmountFinder(teamNames.Count);
            RemoveLabel(_amount);
            AddTeamNames(teamNames, _amount, round);
        }

        private void RemoveLabel(int amount)
        {
            var label = new Label[32];
            for(int i = amount * 2; i < 32; i++)
            {
                label[i] = new Label();
                label[i].Name = "Label" + i;
                var textBoxToRemove = this.Controls["Label" + i];
                this.Controls.Remove(textBoxToRemove);
            }
        }

        private void AddTeamNames(List<string> teamNames, int amount, int round)
        {
            int n = amount * 2 - 1;
            var myLabel = Controls.OfType<Label>();
            myLabel = myLabel.OrderByDescending(label => label.TabIndex);
            for (int i = n - teamNames.Count; i >= 0; i--) {
                myLabel.ElementAt(i).Text = teamNames[n - teamNames.Count - i];
                if ((n - teamNames.Count - i == round * 2 - 1) || (n - teamNames.Count - i == round * 2 - 2))
                {
                    myLabel.ElementAt(i).BackColor = Color.Red;
                }
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
            var load = new BallTracker();
            load.ShowDialog();
            this.Close();
        }
    }
}
