using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 选课系统
{
    public partial class 选课系统 : Form
    {
        public 选课系统()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            comboBox1.Visible = true;
            textBox1.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            学生信息管理 xsxxgl = new 学生信息管理();
            xsxxgl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            班级信息管理 bjxxgl = new 班级信息管理();
            bjxxgl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            开课管理 kkgl = new 开课管理();
            kkgl.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            选课管理 xkgl = new 选课管理();
            xkgl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            教师管理 jsgl = new 教师管理();
            jsgl.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            成绩管理 cjgl = new 成绩管理();
            cjgl.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            添加管理员 tjgly = new 添加管理员();
            tjgly.Show();
        }
    }
}
