using System.Drawing;

namespace AngleMagnifier
{
	partial class FormMain
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.TextView = new System.Windows.Forms.Label();
			this.panel = new System.Windows.Forms.Panel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.TextAngle = new System.Windows.Forms.Label();
			this.picturelarge = new System.Windows.Forms.PictureBox();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.TextAngle1 = new System.Windows.Forms.Label();
			this.Text_x = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picturelarge)).BeginInit();
			this.SuspendLayout();
			// 
			// TextView
			// 
			this.TextView.AutoSize = true;
			this.TextView.BackColor = System.Drawing.Color.Gainsboro;
			this.TextView.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.TextView.ForeColor = System.Drawing.Color.Blue;
			this.TextView.Location = new System.Drawing.Point(154, 12);
			this.TextView.Name = "TextView";
			this.TextView.Size = new System.Drawing.Size(19, 30);
			this.TextView.TabIndex = 0;
			this.TextView.Text = ".";
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.Color.Silver;
			this.panel.Location = new System.Drawing.Point(12, 12);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(100, 100);
			this.panel.TabIndex = 1;
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(12, 131);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(100, 50);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			this.pictureBox.Visible = false;
			this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Click);
			// 
			// TextAngle
			// 
			this.TextAngle.AutoSize = true;
			this.TextAngle.BackColor = System.Drawing.Color.Gainsboro;
			this.TextAngle.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.TextAngle.ForeColor = System.Drawing.Color.Blue;
			this.TextAngle.Location = new System.Drawing.Point(179, 12);
			this.TextAngle.Name = "TextAngle";
			this.TextAngle.Size = new System.Drawing.Size(24, 40);
			this.TextAngle.TabIndex = 3;
			this.TextAngle.Text = ".";
			this.TextAngle.Visible = false;
			// 
			// picturelarge
			// 
			this.picturelarge.Location = new System.Drawing.Point(12, 197);
			this.picturelarge.Name = "picturelarge";
			this.picturelarge.Size = new System.Drawing.Size(100, 50);
			this.picturelarge.TabIndex = 4;
			this.picturelarge.TabStop = false;
			this.picturelarge.Visible = false;
			// 
			// Timer1
			// 
			this.Timer1.Interval = 20;
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// TextAngle1
			// 
			this.TextAngle1.AutoSize = true;
			this.TextAngle1.BackColor = System.Drawing.Color.Gainsboro;
			this.TextAngle1.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.TextAngle1.ForeColor = System.Drawing.Color.LimeGreen;
			this.TextAngle1.Location = new System.Drawing.Point(209, 12);
			this.TextAngle1.Name = "TextAngle1";
			this.TextAngle1.Size = new System.Drawing.Size(24, 40);
			this.TextAngle1.TabIndex = 5;
			this.TextAngle1.Text = ".";
			this.TextAngle1.Visible = false;
			// 
			// Text_x
			// 
			this.Text_x.AutoSize = true;
			this.Text_x.BackColor = System.Drawing.Color.Transparent;
			this.Text_x.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.Text_x.ForeColor = System.Drawing.Color.Orange;
			this.Text_x.Location = new System.Drawing.Point(154, 58);
			this.Text_x.Name = "Text_x";
			this.Text_x.Size = new System.Drawing.Size(19, 30);
			this.Text_x.TabIndex = 6;
			this.Text_x.Text = ".";
			this.Text_x.Visible = false;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1064, 676);
			this.Controls.Add(this.Text_x);
			this.Controls.Add(this.TextAngle1);
			this.Controls.Add(this.picturelarge);
			this.Controls.Add(this.TextAngle);
			this.Controls.Add(this.TextView);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.Text = "Form1";
			this.TransparencyKey = System.Drawing.Color.Silver;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_Closing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FormMain_Wheel);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picturelarge)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label TextView;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label TextAngle;
		private System.Windows.Forms.PictureBox picturelarge;
		private System.Windows.Forms.Timer Timer1;
		private System.Windows.Forms.Label TextAngle1;
		private System.Windows.Forms.Label Text_x;
	}
}

