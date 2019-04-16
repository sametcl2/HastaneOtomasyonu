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
		string tc_no;
		public PersonelKayit(string ad, string soyad, string tc_no)
		{
			this.ad = ad;
			this.soyad = soyad;
			this.tc_no = tc_no;
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
			KayitEkleme kayit = new KayitEkleme(ad, soyad, tc_no);
			kayit.Show();
			this.Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			KayitSorgula kayitSorgula = new KayitSorgula(ad, soyad, tc_no);
			kayitSorgula.Show();
			this.Hide();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			PersonelSifre personelSifre = new PersonelSifre(tc_no, ad, soyad);
			personelSifre.Show();
			this.Close();
		}
	}
}
