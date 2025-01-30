namespace AudioStreamPlayer
{
    partial class MainForm
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			openToolStripMenuItem = new ToolStripMenuItem();
			AddListfile = new ToolStripMenuItem();
			toolStrip1 = new ToolStrip();
			toolStripBtnPlay = new ToolStripButton();
			toolStripBtnPause = new ToolStripButton();
			toolStripBtnStop = new ToolStripButton();
			toolStripBtnStartRec = new ToolStripButton();
			toolStripBtnStopRec = new ToolStripButton();
			toolStripBtnPrevious = new ToolStripButton();
			toolStripBtnNext = new ToolStripButton();
			toolStripBtnExitList = new ToolStripButton();
			toolStripBtnTrackUp = new ToolStripButton();
			toolStripBtnTrackDown = new ToolStripButton();
			openFileDialog1 = new OpenFileDialog();
			menuStrip1.SuspendLayout();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.BackColor = Color.FromArgb(255, 128, 0);
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1234, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, AddListfile });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "Fájl";
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.Size = new Size(210, 22);
			openToolStripMenuItem.Text = "Megnyitás...";
			openToolStripMenuItem.Click += openToolStripMenuItem_Click;
			// 
			// AddListfile
			// 
			AddListfile.Name = "AddListfile";
			AddListfile.Size = new Size(210, 22);
			AddListfile.Text = "Audio fájlok hozzáadása...";
			AddListfile.Click += AddListfile_Click;
			// 
			// toolStrip1
			// 
			toolStrip1.BackColor = Color.FromArgb(255, 128, 0);
			toolStrip1.ImageScalingSize = new Size(32, 32);
			toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripBtnPlay, toolStripBtnPause, toolStripBtnStop, toolStripBtnStartRec, toolStripBtnStopRec, toolStripBtnPrevious, toolStripBtnNext, toolStripBtnExitList, toolStripBtnTrackUp, toolStripBtnTrackDown });
			toolStrip1.Location = new Point(0, 24);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(1234, 39);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "toolStrip1";
			// 
			// toolStripBtnPlay
			// 
			toolStripBtnPlay.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnPlay.Image = (Image)resources.GetObject("toolStripBtnPlay.Image");
			toolStripBtnPlay.ImageTransparentColor = Color.Magenta;
			toolStripBtnPlay.Name = "toolStripBtnPlay";
			toolStripBtnPlay.Size = new Size(36, 36);
			toolStripBtnPlay.Text = "toolStripButton1";
			toolStripBtnPlay.Click += toolStripBtnPlay_Click;
			// 
			// toolStripBtnPause
			// 
			toolStripBtnPause.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnPause.Image = (Image)resources.GetObject("toolStripBtnPause.Image");
			toolStripBtnPause.ImageTransparentColor = Color.Magenta;
			toolStripBtnPause.Name = "toolStripBtnPause";
			toolStripBtnPause.Size = new Size(36, 36);
			toolStripBtnPause.Text = "toolStripButton1";
			toolStripBtnPause.Click += toolStripBtnPause_Click;
			// 
			// toolStripBtnStop
			// 
			toolStripBtnStop.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnStop.Image = (Image)resources.GetObject("toolStripBtnStop.Image");
			toolStripBtnStop.ImageTransparentColor = Color.Magenta;
			toolStripBtnStop.Name = "toolStripBtnStop";
			toolStripBtnStop.Size = new Size(36, 36);
			toolStripBtnStop.Text = "toolStripButton1";
			toolStripBtnStop.Click += toolStripBtnStop_Click;
			// 
			// toolStripBtnStartRec
			// 
			toolStripBtnStartRec.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnStartRec.Image = (Image)resources.GetObject("toolStripBtnStartRec.Image");
			toolStripBtnStartRec.ImageTransparentColor = Color.Magenta;
			toolStripBtnStartRec.Name = "toolStripBtnStartRec";
			toolStripBtnStartRec.Size = new Size(36, 36);
			toolStripBtnStartRec.Text = "toolStripButton1";
			// 
			// toolStripBtnStopRec
			// 
			toolStripBtnStopRec.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnStopRec.Image = (Image)resources.GetObject("toolStripBtnStopRec.Image");
			toolStripBtnStopRec.ImageTransparentColor = Color.Magenta;
			toolStripBtnStopRec.Name = "toolStripBtnStopRec";
			toolStripBtnStopRec.Size = new Size(36, 36);
			toolStripBtnStopRec.Text = "toolStripButton1";
			// 
			// toolStripBtnPrevious
			// 
			toolStripBtnPrevious.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnPrevious.Image = (Image)resources.GetObject("toolStripBtnPrevious.Image");
			toolStripBtnPrevious.ImageTransparentColor = Color.Magenta;
			toolStripBtnPrevious.Name = "toolStripBtnPrevious";
			toolStripBtnPrevious.Size = new Size(36, 36);
			toolStripBtnPrevious.Text = "toolStripButton1";
			// 
			// toolStripBtnNext
			// 
			toolStripBtnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnNext.Image = (Image)resources.GetObject("toolStripBtnNext.Image");
			toolStripBtnNext.ImageTransparentColor = Color.Magenta;
			toolStripBtnNext.Name = "toolStripBtnNext";
			toolStripBtnNext.Size = new Size(36, 36);
			toolStripBtnNext.Text = "toolStripButton1";
			// 
			// toolStripBtnExitList
			// 
			toolStripBtnExitList.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnExitList.Image = (Image)resources.GetObject("toolStripBtnExitList.Image");
			toolStripBtnExitList.ImageTransparentColor = Color.Magenta;
			toolStripBtnExitList.Name = "toolStripBtnExitList";
			toolStripBtnExitList.Size = new Size(36, 36);
			toolStripBtnExitList.Text = "toolStripButton1";
			// 
			// toolStripBtnTrackUp
			// 
			toolStripBtnTrackUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnTrackUp.Image = (Image)resources.GetObject("toolStripBtnTrackUp.Image");
			toolStripBtnTrackUp.ImageTransparentColor = Color.Magenta;
			toolStripBtnTrackUp.Name = "toolStripBtnTrackUp";
			toolStripBtnTrackUp.Size = new Size(36, 36);
			toolStripBtnTrackUp.Text = "toolStripButton1";
			// 
			// toolStripBtnTrackDown
			// 
			toolStripBtnTrackDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripBtnTrackDown.Image = (Image)resources.GetObject("toolStripBtnTrackDown.Image");
			toolStripBtnTrackDown.ImageTransparentColor = Color.Magenta;
			toolStripBtnTrackDown.Name = "toolStripBtnTrackDown";
			toolStripBtnTrackDown.Size = new Size(36, 36);
			toolStripBtnTrackDown.Text = "toolStripButton1";
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			openFileDialog1.Filter = "Audió fájlok(*.mp3;*.wav)|*.mp3;*.wav|All files (*.*)|*.*";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1234, 618);
			Controls.Add(toolStrip1);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Margin = new Padding(4, 3, 4, 3);
			Name = "MainForm";
			Text = "Rádiók";
			FormClosing += MainForm_FormClosing;
			Load += MainForm_Load;
			Shown += MainForm_Shown;
			SizeChanged += MainForm_SizeChanged;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private MP3StreamingPanel panelDemo;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStrip toolStrip1;
		private ToolStripMenuItem openToolStripMenuItem;
		private OpenFileDialog openFileDialog1;
		private ToolStripMenuItem AddListfile;
		private ToolStripButton toolStripBtnPlay;
		private ToolStripButton toolStripBtnPause;
		private ToolStripButton toolStripBtnStop;
		private ToolStripButton toolStripBtnStartRec;
		private ToolStripButton toolStripBtnStopRec;
		private ToolStripButton toolStripBtnPrevious;
		private ToolStripButton toolStripBtnNext;
		private ToolStripButton toolStripBtnExitList;
		private ToolStripButton toolStripBtnTrackUp;
		private ToolStripButton toolStripBtnTrackDown;
	}
}

