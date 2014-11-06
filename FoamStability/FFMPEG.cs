using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FoamStability
{
    class FFMPEG
    {
        private string ffmpeg = @Properties.Settings.Default.ffmpegLocation;
        public string arguments { get; set; }
        public FFMPEG(string args)
        {
            this.arguments = args;
        }

        /// <summary>
        /// Runs ffmpeg with the given arguments
        /// </summary>
        /// <returns>Return the exit code of running ffmpeg</returns>
        public int Run()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = arguments;
            start.FileName = ffmpeg;
            //start.WindowStyle = ProcessWindowStyle.Hidden;
            //start.CreateNoWindow = false;
            using (Process p = Process.Start(start))
            {
                p.WaitForExit();
                return p.ExitCode;
            }
        }

    }
}
