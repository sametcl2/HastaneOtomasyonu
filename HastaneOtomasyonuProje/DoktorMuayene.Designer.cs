namespace HastaneOtomasyonuProje
{
	partial class DoktorMuayene
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoktorMuayene));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkSalmon;
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(970, 71);
			this.panel1.TabIndex = 43;
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
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(71, 419);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(500, 196);
			this.listView1.TabIndex = 44;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// DoktorMuayene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(970, 692);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "DoktorMuayene";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DoktorMuayene";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ListView listView1;
	}
}