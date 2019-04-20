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
	public partial class DoktorSifre : Form
	{
		string ad;
		string soyad;
		string bolum;
		public DoktorSifre(string ad, string soyad, string bolum)
		{
			InitializeComponent();
			this.ad = ad;
			this.soyad = soyad;
			this.bolum = bolum;
		}
		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=doktorlar;" +
					"Integrated Security=true");
		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

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
					SqlCommand sqlCommand = new SqlCommand("UPDATE doktorlar SET sifre=@sifre WHERE ad=@ad and soyad=@soyad", sqlConnection);
					sqlCommand.Parameters.AddWithValue("@ad", ad);
					sqlCommand.Parameters.AddWithValue("@soyad", soyad);
					sqlCommand.Parameters.AddWithValue("@sifre", textBox2.Text);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					MessageBox.Show("Şifre değiştirme başarılı");
					textBox1.Text = " ";
					textBox2.Text = " ";
					textBox3.Text = " ";
					DoktorAnaEkran doktorAnaEkran = new DoktorAnaEkran(ad, soyad, bolum);
					doktorAnaEkran.Show();
					this.Hide();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			sqlConnection.Open();
			string sifre = textBox1.Text;
			string yeni = "";
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM doktorlar WHERE ad=@ad and soyad=@soyad", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@ad", ad);
			sqlCommand.Parameters.AddWithValue("@soyad", soyad);
			SqlDataReader reader = sqlCommand.ExecuteReader();
			while (reader.Read())
			{
				yeni = reader["sifre"].ToString();
				sqlConnection.Close();
				break;
			}
			if(sifre.Trim() != yeni.Trim())
			{
				MessageBox.Show("Mevcut Şifrenizi Giriniz");
				textBox1.Focus();
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
