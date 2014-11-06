namespace GUI
{
    partial class FoamStability
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileLocation = new System.Windows.Forms.TextBox();
            this.openVideoFile = new System.Windows.Forms.OpenFileDialog();
            this.ContinueFromFileSelection = new System.Windows.Forms.Button();
            this.Screenshot = new System.Windows.Forms.PictureBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.IntervalSelectionLabel = new System.Windows.Forms.Label();
            this.IntervalSelection = new System.Windows.Forms.NumericUpDown();
            this.RunButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProcessImages = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.Screenshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // FileLocation
            // 
            this.FileLocation.Location = new System.Drawing.Point(12, 12);
            this.FileLocation.Name = "FileLocation";
            this.FileLocation.Size = new System.Drawing.Size(234, 20);
            this.FileLocation.TabIndex = 1;
            this.FileLocation.Text = "Click to select a video";
            // 
            // openVideoFile
            // 
            this.openVideoFile.FileName = "videoFile";
            this.openVideoFile.Filter = "\"Media Files|*.mpg;*.avi;*.mov;*.wmv;*.mp4;|All Files|*.*\";";
            // 
            // ContinueFromFileSelection
            // 
            this.ContinueFromFileSelection.Location = new System.Drawing.Point(252, 10);
            this.ContinueFromFileSelection.Name = "ContinueFromFileSelection";
            this.ContinueFromFileSelection.Size = new System.Drawing.Size(75, 23);
            this.ContinueFromFileSelection.TabIndex = 3;
            this.ContinueFromFileSelection.Text = "LoadVideo";
            this.ContinueFromFileSelection.UseVisualStyleBackColor = true;
            this.ContinueFromFileSelection.Click += new System.EventHandler(this.ContinueFromFileSelection_Click);
            // 
            // Screenshot
            // 
            this.Screenshot.Enabled = false;
            this.Screenshot.ImageLocation = "";
            this.Screenshot.Location = new System.Drawing.Point(12, 90);
            this.Screenshot.Margin = new System.Windows.Forms.Padding(0);
            this.Screenshot.Name = "Screenshot";
            this.Screenshot.Size = new System.Drawing.Size(640, 360);
            this.Screenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Screenshot.TabIndex = 4;
            this.Screenshot.TabStop = false;
            this.Screenshot.Visible = false;
            this.Screenshot.Click += new System.EventHandler(this.Screenshot_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Enabled = false;
            this.InfoLabel.Location = new System.Drawing.Point(12, 74);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(158, 13);
            this.InfoLabel.TabIndex = 5;
            this.InfoLabel.Text = "Click in the middle of the beaker";
            this.InfoLabel.Visible = false;
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Enabled = false;
            this.PositionLabel.Location = new System.Drawing.Point(655, 90);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(94, 13);
            this.PositionLabel.TabIndex = 6;
            this.PositionLabel.Text = "Selected position: ";
            this.PositionLabel.Visible = false;
            // 
            // IntervalSelectionLabel
            // 
            this.IntervalSelectionLabel.AutoSize = true;
            this.IntervalSelectionLabel.Enabled = false;
            this.IntervalSelectionLabel.Location = new System.Drawing.Point(656, 107);
            this.IntervalSelectionLabel.Name = "IntervalSelectionLabel";
            this.IntervalSelectionLabel.Size = new System.Drawing.Size(151, 13);
            this.IntervalSelectionLabel.TabIndex = 7;
            this.IntervalSelectionLabel.Text = "Seconds between data points:";
            this.IntervalSelectionLabel.Visible = false;
            // 
            // IntervalSelection
            // 
            this.IntervalSelection.Enabled = false;
            this.IntervalSelection.Location = new System.Drawing.Point(811, 105);
            this.IntervalSelection.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.IntervalSelection.Name = "IntervalSelection";
            this.IntervalSelection.Size = new System.Drawing.Size(44, 20);
            this.IntervalSelection.TabIndex = 9;
            this.IntervalSelection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IntervalSelection.Visible = false;
            // 
            // RunButton
            // 
            this.RunButton.Enabled = false;
            this.RunButton.Location = new System.Drawing.Point(779, 426);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 10;
            this.RunButton.Text = "Run!";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Visible = false;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Enabled = false;
            this.ProgressBar.Location = new System.Drawing.Point(673, 426);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 23);
            this.ProgressBar.TabIndex = 11;
            this.ProgressBar.Visible = false;
            // 
            // ProcessImages
            // 
            this.ProcessImages.WorkerReportsProgress = true;
            this.ProcessImages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProcessImages_DoWork);
            this.ProcessImages.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Progress_Changed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 462);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.IntervalSelection);
            this.Controls.Add(this.IntervalSelectionLabel);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.Screenshot);
            this.Controls.Add(this.ContinueFromFileSelection);
            this.Controls.Add(this.FileLocation);
            this.Name = "Form1";
            this.Text = "FoamStability";
            ((System.ComponentModel.ISupportInitialize)(this.Screenshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalSelection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.TextBox FileLocation;
        private System.Windows.Forms.OpenFileDialog openVideoFile;
        private System.Windows.Forms.Button ContinueFromFileSelection;
        private System.Windows.Forms.PictureBox Screenshot;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.Label IntervalSelectionLabel;
        private System.Windows.Forms.NumericUpDown IntervalSelection;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.ComponentModel.BackgroundWorker ProcessImages;
    }
}

