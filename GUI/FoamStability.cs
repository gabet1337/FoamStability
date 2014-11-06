using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using FoamStability;
using System.Threading;

namespace GUI
{
    public partial class FoamStability : Form
    {

        private Point BeakerLocation;

        public FoamStability()
        {
            InitializeComponent();
            this.FileLocation.MouseClick += FileLocation_MouseClick;
        }

        private void ContinueFromFileSelection_Click(object sender, EventArgs e)
        {
            InfoLabel.Enabled = true;
            InfoLabel.Visible = true;
            ImageGenerator ig = new ImageGenerator();
            string i = ig.GetSingleImage(@FileLocation.Text, "0.5");
            Screenshot.Image = Image.FromFile(i);
            Screenshot.Enabled = true;
            Screenshot.Visible = true;
            this.PositionLabel.Visible = true;
            this.PositionLabel.Enabled = true;
            this.IntervalSelectionLabel.Enabled = true;
            this.IntervalSelectionLabel.Visible = true;
            this.IntervalSelection.Enabled = true;
            this.IntervalSelection.Visible = true;
            this.RunButton.Visible = true;
            this.RunButton.Enabled = true;
            this.ProgressBar.Visible = true;
            this.ProgressBar.Enabled = true;
        }

        private void Screenshot_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            BeakerLocation = me.Location;
            PositionLabel.Text = "Selected position: (" + BeakerLocation.X*2 + ", " + BeakerLocation.Y*2 + ")";
            
        }
        void FileLocation_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DialogResult result = openVideoFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                string vid = openVideoFile.FileName;
                //TODO: make sure it is a video file here!

                FileLocation.Text = vid;
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            //generate all the images and start processing them one by one!
            if (BeakerLocation != null)
            {
                ProcessImages.RunWorkerAsync();
            }
        }

        private void ProcessImages_DoWork(object sender, DoWorkEventArgs e)
        {
            ImageGenerator ig = new ImageGenerator();
            int interval = int.Parse(IntervalSelection.Value.ToString());
            this.InfoLabel.Text = interval.ToString();
            List<string> li = ig.GetImagesWithInterval(@FileLocation.Text, interval.ToString());
            int progressIntervals = 100 / li.Count;
            int currentProgress = 0;
            List<int> foamHeights = new List<int>();
            foreach (string s in li)
            {
                ImageProcessor ip = new ImageProcessor(s);
                foamHeights.Add(ip.GetFoamHeight(BeakerLocation.Y*2));
                currentProgress += progressIntervals;
                ProcessImages.ReportProgress(currentProgress);
            }
            ProcessImages.ReportProgress(100);
        }

        private void Progress_Changed(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

    }
}
