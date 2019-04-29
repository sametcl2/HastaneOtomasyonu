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
	public partial class DepoUrunGiris : Form
	{
		string ad;
		string soyad;
		string tc_no;
		public DepoUrunGiris(string ad, string soyad, string tc_no)
		{
			InitializeComponent();
			this.ad = ad;
			this.soyad = soyad;
			this.tc_no = tc_no;
		}
		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=ilaclar;" +
					"Integrated Security=true");
		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				listView1.Items.Clear();
				sqlConnection.Open();
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ilaclar WHERE klinik=@klinik", sqlConnection);
				sqlCommand.Parameters.AddWithValue("@klinik", comboBox1.Text);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = sqlDataReader["ilac_ad"].ToString();
					listView1.Items.Add(listViewItem);
				}

				sqlConnection.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ListViewItem selectedItem = listView1.SelectedItems[0];
			sqlConnection.Open();
			SqlCommand sqlCommandd = new SqlCommand("SELECT * FROM ilaclar WHERE ilac_ad=@ilac_ad", sqlConnection);
			sqlCommandd.Parameters.AddWithValue("@ilac_ad", selectedItem.SubItems[0].Text);
			SqlDataReader reader = sqlCommandd.ExecuteReader();
			string miktar = "";
			while (reader.Read())
			{
				miktar = reader["miktar"].ToString();
				sqlConnection.Close();
				break;
			}
			sqlConnection.Open();
			int topla = int.Parse(miktar) + int.Parse(textBox1.Text);
			SqlCommand sqlCommand = new SqlCommand("UPDATE ilaclar SET miktar=@miktar WHERE ilac_ad=@ilac_ad", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@miktar", topla.ToString());
			sqlCommand.Parameters.AddWithValue("@ilac_ad", selectedItem.SubItems[0].Text);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			MessageBox.Show("Ürün Girişi Başarılı");
			textBox1.Text = "";
			//listView1.Items.Clear();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			DepoAnaEkran depoAnaEkran = new DepoAnaEkran(ad, soyad, tc_no);
			depoAnaEkran.Show();
			this.Hide();
		}
	}
}