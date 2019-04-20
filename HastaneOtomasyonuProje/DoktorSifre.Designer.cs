namespace HastaneOtomasyonuProje
{
	partial class DoktorSifre
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoktorSifre));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.IndianRed;
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(994, 71);
			this.panel1.TabIndex = 45;
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
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(270, 207);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(142, 33);
			this.label1.TabIndex = 46;
			this.label1.Text = "Yeni Şifre";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(270, 291);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 33);
			this.label2.TabIndex = 47;
			this.label2.Text = "Tekrar";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.textBox1.Location = new System.Drawing.Point(510, 126);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(228, 30);
			this.textBox1.TabIndex = 49;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(490, 243);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(260, 17);
			this.label3.TabIndex = 50;
			this.label3.Text = "( En az 5 en fazla 15 karakter olmalıdır )";
			// 
			// textBox2
			// 
			this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.textBox2.Location = new System.Drawing.Point(510, 210);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(228, 30);
			this.textBox2.TabIndex = 51;
			this.textBox2.UseSystemPasswordChar = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.checkBox1.Location = new System.Drawing.Point(276, 380);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(450, 33);
			this.checkBox1.TabIndex = 52;
			this.checkBox1.Text = "Şifremin değiştirilmesini onaylıyorum";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.IndianRed;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button1.Location = new System.Drawing.Point(396, 464);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(188, 87);
			this.button1.TabIndex = 53;
			this.button1.Text = "Onayla";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(270, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(215, 33);
			this.label4.TabIndex = 54;
			this.label4.Text = "Mevcut Şifreniz";
			// 
			// textBox3
			// 
			this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.textBox3.Location = new System.Drawing.Point(510, 291);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(228, 30);
			this.textBox3.TabIndex = 55;
			this.textBox3.UseSystemPasswordChar = true;
			// 
			// DoktorSifre
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(994, 604);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "DoktorSifre";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DoktorSifre";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
	}
}