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
		string tc_no;
		public KayitEkleme(string ad, string soyad, string tc_no)
		{
			this.ad = ad;
			this.soyad = soyad;
			this.tc_no = tc_no;
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
				ListViewItem selectedItem = listView1.SelectedItems[0];
				sqlConnectionKayit.Open();
				SqlCommand sqlCommandd = new SqlCommand("SELECT * FROM randevu_kayit WHERE doktorAd=@doktorAd and doktorSoyad=@doktorSoyad" +
					" and randevu_tarih=@randevu_tarih and randevu_saat=@randevu_saat", sqlConnectionKayit);
				sqlCommandd.Parameters.AddWithValue("@doktorAd", selectedItem.SubItems[0].Text);
				sqlCommandd.Parameters.AddWithValue("@doktorSoyad", selectedItem.SubItems[1].Text);
				sqlCommandd.Parameters.AddWithValue("@randevu_tarih", dateTimePicker2.Value.ToString("dd-MM-yyyy"));
				sqlCommandd.Parameters.AddWithValue("@randevu_saat", comboBox3.SelectedItem.ToString());
				SqlDataReader sqlDataReader = sqlCommandd.ExecuteReader();
				if (sqlDataReader.HasRows == true)
				{
					MessageBox.Show("Doktorunuzun seçtiğiniz saatte başka bir randevusu vardır. Lütfen başka bir saat seçiniz.");
					sqlConnectionKayit.Close();
					sqlDataReader.Close();
				}
				else
				{
					sqlDataReader.Close();
					SqlCommand sqlCommand = new SqlCommand("INSERT INTO randevu_kayit (tc_no, ad, soyad, dogum_tarihi, cinsiyet, " +
					"klinik, doktorAd, doktorSoyad, randevu_tarih, dogum_tarih, randevu_saat) VALUES (@tc_no, @ad, @soyad, @dogum_tarihi, @cinsiyet, " +
					"@klinik, @doktorAd, @doktorSoyad, @randevu_tarih, @dogum_tarih, @randevu_saat)", sqlConnectionKayit);
					sqlCommand.Parameters.AddWithValue("@tc_no", textBox1.Text);
					sqlCommand.Parameters.AddWithValue("@ad", textBox2.Text);
					sqlCommand.Parameters.AddWithValue("@soyad", textBox3.Text);
					sqlCommand.Parameters.AddWithValue("@dogum_tarihi", dateTimePicker1.Value.ToString("dd-mm-yyyy"));
					sqlCommand.Parameters.AddWithValue("@cinsiyet", comboBox1.SelectedItem.ToString());
					sqlCommand.Parameters.AddWithValue("@klinik", comboBox2.SelectedItem.ToString());
					sqlCommand.Parameters.AddWithValue("@doktorAd", selectedItem.SubItems[0].Text);
					sqlCommand.Parameters.AddWithValue("@doktorSoyad", selectedItem.SubItems[1].Text);
					sqlCommand.Parameters.AddWithValue("@randevu_tarih", dateTimePicker2.Value.ToString("dd-MM-yyyy"));
					sqlCommand.Parameters.AddWithValue("@dogum_tarih", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
					sqlCommand.Parameters.AddWithValue("@randevu_saat", comboBox3.SelectedItem.ToString());
					sqlCommand.ExecuteNonQuery();
					sqlConnectionKayit.Close();
					sqlConnectionDoktor.Open();
					SqlCommand sqlCommandD = new SqlCommand("SELECT * FROM doktorlar WHERE ad=@ad and soyad=@soyad", sqlConnectionDoktor);
					sqlCommandD.Parameters.AddWithValue("ad", selectedItem.SubItems[0].Text);
					sqlCommandD.Parameters.AddWithValue("soyad", selectedItem.SubItems[1].Text);
					SqlDataReader reader = sqlCommandD.ExecuteReader();
					string tut = reader["gunlukHastaSayisi"].ToString();
					int sayac = int.Parse(tut);
					sayac++;
					reader.Close();
					sqlConnectionDoktor.Close();
					MessageBox.Show("Kayıt Başarılı");
					textBox1.Clear();
					textBox2.Clear();
					textBox3.Clear();
				}
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
			PersonelKayit personel = new PersonelKayit(ad, soyad, tc_no);
			personel.Show();
			this.Close();
		}
	}
}