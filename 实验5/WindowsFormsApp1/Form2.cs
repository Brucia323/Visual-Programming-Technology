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

        private void button1_Click(object sender, EventArgs e)
        {
            Config.listboxvalue = (string)listBox1.SelectedItem;
            flag1.flag = true;
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.SelectedItem = "RTF文档";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag1.flag = false;
            this.Close();
        }
    }
}
