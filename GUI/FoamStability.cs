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
using System.IO;
using GUI.SaveOutputStrategies;

namespace GUI
{
    public partial class FoamStability : Form
    {

        private Point BeakerLocation;
        private string saveFileLocation;

        public FoamStability()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.FoamStabilitySmall;
            this.FileLocation.MouseClick += FileLocation_MouseClick;
        }

        private void ContinueFromFileSelection_Click(object sender, EventArgs e)
        {
            if (!File.Exists(FileLocation.Text))
            {
                MessageBox.Show("The file could not be located", "Error");
                return;
            }

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
                DialogResult dr = saveOutputDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    saveFileLocation = saveOutputDialog.FileName;
                    ProcessImages.RunWorkerAsync();
                }

            }
        }

        private void ProcessImages_DoWork(object sender, DoWorkEventArgs e)
        {
            ImageGenerator ig = new ImageGenerator();
            int interval = int.Parse(IntervalSelection.Value.ToString());
            //this.InfoLabel.Text = interval.ToString();
            List<string> li = ig.GetImagesWithInterval(@FileLocation.Text, interval.ToString());
            int progressIntervals = 100 / (li.Count+1);
            int currentProgress = 0;
            List<int> foamHeights = new List<int>();
            int d = 1;
            foreach (string s in li)
            {
                ProgressLabel.Text = "Processing image " + d++ + " of " + li.Count;
                ImageProcessor ip = new ImageProcessor(@s);
                foamHeights.Add(ip.GetFoamHeight(BeakerLocation.X*2));
                currentProgress += progressIntervals;
                ProcessImages.ReportProgress(currentProgress);
            }
            ProgressLabel.Text = "Saving to file";
            CSVSaveOutput csv = new CSVSaveOutput();
            csv.SaveOutput(saveFileLocation, foamHeights, interval);
            ProgressLabel.Text = "Saved to file and complete!";
            ProcessImages.ReportProgress(100);
            
        
        }

        private void Progress_Changed(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
