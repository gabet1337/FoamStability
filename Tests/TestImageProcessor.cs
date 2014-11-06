using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoamStability;
namespace Tests
{
    [TestClass]
    public class TestImageProcessor
    {
        private string testFile = @"D:\Dropbox\Skum\testfiles\test.bmp";

        [TestMethod]
        public void TestGetCorrectFoamHeight()
        {
            ImageProcessor ip = new ImageProcessor(testFile);
            int height = ip.GetFoamHeight(870);
            Console.WriteLine(height);
            Assert.IsTrue(200 <= height && height <= 230);
        }
    }
}
