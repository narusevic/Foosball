namespace Foosball
{
    partial class InputPlayerNames
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
            this.tbPlayerAName = new System.Windows.Forms.TextBox();
            this.tbPlayerBName = new System.Windows.Forms.TextBox();
            this.btPlayButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPlayerAName
            // 
            this.tbPlayerAName.Location = new System.Drawing.Point(35, 62);
            this.tbPlayerAName.Name = "tbPlayerAName";
            this.tbPlayerAName.Size = new System.Drawing.Size(100, 20);
            this.tbPlayerAName.TabIndex = 0;
            // 
            // tbPlayerBName
            // 
            this.tbPlayerBName.Location = new System.Drawing.Point(248, 62);
            this.tbPlayerBName.Name = "tbPlayerBName";
            this.tbPlayerBName.Size = new System.Drawing.Size(100, 20);
            this.tbPlayerBName.TabIndex = 1;
            // 
            // btPlayButton
            // 
            this.btPlayButton.Location = new System.Drawing.Point(153, 122);
            this.btPlayButton.Name = "btPlayButton";
            this.btPlayButton.Size = new System.Drawing.Size(75, 23);
            this.btPlayButton.TabIndex = 2;
            this.btPlayButton.Text = "Play!";
            this.btPlayButton.UseVisualStyleBackColor = true;
            this.btPlayButton.Click += new System.EventHandler(this.btPlayButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Player B Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Player A Name";
            // 
            // InputPlayerNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 157);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btPlayButton);
            this.Controls.Add(this.tbPlayerBName);
            this.Controls.Add(this.tbPlayerAName);
            this.Name = "InputPlayerNames";
            this.Text = "InputPlayerNames";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPlayerAName;
        private System.Windows.Forms.TextBox tbPlayerBName;
        private System.Windows.Forms.Button btPlayButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}