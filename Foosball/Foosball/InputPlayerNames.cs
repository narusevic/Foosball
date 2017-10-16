using Foosball.Models;
using System;
using System.Windows.Forms;

namespace Foosball
{
    public partial class InputPlayerNames : Form
    {
        private Match _match;

        public InputPlayerNames(Match match)
        {
            InitializeComponent();

            _match = match;
        }

        private void btPlayButton_Click(object sender, EventArgs e)
        {
            var playerA = new Player(tbPlayerAName.Text);
            var playerB = new Player(tbPlayerBName.Text);

            _match.PlayerA = playerA;
            _match.PlayerB = playerB;

            DialogResult = DialogResult.OK;
        }
    }
}
