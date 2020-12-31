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

namespace 酒店客房管理系统_住宿登记
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //检查是否有房间
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader SqlDataReader =RoomAvailable.SqlCommand.ExecuteReader();
                SqlDataReader.Read();
                if (SqlDataReader[0].ToString()=="0")
                    MessageBox.Show("暂无空闲房间");
                else
                    MessageBox.Show("还有" + SqlDataReader[0].ToString() + "间房");
                SqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //获取预订的房型
            if (checkBox1.Checked == true)
            {
                try
                {
                    SQLConnection.SqlConnection.Open();
                    SqlDataReader sqlDataReader = Booking.SqlCommand.ExecuteReader();
                    sqlDataReader.Read();
                    comboBox1.Text = sqlDataReader[0].ToString();
                    sqlDataReader.Close();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据房型选房间
            string sql = "SELECT no FROM room WHERE roomclass='" + comboBox1.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                textBox8.Text = sqlDataReader[0].ToString();
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
