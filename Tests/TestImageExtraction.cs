using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoamStability;
using System.Collections.Generic;
using System.Drawing;
namespace Tests
{
    [TestClass]
    public class TestImageExtraction
    {

        private string video = @"D:\Dropbox\Skum\Video 8.wmv";

        [TestMethod]
        public void GetSingleImageFromVideo()
        {
            ImageGenerator ig = new ImageGenerator();
            string img = ig.GetSingleImage(video, "0.5");
            Assert.IsNotNull(img);
        }

        [TestMethod]
        public void GetImagesWithInterval5Secs()
        {
            ImageGenerator ig = new ImageGenerator();
            List<string> li = ig.GetImagesWithInterval(video, "5");
            Assert.IsNotNull(li);
            Assert.AreEqual(6, li.Count);
        }
    }
}
