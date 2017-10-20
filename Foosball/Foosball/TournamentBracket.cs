using Foosball.Controllers;
using Foosball.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Foosball
{
    public partial class TournamentBracket : Form
    {
        private int _amount;
        private Tournament _tournament;
        public TournamentBracket(Tournament tournament)
        {
            _tournament = tournament;
            if(_tournament.Round == 1) {
                var shuffledTeamNames = tournament.Teams.OrderBy(a => Guid.NewGuid()).ToList();
                tournament.Teams = shuffledTeamNames;
            }
            
            TournamentBracketController methods = new TournamentBracketController(tournament, this);
            methods.CheckIfEnded();
            InitializeComponent();
            _amount = methods.AmountFinder();
            RemoveLabel();
            AddTeamNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var match = new Match(_tournament.Teams[_tournament.Round * 2 - 2].Name.ToString(), _tournament.Teams[_tournament.Round * 2 - 1].Name.ToString());
            this.Hide();
            var load = new BallTracker(match, _tournament);
            load.ShowDialog();
            this.Close();
        }

        public void RemoveLabel()
        {
            var label = new Label[32];
            for (int i = _amount * 2; i < 32; i++)
            {
                label[i] = new Label();
                label[i].Name = "Label" + i;
                var textBoxToRemove = this.Controls["Label" + i];
                this.Controls.Remove(textBoxToRemove);
            }
        }

        public void AddTeamNames()
        {
            int n = _amount * 2 - 1;
            int z = _tournament.Teams.Count - 1;
            var myLabel = this.Controls.OfType<Label>();
            myLabel = myLabel.OrderBy(label => label.TabIndex);
            for(int i = n - _tournament.Teams.Count; i < n; i++) {
                myLabel.ElementAt(i).Text = _tournament.Teams[z].Name.ToString();
                if ((z == _tournament.Round * 2 - 1) || (z == _tournament.Round * 2 - 2))
                {
                    myLabel.ElementAt(i).BackColor = Color.Red;
                }
                z--;
            }
        }
    }
}
