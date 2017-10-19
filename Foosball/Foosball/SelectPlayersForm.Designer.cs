namespace Foosball
{
    partial class SelectPlayersForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangePlayers = new System.Windows.Forms.Button();
            this.tbPlayerA = new System.Windows.Forms.TextBox();
            this.tbPlayerB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player A Name";
            // 
            // btnChangePlayers
            // 
            this.btnChangePlayers.Location = new System.Drawing.Point(57, 73);
            this.btnChangePlayers.Name = "btnChangePlayers";
            this.btnChangePlayers.Size = new System.Drawing.Size(94, 23);
            this.btnChangePlayers.TabIndex = 1;
            this.btnChangePlayers.Text = "Change Players";
            this.btnChangePlayers.UseVisualStyleBackColor = true;
            this.btnChangePlayers.Click += new System.EventHandler(this.btnChangePlayers_Click);
            // 
            // tbPlayerA
            // 
            this.tbPlayerA.Location = new System.Drawing.Point(102, 8);
            this.tbPlayerA.Name = "tbPlayerA";
            this.tbPlayerA.Size = new System.Drawing.Size(100, 20);
            this.tbPlayerA.TabIndex = 2;
            // 
            // tbPlayerB
            // 
            this.tbPlayerB.Location = new System.Drawing.Point(102, 34);
            this.tbPlayerB.Name = "tbPlayerB";
            this.tbPlayerB.Size = new System.Drawing.Size(100, 20);
            this.tbPlayerB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player B Name";
            // 
            // SelectPlayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 108);
            this.Controls.Add(this.tbPlayerB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPlayerA);
            this.Controls.Add(this.btnChangePlayers);
            this.Controls.Add(this.label1);
            this.Name = "SelectPlayersForm";
            this.Text = "SelectPlayersForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangePlayers;
        private System.Windows.Forms.TextBox tbPlayerA;
        private System.Windows.Forms.TextBox tbPlayerB;
        private System.Windows.Forms.Label label2;
    }
}