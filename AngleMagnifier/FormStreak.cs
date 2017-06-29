using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleMagnifier
{
	public partial class FormStreak : Form
	{
		#region Struct
		public struct MFunction
		{
			public double a, b, c;//ax+by+c=0
			public MFunction(double a, double b, double c)
			{
				this.a = a;
				this.b = b;
				this.c = c;
			}
		}
		public struct A_Point
		{
			public float x, y, x1, y1;
			public A_Point(float x, float y, float x1, float y1)
			{
				this.x = x;
				this.y = y;
				this.x1 = x1;
				this.y1 = y1;
			}
		}
		#endregion
		#region object
		FormStart pF;//For resize super form
		Bitmap IM_Form;//截圖層
		Graphics G;//截圖層
		Bitmap Tmp;//Deep Copy
		Bitmap Largecatch;//Inlarge
		Graphics Glargecatch;//Inlarge
		A_Point a;//Point
		MFunction m;//方程式
		Pen pen, pen1, pen_DL;
		SolidBrush brush;//筆刷
		Rectangle Rec;//Catch size
		#endregion

		int lw;//For Auto Size
		byte count_Pt = 0;//點選順序
		byte count_Line = 0;//角度次序
		bool catched = false;//截圖
		bool inlarged = false;//放大框
		bool magn2x = true;//放大倍數

		public float Pen_width { get; private set; }
		public int RGB_A { get; private set; }

		public FormStreak()
		{
			InitializeComponent();
			this.pF = new FormStart();
		}
		public FormStreak(FormStart pF)
		{
			InitializeComponent();
			this.pF = pF;
		}

		private void FormStreak_Load(object sender, EventArgs e)
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
			FunctionText.Location = p;
			TextView.Location = new Point(0, this.ClientSize.Height - TextView.Height);
			pictureBox.Location = p;

			Rec = new Rectangle(0, 0, lw, lw);//Create Rectangle for catch
			pen1 = new Pen(Color.FromArgb(RGB_A, 0, 255, 0), Pen_width);//Create Pen
			pen = new Pen(Color.FromArgb(RGB_A, 0, 0, 255), Pen_width);//Create pen1
			pen_DL = new Pen(Color.FromArgb((int)(255 * 0.7), 255, 0, 0), 6);//Create pen for draw a Dot
			brush = new SolidBrush(Color.FromArgb(127, 128, 255, 128));//Create Brush draw in dev

			GraphicsPath path = new GraphicsPath();//picturelarge Reshape
			path.AddEllipse(this.picturelarge.ClientRectangle);
			Region reg = new Region(path);
			this.picturelarge.Region = reg;

			IM_Form = new Bitmap((int)w, (int)h);//Catch Screen
			G = Graphics.FromImage(IM_Form);//Catch Screen
			Largecatch = new Bitmap(lw, lw);//Mul box 80,80
			Glargecatch = Graphics.FromImage(Largecatch);//Mul box
		}

		private void FormStreak_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.F:
					#region 截圖事件
					if (catched == false)
					{
						count_Pt = 0;
						count_Line = 1;
						catched = true;
						TextView.Visible = false;

						G.CopyFromScreen(new Point((this.Location.X - PointToClient(this.Location).X),
																				(this.Location.Y - PointToClient(this.Location).Y)),
															new Point(0, 0), new Size(panel.Width, panel.Height));
						this.pictureBox.Image = IM_Form;
						Tmp = IM_Form.Clone(new Rectangle(0, 0, IM_Form.Width, IM_Form.Height), IM_Form.PixelFormat);//Copy
						IntPtr dc = G.GetHdc();
						G.ReleaseHdc(dc);
						TextView.Text = "按D鍵重新擷取  按A鍵使用放大鏡  點選二點取得條數";
						TextView.Visible = true;
						pictureBox.Visible = true;
						panel.Visible = false;
					}
					#endregion
					break;

				case Keys.D:
					#region 清除
					if (inlarged)
					{
						Timer1.Enabled = false;
						Text_x.Visible = false;
						Cursor.Show();
					}
					try
					{
						Tmp.Dispose();
					}
					catch
					{
						MessageBox.Show("按F鍵取得截圖", "Hint", MessageBoxButtons.OK,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					count_Pt = 0;
					count_Line = 1;
					catched = false;
					inlarged = false;//Flag
					FunctionText.Visible = false;
					pictureBox.Visible = false;
					picturelarge.Visible = false;
					pictureBox.Image = null;
					G.Clear(Color.Transparent);
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
			Color[,] colors;//[長度,厚度]
			int ave = 0;//color average
			int colorswidth = 5;
			bool xlonger = false;
			if (e.Button == MouseButtons.Left)
			{
				if (inlarged == true)
				{
					picturelarge.Visible = false;
					Text_x.Visible = false;
					Timer1.Enabled = false;
					TextView.Text = "按D鍵重新擷取  按A鍵使用放大鏡  點選二點取得條數";
					Cursor.Show();
				}
				count_Pt++;
				switch (count_Pt)
				{
					case 1:
						if (inlarged == false)
						{
							a.x = e.X;
							a.y = e.Y;
						}
						else
						{
							a.x = e.X + (lw / 2);//Edit Needs
							a.y = e.Y + (lw / 4);
							inlarged = false;
							Cursor.Position = PointToScreen(new Point((int)a.x, (int)a.y));
						}
						break;
					case 2:
						if (inlarged == false)
						{
							a.x1 = e.X;
							a.y1 = e.Y;
						}
						else
						{
							a.x1 = e.X + (lw / 2);//Edit Needs
							a.y1 = e.Y + (lw / 4);
							inlarged = false;
							Cursor.Position = PointToScreen(new Point((int)a.x1, (int)a.y1));
						}

						pictureBox.Image = IM_Form;
						xlonger = IsXlonger();
						GetFunction();
						FunctionText.Parent = pictureBox;
						FunctionText.Visible = true;
						FunctionText.Text = m.a + "X+(" + m.b + ")Y+(" + m.c + ")=0   " + xlonger.ToString();
						FunctionText.Location = new Point(this.ClientSize.Width - FunctionText.Width, 0);

						#region 取得線區
						if (xlonger)
						{
							if (a.x > a.x1)
							{
								int tmp = (int)a.x;
								a.x = a.x1;
								a.x1 = tmp;
							}
							colors = new Color[(int)(a.x1 - a.x), colorswidth];
							for (int i = (int)a.x; i < a.x1; i++)
							{
								for (int j = -2; j <= 2; j++)
								{
									colors[i - (int)(a.x), j + 2] = IM_Form.GetPixel(i, GetFunctionValue(i, xlonger) + j);
									G.FillRectangle(brush, i, GetFunctionValue(i, xlonger) + j, 1, 1);//畫出擷取線
								}
							}
						}
						else
						{
							if (a.y > a.y1)
							{
								int tmp = (int)a.y;
								a.y = a.y1;
								a.y1 = tmp;
							}
							colors = new Color[(int)(a.y1 - a.y), colorswidth];
							for (int i = (int)a.y; i < a.y1; i++)
							{
								for (int j = -2; j <= 2; j++)
								{
									colors[i - (int)a.y, j + 2] = IM_Form.GetPixel(GetFunctionValue(i, xlonger) + j, i);
									G.FillRectangle(brush, GetFunctionValue(i, xlonger) + j, i, 1, 1);//劃出擷取線
								}
							}
						}
						#endregion
						
						Bitmap ds = new Bitmap(colors.GetLength(0), colors.GetLength(1));//Bitmap for 條數判斷

						Parallel.For(0, colors.GetLength(0), i => //黑白化
						 {
							 for (int j = 0; j < colors.GetLength(1); j++)
							 {
								 int t = Convert.ToInt32(colors[i, j].R * 0.3) + Convert.ToInt32(colors[i, j].G * 0.59) + Convert.ToInt32(colors[i, j].B * 0.11);
								 colors[i, j] = Color.FromArgb(255, t, t, t);
							 }
						 });
						for (int i = 0; i < colors.GetLength(0); i++)//Colors[,] to Bitmap
							for (int j = 0; j < colors.GetLength(1); j++)
							{
								ds.SetPixel(i, j, colors[i, j]);
							}
						//測試存圖
						//ds.Save(@"C:\Users\Apollot403\Desktop\Tmp0.jpg");
						ds = Contrast(ds, 900);
						for(int i=0;i<colors.GetLength(0);i++)//Bitmap to Colors[,]
							for(int j=0;j<colors.GetLength(1);j++)
							{
								colors[i, j] = ds.GetPixel(i, j);
								ave += colors[i, j].R;
							}
						ave /= colors.Length;//像素平均值
						Parallel.For(0, colors.GetLength(0), i =>
						{
							int c = 0;
							for (int j = 0; j < 5; j++)
							{
								if (colors[i, j].R < ave)
									c++;
							}
							if (c >= 3)
								for (int j = 0; j < 5; j++)
								{
									colors[i, j] = Color.FromArgb(255, 0, 0, 0);
								}
							else
								for (int j = 0; j < 5; j++)
								{
									colors[i, j] = Color.FromArgb(255, 255, 255, 255);
								}
						});
						//測試存圖
						//ds.Save(@"C:\Users\Apollot403\Desktop\Tmp1.jpg");
						for (int i = 0; i < colors.GetLength(0); i++)//Colors[,] to Bitmap
							for (int j = 0; j < colors.GetLength(1); j++)
							{
								ds.SetPixel(i, j, colors[i, j]);
							}
						
						//pictureBox.Image = ds;
						//測試存圖
						//ds.Save(@"C:\Users\Apollot403\Desktop\Tmp2.jpg");
						count_Pt = 0;
						count_Line++;
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
					TextView.Text = "按D鍵重新擷取  按A鍵使用放大鏡  點選二點取得條數";
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
				Text_x.Location = new Point(x + (int)(lw * (0.5 + 0.35)), y + (int)(lw * (0.25 + 0.35)));
			}
		}

		private void FormStreak_FormClosing(object sender, FormClosingEventArgs e)
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
		private void FormStreak_Wheel(object sender, MouseEventArgs e)
		{
			if (inlarged)
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

		/// <summary>
		/// 計算方程式
		/// </summary>
		private void GetFunction()
		{
			float tmp = a.x - a.x1;
			float tmp1 = a.y - a.y1;
			m.a = tmp1;
			m.b = -(tmp);
			m.c = -(tmp1 * a.x1) + tmp * a.y1;
		}
		/// <summary>
		/// 截圖像素 位置函數
		/// </summary>
		/// <param name="intex">函數</param>
		/// <param name="xlong">X Y誰長?</param>
		/// <returns></returns>
		private int GetFunctionValue(int intex, bool xlong)
		{
			int ans = 0;
			if (xlong)
			{
				ans = (int)Math.Round((-(m.a * intex + m.c)) / m.b);
			}
			else
			{
				ans = (int)Math.Round((-(m.b * intex + m.c)) / m.a);
			}
			return ans;
		}
		/// <summary>
		/// X Y 長度比較
		/// </summary>
		/// <returns></returns>
		private bool IsXlonger()
		{
			if (Math.Abs(a.x - a.x1) >= Math.Abs(a.y - a.y1))
				return true;
			else
				return false;
		}
		/// <summary>
		/// 高對比
		/// </summary>
		/// <param name="src"></param>
		/// <param name="effectThreshold"> 高對比程度 -100~100</param>
		/// <returns></returns>
		public Bitmap Contrast(Bitmap src, float effectThreshold)
		{
			// 依照 Format24bppRgb 每三個表示一 Pixel 0: 藍 1: 綠 2: 紅
			BitmapData bitmapData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			// 判斷是否在 -100~100
			effectThreshold = effectThreshold < -100 ? -100 : effectThreshold;
			effectThreshold = effectThreshold > 1000 ? 1000 : effectThreshold;
			effectThreshold = (float)((100.0 + effectThreshold) / 100.0);
			effectThreshold *= effectThreshold;
			unsafe
			{
				// 抓住第一個 Pixel 第一個數值
				byte* p = (byte*)(void*)bitmapData.Scan0;

				// 跨步值 - 寬度 *3 可以算出畸零地 之後跳到下一行
				int nOffset = bitmapData.Stride - src.Width * 3;
				for (int y = 0; y < src.Height; y++)
				{
					for (int x = 0; x < src.Width; x++)
					{
						double buffer = 0;
						// 公式  (Red/255)-0.5= 偏離中間值程度
						// ((偏離中間值程度 * 影響範圍)+0.4 ) * 255
						buffer = ((((p[2] / 255.0) - 0.5) * effectThreshold) + 0.5) * 255.0;
						buffer = buffer > 255 ? 255 : buffer;
						buffer = buffer < 0 ? 0 : buffer;
						p[2] = (byte)buffer;

						buffer = ((((p[1] / 255.0) - 0.5) * effectThreshold) + 0.5) * 255.0;
						buffer = buffer > 255 ? 255 : buffer;
						buffer = buffer < 0 ? 0 : buffer;
						p[1] = (byte)buffer;
						buffer = ((((p[0] / 255.0) - 0.5) * effectThreshold) + 0.5) * 255.0;
						buffer = buffer > 255 ? 255 : buffer;
						buffer = buffer < 0 ? 0 : buffer;
						p[0] = (byte)buffer;
						// 跳去下一個 Pixel
						p += 3;
					}
					// 跨越畸零地
					p += nOffset;
				}
			}
			src.UnlockBits(bitmapData);
			return src;
		}
	}////Class
}//////NameSpace
