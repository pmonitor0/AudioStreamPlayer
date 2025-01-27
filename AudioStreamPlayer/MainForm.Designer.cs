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
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			openToolStripMenuItem = new ToolStripMenuItem();
			AddListfile = new ToolStripMenuItem();
			toolStrip1 = new ToolStrip();
			openFileDialog1 = new OpenFileDialog();
			menuStrip1.SuspendLayout();
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
			toolStrip1.Location = new Point(0, 24);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(1234, 25);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "toolStrip1";
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
			ResumeLayout(false);
			PerformLayout();
		}

		private MP3StreamingPanel panelDemo = new MP3StreamingPanel();
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStrip toolStrip1;
		private ToolStripMenuItem openToolStripMenuItem;
		private OpenFileDialog openFileDialog1;
		private ToolStripMenuItem AddListfile;
	}
}

