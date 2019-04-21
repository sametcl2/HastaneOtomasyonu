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
	public partial class StokTakibi : Form
	{
		string ad;
		string soyad;
		string tc_no;
		public StokTakibi(string ad, string soyad, string tc_no)
		{
			InitializeComponent();
			this.ad = ad;
			this.soyad = soyad;
			this.tc_no = tc_no;
		}
		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=ilaclar;" +
					"Integrated Security=true");
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
					listViewItem.SubItems.Add(sqlDataReader["miktar"].ToString());
					listView1.Items.Add(listViewItem);
				}
		
				sqlConnection.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			DepoAnaEkran depoAnaEkran = new DepoAnaEkran(ad, soyad,tc_no);
			depoAnaEkran.Show();
			this.Hide();
		}
	}
}
