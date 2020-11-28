using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DALS.RoomDA rd = new DALS.RoomDA();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.Room room = new Models.Room();
            room.BuildingName = this.comboBox1.Text;
            room.Floor = this.comboBox2.Text;
            room.Num = this.comboBox3.Text;
            textBox1.Text = room.RoomName;
            room.RoomType = comboBox4.Text;
            room.Memo = textBox2.Text;
            room.RoomStatus = comboBox5.Text;

            label8.Text = rd.AddRoom(room);

            dataGridView1.DataSource = DALS.DataWork.ds.Tables[0];

        }
    }
}
