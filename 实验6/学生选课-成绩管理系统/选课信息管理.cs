using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生选课_成绩管理系统
{
    public partial class 选课信息管理 : Form
    {
        public 选课信息管理()
        {
            InitializeComponent();
        }

        private void 选课信息管理_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"server=.;database=JWGLDB;integrated security=sspi");
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            try
            {
                sqlConnection.Open();
                //MessageBox.Show(sqlConnection.State.ToString());
                string sql = "select name from department";//学院
                sqlCommand.CommandText = sql;
                SqlDataReader sqlDataReader1 = sqlCommand.ExecuteReader();
                while (sqlDataReader1.Read())
                {
                    comboBox1.Items.Add(sqlDataReader1[0].ToString());
                }
                comboBox1.Text = (string)comboBox1.Items[0];
                sqlDataReader1.Close();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            SqlConnection sqlConnection = new SqlConnection(@"server=.;database=JWGLDB;integrated security=sspi");
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            try
            {
                sqlConnection.Open();

                string sql = "select name from major where department=(select no from department where name=(@department))";//专业
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.Add("@department", SqlDbType.NVarChar, 255).Value = comboBox1.Text;
                SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();
                while (sqlDataReader2.Read())
                {
                    comboBox2.Items.Add(sqlDataReader2[0].ToString());
                }
                comboBox2.Text = (string)comboBox2.Items[0];
                sqlDataReader2.Close();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            SqlConnection sqlConnection = new SqlConnection(@"server=.;database=JWGLDB;integrated security=sspi");
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            try
            {
                sqlConnection.Open();

                string sql = "select name from class where major=(select no from major where name=(@major))";//班级
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.Add("@major", SqlDbType.NVarChar, 255).Value = comboBox2.Text;
                SqlDataReader sqlDataReader3 = sqlCommand.ExecuteReader();
                while (sqlDataReader3.Read())
                {
                    comboBox3.Items.Add(sqlDataReader3[0].ToString());
                }
                comboBox3.Text = (string)comboBox3.Items[0];
                sqlDataReader3.Close();

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            SqlConnection sqlConnection = new SqlConnection(@"server=.;database=JWGLDB;integrated security=sspi");
            string sql = "select cs.no as '选课编号',course.name as '课程名称',time as '上课时间',place as '上课地点' from cs,course where cs.course=course.no and class=(select no from class where name like '" + comboBox3.Text + "%' and major=(select no from major where name like '" + comboBox2.Text + "%'))";
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = sql;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataSet dataSet = new DataSet();
            try
            {
                sqlConnection.Open();
                sqlDataAdapter.Fill(dataSet);//将原表名作为默认表名
                dataGridView1.DataSource = dataSet.Tables[0];
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
