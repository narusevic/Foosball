using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foosball
{
    public partial class Video : Form
    {
        private VideoProvider _videoProvider;

        public Video()
        {
            InitializeComponent();
            _videoProvider = new VideoProvider(@"C:\Users\narus\Downloads\LiveByNight.mkv");
        }

        private void Video_Load(object sender, EventArgs e)
        {
            VideoPlayer.URL = _videoProvider.GetVideoUrl();
        }
    }
}
