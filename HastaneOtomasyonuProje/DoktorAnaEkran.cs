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

		private void DoktorAnaEkran_Load(object sender, EventArgs e)
		{

		}
	}
}
