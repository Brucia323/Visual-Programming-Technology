using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Text = "中文";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                comboBox3.Items.Add(adapter.Name);
            }
            comboBox3.SelectedIndex = 0;
            if (File.Exists(Application.StartupPath + "\\User.txt"))
            {
                string[] vs = File.ReadAllLines(Application.StartupPath + "\\User.txt", Encoding.Default);
                comboBox1.Text = vs[0];
                textBox1.Text = vs[1];
                if (bool.Parse(vs[2]))
                    checkBox1.Checked = true;
                try
                {
                    if (bool.Parse(vs[3]))
                    {
                        checkBox2.Checked = true;
                        button2.PerformClick();
                    }
                }
                catch { }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "中文")
            {
                label2.Text = "用户名";
                label3.Text = "密码";
                label4.Text = "Language";
                label5.Text = "网卡";
                checkBox1.Text = "保存密码";
                checkBox2.Text = "自动登录";
                linkLabel1.Text = "自助服务";
                button1.Text = "设置";
                button2.Text = "认证";
            }
            else
            {
                label2.Text = "Username";
                label3.Text = "Password";
                label4.Text = "语言";
                label5.Text = "NIC";
                checkBox1.Text = "Save Password";
                checkBox2.Text = "Automatic";
                linkLabel1.Text = "Self Service";
                button1.Text = "Settings";
                button2.Text = "Certification";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("别点了，没做");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "root" && textBox1.Text == "123456")
            {
                string Username, Password;
                if (checkBox1.Checked)
                {
                    FileStream file = new FileStream(Application.StartupPath + "\\User.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(file);
                    Username = comboBox1.Text;
                    Password = textBox1.Text;
                    writer.WriteLine(Username);
                    writer.WriteLine(Password);
                    writer.WriteLine(true);
                    writer.Flush();
                    writer.Close();
                }
                else
                {
                    if (File.Exists(Application.StartupPath + "\\User.txt"))
                        System.IO.File.Delete(Application.StartupPath + "\\User.txt");
                }
                if (checkBox2.Checked)
                {
                    FileStream file = new FileStream(Application.StartupPath + "\\User.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(file);
                    writer.WriteLine(true);
                    writer.Flush();
                    writer.Close();
                }
                new Form2().Show();
            }
            else
            {
                comboBox1.Text = "";
                textBox1.Text = "";
                MessageBox.Show("用户名或密码错误");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://dh.fjut.edu.cn");
        }
    }
}
