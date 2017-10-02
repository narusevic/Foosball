using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;


namespace Foosball
{

    public partial class Form1 : Form
    {
        Capture capture;
        Deque<Point> deque = new Deque<Point>();
 
        int HLow = 0;
        int SLow = 43;
        int VLow = 209;
        int HHigh = 13;
        int SHigh = 255;
        int VHigh = 255;
        public Form1()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
                     

            if (capture==null)
            capture = new Emgu.CV.Capture(0);

            capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start(); 

        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {

                Hsv lowerLimit = new Hsv(HLow, SLow, VLow);
                Hsv upperLimit = new Hsv(HHigh, SHigh, VHigh);

                Image<Hsv, byte> imgHSV;

                Mat m = new Mat();


                capture.Retrieve(m);
                //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, 10);
                CvInvoke.Resize(m, m, new Size(1280, 720));
                //CvInvoke.GaussianBlur(m, m, new Size(11, 11), 0);
                imgHSV = new Image<Hsv, byte>(m.Bitmap);
                Image<Bgr, byte> imgBGR = new Image<Bgr, byte>(m.Bitmap); ;
                Image<Gray, byte> imgHSVDest = imgHSV.InRange(lowerLimit, upperLimit);
                imgHSVDest.Erode(2);
                imgHSVDest.Dilate(2);
               


                int largest_contour_index = 0;
                double largest_area = 0;
               VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
              
               CvInvoke.FindContours(imgHSVDest, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                for (int i = 0; i < contours.Size; i++)
                {
                    MCvScalar color = new MCvScalar(0, 0, 255);

                    double a = CvInvoke.ContourArea(contours[i], false);  
                    if (a > largest_area)
                    {
                        largest_area = a;
                        largest_contour_index = i;               
                    }

                   
                }
               
                Rectangle rect = CvInvoke.BoundingRectangle(contours[largest_contour_index]);
              
                CvInvoke.Rectangle(imgBGR, rect, new MCvScalar(255, 0, 0));
                /* 
                  CvInvoke.Rectangle(imgHSVDest, rect, new MCvScalar(255, 0, 0));
                  deque.AddToFront(new Point(rect.Left + rect.Width / 2,
                                      rect.Top + rect.Height / 2));
                 if (deque.Count > 20)
                 {
                     deque.RemoveFromBack();
                 }
                 CvInvoke.Line(imgBGR, deque[0], deque[1], new MCvScalar(0, 255, 0), 10);
                 for (int i=1; i<deque.Count; i++)
                 {

                     CvInvoke.Line(imgBGR, deque[i-1], deque[i], new MCvScalar(0, 255, 0), deque.Count - i);
                 }

                 */



                //CvInvoke.DrawContours(imgHSVDest, contours, largest_contour_index, new MCvScalar(255, 0, 0));

                //CvInvoke.DrawContours(imgHSVDest, contours, -1, new MCvScalar(255, 0, 0));

                pictureBox1.Image = imgBGR.ToBitmap();
               // pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
             //  pictureBox1.Image = imgHSVDest.ToBitmap();
                Thread.Sleep((int)capture.GetCaptureProperty(CapProp.Fps));
            }

            catch (Exception) { }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            HLow = trackBar1.Value;
            label1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            SLow = trackBar2.Value;
            label2.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            VLow = trackBar3.Value;
            label3.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            HHigh = trackBar4.Value;
            label4.Text = trackBar4.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            SHigh = trackBar5.Value;
            label5.Text = trackBar5.Value.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            VHigh = trackBar6.Value;
            label6.Text = trackBar6.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = HLow;
            trackBar2.Value = SLow;
            trackBar3.Value = VLow;
            trackBar4.Value = HHigh;
            trackBar5.Value = SHigh;
            trackBar6.Value = VHigh;

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture.Pause();
            }
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          if(capture==null)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    capture = new Emgu.CV.Capture(ofd.FileName);
                    capture.ImageGrabbed += Capture_ImageGrabbed;
                    capture.Start();
                }
            }
        }
    }
}
