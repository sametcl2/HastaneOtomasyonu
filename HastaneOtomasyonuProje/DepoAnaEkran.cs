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
	public partial class DepoAnaEkran : Form
	{
		string ad;
		string soyad;
		string tc_no;
		public DepoAnaEkran(string ad, string soyad, string tc_no)
		{
			InitializeComponent();
			this.ad = ad;
			this.soyad = soyad;
			this.tc_no = tc_no;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Depo depo = new Depo();
			depo.Show();
			this.Hide();
		}

		private void DepoAnaEkran_Load(object sender, EventArgs e)
		{
			label1.Text = ad + " " + soyad;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DepoSifre depoSifre = new DepoSifre(ad, soyad, tc_no);
			depoSifre.Show();
			this.Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			StokTakibi stokTakibi = new StokTakibi(ad, soyad,tc_no);
			stokTakibi.Show();
			this.Hide();
		}
	}
}
