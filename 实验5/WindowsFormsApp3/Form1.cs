using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static int count = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = new ListViewItem(count++.ToString());
            listViewItem.SubItems.Add(textBox1.Text);
            listViewItem.SubItems.Add(textBox2.Text);
            if (radioButton1.Checked)
            {
                listViewItem.SubItems.Add(radioButton1.Text);
            }
            else
            {
                listViewItem.SubItems.Add(radioButton2.Text);
            }

            listViewItem.SubItems.Add(numericUpDown1.Value.ToString());
            listViewItem.SubItems.Add(textBox3.Text);
            listViewItem.SubItems.Add(textBox4.Text);
            listView1.Items.Add(listViewItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count>0)
            {
                foreach(ListViewItem listViewItem in listView1.SelectedItems)
                {
                    listView1.Items.Remove(listViewItem);
                }
            }
            else
            {
                MessageBox.Show("请先选择要移除的项");
            }
        }
    }
}
