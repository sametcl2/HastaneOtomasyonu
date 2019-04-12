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
	public partial class KayitEkleme : Form
	{
		string ad;
		string soyad;
		public KayitEkleme(string ad, string soyad)
		{
			this.ad = ad;
			this.soyad = soyad;
			InitializeComponent();
		}

		SqlConnection sqlConnectionKayit = new SqlConnection("server=DESKTOP-4B6TH1C;database=randevu_kayit;" +
					"Integrated Security=true");
		SqlConnection sqlConnectionDoktor = new SqlConnection("server=DESKTOP-4B6TH1C;database=doktorlar;" +
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

		private void KayitEkleme_Load(object sender, EventArgs e)
		{

		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) == true && char.IsControl(e.KeyChar) == false)
				e.Handled = true;
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) == true && char.IsControl(e.KeyChar) == false)
				e.Handled = true;
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			try
			{
				sqlConnectionKayit.Open();
				SqlCommand sqlCommand = new SqlCommand("INSERT INTO randevu_kayit (tc_no, ad, soyad, dogum_tarihi, cinsiyet, " +
				"klinik, doktor, randevu_tarih) VALUES (@tc_no, @ad, @soyad, @dogum_tarihi, @cinsiyet, " +
				"@klinik, @doktor, @randevu_tarihi)", sqlConnectionKayit);
				sqlCommand.Parameters.AddWithValue("@tc_no", textBox1.Text);
				sqlCommand.Parameters.AddWithValue("@ad", textBox2.Text);
				sqlCommand.Parameters.AddWithValue("@soyad", textBox3.Text);
				sqlCommand.Parameters.AddWithValue("@dogum_tarihi", dateTimePicker1.Value.ToShortTimeString());
				sqlCommand.Parameters.AddWithValue("@cinsiyet", comboBox1.SelectedItem.ToString());
				sqlCommand.Parameters.AddWithValue("@klinik", comboBox2.SelectedItem.ToString());
				sqlCommand.Parameters.AddWithValue("@doktor", listView1.SelectedItems.ToString());
				sqlCommand.Parameters.AddWithValue("@randevu_tarihi", dateTimePicker2.Value.ToShortTimeString());
				sqlCommand.ExecuteNonQuery();
				sqlConnectionKayit.Close(); 
				MessageBox.Show("Kayıt Başarılı");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			sqlConnectionDoktor.Open();
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM doktorlar WHERE bolum=@bolum", sqlConnectionDoktor);
			sqlCommand.Parameters.AddWithValue("@bolum", comboBox2.Text);
			SqlDataReader reader = sqlCommand.ExecuteReader();
			while (reader.Read())
			{
				ListViewItem ekle = new ListViewItem();
				ekle.Text = reader["ad"].ToString();
				ekle.SubItems.Add(reader["soyad"].ToString());
				ekle.SubItems.Add(reader["bolum"].ToString());
				listView1.Items.Add(ekle);
			}
			sqlConnectionDoktor.Close();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			PersonelKayit personel = new PersonelKayit(ad, soyad);
			personel.Show();
			this.Close();
		}
	}
}
