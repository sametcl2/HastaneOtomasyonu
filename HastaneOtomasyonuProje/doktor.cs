﻿using System;
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
	public partial class doktor : Form
	{
		public doktor()
		{
			InitializeComponent();
		}

		private void doktor_Load(object sender, EventArgs e)
		{

		}

		private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
				e.Handled = true;
			else
			{
				if (textBox1.TextLength > 11 && char.IsControl(e.KeyChar) == false)
					e.Handled = true;
			}
		}

		private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) == true && char.IsControl(e.KeyChar) == false)
				e.Handled = true;
		}

		private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) == true && char.IsControl(e.KeyChar) == false)
				e.Handled = true;
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Form1 form1 = new Form1();
			form1.Show();
			this.Close();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}