using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace AudioStreamPlayer
{
	internal class CustomProgressBar : ProgressBar
	{
		public CustomProgressBar() { this.SetStyle(ControlStyles.UserPaint, true); }

		

		
		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle rect = e.ClipRectangle;
			Graphics g = e.Graphics;
			rect.Width = (int)(rect.Width * ((double)Value / Maximum)) - 4;
			rect.Height -= 4;
			g.FillRectangle(Brushes.DarkGray, e.ClipRectangle);
			g.FillRectangle(Brushes.LightGreen, 2, 2, rect.Width, rect.Height);
		}
		
	}
}
