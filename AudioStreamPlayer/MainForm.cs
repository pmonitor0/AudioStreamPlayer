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
		MP3StreamingPanel panel;

		public MainForm()
		{
			//
			InitializeComponent();

			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			//toolStripBtnPause = new System.Windows.Forms.ToolStripButton();
			//toolStripBtnPause.DisplayStyle = ToolStripItemDisplayStyle.Image;
			//toolStripBtnPlay.Image = (Image)resources.GetObject("toolStripBtnPause.Image");


			//resources.GetObject()

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
			panel = new MP3StreamingPanel(this);
			this.Controls.Add(panel);
			panel.Location = new System.Drawing.Point(0, 0);
			panel.MP3StreamingPanel_SizeChanged(null, null);


			toolStripBtnPlay.Visible = true;
			toolStripBtnPause.Visible = false;
			toolStripBtnStartRec.Visible = true;
			toolStripBtnStopRec.Visible = false;
			toolStrip1.Refresh();

			this.MainForm_SizeChanged(null, null);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{


		}

		public void MainForm_SizeChanged(object sender, EventArgs e)
		{
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

				panel.textBoxStreamingUrl.Text = "file:///" + openFileDialog1.FileName;
			}
		}

		private void AddListfile_Click(object sender, EventArgs e)
		{
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.CheckPathExists = true;
			openFileDialog1.Multiselect = true;
			openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				MP3StreamingPanel mP3StreamingPanel = (MP3StreamingPanel)this.Controls["MP3StreamingPanel"];
				foreach (string file in openFileDialog1.FileNames)
				{
					string fileName = Path.GetFileName(file);
					string dirName = Path.GetDirectoryName(file);
					string ext = Path.GetExtension(file);

					int pos = fileName.IndexOf(ext);
					string address = fileName.Substring(0, pos);

					ListViewItem item = new ListViewItem(address);
					item.SubItems.Add(file);
					mP3StreamingPanel.listViewFile.Items.Add(item);
				}

			}
		}

		private void toolStripBtnPlay_Click(object sender, EventArgs e)
		{
			
			panel.buttonPlay_Click(null, null);
			if (ASPlayerAPI.Getstate() == MP3StreamingPanel.VLCState.Playing)
			{
				toolStripBtnPlay.Visible = false;
				toolStripBtnPause.Visible = true;
				toolStrip1.Refresh();
			}
		}

		private void toolStripBtnPause_Click(object sender, EventArgs e)
		{
			panel.buttonPlay_Click(null, null);
			toolStripBtnPlay.Visible = true;
			toolStripBtnPause.Visible = false;
			toolStrip1.Refresh();
		}

		private void toolStripBtnStop_Click(object sender, EventArgs e)
		{
			panel.buttonStop_Click(null, null);
			toolStripBtnPause.Visible= false;
			toolStripBtnPlay.Visible= true;
			toolStripBtnStopRec.Visible= false;
			toolStripBtnStartRec.Visible= true;
			toolStrip1.Refresh();
		}
	}
}