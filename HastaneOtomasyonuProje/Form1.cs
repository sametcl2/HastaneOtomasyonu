using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonuProje
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void circularButton3_Click(object sender, EventArgs e)
		{
			
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			Personel personel = new Personel();
			personel.Show();
			this.Hide();
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			doktor doctor = new doktor();
			doctor.Show();
			this.Hide();
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			Depo depo = new Depo();
			depo.Show();
			this.Hide();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
