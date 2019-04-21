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
	public partial class DepoSifre : Form
	{
		string tc_no;
		string ad;
		string soyad;
		public DepoSifre(string ad, string soyad, string tc_no)
		{
			InitializeComponent();
			this.tc_no = tc_no;
			this.ad = ad;
			this.soyad = soyad;
		}
		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=depo_elemanlari;" +
					"Integrated Security=true");
		private void button1_Click(object sender, EventArgs e)
		{
			bool gecerli = true;
			if (textBox2.Text.Length > 15 || textBox2.Text.Length < 5)
			{
				MessageBox.Show("Şİfre uzunluğu 5 ile 15 karakter arası olmalıdır.");
				textBox2.Focus();
				gecerli = false;
			}

			if (textBox2.Text != textBox3.Text)
			{
				MessageBox.Show("Şifreler uyuşmuyor.");
				textBox3.Focus();
				gecerli = false;
			}

			if (textBox2.Text == "")
			{
				MessageBox.Show("Geçerli bir şifre giriniz.");
				textBox2.Focus();
				gecerli = false;
			}
			if (!checkBox1.Checked)
			{
				MessageBox.Show("Şifre değiştirmeyi onaylayınız.");
				gecerli = false;
			}
			if (textBox1.Text == "")
			{
				MessageBox.Show("Mevcut Şifrenizi giriniz.");
				textBox3.Focus();
				gecerli = false;
			}

			else if (gecerli == true)
			{
				try
				{
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand("UPDATE depo_elemanlari SET sifre=@sifre WHERE tc_no=@tc_no", sqlConnection);
					sqlCommand.Parameters.AddWithValue("@sifre", textBox2.Text);
					sqlCommand.Parameters.AddWithValue("@tc_no", tc_no);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					MessageBox.Show("Şifre değiştirme başarılı");
					textBox1.Text = " ";
					textBox2.Text = " ";
					textBox3.Text = " ";
					DepoAnaEkran depoAnaEkran = new DepoAnaEkran(ad, soyad, tc_no);
					depoAnaEkran.Show();
					this.Hide();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			DepoAnaEkran depoAnaEkran = new DepoAnaEkran(ad, soyad, tc_no);
			depoAnaEkran.Show();
			this.Hide();
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			try
			{
				sqlConnection.Open();
				string sifre = textBox1.Text;
				string yeni = "";
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM depo_elemanlari WHERE tc_no=@tc_no", sqlConnection);
				sqlCommand.Parameters.AddWithValue("@tc_no", tc_no);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					yeni = sqlDataReader["sifre"].ToString();
					sqlConnection.Close();
					break;
				}
				if (yeni.Trim() != sifre.Trim())
				{
					MessageBox.Show("Mevcut Şifrenizi Giriniz");
					textBox1.Focus();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void pictureBox2_Click_1(object sender, EventArgs e)
		{
			DepoAnaEkran depoAnaEkran = new DepoAnaEkran(ad ,soyad, tc_no);
			depoAnaEkran.Show();
			this.Hide();
		}
	}
}