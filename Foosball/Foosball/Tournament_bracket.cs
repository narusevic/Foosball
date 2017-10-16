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
    public partial class Tournament_bracket : Form
    {
        private static Random rng = new Random();
        public Tournament_bracket(List<String> teamNames, int round = 1)
        {
            if(round == 1) {
                var shuffledTeamNames = teamNames.OrderBy(a => Guid.NewGuid()).ToList();
                teamNames = shuffledTeamNames;
            }
            checkIfEnded(teamNames);
            InitializeComponent();
            removeLabel(amountFinder(teamNames.Count));
            addTeamNames(teamNames, amountFinder(teamNames.Count), round);
        }

        private void removeLabel(int amount)
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

        private void addTeamNames(List<string> teamNames, int amount, int round)
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

        private int amountFinder(int amount)
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
            else return 0;
        }

        private void checkIfEnded(List<string> teamNames)
        {
            if(teamNames.Count == amountFinder(teamNames.Count) * 2 - 1)
            {
                this.Hide();
                var load = new Tournament_Winner(teamNames.Last());
                load.ShowDialog();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Match match = new Match();

            InputPlayerNames inputPlayerNames = new InputPlayerNames(match);
            inputPlayerNames.ShowDialog();

            var load = new BallTracker(match);
            load.ShowDialog();

            this.Close();
        }
    }
}
