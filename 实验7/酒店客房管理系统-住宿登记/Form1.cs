using System;
using System.Data.SqlClient;
using System.Drawing;
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
            string sql = "SELECT COUNT(*) FROM room WHERE [state] = '空闲'";
            SqlCommand SqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader SqlDataReader = SqlCommand.ExecuteReader();
                SqlDataReader.Read();
                if (SqlDataReader[0].ToString() == "0")
                {
                    label12.Text = "暂无空闲房间";
                    label12.ForeColor = Color.Red;
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
            sql = "SELECT DISTINCT roomtype FROM room WHERE [state] = '空闲'";
            SqlCommand.CommandText = sql;
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox1.Items.Add(sqlDataReader[0].ToString());
                }
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
            comboBox1.Text = comboBox1.Items[0].ToString();
            }
            catch (Exception)
            {
                //throw;
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            //根据房型选房间
            if (!checkBox1.Checked)
            {
                string sql = "SELECT number FROM room WHERE roomtype = '" + comboBox1.Text + "' AND [state] = '空闲'";
                SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox2.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                comboBox2.Text = comboBox2.Items[0].ToString();
            }
            else
            {
                string sql = "SELECT number FROM room WHERE roomtype = '" + comboBox1.Text + "' AND [state] = '已预定'";
                SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox2.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                try
                {
                    comboBox2.Text = comboBox2.Items[0].ToString();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //预交金计算
            string sql = "SELECT price FROM room WHERE number = '" + comboBox2.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95 * Convert.ToDouble(numericUpDown1.Value));
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //获取预订的房型
            if (checkBox1.Checked == true)
            {
                string sql = "SELECT roomtype FROM book WHERE tel = '" + textBox1.Text + "'";
                SqlCommand SqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    SqlDataReader sqlDataReader = SqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        MessageBox.Show("预订的是" + sqlDataReader[0].ToString());
                    }
                    else
                    {
                        MessageBox.Show("无预定信息，可能是联系方式输入错误，请重新输入");
                        textBox1.Text = "";
                    }
                    sqlDataReader.Close();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //预交金计算
            string sql = "SELECT price FROM room WHERE number = '" + comboBox2.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
            try
            {
                SQLConnection.SqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95 * Convert.ToDouble(numericUpDown1.Value));
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (checkBox1.Checked)
            {//筛选出有已预定房间的房型
                string sql = "SELECT DISTINCT roomtype FROM room WHERE [state] = '已预定'";
                SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox1.Items.Add(sqlDataReader[0].ToString());
                    }
                    sqlDataReader.Close();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
            else
            {
                //筛选出有空闲房间的房型
                string sql = "SELECT DISTINCT roomtype FROM room WHERE [state] = '空闲'";
                SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox1.Items.Add(sqlDataReader[0].ToString());
                    }
                    sqlDataReader.Close();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text == "" && textBox5.Text == "")
            {
                sql = "INSERT INTO Accommodation(Number, Name, ID, Stay, [Date], AdvancePayment, Rno, [State]) VALUES ((SELECT COUNT(*) FROM Accommodation) + 1, '" + textBox2.Text + "', '" + textBox3.Text + "', " + numericUpDown1.Value + ", '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "', '" + textBox9.Text + "', '" + comboBox2.Text + "', '已入住')";
                SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                sql = "INSERT INTO Accommodation(Number, Name, ID, Stay, [Date], AdvancePayment, Rno, [State]) VALUES ((SELECT COUNT(*) FROM Accommodation) + 1, '" + textBox2.Text + "', '" + textBox3.Text + "', " + numericUpDown1.Value + ", '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "', '" + textBox9.Text + "', '" + comboBox2.Text + "', '已入住')";
                SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                sql = "INSERT INTO Accommodation(Number, Name, ID, Stay, [Date], AdvancePayment, Rno, [State]) VALUES ((SELECT COUNT(*) FROM Accommodation) + 1, '" + textBox4.Text + "', '" + textBox5.Text + "', " + numericUpDown1.Value + ", '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "', '" + textBox9.Text + "', '" + comboBox2.Text + "', '已入住')";
                sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                try
                {
                    SQLConnection.SqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            sql = "UPDATE room SET [state] = '已入住' WHERE number = '" + comboBox2.Text + "'";
            SqlCommand sqlCommand1 = new SqlCommand(sql, SQLConnection.SqlConnection);
            try
            {
                SQLConnection.SqlConnection.Open();
                sqlCommand1.ExecuteNonQuery();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            if (checkBox1.Checked)
            {
                sql = "UPDATE book SET [state] = '已入住' WHERE tel = '" + textBox1.Text + "'";
                sqlCommand1.CommandText = sql;
                try
                {
                    SQLConnection.SqlConnection.Open();
                    sqlCommand1.ExecuteNonQuery();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            MessageBox.Show("登记成功");
            checkBox1.Checked = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
