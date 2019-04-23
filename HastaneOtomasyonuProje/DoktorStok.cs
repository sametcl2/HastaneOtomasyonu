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
	public partial class DoktorStok : Form
	{
		string ad;
		string soyad;
		string bolum;
		public DoktorStok(string ad, string soyad, string bolum)
		{
			InitializeComponent();
			this.ad = ad;
			this.soyad = soyad;
			this.bolum = bolum;
		}
		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=ilaclar;" +
					"Integrated Security=true");
		private void DoktorStok_Load(object sender, EventArgs e)
		{
			sqlConnection.Open();
			label1.Text = bolum + " İlaç Stokları";	
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ilaclar WHERE klinik=@klinik", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@klinik", bolum);
			SqlDataReader reader = sqlCommand.ExecuteReader();
			while (reader.Read())
			{
				ListViewItem item = new ListViewItem();
				item.Text = reader["ilac_ad"].ToString();
				item.SubItems.Add(reader["miktar"].ToString());
				listView1.Items.Add(item);
			}
			sqlConnection.Close();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			DoktorAnaEkran doktorAnaEkran = new DoktorAnaEkran(ad, soyad, bolum);
			doktorAnaEkran.Show();
			this.Hide();
		}
	}
}
