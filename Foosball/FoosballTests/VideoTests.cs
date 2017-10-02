using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foosball;

namespace FoosballTests
{
    [TestClass]
    public class VideoTests
    {
        [TestMethod]
        public void VideoProvider_GetVideoUrlTest()
        {
            var videoUrl = @"C:\Users\narus\Downloads\LiveByNight.mkv";
            var videoProvider = new VideoProvider(videoUrl);

            Assert.AreEqual(videoProvider.GetVideoUrl(), videoUrl);
        }
    }
}
