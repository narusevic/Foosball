using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    public class VideoProvider
    {
        private string m_videoUrl;

        public VideoProvider(string videoUrl)
        {
            m_videoUrl = videoUrl;
        }

        public string GetVideoUrl()
        {
            return m_videoUrl;
        }
    }
}
