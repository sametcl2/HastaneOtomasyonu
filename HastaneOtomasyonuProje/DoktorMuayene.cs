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
	public partial class DoktorMuayene : Form
	{
		string ad;
		string soyad;
		string bolum;
		string tarih;
		bool dolu = false;
		public DoktorMuayene(string ad, string soyad, string bolum, string tarih)
		{
			InitializeComponent();
			this.ad = ad;
			this.soyad = soyad;
			this.bolum = bolum;
			this.tarih = tarih;
		}
		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=randevu_kayit;" +
					"Integrated Security=true");
		SqlConnection sqlConnectionIlac = new SqlConnection("server=DESKTOP-4B6TH1C;database=ilaclar;" +
					"Integrated Security=true");

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

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter_1(object sender, EventArgs e)
		{

		}

		private void DoktorMuayene_Load(object sender, EventArgs e)
		{
			listView2.Visible = false;
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand("SELECT tc_no, ad, soyad, dogum_tarihi, cinsiyet, randevu_saat" +
				" FROM randevu_kayit WHERE doktorAd=@doktorAd and doktorSoyad=@doktorSoyad and randevu_tarih=@randevu_tarih" +
				" ORDER BY randevu_saat", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@doktorAd", ad);
			sqlCommand.Parameters.AddWithValue("@doktorSoyad", soyad);
			sqlCommand.Parameters.AddWithValue("@randevu_tarih", tarih);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if(sqlDataReader.Read())
			{
				label2.Text = sqlDataReader["tc_no"].ToString();
				label3.Text = sqlDataReader["ad"].ToString();
				label4.Text = sqlDataReader["soyad"].ToString();
				label5.Text = sqlDataReader["dogum_tarihi"].ToString();
				label6.Text = sqlDataReader["cinsiyet"].ToString();
			}
			else
			{
				
			}
			sqlConnection.Close();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked && dolu == false)
			{
				listView2.Visible = true;
				dolu = true;
				sqlConnectionIlac.Open();
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ilaclar WHERE klinik=@bolum", sqlConnectionIlac);
				sqlCommand.Parameters.AddWithValue("@bolum", bolum);
				SqlDataReader reader = sqlCommand.ExecuteReader();
				while (reader.Read())
				{
					ListViewItem item = new ListViewItem();
					item.Text = reader["ilac_ad"].ToString();
					item.SubItems.Add(reader["miktar"].ToString());
					listView2.Items.Add(item);
				}
				sqlConnection.Close();
			}
			else if (checkBox1.Checked)
				listView2.Visible = true;
			else
				listView2.Visible = false;
		}
	}
}