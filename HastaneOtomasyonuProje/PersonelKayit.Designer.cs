﻿namespace HastaneOtomasyonuProje
{
	partial class PersonelKayit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelKayit));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Teal;
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1000, 71);
			this.panel1.TabIndex = 41;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(3, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(79, 65);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(41, 672);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 31);
			this.label1.TabIndex = 42;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Silver;
			this.button1.Location = new System.Drawing.Point(116, 203);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(211, 94);
			this.button1.TabIndex = 43;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Silver;
			this.button2.Location = new System.Drawing.Point(630, 203);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(211, 94);
			this.button2.TabIndex = 44;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Silver;
			this.button3.Location = new System.Drawing.Point(372, 388);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(211, 94);
			this.button3.TabIndex = 45;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = false;
			// 
			// PersonelKayit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1000, 768);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "PersonelKayit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PersonelKayit";
			this.Load += new System.EventHandler(this.PersonelKayit_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}