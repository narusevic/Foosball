namespace Foosball
{
    partial class BallTracking
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
            this.SuspendLayout();
            // 
            // BallTracking
            // 
            this.ClientSize = new System.Drawing.Size(1320, 780);
            this.Name = "BallTracking";
            this.Load += new System.EventHandler(this.BallTracking_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblOuter;
        private System.Windows.Forms.TableLayoutPanel tblInner;
        private Emgu.CV.UI.ImageBox imageBoxOriginal;
        private System.Windows.Forms.Button buttonPauseAndResume;
        private Emgu.CV.UI.ImageBox imageBoxTresh;
        private System.Windows.Forms.TextBox textBoxXYRadius;
    }
}