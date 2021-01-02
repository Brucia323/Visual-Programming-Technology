using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            string sql = "SELECT COUNT(*) FROM room WHERE state = '空闲'";
            SqlCommand SqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader SqlDataReader = SqlCommand.ExecuteReader();
                SqlDataReader.Read();
                if (SqlDataReader[0].ToString() == "0")
                {
                    label12.Text = "暂无空闲房间";
                }
                else
                {
                    label12.Text = "还有" + SqlDataReader[0].ToString() + "间房";
                }
                SqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            //筛选出有空闲房间的房型
            sql = "SELECT DISTINCT roomtype FROM room WHERE state like '空闲'";
            SqlCommand.CommandText = sql;
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox1.Items.Add(sqlDataReader[0].ToString());
                }
                comboBox1.Text = (string)comboBox1.Items[0];
                sqlDataReader.Close();
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
                string sql = "SELECT roomtype FROM book WHEERE tel = '" + textBox1.Text + "'";
                SqlCommand SqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();
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

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT price FROM room WHERE no = '" + textBox8.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95);
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //根据房型选房间
            if (!checkBox1.Checked)
            {
                string sql = "SELECT no FROM room WHERE roomtype = '" + comboBox1.Text + "' AND state = '空闲'";
                SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                        textBox8.Text = sqlDataReader[0].ToString();
                    sqlDataReader.Close();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                string sql = "SELECT no FROM room WHERE roomtype = '" + comboBox1.Text + "' AND state = '已预定'";
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
}
