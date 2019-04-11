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
	public partial class Personel : Form
	{
		public Personel()
		{
			InitializeComponent();
		}

		private void Personel_Load(object sender, EventArgs e)
		{
			
		}

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

		private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{
			
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Form1 form1 = new Form1();
			form1.Show();
			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4B6TH1C;Integrated Security=True");
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM kayit_elemanlari WHERE tc_no=" + textBox1.Text.ToString() +
					"and ad=" + textBox1.Text.ToString() +
					"and soyad=" + textBox3.Text.ToString() +
					"and personel_no=" + maskedTextBox1.Text.ToString(), sqlConnection);
				sqlConnection.Open();
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows == true)
					MessageBox.Show("Helal lan");
				else
					MessageBox.Show("Tekrar dene");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}