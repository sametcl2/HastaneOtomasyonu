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
	public partial class KayitSorgula : Form
	{
		string ad;
		string soyad;
		public KayitSorgula(string ad, string soyad)
		{
			this.ad = ad;
			this.soyad = soyad;
			InitializeComponent();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void KayitSorgula_Load(object sender, EventArgs e)
		{

		}

		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=randevu_kayit;" +
					"Integrated Security=true");

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
				e.Handled = true;
			else
			{
				if (textBox1.TextLength > 11 && char.IsControl(e.KeyChar) == false)
					e.Handled = true;
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			try
			{
				string tc_no = textBox1.Text;
				sqlConnection.Open();
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM randevu_kayit Where tc_no=@tc_no", sqlConnection);
				sqlCommand.Parameters.AddWithValue("@tc_no", tc_no);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = sqlDataReader["tc_no"].ToString();
					listViewItem.SubItems.Add(sqlDataReader["ad"].ToString());
					listViewItem.SubItems.Add(sqlDataReader["soyad"].ToString());
					listViewItem.SubItems.Add(sqlDataReader["dogum_tarihi"].ToString());
					listViewItem.SubItems.Add(sqlDataReader["cinsiyet"].ToString());
					listViewItem.SubItems.Add(sqlDataReader["doktor"].ToString());
					listViewItem.SubItems.Add(sqlDataReader["klinik"].ToString());
					listViewItem.SubItems.Add(sqlDataReader["randevu_tarih"].ToString());
					listViewItem.SubItems.Add(sqlDataReader["randevu_saat"].ToString());
					listView1.Items.Add(listViewItem);
				}
				sqlConnection.Close();
				textBox1.Clear();
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			PersonelKayit personelKayit = new PersonelKayit(ad, soyad);
			personelKayit.Show();
			this.Close();
		}
	}
}
