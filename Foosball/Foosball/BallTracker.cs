using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Foosball.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Windows.Forms;

namespace Foosball
{
    public partial class BallTracker : Form
    {
        private Capture _capture;
       
        private Deque<Point> _deque = new Deque<Point>();
        private int _hLow = 0;
        private int _sLow = 43;
        private int _vLow = 209;
        private int _hHigh = 13;
        private int _sHigh = 255;
        private int _vHigh = 255;
        private MatchController _ball = new MatchController();
        Mat m = new Mat();

        
        private List<String> _teamNames = new List<string>();
                
        private int _width = 600;
        private int _height = 300;

        private Match _match;
        private int _round;
        private int _scoreA = 0;
        private int _scoreB = 0;

        public BallTracker(Match match)
        {
            _match = match;
            InitializeComponent();
            SetPlayerNames();
        }

        public BallTracker(List<String> teamNames, int round)
        {
            _teamNames = teamNames;
            _round = round;
            InitializeComponent();
            SetTeamNames();
        }

        private void SetPlayerNames()
        {
            lbPlayerA.Text = _match.PlayerA.Name;
            lbPlayerB.Text = _match.PlayerB.Name;
        }

        private void SetTeamNames()
        {
            lbPlayerA.Text = _teamNames[_round * 2 - 2];
            lbPlayerB.Text = _teamNames[_round * 2 - 1];
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
            try
            {
                _capture.Retrieve(m);
                CvInvoke.Resize(m, m, new Size(_width, _height));
                Image<Bgr, byte> imgBGR = new Image<Bgr, byte>(m.Bitmap);
                var rect = _ball.FindBall(m, new Hsv(_hLow, _sLow, _vLow), new Hsv(_hHigh, _sHigh, _vHigh));
                CvInvoke.Rectangle(imgBGR, rect, new MCvScalar(255, 0, 0));
                pictureBox1.Image = imgBGR.ToBitmap();
                if (_ball.SetScores(_width)) UpdateScores();             
                Thread.Sleep((int)_capture.GetCaptureProperty(CapProp.Fps));
            }
            catch (Exception) { }
        }

        private void UpdateScores()
        {
            _ball.CheckForWinner();
            lbScoreA.Text = _scoreA.ToString();
            lbScoreB.Text = _scoreB.ToString();
        }

        private void CheckForWinner()
        {
            if(_teamNames.Count() != 0)
            {
                if((_scoreA >= 10) || (_scoreB >= 10))
                {
                    if(_scoreA >= 10) 
                    {
                        _teamNames.Add(_teamNames[_round * 2 - 2]);
                    }
                    if (_scoreB >= 10)
                    {
                        _teamNames.Add(_teamNames[_round * 2 - 1]);
                    }
                    _round++;
                    this.Hide();
                    var load = new TournamentBracket(_teamNames, _round);
                    load.ShowDialog();
                    this.Close();
                }
            }
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
            _scoreA++;
            UpdateScores();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _scoreB++;
            UpdateScores();
        }
    }
}
