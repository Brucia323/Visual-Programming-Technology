using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                richTextBox1.ForeColor = Color.Red;
            else if (radioButton2.Checked)
                richTextBox1.ForeColor = Color.Blue;
            else
                richTextBox1.ForeColor = Color.Black;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 48, richTextBox1.Font.Style);
            else if (radioButton5.Checked)
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 28, richTextBox1.Font.Style);
            else if (radioButton6.Checked)
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 38, richTextBox1.Font.Style);
            else
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 18, richTextBox1.Font.Style);
        }

        private void radioButton8_Click(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
                richTextBox1.Font = new Font("宋体", richTextBox1.Font.Size, richTextBox1.Font.Style);
            else if (radioButton9.Checked)
                richTextBox1.Font = new Font("楷体", richTextBox1.Font.Size, richTextBox1.Font.Style);
            else
                richTextBox1.Font = new Font("隶书", richTextBox1.Font.Size, richTextBox1.Font.Style);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Bold);
            else
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Bold);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Italic);
            else
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Italic);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Underline);
            else
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Underline);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Strikeout);
            else
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Strikeout);
        }

    }
}
