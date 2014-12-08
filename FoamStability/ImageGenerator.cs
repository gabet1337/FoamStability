using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
namespace FoamStability
{
    public class ImageGenerator
    {

        private string outputPath = @Properties.Settings.Default.OutputPath;
        private readonly string imageType = "jpg";

        public ImageGenerator()
        {
            if (!Directory.Exists(outputPath)) Directory.CreateDirectory(outputPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="video">file containing the video</param>
        /// <param name="ss">point in time to get image</param>
        /// <returns>A single image located a ss</returns>
        public string GetSingleImage(string video, string ss)
        {
            string imgName = "FOAM" + Guid.NewGuid().ToString();
            string args = "-ss " + ss + " -i " + "\"" + video + "\"" + " -vframes 1 -s hd720 -f image2 "
                + "\"" + outputPath + imgName + "." + imageType + "\"";
            Console.WriteLine(args);
            FFMPEG ffmpeg = new FFMPEG(args);
            if (ffmpeg.Run() != 0) return null;
            return Path.Combine(outputPath, imgName + "." + imageType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="video">file containing the video</param>
        /// <param name="interval">the interval at which to extract images at</param>
        /// <returns></returns>
        public List<string> GetImagesWithInterval(string video, string interval)
        {
            string imgName = "FOAM" + Guid.NewGuid().ToString();
            string args = "-i " + "\"" + video + "\"" + " -vf fps=fps=1/" + interval +
                " -f image2 " + "\"" + outputPath + imgName + "-%05d." + imageType + "\"";
            Console.WriteLine(args);
            FFMPEG ffmpeg = new FFMPEG(args);
            if (ffmpeg.Run() != 0) return null;
            List<string> result = new List<string>();
            foreach (string f in Directory.GetFiles(outputPath, imgName+"*"))
            {
                result.Add(f);
            }
            return result;
        }

    }
}
