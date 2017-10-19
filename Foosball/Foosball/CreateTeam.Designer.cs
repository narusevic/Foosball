namespace Foosball
{
    partial class CreateTeam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbTeamName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPlayerA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPlayerB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Team";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbTeamName
            // 
            this.tbTeamName.Location = new System.Drawing.Point(79, 32);
            this.tbTeamName.Name = "tbTeamName";
            this.tbTeamName.Size = new System.Drawing.Size(100, 20);
            this.tbTeamName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Team Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Player A";
            // 
            // tbPlayerA
            // 
            this.tbPlayerA.Location = new System.Drawing.Point(79, 58);
            this.tbPlayerA.Name = "tbPlayerA";
            this.tbPlayerA.Size = new System.Drawing.Size(100, 20);
            this.tbPlayerA.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Player B";
            // 
            // tbPlayerB
            // 
            this.tbPlayerB.Location = new System.Drawing.Point(79, 84);
            this.tbPlayerB.Name = "tbPlayerB";
            this.tbPlayerB.Size = new System.Drawing.Size(100, 20);
            this.tbPlayerB.TabIndex = 5;
            // 
            // CreateTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 159);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPlayerB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPlayerA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTeamName);
            this.Controls.Add(this.button1);
            this.Name = "CreateTeam";
            this.Text = "CreateTeam";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbTeamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPlayerA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPlayerB;
    }
}