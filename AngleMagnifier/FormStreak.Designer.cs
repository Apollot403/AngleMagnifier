﻿namespace AngleMagnifier
{
	partial class FormStreak
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStreak));
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.Text_x = new System.Windows.Forms.Label();
			this.picturelarge = new System.Windows.Forms.PictureBox();
			this.TextView = new System.Windows.Forms.Label();
			this.panel = new System.Windows.Forms.Panel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.FunctionText = new System.Windows.Forms.Label();
			this.Textshow = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picturelarge)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// Timer1
			// 
			this.Timer1.Interval = 20;
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
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
			this.Text_x.TabIndex = 13;
			this.Text_x.Text = ".";
			this.Text_x.Visible = false;
			// 
			// picturelarge
			// 
			this.picturelarge.Location = new System.Drawing.Point(12, 197);
			this.picturelarge.Name = "picturelarge";
			this.picturelarge.Size = new System.Drawing.Size(100, 50);
			this.picturelarge.TabIndex = 11;
			this.picturelarge.TabStop = false;
			this.picturelarge.Visible = false;
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
			this.TextView.TabIndex = 7;
			this.TextView.Text = ".";
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.Color.Maroon;
			this.panel.Location = new System.Drawing.Point(31, 40);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(66, 30);
			this.panel.TabIndex = 8;
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(12, 131);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(100, 50);
			this.pictureBox.TabIndex = 9;
			this.pictureBox.TabStop = false;
			this.pictureBox.Visible = false;
			this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Click);
			// 
			// FunctionText
			// 
			this.FunctionText.AutoSize = true;
			this.FunctionText.BackColor = System.Drawing.Color.Transparent;
			this.FunctionText.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.FunctionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.FunctionText.Location = new System.Drawing.Point(241, 12);
			this.FunctionText.Name = "FunctionText";
			this.FunctionText.Size = new System.Drawing.Size(11, 18);
			this.FunctionText.TabIndex = 14;
			this.FunctionText.Text = ".";
			this.FunctionText.Visible = false;
			// 
			// Textshow
			// 
			this.Textshow.AutoSize = true;
			this.Textshow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
			this.Textshow.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.Textshow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Textshow.Location = new System.Drawing.Point(0, 0);
			this.Textshow.Name = "Textshow";
			this.Textshow.Size = new System.Drawing.Size(24, 40);
			this.Textshow.TabIndex = 15;
			this.Textshow.Text = ".";
			this.Textshow.Visible = false;
			this.Textshow.Click += new System.EventHandler(this.Textshow_Click);
			// 
			// FormStreak
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1064, 676);
			this.Controls.Add(this.Textshow);
			this.Controls.Add(this.FunctionText);
			this.Controls.Add(this.Text_x);
			this.Controls.Add(this.picturelarge);
			this.Controls.Add(this.TextView);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormStreak";
			this.Text = "FormStreak";
			this.TransparencyKey = System.Drawing.Color.Maroon;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStreak_FormClosing);
			this.Load += new System.EventHandler(this.FormStreak_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormStreak_KeyDown);
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FormStreak_Wheel);
			((System.ComponentModel.ISupportInitialize)(this.picturelarge)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer Timer1;
		private System.Windows.Forms.Label Text_x;
		private System.Windows.Forms.PictureBox picturelarge;
		private System.Windows.Forms.Label TextView;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label FunctionText;
		private System.Windows.Forms.Label Textshow;
	}
}