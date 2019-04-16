using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonuProje
{
	public partial class PersonelSifre : Form
	{
		public PersonelSifre()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length > 15 || textBox1.Text.Length < 5)
			{
				MessageBox.Show("Şİfre uzunluğu 5 ile 15 karakter arası olmalıdır");
				textBox1.Focus();
			}

			if (textBox2.Text != textBox1.Text)
			{
				MessageBox.Show("Şifreler uyuşmuyor");
				textBox2.Focus();
			}

			if (textBox1.Text=="" || textBox2.Text == "")
			{
				MessageBox.Show("Geçerli bir şifre giriniz.");
			}
			if (!checkBox1.Checked)
			{
				MessageBox.Show("Şifre değiştirmeyi onaylıyor musunuz?");
			}
		}
	}
}
