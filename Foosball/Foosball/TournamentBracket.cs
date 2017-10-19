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
using Foosball.Models;

namespace Foosball
{
    public partial class TournamentBracket : Form
    {
        private int _amount;
        private Tournament _tournament;
        public TournamentBracket(Tournament tournament, int round = 1)
        {
            if(round == 1) {
                var shuffledTeamNames = tournament.Players.OrderBy(a => Guid.NewGuid()).ToList();
                tournament.Players = shuffledTeamNames;
            }
            _tournament = tournament;
            TournamentBracketController methods = new TournamentBracketController(tournament, this);
            methods.CheckIfEnded();
            InitializeComponent();
            _amount = methods.AmountFinder();
            RemoveLabel();
            AddTeamNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var match = new Match(_tournament.Players[_tournament.Round * 2 - 2].ToString(), _tournament.Players[_tournament.Round * 2 - 1].ToString());
            this.Hide();
            //var load = new BallTracker(match, _tournament);
            //load.ShowDialog();
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
            int z = _tournament.Players.Count - 1;
            var myLabel = this.Controls.OfType<Label>();
            myLabel = myLabel.OrderBy(label => label.TabIndex);
            for (int i = n - _tournament.Players.Count; i < n; i++)
            {
                myLabel.ElementAt(i).Text = _tournament.Players[z].ToString();
                if ((z == _tournament.Round * 2 - 1) || (z == _tournament.Round * 2 - 2))
                {
                    myLabel.ElementAt(i).BackColor = Color.Red;
                }
                z--;
            }
        }
    }
}
