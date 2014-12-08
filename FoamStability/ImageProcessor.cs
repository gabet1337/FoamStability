using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FoamStability
{
    public class ImageProcessor
    {
        //the number of pixels to look at on both sides of the center (x)
        private static readonly int WIDTH = 50;
        private static readonly int HEIGHT = 10;

        private Bitmap image;
        public ImageProcessor(string i)
        {
            this.image = new Bitmap(i);
        }

        /// <summary>
        /// Gets the foam height in pixels
        /// </summary>
        /// <param name="x">the x coordinate that the beaker resides</param>
        /// <returns>foam height in pixels</returns>
        public int GetFoamHeight(int x)
        {
            //compute the brightnessLevels!
            double[] brightnessLevels = new double[image.Height];
            for (int i = 1; i < image.Height; i++)
            {
                double brightnessSum = 0.0;
                for (int j = -WIDTH; j <= WIDTH; j++)
                {
                    brightnessSum += image.GetPixel(x+j, i).GetBrightness();
                }
                brightnessLevels[i] = brightnessSum / (double)(WIDTH + WIDTH);
            }

            int result = 0;
            for (int i = 0; i < image.Height; i++)
            {
                if (brightnessLevels[i] > 0.1 &&
                    (brightnessLevels[i + HEIGHT >= image.Height ? image.Height : i + HEIGHT] > 0.1 ||
                    brightnessLevels[i - HEIGHT >= image.Height ? image.Height : i + HEIGHT] > 0.1))
                {
                    result++;
                    Console.WriteLine(i);
                }
            }
            return result;
        }

    }
}
