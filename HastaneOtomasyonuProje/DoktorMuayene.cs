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
				sqlConnectionIlac.Close();
			}
			else if (checkBox1.Checked)
				listView2.Visible = true;
			else
				listView2.Visible = false;
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			printDialog1.ShowDialog();
			printDocument1.Print();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			string ilac = "";
			if (checkBox1.Checked)
				ilac = listView2.SelectedItems[0].Text;
			Font yazi_tipi = new Font("Tahoma", 12, FontStyle.Bold);
			e.Graphics.DrawString(label2.Text, yazi_tipi, Brushes.Black, 100, 50);
			e.Graphics.DrawString(label3.Text, yazi_tipi, Brushes.Black, 100, 100);
			e.Graphics.DrawString(label4.Text, yazi_tipi, Brushes.Black, 100, 150);
			e.Graphics.DrawString(label5.Text, yazi_tipi, Brushes.Black, 100, 200);
			e.Graphics.DrawString(label6.Text, yazi_tipi, Brushes.Black, 100, 250);
			e.Graphics.DrawString(ilac, yazi_tipi, Brushes.Black, 100, 350);
			e.Graphics.DrawString(richTextBox1.Text,yazi_tipi, Brushes.Black, 100, 400);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			sqlConnection.Open();
			SqlCommand sqlCommandd = new SqlCommand("DELETE randevu_kayit WHERE tc_no=@tc_no and klinik=@klinik",sqlConnection);
			sqlCommandd.Parameters.AddWithValue("@tc_no", label1.Text);
			sqlCommandd.Parameters.AddWithValue("@klinik", bolum);
			sqlCommandd.ExecuteNonQuery();
			if (checkBox1.Checked)
			{
				ListViewItem listViewItem = listView2.SelectedItems[0];
				sqlConnectionIlac.Open();
				string ilac = listViewItem.SubItems[0].Text;
				int miktari = int.Parse(listViewItem.SubItems[1].Text) - 1;
				string miktar = miktari.ToString();
				SqlCommand sqlCommand = new SqlCommand("UPDATE ilaclar SET miktar=@miktar WHERE ilac_ad=@ilac_ad", sqlConnectionIlac);
				sqlCommand.Parameters.AddWithValue("@miktar", miktar);
				sqlCommand.Parameters.AddWithValue("@ilac_ad", ilac);
				sqlCommand.ExecuteNonQuery();
				sqlConnectionIlac.Close();
			}
			MessageBox.Show("işlem başarılı");
			sqlConnection.Close();
		}
	}
}