using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Foosball.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Foosball
{
    public partial class BallTracker : Form
    {
        private Capture _capture;

        private int _hLow = 0;
        private int _sLow = 100;
        private int _vLow = 185;
        private int _hHigh = 15;
        private int _sHigh = 255;
        private int _vHigh = 255;

        private int _hLowG = 0;
        private int _sLowG = 0;
        private int _vLowG = 0;
        private int _hHighG = 30;
        private int _sHighG = 60;
        private int _vHighG = 80;

        private MatchController _matchController;
        Mat m = new Mat();

                
        private int _width = 600;
        private int _height = 300;

        private Tournament _tournament = new Tournament();

        public BallTracker(Match match)
        {
            _matchController = new MatchController(match);
            InitializeComponent();
            SetPlayerNames();
        }

        public BallTracker(Match match, Tournament tournament)
        {
            _matchController = new MatchController(match);
            _tournament = tournament;
            InitializeComponent();
            SetPlayerNames();
        }

        private void SetPlayerNames()
        {
            lbPlayerA.Text = _matchController.PlayerA.Name;
            lbPlayerB.Text = _matchController.PlayerB.Name;
        }
        
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_capture == null)
            {
                _capture = new Capture(0);
            }
           
            _capture.ImageGrabbed += Capture_ImageGrabbed;
            _capture.Start();
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
          
            _capture.Retrieve(m);
            CvInvoke.Resize(m, m, new Size(_width, _height));          
            Image<Bgr, byte> imgBGR = new Image<Bgr, byte>(m.Bitmap);  
            var ball = _matchController.FindObject(m, new Hsv(_hLow, _sLow, _vLow), new Hsv(_hHigh, _sHigh, _vHigh));
            CvInvoke.Rectangle(imgBGR, ball, new MCvScalar(255, 0, 0));
            Tuple<Rectangle, Rectangle> goals = _matchController.FindGoals(m, new Hsv(_hLowG, _sLowG, _vLowG), new Hsv(_hHighG, _sHighG, _vHighG));
            var rectA = goals.Item1;
            var rectB = goals.Item2;            
            CvInvoke.Rectangle(imgBGR, rectA, new MCvScalar(0, 255, 0));      
            CvInvoke.Rectangle(imgBGR, rectB, new MCvScalar(0, 0, 255));

            if (_matchController.SetScores(ball))
            {
                BeginInvoke(new Action(UpdateScores));
            }
            
            pictureBox1.Image = imgBGR.ToBitmap();
          
            Thread.Sleep((int)_capture.GetCaptureProperty(CapProp.Fps));
            
           
        }


        private void UpdateScores()
        {
            if(_matchController.CheckForWinner())
            {
                if(_tournament.Players.Count != 0) {
                    if(_matchController.CheckIfPlayerAWon())
                    {
                        _tournament.Players.Add(_matchController.PlayerA);
                    }
                    else
                    {
                        _tournament.Players.Add(_matchController.PlayerB);
                    }
                    _tournament.Round++;
                    this.Hide();
                    var load = new TournamentBracket(_tournament);
                    load.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.Hide();
                    if (_matchController.CheckIfPlayerAWon())
                    {
                        var load = new TournamentWinner(_matchController.PlayerA.Name);
                        load.ShowDialog();
                    }
                    else
                    {
                        var load = new TournamentWinner(_matchController.PlayerB.Name);
                        load.ShowDialog();
                    }
                    this.Close();
                }
            }
            
            lbScoreA.Text = _matchController.AScore.ToString();
            lbScoreB.Text = _matchController.BScore.ToString();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _hLow = trackBar1.Value;
            label1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            _sLow = trackBar2.Value;
            label2.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            _vLow = trackBar3.Value;
            label3.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            _hHigh = trackBar4.Value;
            label4.Text = trackBar4.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            _sHigh = trackBar5.Value;
            label5.Text = trackBar5.Value.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            _vHigh = trackBar6.Value;
            label6.Text = trackBar6.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = _hLow;
            trackBar2.Value = _sLow;
            trackBar3.Value = _vLow;
            trackBar4.Value = _hHigh;
            trackBar5.Value = _sHigh;
            trackBar6.Value = _vHigh;

            trackBar12.Value = _hLowG;
            trackBar11.Value = _sLowG;
            trackBar10.Value = _vLowG;
            trackBar9.Value = _hHighG;
            trackBar8.Value = _sHighG;
            trackBar7.Value = _vHighG;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _capture?.Pause();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_capture == null)
            {
                var ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _capture = new Capture(ofd.FileName);
                    _capture.ImageGrabbed += Capture_ImageGrabbed;
                    _capture.Start();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _matchController.AScore++;
            UpdateScores();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _matchController.BScore++;
            UpdateScores();
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            _hLowG = trackBar12.Value;
            label15.Text = trackBar12.Value.ToString();
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            _sLowG = trackBar11.Value;
            label14.Text = trackBar11.Value.ToString();
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            _vLowG = trackBar10.Value;
            label13.Text = trackBar10.Value.ToString();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            _hHighG = trackBar9.Value;
            label11.Text = trackBar9.Value.ToString();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            _sHighG = trackBar8.Value;
            label10.Text = trackBar8.Value.ToString();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            _vHighG = trackBar7.Value;
            label9.Text = trackBar7.Value.ToString();
        }
    }
}
