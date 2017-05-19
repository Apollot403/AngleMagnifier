using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleMagnifier
{
	public partial class FormStreak : Form
	{
		#region
		private FormStart formStart;
		private Image IM_Form;
		Graphics G;
		
		#endregion
		public FormStreak()
		{
			InitializeComponent();
		}
		public FormStreak(FormStart formStart)
		{
			InitializeComponent();
			this.formStart = formStart;
		}

		private void FormStreak_Load(object sender, EventArgs e)
		{
			this.Size = new Size((int)(SystemInformation.PrimaryMonitorSize.Width * 0.9),
												(int)(SystemInformation.PrimaryMonitorSize.Height * 0.9));
			int x = this.ClientSize.Width;
			int y = this.ClientSize.Height;
			this.Text = "AngleMagnifier";
			TextView.Text = "按F鍵擷取畫面";
			panel.Location = new Point(0, 0);
			TextView.Location = new Point(0, this.ClientSize.Height-TextView.Height);

			panel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
			IM_Form = new Bitmap(x, y);
			G = Graphics.FromImage(IM_Form);
		}

		private void FormStreak_KeyDown(object sender, KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.F:
					TextView.Visible = false;
					G.CopyFromScreen(new Point((Location.X + Size.Width - ClientSize.Width - 8),//Get form screen
																			(Location.Y + Size.Height - ClientSize.Height - 8))
																, new Point(0, 0), new Size(panel.Width, panel.Height));
					this.BackgroundImage = IM_Form;
					IntPtr dc = G.GetHdc();
					G.ReleaseHdc(dc);
					panel.Visible = false;
					TextView.Visible = true;
					TextView.Text = "按D鍵重新擷取\n點選兩點計算條數";
					TextView.Location = new Point(0, this.ClientSize.Height - TextView.Height);
					break;
				case Keys.D:
					BackgroundImage = null;
					panel.Visible = true;
					TextView.Text = "按F鍵擷取畫面";
					TextView.Location = new Point(0, this.ClientSize.Height - TextView.Height);
					break;
			}
		}

		private void FormStreak_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				formStart.WindowState = FormWindowState.Normal;
			}
			catch {; }
		}		
	}
}
