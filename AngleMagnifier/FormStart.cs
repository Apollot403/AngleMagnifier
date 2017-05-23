using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace AngleMagnifier
{
	public partial class FormStart : Form
	{
		public FormStart()
		{
			InitializeComponent();
			this.KeyPreview = true;
		}

		private void FormStart_Load(object sender, EventArgs e)
		{
			this.Text = "AngleMagnifier";
			label_now.Location = new Point(0, this.Height - label_now.Height);
			Keyboard.ClearFocus();
			timer.Enabled = true;
			label_now.Text = DateTime.Now.ToShortTimeString().ToString();
		}

		private void Button_Start_Click(object sender, EventArgs e)
		{
			FormMain F = new FormMain(this);
			F.Show();
			this.WindowState = FormWindowState.Minimized;
		}
		private void Button_Streak_Click(object sender, EventArgs e)
		{
			FormStreak Fs = new FormStreak(this);
			Fs.Show();
			this.WindowState = FormWindowState.Minimized;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			label_now.Text = DateTime.Now.ToShortTimeString().ToString();
		}

		private void FormStart_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.A)
			{
				FormMain F = new FormMain(this);
				F.Show();
				this.WindowState = FormWindowState.Minimized;
			}
			if(e.KeyCode==Keys.S)
			{
				FormStreak Fs = new FormStreak(this);
				Fs.Show();
				this.WindowState = FormWindowState.Minimized;
			}
			if (e.KeyData == Keys.Escape)
				this.Close();
		}
	}////Class
}//////NameSpace
