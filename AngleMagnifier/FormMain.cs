using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleMagnifier
{
	public partial class FormMain : Form
	{
		#region Struct
		public struct A_Point
		{
			public int x, y;
			public A_Point(int x,int y)
			{
				this.x = x;
				this.y = y;
			}
		}
		#endregion
		#region object
		FormStart pF;
		Image IM_Form;//截圖層
		Graphics G;//截圖層
		Image Largecatch;//Inlarge
		Graphics Glargecatch;//Inlarge
		Image Large;
		Graphics Glarge;
		A_Point Pa1;
		A_Point Pb1;
		A_Point Pcom1;
		Pen pen,pen1;
		#endregion

		byte count_Pt =0;//點選順序
		byte count_Angle = 0;//角度次序
		bool catched = false;//截圖
		bool inlarged = false;//放大框
		float multiple = 2;//Inlarge multiple
		public float Pen_width { get; private set; }
		public int RGB_A { get; private set; }

		public FormMain()
		{
			InitializeComponent();
			this.pF = new FormStart();
		}
		public FormMain(FormStart pF)
		{
			InitializeComponent();
			this.pF = pF;
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			float w = (float)this.ClientSize.Width;
			float h = (float)this.ClientSize.Height;
			Point p = new Point(0, 0);
			this.Text = "AngleMagnifier";
			TextView.Text = "按F鍵擷取畫面";

			Pen_width = 4;
			RGB_A = 128;

			panel.Visible = true;
			TextView.Visible = true;

			panel.Size = new Size((int)w, (int)h);
			pictureBox.Size = new Size((int)w,(int)h);
			picturelarge.Size = new Size(160, 160);

			panel.Location = p;
			TextView.Location = new Point(0,this.ClientSize.Height-TextView.Height);
			TextAngle.Location = p;
			TextAngle1.Location = new Point(100, 0);
			pictureBox.Location = p;

			pen = new Pen(Color.FromArgb(RGB_A, 0, 255, 0), Pen_width);//Create Pen
			pen1 = new Pen(Color.FromArgb(RGB_A, 0, 0, 255), Pen_width);//Create pen1
			//GraphicsPath path = new GraphicsPath();//picturelarge Reshape
			//path.AddEllipse(this.picturelarge.ClientRectangle);
			//Region reg = new Region(path);
			//this.picturelarge.Region = reg;

			IM_Form = new Bitmap((int)w, (int)h);//Catch Screen
			G = Graphics.FromImage(IM_Form);//Catch Screen
			Largecatch = new Bitmap((int)(160/multiple), (int)(160/multiple));//Mul box
			Glargecatch = Graphics.FromImage(Largecatch);//Mul box
			Large = new Bitmap(160, 160);
			Glarge = Graphics.FromImage(Large);
			
		}

		private void FormMain_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.F:
					#region 截圖事件
						count_Pt = 0;
						count_Angle = 1;
						catched = true;
						TextView.Visible = false;
						TextAngle.Visible = false;

						G.CopyFromScreen(new Point((Location.X + Size.Width - ClientSize.Width - 8),//Get form screen
																				(Location.Y + Size.Height - ClientSize.Height - 8))
																	, new Point(0, 0), new Size(panel.Width, panel.Height));
						this.pictureBox.Image = IM_Form;
						try
						{
							IM_Form.Save(@".\Tmp.jpg");
						}
						catch (System.Runtime.InteropServices.ExternalException) {; }

						IntPtr dc = G.GetHdc();
						G.ReleaseHdc(dc);
						TextView.Text = "按D鍵重新擷取  點選三點計算角度";
						TextView.Location = new Point(0, (this.ClientSize.Height - TextView.Height));
						TextView.Visible = true;
						pictureBox.Visible = true;
						panel.Visible = false;
					#endregion 
					break;

				case Keys.D:
					count_Pt = 0;
					count_Angle = 1;
					catched = false;
					inlarged = false;//Flag
					this.pictureBox.Visible = false;
					this.picturelarge.Visible = false;
					this.picturelarge.Image = null;
					this.pictureBox.Image = null;
					G.Clear(Color.Transparent);
					TextAngle.Visible = false;
					TextAngle1.Visible = false;
					TextView.Text = "按F鍵擷取畫面";
					TextView.Location = new Point(0, this.ClientSize.Height - TextView.Height);
					panel.Visible = true;
					Cursor.Show();
					timer1.Enabled = false;
					break;

				case Keys.A:
					if(catched==true)
					{
						inlarged = true;
						timer1.Enabled = true;
						//TextView.Visible = true;
						//Cursor.Hide();
					}
					break;

				case Keys.Escape:
					this.Close();
					break;
			}
		}

		private void pictureBox_Click(object sender, MouseEventArgs e)
		{
			if (count_Angle == 1)
			{
				count_Pt++;
				switch (count_Pt)
				{
					case 1:
						Pa1.x = e.X;
						Pa1.y = e.Y;
						break;
					case 2:
						Pcom1.x = e.X;
						Pcom1.y = e.Y;
						G.DrawLine(pen1, Pa1.x, Pa1.y, Pcom1.x, Pcom1.y);
						IntPtr dc = G.GetHdc();
						G.ReleaseHdc(dc);
						pictureBox.Image = IM_Form;
						break;
					case 3:
						Pb1.x = e.X;
						Pb1.y = e.Y;
						G.DrawLine(pen1, Pcom1.x, Pcom1.y, Pb1.x, Pb1.y);
						dc = G.GetHdc();
						G.ReleaseHdc(dc);
						this.pictureBox.Image = IM_Form;
						count_Pt = 0;
						TextAngle.Visible = true;
						TextAngle.Text =Degree().ToString("f1");
						count_Angle++;
						break;
				}
			}
			else if(count_Angle==2)
			{
				count_Pt++;
				switch (count_Pt)
				{
					case 1:
						Pa1.x = e.X;
						Pa1.y = e.Y;
						break;
					case 2:
						Pcom1.x = e.X;
						Pcom1.y = e.Y;
						G.DrawLine(pen, Pa1.x, Pa1.y, Pcom1.x, Pcom1.y);
						IntPtr dc = G.GetHdc();
						G.ReleaseHdc(dc);
						pictureBox.Image = IM_Form;
						break;
					case 3:
						Pb1.x = e.X;
						Pb1.y = e.Y;
						G.DrawLine(pen, Pcom1.x, Pcom1.y, Pb1.x, Pb1.y);
						dc = G.GetHdc();
						G.ReleaseHdc(dc);
						this.pictureBox.Image = IM_Form;
						count_Pt = 0;
						TextAngle1.Visible = true;
						TextAngle1.Text = Degree().ToString("f1");
						count_Angle++;
						break;
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if(inlarged)
			{
				picturelarge.Visible = false;
				Task.Delay(100);
				picturelarge.Location = this.PointToClient(Cursor.Position);
				//Glargecatch.CopyFromScreen(Cursor.Position.X,Cursor.Position.Y, 0, 0, Largecatch.Size);
				//Glarge.DrawImage(Largecatch, 0, 0, 160, 160);
				picturelarge.Visible = true;
				//picturelarge.Image = Large;
				//IntPtr dc = G.GetHdc();
				//G.ReleaseHdc(dc);
			}
		}
		
		private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				pF.WindowState = FormWindowState.Normal;
			}
			catch {; }
		}

		double Degree()
		{
			double A=0f, B=0f;
			double AB = 0f;
			double degree=0.0f;
			A = Math.Pow((Pa1.x - Pcom1.x), 2.0)+Math.Pow((Pa1.y-Pcom1.y),2.0);
			A=Math.Pow(A,0.5);///A距
			B = Math.Pow((Pb1.x - Pcom1.x), 2.0) + Math.Pow((Pb1.y - Pcom1.y), 2.0);
			B = Math.Pow(B, 0.5);////距
			AB = ((Pa1.x-Pcom1.x) * (Pb1.x-Pcom1.x))+((Pa1.y-Pcom1.y)*(Pb1.y-Pcom1.y));
			degree = Math.Acos(AB / (A * B));
			degree = degree * 180 / Math.PI;
			return degree;
		}

	}/////CLASS
}///////NAMESPACE
