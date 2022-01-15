﻿using System;
using System.Windows.Forms;

namespace 实验一
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = 0.0, b = 0.0, sum = 0.0;
                char c;
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);
                c = Convert.ToChar(comboBox1.SelectedItem);
                switch (c)
                {
                    case '+':
                        sum = a + b;
                        break;
                    case '-':
                        sum = a - b;
                        break;
                    case '*':
                        sum = a * b;
                        break;
                    case '/':
                        sum = a / b;
                        break;
                }
                textBox3.Text = Convert.ToString(sum);
            }
            catch
            {
                textBox3.Text = ("非法输入");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fo = new Form2();
            fo.Show();
        }
    }
}
