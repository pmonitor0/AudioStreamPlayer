namespace AudioStreamPlayer
{
    partial class MP3StreamingPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			buttonPlay = new Button();
			textBoxStreamingUrl = new TextBox();
			lblStreamURL = new Label();
			progressBarBuffer = new ProgressBar();
			lblBuffer = new Label();
			buttonStop = new Button();
			labelBuffered = new Label();
			labelVolume = new Label();
			volumeSlider1 = new ProgressBar();
			listViewStations = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			textBoxFilter = new TextBox();
			buttonRec = new Button();
			lblVolumePos = new Label();
			lblBufferPos = new Label();
			trackBarPos = new TrackBar();
			lblValuePos = new Label();
			listViewFile = new ListView();
			columnHeader3 = new ColumnHeader();
			columnHeader4 = new ColumnHeader();
			myTimer1 = new MyTimer(components);
			btnListDelete = new Button();
			((System.ComponentModel.ISupportInitialize)trackBarPos).BeginInit();
			SuspendLayout();
			// 
			// buttonPlay
			// 
			buttonPlay.Location = new Point(620, 90);
			buttonPlay.Margin = new Padding(4, 3, 4, 3);
			buttonPlay.Name = "buttonPlay";
			buttonPlay.Size = new Size(49, 27);
			buttonPlay.TabIndex = 0;
			buttonPlay.Text = "Play";
			buttonPlay.UseVisualStyleBackColor = true;
			buttonPlay.Click += buttonPlay_Click;
			// 
			// textBoxStreamingUrl
			// 
			textBoxStreamingUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBoxStreamingUrl.Location = new Point(113, 14);
			textBoxStreamingUrl.Margin = new Padding(4, 3, 4, 3);
			textBoxStreamingUrl.Name = "textBoxStreamingUrl";
			textBoxStreamingUrl.Size = new Size(1000, 23);
			textBoxStreamingUrl.TabIndex = 1;
			// 
			// lblStreamURL
			// 
			lblStreamURL.AutoSize = true;
			lblStreamURL.Location = new Point(14, 17);
			lblStreamURL.Margin = new Padding(4, 0, 4, 0);
			lblStreamURL.Name = "lblStreamURL";
			lblStreamURL.Size = new Size(88, 15);
			lblStreamURL.TabIndex = 2;
			lblStreamURL.Text = "Streaming URL:";
			// 
			// progressBarBuffer
			// 
			progressBarBuffer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			progressBarBuffer.Location = new Point(113, 43);
			progressBarBuffer.Margin = new Padding(4, 3, 4, 3);
			progressBarBuffer.Name = "progressBarBuffer";
			progressBarBuffer.Size = new Size(946, 27);
			progressBarBuffer.Step = 1;
			progressBarBuffer.Style = ProgressBarStyle.Continuous;
			progressBarBuffer.TabIndex = 3;
			// 
			// lblBuffer
			// 
			lblBuffer.AutoSize = true;
			lblBuffer.Location = new Point(14, 52);
			lblBuffer.Margin = new Padding(4, 0, 4, 0);
			lblBuffer.Name = "lblBuffer";
			lblBuffer.Size = new Size(55, 15);
			lblBuffer.TabIndex = 4;
			lblBuffer.Text = "Buffered:";
			// 
			// buttonStop
			// 
			buttonStop.Location = new Point(677, 90);
			buttonStop.Margin = new Padding(4, 3, 4, 3);
			buttonStop.Name = "buttonStop";
			buttonStop.Size = new Size(70, 27);
			buttonStop.TabIndex = 6;
			buttonStop.Text = "Stop";
			buttonStop.UseVisualStyleBackColor = true;
			buttonStop.Click += buttonStop_Click;
			// 
			// labelBuffered
			// 
			labelBuffered.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			labelBuffered.AutoSize = true;
			labelBuffered.Location = new Point(1972, 52);
			labelBuffered.Margin = new Padding(4, 0, 4, 0);
			labelBuffered.Name = "labelBuffered";
			labelBuffered.Size = new Size(27, 15);
			labelBuffered.TabIndex = 7;
			labelBuffered.Text = "0.0s";
			// 
			// labelVolume
			// 
			labelVolume.AutoSize = true;
			labelVolume.Location = new Point(14, 84);
			labelVolume.Margin = new Padding(4, 0, 4, 0);
			labelVolume.Name = "labelVolume";
			labelVolume.Size = new Size(50, 15);
			labelVolume.TabIndex = 8;
			labelVolume.Text = "Volume:";
			// 
			// volumeSlider1
			// 
			volumeSlider1.ForeColor = Color.Lime;
			volumeSlider1.Location = new Point(113, 90);
			volumeSlider1.Margin = new Padding(4, 3, 4, 3);
			volumeSlider1.MarqueeAnimationSpeed = 0;
			volumeSlider1.MaximumSize = new Size(600, 30);
			volumeSlider1.MinimumSize = new Size(10, 15);
			volumeSlider1.Name = "volumeSlider1";
			volumeSlider1.RightToLeft = RightToLeft.No;
			volumeSlider1.Size = new Size(438, 25);
			volumeSlider1.Step = 0;
			volumeSlider1.Style = ProgressBarStyle.Continuous;
			volumeSlider1.TabIndex = 9;
			volumeSlider1.Value = 80;
			volumeSlider1.Click += volumeSlider1_Click;
			volumeSlider1.MouseDown += volumeSlider1_MouseDown;
			volumeSlider1.MouseMove += volumeSlider1_MouseMove;
			volumeSlider1.MouseUp += volumeSlider1_MouseUp;
			// 
			// listViewStations
			// 
			listViewStations.Alignment = ListViewAlignment.Default;
			listViewStations.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			listViewStations.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
			listViewStations.ForeColor = SystemColors.WindowText;
			listViewStations.FullRowSelect = true;
			listViewStations.GridLines = true;
			listViewStations.Location = new Point(18, 179);
			listViewStations.Margin = new Padding(4, 3, 4, 3);
			listViewStations.MultiSelect = false;
			listViewStations.Name = "listViewStations";
			listViewStations.Size = new Size(510, 637);
			listViewStations.TabIndex = 10;
			listViewStations.UseCompatibleStateImageBehavior = false;
			listViewStations.View = View.Details;
			listViewStations.DoubleClick += listView1_DoubleClick;
			listViewStations.KeyPress += listView1_KeyPress;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Rádió";
			columnHeader1.Width = 101;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "URL";
			columnHeader2.Width = 252;
			// 
			// textBoxFilter
			// 
			textBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			textBoxFilter.Location = new Point(18, 123);
			textBoxFilter.Margin = new Padding(4, 3, 4, 3);
			textBoxFilter.Name = "textBoxFilter";
			textBoxFilter.Size = new Size(233, 23);
			textBoxFilter.TabIndex = 11;
			textBoxFilter.TextChanged += textBox1_TextChanged;
			// 
			// buttonRec
			// 
			buttonRec.Location = new Point(754, 90);
			buttonRec.Name = "buttonRec";
			buttonRec.Size = new Size(76, 27);
			buttonRec.TabIndex = 12;
			buttonRec.Text = "Start Rec";
			buttonRec.UseVisualStyleBackColor = true;
			buttonRec.Click += buttonRec_Click;
			// 
			// lblVolumePos
			// 
			lblVolumePos.AutoSize = true;
			lblVolumePos.Location = new Point(558, 96);
			lblVolumePos.Name = "lblVolumePos";
			lblVolumePos.Size = new Size(38, 15);
			lblVolumePos.TabIndex = 13;
			lblVolumePos.Text = "label3";
			// 
			// lblBufferPos
			// 
			lblBufferPos.AutoSize = true;
			lblBufferPos.Location = new Point(1066, 52);
			lblBufferPos.Name = "lblBufferPos";
			lblBufferPos.Size = new Size(38, 15);
			lblBufferPos.TabIndex = 14;
			lblBufferPos.Text = "label4";
			// 
			// trackBarPos
			// 
			trackBarPos.AutoSize = false;
			trackBarPos.Location = new Point(267, 128);
			trackBarPos.Name = "trackBarPos";
			trackBarPos.Size = new Size(792, 45);
			trackBarPos.TabIndex = 15;
			trackBarPos.MouseDown += trackBarPos_MouseDown;
			trackBarPos.MouseMove += trackBarPos_MouseMove;
			trackBarPos.MouseUp += trackBarPos_MouseUp;
			// 
			// lblValuePos
			// 
			lblValuePos.Location = new Point(1066, 131);
			lblValuePos.Name = "lblValuePos";
			lblValuePos.Size = new Size(38, 15);
			lblValuePos.TabIndex = 16;
			lblValuePos.Text = "0/0";
			// 
			// listViewFile
			// 
			listViewFile.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
			listViewFile.FullRowSelect = true;
			listViewFile.GridLines = true;
			listViewFile.Location = new Point(549, 179);
			listViewFile.Name = "listViewFile";
			listViewFile.Size = new Size(564, 637);
			listViewFile.TabIndex = 17;
			listViewFile.UseCompatibleStateImageBehavior = false;
			listViewFile.View = View.Details;
			listViewFile.SelectedIndexChanged += listViewFile_SelectedIndexChanged;
			listViewFile.DoubleClick += listViewFile_DoubleClick;
			listViewFile.KeyPress += listViewFile_KeyPress;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Fájlnév";
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "Teljes útvonal";
			// 
			// myTimer1
			// 
			myTimer1.Site.Name = "myTimer1";
			// 
			// btnListDelete
			// 
			btnListDelete.Location = new Point(836, 90);
			btnListDelete.Name = "btnListDelete";
			btnListDelete.Size = new Size(85, 27);
			btnListDelete.TabIndex = 18;
			btnListDelete.Text = "Lista törlése";
			btnListDelete.UseVisualStyleBackColor = true;
			btnListDelete.Click += btnListDelete_Click;
			// 
			// MP3StreamingPanel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(255, 128, 0);
			Controls.Add(btnListDelete);
			Controls.Add(listViewFile);
			Controls.Add(lblValuePos);
			Controls.Add(trackBarPos);
			Controls.Add(lblBufferPos);
			Controls.Add(lblVolumePos);
			Controls.Add(buttonRec);
			Controls.Add(textBoxFilter);
			Controls.Add(listViewStations);
			Controls.Add(volumeSlider1);
			Controls.Add(labelVolume);
			Controls.Add(labelBuffered);
			Controls.Add(buttonStop);
			Controls.Add(lblBuffer);
			Controls.Add(progressBarBuffer);
			Controls.Add(lblStreamURL);
			Controls.Add(textBoxStreamingUrl);
			Controls.Add(buttonPlay);
			Margin = new Padding(4, 3, 4, 3);
			Name = "MP3StreamingPanel";
			Size = new Size(1128, 840);
			Load += MP3StreamingPanel_Load;
			SizeChanged += MP3StreamingPanel_SizeChanged;
			((System.ComponentModel.ISupportInitialize)trackBarPos).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private System.Windows.Forms.Button buttonPlay;
        public System.Windows.Forms.TextBox textBoxStreamingUrl;
        private System.Windows.Forms.Label lblStreamURL;
		private System.Windows.Forms.ProgressBar volumeSlider1;
        private System.Windows.Forms.ProgressBar progressBarBuffer;
        private System.Windows.Forms.Label lblBuffer;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelBuffered;
        private System.Windows.Forms.Label labelVolume;
		private System.Windows.Forms.ListView listViewStations;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TextBox textBoxFilter;
		private Button buttonRec;
		private Label lblVolumePos;
		private Label lblBufferPos;
		private TrackBar trackBarPos;
		private Label lblValuePos;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private MyTimer myTimer1;
		private Button btnListDelete;
		public ListView listViewFile;
	}
}