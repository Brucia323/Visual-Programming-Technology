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
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader SqlDataReader =RoomAvailable.SqlCommand.ExecuteReader();
                if (!SqlDataReader.Read())
                    MessageBox.Show("暂无空闲房间");
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
    }
}
