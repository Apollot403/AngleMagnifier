using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AngleMagnifier
{
	public partial class FormMain : Form
	{
		#region Struct
		public struct A_Point
		{
			public int x, y;
			public A_Point(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}
		#endregion
		#region object
		FormStart pF;
		Bitmap IM_Form;//截圖層
		Graphics G;//截圖層
		Bitmap Tmp;
		Bitmap Largecatch;//Inlarge
		Graphics Glargecatch;//Inlarge
		A_Point Pa1;
		A_Point Pb1;
		A_Point Pcom1;
		Pen pen, pen1, pen_DL;
		Rectangle Rec;
		#endregion

		int lw;//For Auto Size
		byte count_Pt = 0;//點選順序
		byte count_Angle = 0;//角度次序
		bool catched = false;//截圖
		bool inlarged = false;//放大框
		bool magn2x = true;//放大倍數

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
			this.Size = new Size((int)(SystemInformation.PrimaryMonitorSize.Width * 0.9),
												(int)(SystemInformation.PrimaryMonitorSize.Height * 0.9));
			int w = this.ClientSize.Width;
			int h = this.ClientSize.Height;
			lw = (int)(h * 0.3);
			switch (lw % 4)
			{
				case 1:
					lw = lw + 3;
					break;
				case 2:
					lw = lw + 2;
					break;
				case 3:
					lw = lw + 1;
					break;
				default:
					break;
			}//Mod 4
			 //MessageBox.Show(lw.ToString());
			Point p = new Point(0, 0);
			this.Text = "AngleMagnifier";
			TextView.Text = "按F鍵擷取畫面";

			Pen_width = 4;//筆刷厚度
			RGB_A = 128;//透明度

			panel.Visible = true;
			TextView.Visible = true;

			panel.Size = new Size((int)w, (int)h);
			pictureBox.Size = new Size((int)w, (int)h);
			picturelarge.Size = new Size(lw, lw);//Edit Needs

			panel.Location = p;
			TextView.Location = new Point(0, this.ClientSize.Height - TextView.Height);
			pictureBox.Location = p;

			Rec = new Rectangle(0, 0, lw, lw);//Create Rectangle for catch
			pen1 = new Pen(Color.FromArgb(RGB_A, 0, 255, 0), Pen_width);//Create Pen
			pen = new Pen(Color.FromArgb(RGB_A, 0, 0, 255), Pen_width);//Create pen1
			pen_DL = new Pen(Color.FromArgb((int)(255 * 0.7), 255, 0, 0), 6);//Create pen for draw a Dot

			GraphicsPath path = new GraphicsPath();//picturelarge Reshape
			path.AddEllipse(this.picturelarge.ClientRectangle);
			Region reg = new Region(path);
			this.picturelarge.Region = reg;

			IM_Form = new Bitmap((int)w, (int)h);//Catch Screen
			G = Graphics.FromImage(IM_Form);//Catch Screen
			Largecatch = new Bitmap(lw, lw);//Mul box 80,80
			Glargecatch = Graphics.FromImage(Largecatch);//Mul box
		}

		private void FormMain_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.F:
					#region 截圖事件
					if (catched == false)
					{
						count_Pt = 0;
						count_Angle = 1;
						catched = true;
						TextView.Visible = false;
						TextAngle.Visible = false;

						G.CopyFromScreen(new Point((this.Location.X - PointToClient(this.Location).X),
																				(this.Location.Y - PointToClient(this.Location).Y)),
															new Point(0, 0), new Size(panel.Width, panel.Height));
						this.pictureBox.Image = IM_Form;
						Tmp = IM_Form.Clone(new Rectangle(0, 0, IM_Form.Width, IM_Form.Height), IM_Form.PixelFormat);//Copy
						IntPtr dc = G.GetHdc();
						G.ReleaseHdc(dc);
						TextView.Text = "按D鍵重新擷取  按A鍵使用放大鏡  點選三點計算角度";
						TextView.Visible = true;
						pictureBox.Visible = true;
						panel.Visible = false;
					}
					#endregion
					break;//Try Catch function unsccess

				case Keys.D:
					#region 清除
					if (inlarged)
					{
						Timer1.Enabled = false;
						Text_x.Visible = false;
						Cursor.Show();
					}
					count_Pt = 0;
					count_Angle = 1;
					catched = false;
					inlarged = false;//Flag
					pictureBox.Visible = false;
					picturelarge.Visible = false;
					pictureBox.Image = null;
					G.Clear(Color.Transparent);
					TextAngle.Visible = false;
					TextAngle1.Visible = false;
					TextView.Text = "按F鍵擷取畫面";
					panel.Visible = true;
					Timer1.Enabled = false;
					#endregion
					break;

				case Keys.A:
					if (catched == true)
					{
						Cursor.Position = new Point(Cursor.Position.X - (lw / 2), Cursor.Position.Y - (lw / 4));
						magn2x = true;
						inlarged = true;
						Timer1.Enabled = true;
						picturelarge.Visible = true;
						Text_x.Visible = true;
						TextView.Text = "點左鍵選取點   點右鍵可取消放大鏡";
						Text_x.Text = "X2";
						Text_x.Parent = pictureBox;
						Timer1.Enabled = true;
						Cursor.Hide();
					}
					break;

				case Keys.Escape:
					this.Close();
					break;
			}
		}

		private void PictureBox_Click(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (inlarged == true)
				{
					picturelarge.Visible = false;
					Text_x.Visible = false;
					Timer1.Enabled = false;
					TextView.Text = "按D鍵重新擷取  按A鍵使用放大鏡  點選三點計算角度";
					Cursor.Show();
				}
				count_Pt++;
				switch (count_Pt)
				{
					case 1:
						if (inlarged == false)
						{
							Pa1.x = e.X;
							Pa1.y = e.Y;
						}
						else
						{
							Pa1.x = e.X + (lw / 2);//Edit Needs
							Pa1.y = e.Y + (lw / 4);
							inlarged = false;
							Cursor.Position = PointToScreen(new Point(Pa1.x, Pa1.y));
						}
						break;
					case 2:
						if (inlarged == false)
						{
							Pcom1.x = e.X;
							Pcom1.y = e.Y;
						}
						else
						{
							Pcom1.x = e.X + (lw / 2);//Edit Needs
							Pcom1.y = e.Y + (lw / 4);
							inlarged = false;
							Cursor.Position = PointToScreen(new Point(Pcom1.x, Pcom1.y));
						}
						if (count_Angle == 1)
							G.DrawLine(pen, Pa1.x, Pa1.y, Pcom1.x, Pcom1.y);
						else if (count_Angle == 2)
							G.DrawLine(pen1, Pa1.x, Pa1.y, Pcom1.x, Pcom1.y);
						IntPtr dc = G.GetHdc();
						G.ReleaseHdc(dc);
						pictureBox.Image = IM_Form;
						break;
					case 3:
						if (inlarged == false)
						{
							Pb1.x = e.X;
							Pb1.y = e.Y;
						}
						else
						{
							Pb1.x = e.X + (lw / 2);//Edit Needs
							Pb1.y = e.Y + (lw / 4);
							inlarged = false;
							Cursor.Position = PointToScreen(new Point(Pb1.x, Pb1.y));
						}
						if (count_Angle == 1)
							G.DrawLine(pen, Pcom1.x, Pcom1.y, Pb1.x, Pb1.y);
						else if (count_Angle == 2)
							G.DrawLine(pen1, Pcom1.x, Pcom1.y, Pb1.x, Pb1.y);
						dc = G.GetHdc();
						G.ReleaseHdc(dc);
						this.pictureBox.Image = IM_Form;
						count_Pt = 0;
						if (count_Angle == 1)
						{
							TextAngle.Visible = true;
							TextAngle.Text = Degree().ToString("f1");
							TextAngle.Location = new Point(Pb1.x+5,Pb1.y+3);
						}
						else if (count_Angle == 2)
						{
							TextAngle1.Visible = true;
							TextAngle1.Text = Degree().ToString("f1");
							if (Distance(Pb1.x,TextAngle.Location.X)<20||Distance(Pb1.y,TextAngle.Location.Y)<20)
								TextAngle1.Location = new Point(TextAngle.Location.X, TextAngle.Location.Y - TextAngle1.Height-5);
							else
								TextAngle1.Location = new Point(Pb1.x+5, Pb1.y+3);
						}
						count_Angle++;
						break;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				if (inlarged == true)
				{
					picturelarge.Visible = false;
					Text_x.Visible = false;
					Timer1.Enabled = false;
					TextView.Text = "按D鍵重新擷取  按A鍵使用放大鏡  點選三點計算角度";
					inlarged = false;
					Cursor.Show();
				}
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			int x = PointToClient(Cursor.Position).X;
			int y = PointToClient(Cursor.Position).Y;
			if (inlarged)
			{
				if (magn2x)
				{
					Glargecatch.DrawImage(Tmp, Rec, x + (lw / 4), y, (lw / 2), (lw / 2), GraphicsUnit.Pixel);//Edit Needs
					Glargecatch.DrawLine(pen_DL, (lw / 2) - 3, (lw / 2), (lw / 2) + 3, (lw / 2));
				}
				else
				{
					Glargecatch.DrawImage(Tmp, Rec, x + (lw / 4) + (lw / 8), y + (lw / 8), (lw / 4), (lw / 4), GraphicsUnit.Pixel);//Edit Needs
					Glargecatch.DrawLine(pen_DL, (lw / 2) - 3, (lw / 2), (lw / 2) + 3, (lw / 2));
				}
				picturelarge.Location = new Point(x, y - (lw / 4));
				picturelarge.Image = Largecatch;
				IntPtr dc = G.GetHdc();
				G.ReleaseHdc(dc);
				Text_x.Location = new Point(x + (int)(lw*(0.5+0.35)), y + (int)(lw * (0.25+0.35)));
			}
		}
		private void FormMain_Wheel(object sender,MouseEventArgs e)
		{
			if(inlarged)
			{
				if (e.Delta > 0)
				{
					magn2x = false;
					Text_x.Text = "X4";
				}
				else if (e.Delta < 0)
				{
					magn2x = true;
					Text_x.Text = "X2";
				}
			}
		}
		private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				pF.WindowState = FormWindowState.Normal;
			}
			catch
			{
				MessageBox.Show("內部錯誤\n請重新開啟程式");
			}
		}
		private double Degree()
		{
			double A = 0f, B = 0f;
			double AB = 0f;
			double degree = 0.0f;
			A = Math.Pow((Pa1.x - Pcom1.x), 2.0) + Math.Pow((Pa1.y - Pcom1.y), 2.0);
			A = Math.Pow(A, 0.5);///A距
			B = Math.Pow((Pb1.x - Pcom1.x), 2.0) + Math.Pow((Pb1.y - Pcom1.y), 2.0);
			B = Math.Pow(B, 0.5);///B距
			AB = ((Pa1.x - Pcom1.x) * (Pb1.x - Pcom1.x)) + ((Pa1.y - Pcom1.y) * (Pb1.y - Pcom1.y));
			degree = Math.Acos(AB / (A * B));
			degree = degree * 180 / Math.PI;
			return degree;
		}
		private int Distance(int x1,int x2)
		{
			return Math.Abs(x1 - x2);
		}
	}/////CLASS
}///////NAMESPACE
