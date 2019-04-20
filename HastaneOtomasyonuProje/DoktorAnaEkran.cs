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
	public partial class DoktorAnaEkran : Form
	{
		string ad, soyad, bolum;

		public DoktorAnaEkran(string ad, string soyad, string bolum)
		{
			InitializeComponent();
			this.ad = ad;
			this.soyad = soyad;
			this.bolum = bolum;
			label1.Text = ad + " " + soyad + ", " + bolum;

		}

		private void button4_Click(object sender, EventArgs e)
		{
			DoktorSifre doktorSifre = new DoktorSifre(ad, soyad, bolum);
			doktorSifre.Show();
			this.Hide();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			doktor doktor = new doktor();
			doktor.Show();
			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DoktorRandevu doktorRandevu = new DoktorRandevu(ad, soyad, bolum);
			doktorRandevu.Show();
			this.Hide();
		}

		private void DoktorAnaEkran_Load(object sender, EventArgs e)
		{

		}
	}
}
