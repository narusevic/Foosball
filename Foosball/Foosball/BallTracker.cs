using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Drawing;
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

        public BallTracker()
        {
            InitializeComponent();
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
                var lowerLimit = new Hsv(_hLow, _sLow, _vLow);
                var upperLimit = new Hsv(_hHigh, _sHigh, _vHigh);

                Image<Hsv, byte> imgHSV;

                var m = new Mat();

                _capture.Retrieve(m);
                //_capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, 10);
                CvInvoke.Resize(m, m, new Size(600, 300));
                //CvInvoke.GaussianBlur(m, m, new Size(11, 11), 0);
                imgHSV = new Image<Hsv, byte>(m.Bitmap);
                Image<Bgr, byte> imgBGR = new Image<Bgr, byte>(m.Bitmap); ;
                Image<Gray, byte> imgHSVDest = imgHSV.InRange(lowerLimit, upperLimit);
                imgHSVDest.Erode(2);
                imgHSVDest.Dilate(2);

                int largestContourIndex = 0;
                double largestArea = 0;
                var contours = new VectorOfVectorOfPoint();

                CvInvoke.FindContours(imgHSVDest, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                for (int i = 0; i < contours.Size; i++)
                {
                    var color = new MCvScalar(0, 0, 255);
                    double a = CvInvoke.ContourArea(contours[i], false);

                    if (a > largestArea)
                    {
                        largestArea = a;
                        largestContourIndex = i;
                    }
                }

                var rect = CvInvoke.BoundingRectangle(contours[largestContourIndex]);

                CvInvoke.Rectangle(imgBGR, rect, new MCvScalar(255, 0, 0));
                /* 
                  CvInvoke.Rectangle(imgHSVDest, rect, new MCvScalar(255, 0, 0));
                  _deque.AddToFront(new Point(rect.Left + rect.Width / 2,
                                      rect.Top + rect.Height / 2));
                 if (_deque.Count > 20)
                 {
                     _deque.RemoveFromBack();
                 }
                 CvInvoke.Line(imgBGR, _deque[0], _deque[1], new MCvScalar(0, 255, 0), 10);
                 for (int i=1; i<_deque.Count; i++)
                 {

                     CvInvoke.Line(imgBGR, _deque[i-1], _deque[i], new MCvScalar(0, 255, 0), _deque.Count - i);
                 }

                 */



                //CvInvoke.DrawContours(imgHSVDest, contours, largest_contour_index, new MCvScalar(255, 0, 0));

                //CvInvoke.DrawContours(imgHSVDest, contours, -1, new MCvScalar(255, 0, 0));

                pictureBox1.Image = imgBGR.ToBitmap();
                // pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
                //  pictureBox1.Image = imgHSVDest.ToBitmap();
                Thread.Sleep((int)_capture.GetCaptureProperty(CapProp.Fps));
            }
            catch (Exception) { }
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
            if (_capture != null)
            {
                _capture.Pause();
            }
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
    }
}
