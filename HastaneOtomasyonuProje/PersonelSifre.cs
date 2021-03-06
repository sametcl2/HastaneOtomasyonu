﻿using System;
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
	public partial class PersonelSifre : Form
	{
		string tc_no;
		string ad;
		string soyad;
		public PersonelSifre(string tc_no, string ad, string soyad)
		{
			InitializeComponent();
			this.tc_no = tc_no;
			this.ad = ad;
			this.soyad = soyad;
		}

		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=kayit_elemanlari;" +
					"Integrated Security=true");
		private void button1_Click(object sender, EventArgs e)
		{
			bool gecerli = true;
			if (textBox1.Text.Length > 15 || textBox1.Text.Length < 5)
			{
				MessageBox.Show("Şİfre uzunluğu 5 ile 15 karakter arası olmalıdır.");
				textBox1.Focus();
				gecerli = false;
			}

			if (textBox2.Text != textBox1.Text)
			{
				MessageBox.Show("Şifreler uyuşmuyor.");
				textBox2.Focus();
				gecerli = false;
			}

			if (textBox1.Text=="")
			{
				MessageBox.Show("Geçerli bir şifre giriniz.");
				textBox1.Focus();
				gecerli = false;
			}
			if (!checkBox1.Checked)
			{
				MessageBox.Show("Şifre değiştirmeyi onaylayınız.");
				gecerli = false;
			}
			if (textBox3.Text == "")
			{
				MessageBox.Show("Mevcut Şifrenizi giriniz.");
				textBox3.Focus();
				gecerli = false;
			}

			else if(gecerli==true)
			{
				try
				{
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand("UPDATE kayit_elemanlari SET sifre=@sifre WHERE tc_no=@tc_no",
						sqlConnection);
					sqlCommand.Parameters.AddWithValue("@tc_no", tc_no);
					sqlCommand.Parameters.AddWithValue("@sifre", textBox1.Text);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					MessageBox.Show("Şifre değiştirme başarılı");
					textBox1.Text = " ";
					textBox2.Text = " ";
					textBox3.Text = " ";
					PersonelKayit personelKayit = new PersonelKayit(ad, soyad, tc_no);
					personelKayit.Show();
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
			PersonelKayit personelKayit = new PersonelKayit(ad, soyad, tc_no);
			personelKayit.Show();
			this.Hide();
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			string sifre = textBox3.Text;
			string yeni = "";
			sqlConnection.Open();
			SqlCommand sqlCommandd = new SqlCommand("SELECT * FROM kayit_elemanlari WHERE ad=@ad and soyad=@soyad", sqlConnection);
			sqlCommandd.Parameters.AddWithValue("@ad", ad);
			sqlCommandd.Parameters.AddWithValue("@soyad", soyad);
			SqlDataReader reader = sqlCommandd.ExecuteReader();
			while (reader.Read())
			{
				yeni = reader["sifre"].ToString();
				sqlConnection.Close();
				break;
			}
			if(sifre.Trim() != yeni.Trim())
			{
				MessageBox.Show("Mevcut Şifrenizi Giriniz.");
				textBox3.Focus();
			}
		}
	}
}