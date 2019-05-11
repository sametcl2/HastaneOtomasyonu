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
	public partial class Depo : Form
	{
		public Depo()
		{
			InitializeComponent();
		}
		SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-4B6TH1C;database=depo_elemanlari;" +
					"Integrated Security=true");
		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
				e.Handled = true;
			else
			{
				if (textBox1.TextLength > 10 && char.IsControl(e.KeyChar) == false)
					e.Handled = true;
			}
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

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Form1 form1 = new Form1();
			form1.Show();
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM depo_elemanlari WHERE tc_no=@tc_no and ad=@ad and soyad=@soyad and " +
				"personel_no=@personel_no and sifre=@sifre", sqlConnection);
			sqlConnection.Open();
			sqlCommand.Parameters.AddWithValue("@tc_no", textBox1.Text);
			sqlCommand.Parameters.AddWithValue("@ad", textBox2.Text);
			sqlCommand.Parameters.AddWithValue("@soyad", textBox3.Text);
			sqlCommand.Parameters.AddWithValue("@personel_no", maskedTextBox1.Text);
			sqlCommand.Parameters.AddWithValue("@sifre", textBox4.Text);
			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					MessageBox.Show("Giriş Başarılı");
					DepoAnaEkran depoAnaEkran = new DepoAnaEkran(textBox2.Text, textBox3.Text, textBox1.Text);
					depoAnaEkran.Show();
					this.Hide();
					break;
				}
			}
			else
				MessageBox.Show("Kayıt Bulunamadı...");
			sqlConnection.Close();
		}
	}
}