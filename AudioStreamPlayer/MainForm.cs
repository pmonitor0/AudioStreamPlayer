using AudioStreamPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AudioStreamPlayer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			InitializeComponent();



			this.Text = this.Text + ((System.Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) == 8) ? " (x64)" : " (x86)");

		}


		private void DisposeCurrentDemo()
		{
			/*
            if (panelDemo.Controls.Count > 0)
            {
                panelDemo.Controls[0].Dispose();
                panelDemo.Controls.Clear();
                GC.Collect();
            }
            */
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			DisposeCurrentDemo();
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			this.MainForm_SizeChanged(null, null);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			MP3StreamingPanel panel = new MP3StreamingPanel();
			this.Controls.Add(panel);
			panel.Location = new System.Drawing.Point(0, 0);
			panel.MP3StreamingPanel_SizeChanged(null, null);

		}

		public void MainForm_SizeChanged(object sender, EventArgs e)
		{
			MP3StreamingPanel panel = (MP3StreamingPanel)this.Controls["MP3StreamingPanel"];
			panel.Location = new Point(0, toolStrip1.Bottom);
			panel.Width = this.Width;
			panel.Height = this.Height - toolStrip1.Bottom;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.CheckPathExists = true;
			openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				MP3StreamingPanel mP3StreamingPanel = (MP3StreamingPanel)this.Controls["MP3StreamingPanel"];
				mP3StreamingPanel.textBoxStreamingUrl.Text = "file:///" + openFileDialog1.FileName;
			}
		}

		private void AddListfile_Click(object sender, EventArgs e)
		{
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.CheckPathExists = true;
			openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				MP3StreamingPanel mP3StreamingPanel = (MP3StreamingPanel)this.Controls["MP3StreamingPanel"];
				mP3StreamingPanel.textBoxStreamingUrl.Text = "file:///" + openFileDialog1.FileName;
			}
		}
	}
}