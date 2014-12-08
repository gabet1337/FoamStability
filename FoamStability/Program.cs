using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace FoamStability
{
    class Program
    {
        static readonly string imageType = "bmp";
        static readonly bool processVideo = false;
        static void Main(string[] args)
        {
            if (processVideo)
            {
                string video = args[0];
                string interval = args[1];
                double fps = 1.0 / double.Parse(interval);
                ProcessStartInfo start = new ProcessStartInfo();
                start.Arguments = "-i " + "\"" + video + "\"" + " -r " + fps.ToString().Replace(',', '.') + " -s hd720 -f image2 "
                    + "\"" + @Properties.Settings.Default.OutputPath +"image-%5d." + imageType + "\"";
                start.FileName = @"E:\Program Files (x86)\ffmpeg\bin\ffmpeg.exe";
                //start.WindowStyle = ProcessWindowStyle.Hidden;
                //start.CreateNoWindow = false;
                using (Process p = Process.Start(start))
                {
                    Console.WriteLine(p.StartInfo.Arguments);
                    p.WaitForExit();
                    Console.WriteLine(p.ExitCode);
                }
            }

            /*
             * The general algorithm:
             * Make a vertical sweep of each of the beakers and measure their brightness.
             * The sweep should have some width and then average the pixels
             * This should result in a list of averaged brightness levels
             * From this list, it should be possible to compute when the foam starts and ends
             * 
             * From the start and end point, compute the height and from that calculate the volume of the foam.
             * Need to figure out how to do this efficiently.
             * One possibility is to have a measure of how much 100pixels is in mm or cm.
             */

            Image img = Image.FromFile(Path.Combine(@Properties.Settings.Default.OutputPath, "image-1.bmp"));
            Bitmap b = new Bitmap(img);
            for (int i = 719; i >= 0; i--)
            {
                Console.WriteLine(i + " " + b.GetPixel(870, i).GetBrightness());
            }
        }
    }
}
