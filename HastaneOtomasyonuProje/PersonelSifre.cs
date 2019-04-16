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
	public partial class PersonelSifre : Form
	{
		string tc_no;
		string ad;
		string soyad;
		public PersonelSifre(string tc_no, string ad, string soyad)
		{
			this.tc_no = tc_no;
			this.ad = ad;
			this.soyad = soyad;
			InitializeComponent();
		}

		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=kayit_elemanlari;" +
					"Integrated Security=true");

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length > 15 || textBox1.Text.Length < 5)
			{
				MessageBox.Show("Şİfre uzunluğu 5 ile 15 karakter arası olmalıdır.");
				textBox1.Focus();
			}

			if (textBox2.Text != textBox1.Text)
			{
				MessageBox.Show("Şifreler uyuşmuyor.");
				textBox2.Focus();
			}

			if (textBox1.Text=="")
			{
				MessageBox.Show("Geçerli bir şifre giriniz.");
			}
			if (!checkBox1.Checked)
			{
				MessageBox.Show("Şifre değiştirmeyi onaylayınız.");
			}

			try
			{
				SqlCommand sqlCommand = new SqlCommand("UPDATE kayit_elemanlari SET sifre=@sifre WHERE tc_no=@tc_no",
					sqlConnection);
				sqlCommand.Parameters.AddWithValue("@tc_no", tc_no);
				sqlCommand.Parameters.AddWithValue("@sifre", textBox1.Text);
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				MessageBox.Show("Şifre değiştirme başarılı");
				PersonelKayit personelKayit = new PersonelKayit(ad, soyad, tc_no);
				personelKayit.Show();
				this.Hide();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}