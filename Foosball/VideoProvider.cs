using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    public class VideoProvider
    {
        private string s_videoUrl;

        public VideoProvider(string videoUrl)
        {
            s_videoUrl = videoUrl;
        }

        public string GetVideoUrl()
        {
            return s_videoUrl;
        }
    }
}
