using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Linq;
using AudioStreamPlayer;
using  System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AudioStreamPlayer
{
	public partial class MP3StreamingPanel : UserControl
	{
		long duration;
		enum StreamingPlaybackState
		{
			Stopped,
			Playing,
			Buffering,
			Paused
		}

		public enum VLCState
		{
			NothingSpecial = 0,
			Opening = 1,
			Buffering = 2,
			Playing = 3,
			Paused = 4,
			Stopped = 5,
			Ended = 6,
			Error = 7
		}

		public MP3StreamingPanel()
		{
			InitializeComponent();
			listViewFile.AllowDrop = true;
			this.AllowDrop = true;
			listViewFile.DragEnter += new DragEventHandler(listViewFile_DragEnter);
			listViewFile.DragDrop += new DragEventHandler(listViewFile_DragDrop);
		}

		void listViewFile_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}

		void listViewFile_DragDrop(object sender, DragEventArgs e)
		{
			string currDir = System.IO.Directory.GetCurrentDirectory();
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			foreach (string file in files)
			{
				string fileName = Path.GetFileName(file);
				string dirName = Path.GetDirectoryName(file);
				string ext = Path.GetExtension(file);

				int pos = fileName.IndexOf(ext);
				string address = fileName.Substring(0, pos);

				ListViewItem item = new ListViewItem(address);
				item.SubItems.Add(file);
				listViewFile.Items.Add(item);
			}
		}

		private void RPlayerAPI_PlayingChanged(object? sender, int e)
		{
			Console.WriteLine("PlayingChanged");
			//trackBar1.Maximum = e;
			//Console.WriteLine(e.ToString());
			//duration = RPlayerAPI.GetMediaDuration();

		}

		private void myTimer1_Tick(object? sender, EventArgs e)
		{
			if (ASPlayerAPI.Getstate() == VLCState.Playing || ASPlayerAPI.Getstate() == VLCState.Paused)
			{

				duration = ASPlayerAPI.Getduration();
				if (duration <= 0) return;
				if (mousePressed || mousePressed2) return;
				trackBarPos.Invoke(new Action(() =>
				{
					trackBarPos.Maximum = (int)(duration / 1000.0);
					long lng = (long)(ASPlayerAPI.GetPosition() / 1000.0);
					if (lng > trackBarPos.Maximum) lng = (long)(trackBarPos.Maximum);
					trackBarPos.Value = (int)lng;
					lblValuePos.Text = trackBarPos.Value.ToString() + "/" + ((int)(duration / 1000.0)).ToString();
					//RPlayerAPI.Seek(0.5f);
				}));
			}
			else if (ASPlayerAPI.Getstate() == VLCState.Ended)
			{

				currentURL = "";
				trackBarPos.Value = 0;
				trackBarPos.Maximum = 0;
				trackBarPos.Minimum = 0;
				buttonPlay.Text = "Play";
				if (IsPlayListFile)
				{
					listViewFile.Items[lstviewSelectedIndex].Selected = false;
					++lstviewSelectedIndex;
					if (lstviewSelectedIndex >= listViewFile.Items.Count)
					{
						lstviewSelectedIndex = 0;
						listViewFile.Items[0].Selected = true;
						listViewFile.Items[0].Focused = true;
						listViewFile.Items[0].EnsureVisible();
						//listViewFile.Focused = true;
						//listViewFile.Focus();

						IsPlayListFile = false;
						lblValuePos.Text = "0/0";
						listViewStations.Enabled = true;
						textBoxStreamingUrl.Enabled = true;
						btnListDelete.Enabled = true;
						return;

					}
					listViewFile.Items[lstviewSelectedIndex].Selected = true;
					listViewFile_DoubleClick(null, null);
				}
			}
		}



		private void TrackBar1_Scroll(object? sender, EventArgs e)
		{
			int value = trackBarPos.Value;
			double indexDbl = (value * 1.0) / trackBarPos.TickFrequency;
			int index = Convert.ToInt32(Math.Round(indexDbl));

			trackBarPos.Value = trackBarPos.TickFrequency * index;

			string str = trackBarPos.Value.ToString();
		}

		private void RPlayerAPI_BufferChanged(object? sender, float e)
		{
			progressBarBuffer.Invoke(new Action(() =>
			{
				if (((int)e) > 100) e = 100;
				progressBarBuffer.Value = (int)e;
				lblBufferPos.Text = ((int)e).ToString();
			}));
		}


		private void VolumeSlider1_DataContextChanged(object? sender, EventArgs e)
		{
			int val = volumeSlider1.Value;
			ASPlayerAPI.SetVolume((int)val);
			volumeSlider1.Refresh();
		}

		bool IsPlayListFile = false;
		private volatile StreamingPlaybackState playbackState;
		private volatile bool fullyDownloaded;
		private HttpWebRequest webRequest;
		public List<Radio> Radios = new List<Radio>();
		public List<Radio> RadioFilter = new List<Radio>();
		string currentURL;
		delegate void ShowErrorDelegate(string message);

		private void ShowError(string message)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new ShowErrorDelegate(ShowError), message);
			}
			else
			{
				MessageBox.Show(message);
			}
		}

		private void buttonPlay_Click(object sender, EventArgs e)
		{
			VLCState state = ASPlayerAPI.Getstate();
			if (textBoxStreamingUrl.Text == currentURL)
			{
				if (state == VLCState.Playing || state == VLCState.Paused)
				{
					ASPlayerAPI.Play(null);
				}
				if (buttonPlay.Text == "Play") buttonPlay.Text = "Pause";
				else buttonPlay.Text = "Play";
				return;
			}
			ASPlayerAPI.ChangeStation(textBoxStreamingUrl.Text);
			buttonPlay.Text = "Pause";
			currentURL = textBoxStreamingUrl.Text;
			duration = -1;
			ASPlayerAPI.SetVolume(volumeSlider1.Value);
			ASPlayerAPI.RegisterBufferEvent();
			//RPlayerAPI.RegisterPlayingEvent();
			this.Parent.Text = "";
			foreach (var item in Radios)
			{
				if (textBoxStreamingUrl.Text.ToLower() == item.RadioURL.ToLower())
				{
					this.Parent.Text = "AudioStreamPlayer " + ((System.Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) == 8) ? " (x64) " : " (x86) - ") + item.RadioName;
					break;
				}
			}
			if (this.Parent.Text == "") this.Parent.Text = "AudioStreamPlayer " + ((System.Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) == 8) ? " (x64) " : " (x86) - Ismeretlen");
		}

		private void ShowBufferState(double totalSeconds)
		{
			labelBuffered.Text = String.Format("{0:0.0}s", totalSeconds);
			progressBarBuffer.Value = (int)(totalSeconds * 1000);
		}


		private void MP3StreamingPanel_Disposing(object sender, EventArgs e)
		{
			buttonStop_Click(sender, e);
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			ASPlayerAPI.Stop();
			buttonPlay.Text = "Play";
			currentURL = "";
			if (this.Parent != null) this.Parent.Text = "AudioStreamPlayer " + ((System.Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) == 8) ? " (x64) " : " (x86) ");
		}

		private void waveOut_PlaybackStopped(object sender, EventArgs e)
		{
			//Debug.WriteLine("Playback Stopped");
		}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			if (listViewStations.SelectedItems.Count == 1)
			{
				textBoxStreamingUrl.Text = listViewStations.SelectedItems[0].SubItems[1].Text;
				buttonPlay_Click(sender, e);
			}
		}

		private void listView1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter) listView1_DoubleClick(sender, e);
		}

		bool playlist = false;

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (!playlist)
			{
				RadioFilter = Radios.Where(x => x.RadioName.Substring(0, textBoxFilter.Text.Length).ToUpper() == textBoxFilter.Text.ToUpper())
					.Select(x => x)
					.Distinct()
					.ToList<Radio>();

				listViewStations.Items.Clear();
				foreach (Radio radio in RadioFilter)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = radio.RadioName;
					lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, radio.RadioURL));
					listViewStations.Items.Add(lvi);
				}
			}
		}

		void listViewStationsLoad()
		{
			string[] radiok = File.ReadAllLines("Stations.txt");
			foreach (string radio in radiok)
			{
				Radio rd = new Radio();
				string[] strings = radio.Split(',');
				rd.RadioName = strings[0].Trim();
				rd.RadioURL = strings[1].Trim();
				Radios.Add(rd);
			}
		}

		List<ListFile> ListFiles = new List<ListFile>();

		void listViewFileLoad()
		{

			string[] listfiles = File.ReadAllLines("ListFile.txt");
			foreach (string lstfile in listfiles)
			{
				ListFile lf = new ListFile();
				string[] strings = lstfile.Split(',');
				//Radiok.Rows.Add()
				lf.Name = strings[0];
				lf.Path = strings[1];
				ListFiles.Add(lf);
			}
			listViewFile.Items.Clear();
			foreach (ListFile item in ListFiles)
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = item.Name;
				lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, item.Path));
				listViewFile.Items.Add(lvi);
			}
		}

		public class ListFile
		{
			public string Name { get; set; }
			public string Path { get; set; }
		}

		public class Radio
		{
			public string RadioName { get; set; }
			public string RadioURL { get; set; }
		}

		bool mousePressed = false;
		bool mousePressed2 = false;

		private void volumeSlider1_MouseMove(object sender, MouseEventArgs e)
		{
			if (mousePressed)
			{
				volumeSlider1.Focus();
				double value;
				if (e.X > volumeSlider1.Width) value = volumeSlider1.Width;
				else value = e.X;
				value = value / volumeSlider1.Width;
				int max = volumeSlider1.Maximum;
				int min = volumeSlider1.Minimum;
				double val = min + value * (max - min);
				if (val > volumeSlider1.Maximum) val = volumeSlider1.Maximum;
				if (val < volumeSlider1.Minimum) val = volumeSlider1.Minimum;
				volumeSlider1.Value = (int)val;
				ASPlayerAPI.SetVolume((int)val);
				lblVolumePos.Text = volumeSlider1.Value.ToString();
			}
		}

		private void volumeSlider1_MouseUp(object sender, MouseEventArgs e)
		{
			mousePressed = false;
		}

		private void volumeSlider1_MouseDown(object sender, MouseEventArgs e)
		{
			volumeSlider1.Focus();
			double value;
			if (e.X > volumeSlider1.Width) value = volumeSlider1.Width;
			else value = e.X;
			value = value / volumeSlider1.Width;
			int max = volumeSlider1.Maximum;
			int min = volumeSlider1.Minimum;
			double val = min + value * (max - min);
			if (val > volumeSlider1.Maximum) val = volumeSlider1.Maximum;
			volumeSlider1.Value = (int)val;
			ASPlayerAPI.SetVolume((int)val);
			lblVolumePos.Text = volumeSlider1.Value.ToString();
			mousePressed = true;
		}

		private void volumeSlider1_Click(object sender, EventArgs e)
		{

		}

		private void MP3StreamingPanel_Load(object sender, EventArgs e)
		{
			myTimer1.Mode = MyTimer.TimerMode.Periodic;
			ASPlayerAPI.BufferChanged += RPlayerAPI_BufferChanged;
			progressBarBuffer.Value = 0;
			listViewStationsLoad();
			listViewFileLoad();
			textBox1_TextChanged(null, null);
			this.volumeSlider1.Enabled = true;
			this.volumeSlider1.Minimum = 0;
			this.volumeSlider1.Maximum = 100;
			this.volumeSlider1.Step = 1;
			this.volumeSlider1.DataContextChanged += VolumeSlider1_DataContextChanged;
			VolumeSlider1_DataContextChanged(null, null);
			trackBarPos.Minimum = 0;
			trackBarPos.Maximum = int.MaxValue;
			trackBarPos.TickFrequency = 5;
			trackBarPos.LargeChange = 3;
			trackBarPos.Scroll += TrackBar1_Scroll;
			lblVolumePos.Text = volumeSlider1.Value.ToString();
			myTimer1.SynchronizingObject = this.Parent;
			myTimer1.Interval = 25;
			myTimer1.Tick += myTimer1_Tick;
			myTimer1.Start();
			ASPlayerAPI.RegisterBufferEvent();
			ASPlayerAPI.AttachPlayingEvent();
			this.Parent.Text = "AudioStreamPlayer " + ((System.Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) == 8) ? " (x64) " : " (x86) ");
		}

		private void buttonRec_Click(object sender, EventArgs e)
		{
			if (buttonRec.Text == "Start Rec")
			{
				ASPlayerAPI.StartRecorder(textBoxStreamingUrl.Text);
				buttonRec.Text = "Stop Rec";
			}
			else
			{
				ASPlayerAPI.StopRecorder();
				buttonRec.Text = "Start Rec";
			}
		}

		public void MP3StreamingPanel_SizeChanged(object sender, EventArgs e)
		{

			this.textBoxStreamingUrl.Width = listViewStations.Right - textBoxStreamingUrl.Left;
			lblBufferPos.Location = new Point(textBoxStreamingUrl.Right - lblBufferPos.Width - 0, textBoxStreamingUrl.Bottom + 15);
			progressBarBuffer.Width = textBoxStreamingUrl.Right - textBoxStreamingUrl.Left - lblBufferPos.Width - 20;
			lblBufferPos.Text = progressBarBuffer.Value.ToString();
			lblValuePos.AutoSize = false;
			lblValuePos.Width = 100;
			lblValuePos.Text = trackBarPos.Value.ToString() + "/0";
			trackBarPos.Location = new Point(textBoxFilter.Right + 10, textBoxFilter.Top);
			listViewStations.Location = new Point(textBoxFilter.Left, trackBarPos.Bottom + 10);
			trackBarPos.Width = this.Width - textBoxFilter.Right - lblValuePos.Width - 80;
			lblValuePos.Location = new Point(trackBarPos.Right + 5, trackBarPos.Top + 5);
			listViewStations.Width = (int)((this.Width - 60) / 2.0 - 10);
			listViewStations.Height = (this.Height - trackBarPos.Bottom - 60);  /// 2 - 10;
			listViewFile.Location = new Point(listViewStations.Right + 10, listViewStations.Top);
			listViewFile.Width = listViewStations.Width; ;
			listViewFile.Height = listViewStations.Height;

		}

		private void trackBarPos_MouseUp(object sender, MouseEventArgs e)
		{
			mousePressed2 = false;
		}

		private void trackBarPos_MouseMove(object sender, MouseEventArgs e)
		{
			if (mousePressed2)
			{
				trackBarPos.Focus();
				ASPlayerAPI.Seek(((float)trackBarPos.Value / trackBarPos.Maximum));
				trackBarPos.Text = trackBarPos.Value.ToString() + '/' + duration;
			}
		}

		private void trackBarPos_MouseDown(object sender, MouseEventArgs e)
		{
			mousePressed2 = true;
			trackBarPos.Focus();
			double value;
			if (e.X > trackBarPos.Width) value = trackBarPos.Width;
			else value = e.X;
			value = value / trackBarPos.Width;
			int max = trackBarPos.Maximum;
			int min = trackBarPos.Minimum;
			double val = min + value * (max - min);
			if (val > trackBarPos.Maximum) val = trackBarPos.Maximum;
			ASPlayerAPI.Seek(((float)trackBarPos.Value / trackBarPos.Maximum));
			trackBarPos.Text = trackBarPos.Value.ToString() + '/' + duration;
		}

		private void listViewFile_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter) listViewFile_DoubleClick(sender, e);
		}

		int lstviewSelectedIndex = 0;
		ListViewItem lvc = null;

		private void listViewFile_DoubleClick(object sender, EventArgs e)
		{
			if (listViewFile.SelectedItems.Count == 1)
			{
				textBoxStreamingUrl.Text = "file:///" + listViewFile.SelectedItems[0].SubItems[1].Text;
				lvc = listViewFile.Items[listViewFile.SelectedItems[0].SubItems[1].Text];
				lstviewSelectedIndex = listViewFile.Items.IndexOf(listViewFile.SelectedItems[0]);
				buttonPlay_Click(sender, e);
				IsPlayListFile = true;
				listViewStations.Enabled = false;
				textBoxStreamingUrl.Enabled = false;
				btnListDelete.Enabled = false;
			}
		}

		private void listViewFile_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listViewFile.SelectedItems.Count != 1) return;

		}

		private void btnListDelete_Click(object sender, EventArgs e)
		{
			listViewFile.Items.Clear();
		}
	}
}
