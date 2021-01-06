using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace 酒店客房管理系统_住宿登记
{
    public partial class Form1 : Form
    {
        private static readonly SqlConnection sqlConnection = new SqlConnection(@"server=.;database=JDKFGLXT;integrated security=sspi");
        private readonly SqlCommand sqlCommand = new SqlCommand("", sqlConnection);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //检查是否有房间
            sqlCommand.CommandText = "SELECT COUNT(*) FROM room WHERE [state] = '空闲'";
            try
            {
                sqlConnection.Open();
                SqlDataReader SqlDataReader = sqlCommand.ExecuteReader();
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
                sqlConnection.Close();
            }
            catch (Exception)
            {
                //throw;
            }

            //筛选出有空闲房间的房型
            sqlCommand.CommandText = "SELECT DISTINCT roomtype FROM room WHERE [state] = '空闲'";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox1.Items.Add(sqlDataReader[0].ToString());
                }

                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                //throw;
            }

            try
            {
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
            catch (Exception)
            {
                //throw;
            }

            //根据房型选房间
            sqlCommand.CommandText = "SELECT number FROM room WHERE roomtype = '" + comboBox1.Text + "' AND [state] = '空闲'";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox2.Items.Add(sqlDataReader[0].ToString());
                }

                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                //throw;
            }

            try
            {
                comboBox2.Text = comboBox2.Items[0].ToString();
            }
            catch (Exception)
            {
                //throw;
            }

            //预交金计算
            sqlCommand.CommandText = "SELECT price FROM room WHERE number = '" + comboBox2.Text + "'";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95 * Convert.ToDouble(numericUpDown1.Value));
                }

                sqlDataReader.Close();
                sqlConnection.Close();
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            //获取预订的房型
            sqlCommand.CommandText = "SELECT roomtype FROM book WHERE tel = '" + textBox1.Text + "'";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    comboBox1.Text = sqlDataReader[0].ToString();
                }
                else
                {
                    MessageBox.Show("无预订信息，可能是联系方式输入错误，请重新输入");
                    textBox1.Text = "";
                }

                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                //throw;
            }

            //根据房型选房间
            sqlCommand.CommandText = "SELECT number FROM room WHERE roomtype = '" + comboBox1.Text + "' AND [state] = '已预订'";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox2.Items.Add(sqlDataReader[0].ToString());
                }

                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                //throw;
            }

            try
            {
                comboBox2.Text = comboBox2.Items[0].ToString();
            }
            catch (Exception)
            {
                //throw;
            }

            //预交金计算
            sqlCommand.CommandText = "SELECT price FROM room WHERE number = '" + comboBox2.Text + "'";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95 * Convert.ToDouble(numericUpDown1.Value));
                }

                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                //throw;
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //预交金计算
            sqlCommand.CommandText = "SELECT price FROM room WHERE number = '" + comboBox2.Text + "'";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95 * Convert.ToDouble(numericUpDown1.Value));
                }

                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                //throw;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox9.Text = "";
            if (checkBox1.Checked)
            {
                label1.Visible = true;
                textBox1.Visible = true;
                //筛选出有已预订房间的房型
                sqlCommand.CommandText = "SELECT DISTINCT roomtype FROM room WHERE [state] = '已预订'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox1.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                try
                {
                    comboBox1.Text = comboBox1.Items[0].ToString();
                }
                catch (Exception)
                {
                    //throw;
                }

                comboBox2.Items.Clear();
                //根据房型选房间
                sqlCommand.CommandText = "SELECT number FROM room WHERE roomtype = '" + comboBox1.Text + "' AND [state] = '已预订'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox2.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                try
                {
                    comboBox2.Text = comboBox2.Items[0].ToString();
                }
                catch (Exception)
                {
                    //throw;
                }

                //预交金计算
                sqlCommand.CommandText = "SELECT price FROM room WHERE number = '" + comboBox2.Text + "'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95 * Convert.ToDouble(numericUpDown1.Value));
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

            }
            else
            {
                label1.Visible = false;
                textBox1.Text = "";
                textBox1.Visible = false;
                //筛选出有空闲房间的房型
                sqlCommand.CommandText = "SELECT DISTINCT roomtype FROM room WHERE [state] = '空闲'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox1.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                try
                {
                    comboBox1.Text = comboBox1.Items[0].ToString();
                }
                catch (Exception)
                {
                    //throw;
                }

                //根据房型选房间
                sqlCommand.CommandText = "SELECT number FROM room WHERE roomtype = '" + comboBox1.Text + "' AND [state] = '空闲'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox2.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                try
                {
                    comboBox2.Text = comboBox2.Items[0].ToString();
                }
                catch (Exception)
                {
                    //throw;
                }

                //预交金计算
                sqlCommand.CommandText = "SELECT price FROM room WHERE number = '" + comboBox2.Text + "'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95 * Convert.ToDouble(numericUpDown1.Value));
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("无法确认");
            }

            else if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("天数为0");
            }
            else
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    sqlCommand.CommandText = "INSERT INTO Accommodation(Number, Name, ID, Stay, [Date], AdvancePayment, Rno, [State]) VALUES ((SELECT COUNT(*) FROM Accommodation) + 1, '" + textBox2.Text + "', '" + textBox3.Text + "', " + numericUpDown1.Value + ", '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "', '" + textBox9.Text + "', '" + comboBox2.Text + "', '已入住')";
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                    catch (Exception)
                    {
                        //throw;
                    }

                }
                if (textBox4.Text != "" && textBox5.Text != "")
                {
                    sqlCommand.CommandText = "INSERT INTO Accommodation(Number, Name, ID, Stay, [Date], AdvancePayment, Rno, [State]) VALUES ((SELECT COUNT(*) FROM Accommodation) + 1, '" + textBox4.Text + "', '" + textBox5.Text + "', " + numericUpDown1.Value + ", '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "', '" + textBox9.Text + "', '" + comboBox2.Text + "', '已入住')";
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                    catch (Exception)
                    {
                        //throw;
                    }

                }
                sqlCommand.CommandText = "UPDATE room SET [state] = '已入住' WHERE number = '" + comboBox2.Text + "'";
                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                if (checkBox1.Checked)
                {
                    sqlCommand.CommandText = "UPDATE book SET [state] = '已入住' WHERE tel = '" + textBox1.Text + "'";
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                    catch (Exception)
                    {
                        //throw;
                    }

                }
                MessageBox.Show("登记成功");
                checkBox1.Checked = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                textBox9.Text = "";
                //检查是否有房间
                sqlCommand.CommandText = "SELECT COUNT(*) FROM room WHERE [state] = '空闲'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader SqlDataReader = sqlCommand.ExecuteReader();
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
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                //筛选出有空闲房间的房型
                sqlCommand.CommandText = "SELECT DISTINCT roomtype FROM room WHERE [state] = '空闲'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox1.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                try
                {
                    comboBox1.Text = comboBox1.Items[0].ToString();
                }
                catch (Exception)
                {
                    //throw;
                }

                //根据房型选房间
                sqlCommand.CommandText = "SELECT number FROM room WHERE roomtype = '" + comboBox1.Text + "' AND [state] = '空闲'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox2.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                try
                {
                    comboBox2.Text = comboBox2.Items[0].ToString();
                }
                catch (Exception)
                {
                    //throw;
                }

                //预交金计算
                sqlCommand.CommandText = "SELECT price FROM room WHERE number = '" + comboBox2.Text + "'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95 * Convert.ToDouble(numericUpDown1.Value));
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

            }

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            //根据房型选房间
            if (!checkBox1.Checked)
            {
                sqlCommand.CommandText = "SELECT number FROM room WHERE roomtype = '" + comboBox1.Text + "' AND [state] = '空闲'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox2.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                try
                {
                    comboBox2.Text = comboBox2.Items[0].ToString();
                }
                catch (Exception)
                {
                    //throw;
                }

            }
            else
            {
                sqlCommand.CommandText = "SELECT number FROM room WHERE roomtype = '" + comboBox1.Text + "' AND [state] = '已预订'";
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        comboBox2.Items.Add(sqlDataReader[0].ToString());
                    }

                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    //throw;
                }

                try
                {
                    comboBox2.Text = comboBox2.Items[0].ToString();
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            //预交金计算
            sqlCommand.CommandText = "SELECT price FROM room WHERE number = '" + comboBox2.Text + "'";
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    textBox9.Text = Convert.ToString(Convert.ToDouble(sqlDataReader[0]) * 0.95 * Convert.ToDouble(numericUpDown1.Value));
                }

                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                //throw;
            }

        }

    }

}
