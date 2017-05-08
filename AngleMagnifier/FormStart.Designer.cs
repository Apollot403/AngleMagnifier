namespace AngleMagnifier
{
	partial class FormStart
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
			this.label_now = new System.Windows.Forms.Label();
			this.button_Start = new System.Windows.Forms.Button();
			this.button_Streak = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.button_Set = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label_now
			// 
			this.label_now.AutoSize = true;
			this.label_now.BackColor = System.Drawing.Color.Transparent;
			this.label_now.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label_now.Location = new System.Drawing.Point(-5, 169);
			this.label_now.Name = "label_now";
			this.label_now.Size = new System.Drawing.Size(112, 27);
			this.label_now.TabIndex = 0;
			this.label_now.Text = "上午 11:02";
			// 
			// button_Start
			// 
			this.button_Start.BackColor = System.Drawing.Color.Transparent;
			this.button_Start.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button_Start.Location = new System.Drawing.Point(340, 72);
			this.button_Start.Name = "button_Start";
			this.button_Start.Size = new System.Drawing.Size(75, 28);
			this.button_Start.TabIndex = 1;
			this.button_Start.Text = "Angle";
			this.button_Start.UseVisualStyleBackColor = false;
			this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
			// 
			// button_Streak
			// 
			this.button_Streak.BackColor = System.Drawing.Color.Transparent;
			this.button_Streak.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button_Streak.Location = new System.Drawing.Point(340, 106);
			this.button_Streak.Name = "button_Streak";
			this.button_Streak.Size = new System.Drawing.Size(75, 28);
			this.button_Streak.TabIndex = 2;
			this.button_Streak.Text = "Streak";
			this.button_Streak.UseVisualStyleBackColor = false;
			this.button_Streak.Click += new System.EventHandler(this.button_Streak_Click);
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = global::AngleMagnifier.Properties.Resources.d974148;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel1.Controls.Add(this.button_Set);
			this.panel1.Controls.Add(this.label_now);
			this.panel1.Controls.Add(this.button_Streak);
			this.panel1.Controls.Add(this.button_Start);
			this.panel1.Location = new System.Drawing.Point(0, -45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(688, 225);
			this.panel1.TabIndex = 3;
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// button_Set
			// 
			this.button_Set.BackColor = System.Drawing.Color.Transparent;
			this.button_Set.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button_Set.Location = new System.Drawing.Point(340, 140);
			this.button_Set.Name = "button_Set";
			this.button_Set.Size = new System.Drawing.Size(75, 28);
			this.button_Set.TabIndex = 3;
			this.button_Set.Text = "設定";
			this.button_Set.UseVisualStyleBackColor = false;
			// 
			// FormStart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(484, 151);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormStart";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.FormStart_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormStart_KeyDown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label_now;
		private System.Windows.Forms.Button button_Start;
		private System.Windows.Forms.Button button_Streak;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button button_Set;
	}
}