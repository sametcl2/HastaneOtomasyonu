using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneOtomasyonuProje
{
	public partial class PersonelKayit : Form
	{
		string ad;
		string soyad;
		public PersonelKayit(string ad, string soyad)
		{
			this.ad = ad;
			this.soyad = soyad;
			InitializeComponent();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Personel personel = new Personel();
			personel.Show();
			this.Hide();
		}
		private void PersonelKayit_Load(object sender, EventArgs e)
		{
			label1.Text = ad + " " + soyad;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			KayitEkleme kayit = new KayitEkleme(ad, soyad);
			kayit.Show();
			this.Hide();
		}
	}
}
