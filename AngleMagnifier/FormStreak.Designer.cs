namespace AngleMagnifier
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
			this.TextView = new System.Windows.Forms.Label();
			this.panel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// TextView
			// 
			this.TextView.AutoSize = true;
			this.TextView.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.TextView.ForeColor = System.Drawing.Color.Blue;
			this.TextView.Location = new System.Drawing.Point(188, 9);
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
			this.panel.Size = new System.Drawing.Size(132, 67);
			this.panel.TabIndex = 1;
			// 
			// FormStreak
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1064, 676);
			this.Controls.Add(this.TextView);
			this.Controls.Add(this.panel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormStreak";
			this.Text = "FormStreak";
			this.TransparencyKey = System.Drawing.Color.Silver;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStreak_FormClosing);
			this.Load += new System.EventHandler(this.FormStreak_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormStreak_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label TextView;
		private System.Windows.Forms.Panel panel;
	}
}