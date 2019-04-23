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
	public partial class DoktorMuayene : Form
	{
		string ad;
		string soyad;
		string bolum;
		public DoktorMuayene(string ad, string soyad, string bolum)
		{
			InitializeComponent();
			this.ad = ad;
			this.soyad = soyad;
			this.bolum = bolum;
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			DoktorAnaEkran doktorAnaEkran = new DoktorAnaEkran(ad, soyad, bolum);
			doktorAnaEkran.Show();
			this.Hide();
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}