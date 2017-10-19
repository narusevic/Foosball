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
        private Tournament _tournament;
        public TournamentBracket(Tournament tournament, int round = 1)
        {
            if(round == 1) {
                var shuffledTeamNames = tournament.Players.OrderBy(a => Guid.NewGuid()).ToList();
                tournament.Players = shuffledTeamNames;
            }
            _tournament = tournament;
            TournamentBracketMethods methods = new TournamentBracketMethods(tournament, this);
            methods.CheckIfEnded();
            InitializeComponent();
            methods.AmountFinder();
            methods.RemoveLabel();
            methods.AddTeamNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var match = new Match(_tournament.Players[_tournament.Round * 2 - 2].ToString(), _tournament.Players[_tournament.Round * 2 - 1].ToString());
            this.Hide();
            var load = new BallTracker(match, _tournament);
            load.ShowDialog();
            this.Close();
        }
    }
}
