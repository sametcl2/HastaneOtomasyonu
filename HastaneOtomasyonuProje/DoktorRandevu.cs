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
	public partial class DoktorRandevu : Form
	{
		string ad;
		string soyad;
		string bolum;

		public DoktorRandevu(string ad, string soyad, string bolum)
		{
			InitializeComponent();
			this.ad = ad;
			this.soyad = soyad;
			this.bolum = bolum;
		}
		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=randevu_kayit;" +
					"Integrated Security=true");

		private void DoktorRandevu_Load(object sender, EventArgs e)
		{

			label1.Text = DateTime.Now.ToString("dd-MM-yyyy") + " tarihli randevular.";
			try
			{
				sqlConnection.Open();
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM randevu_kayit WHERE doktorAd=@doktorAd and" +
					" doktorSoyad=@doktorSoyad and randevu_tarih=@randevu_tarih ORDER BY randevu_saat", sqlConnection);
				sqlCommand.Parameters.AddWithValue("@doktorAd", ad);
				sqlCommand.Parameters.AddWithValue("@doktorSoyad", soyad);
				sqlCommand.Parameters.AddWithValue("@randevu_tarih", DateTime.Now.ToString("dd-MM-yyyy"));
				SqlDataReader reader = sqlCommand.ExecuteReader();
				while (reader.Read())
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = reader["tc_no"].ToString();
					listViewItem.SubItems.Add(reader["ad"].ToString());
					listViewItem.SubItems.Add(reader["soyad"].ToString());
					listViewItem.SubItems.Add(reader["cinsiyet"].ToString());
					listViewItem.SubItems.Add(reader["randevu_saat"].ToString());
					listView1.Items.Add(listViewItem);
				}
				sqlConnection.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			DoktorAnaEkran doktorAnaEkran = new DoktorAnaEkran(ad, soyad, bolum);
			doktorAnaEkran.Show();
			this.Hide();
		}
	}
}