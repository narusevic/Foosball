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
    public partial class Tournament_team_selection : Form
    {
        public Tournament_team_selection(int selectedMode)
        {
            InitializeComponent();
            textBoxRemover(selectedMode);
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var load = new Tournament_mode();
            load.ShowDialog();
            this.Close();
        }

        private void textBoxRemover(int amount)
        {
            TextBox[] textBox = new TextBox[16];
            for (int i = amount; i < 16; i++) {
                textBox[i] = new TextBox();
                textBox16.Name = "textBox" + i;
                var textBoxToRemove = this.Controls["TextBox" + i];
                this.Controls.Remove(textBoxToRemove);
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            List<string> teamNames = new List<string>();
            var myTextBox = Controls.OfType<TextBox>();
            foreach(var txt in myTextBox)
            {
                teamNames.Add(txt.Text);
            }
            nameValidation(teamNames);
        }

        private void nameValidation(List<String> names)
        {
            var pattern1 = @"^[a-zA-Z]+\s[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern2 = @"^[a-zA-Z]+\s[a-zA-Z]+$";
            var pattern3 = @"^[a-zA-Z]+$";
            foreach (string s in names)
            {
                if ((Regex.IsMatch(s, pattern1)) || (Regex.IsMatch(s, pattern2)) || (Regex.IsMatch(s, pattern3)))
                {
                    if (s == names.Last<String>())
                    {
                        this.Hide();
                        var load = new Tournament_bracket(names);
                        load.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Bad name", "Bad name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }
    }
}