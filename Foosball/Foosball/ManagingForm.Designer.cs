namespace Foosball
{
    partial class ManagingForm
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
            this.dgvTeams = new System.Windows.Forms.DataGridView();
            this.btnRenameTeam = new System.Windows.Forms.Button();
            this.btnSelectPlayers = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateTeam = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeams
            // 
            this.dgvTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeams.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTeams.Location = new System.Drawing.Point(0, 0);
            this.dgvTeams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTeams.Name = "dgvTeams";
            this.dgvTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeams.Size = new System.Drawing.Size(428, 327);
            this.dgvTeams.TabIndex = 0;
            // 
            // btnRenameTeam
            // 
            this.btnRenameTeam.Location = new System.Drawing.Point(253, 364);
            this.btnRenameTeam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRenameTeam.Name = "btnRenameTeam";
            this.btnRenameTeam.Size = new System.Drawing.Size(100, 28);
            this.btnRenameTeam.TabIndex = 1;
            this.btnRenameTeam.Text = "Rename Team";
            this.btnRenameTeam.UseVisualStyleBackColor = true;
            this.btnRenameTeam.Click += new System.EventHandler(this.btnRenameTeam_Click);
            // 
            // btnSelectPlayers
            // 
            this.btnSelectPlayers.Location = new System.Drawing.Point(57, 417);
            this.btnSelectPlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectPlayers.Name = "btnSelectPlayers";
            this.btnSelectPlayers.Size = new System.Drawing.Size(137, 28);
            this.btnSelectPlayers.TabIndex = 2;
            this.btnSelectPlayers.Text = "Select Players";
            this.btnSelectPlayers.UseVisualStyleBackColor = true;
            this.btnSelectPlayers.Click += new System.EventHandler(this.btnSelectPlayers_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(253, 417);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Team";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(312, 480);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateTeam
            // 
            this.btnCreateTeam.Location = new System.Drawing.Point(57, 364);
            this.btnCreateTeam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateTeam.Name = "btnCreateTeam";
            this.btnCreateTeam.Size = new System.Drawing.Size(137, 28);
            this.btnCreateTeam.TabIndex = 5;
            this.btnCreateTeam.Text = "Create Team";
            this.btnCreateTeam.UseVisualStyleBackColor = true;
            this.btnCreateTeam.Click += new System.EventHandler(this.btnCreateTeam_Click);
            // 
            // ManagingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Foosball.Properties.Resources.apple;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(428, 528);
            this.Controls.Add(this.btnCreateTeam);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSelectPlayers);
            this.Controls.Add(this.btnRenameTeam);
            this.Controls.Add(this.dgvTeams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManagingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTeams;
        private System.Windows.Forms.Button btnRenameTeam;
        private System.Windows.Forms.Button btnSelectPlayers;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateTeam;
    }
}