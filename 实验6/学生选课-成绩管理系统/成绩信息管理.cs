using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 学生选课_成绩管理系统
{
    public partial class 成绩信息管理 : Form
    {
        public 成绩信息管理()
        {
            InitializeComponent();
        }

        private void 成绩信息管理_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = SQLConnection.SqlConnection.CreateCommand();
            try
            {
                SQLConnection.SqlConnection.Open();
                string sql = "select name from department";//学院
                sqlCommand.CommandText = sql;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox1.Items.Add(sqlDataReader[0].ToString());
                }

                comboBox1.Text = (string)comboBox1.Items[0];
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
                SQLConnection.SqlConnection.Open();
                sql = "select name from major where department=(select no from department where name=(@department))";//专业
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.Add("@department", SqlDbType.NVarChar, 255).Value = comboBox1.Text;
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox2.Items.Add(sqlDataReader[0].ToString());
                }

                comboBox2.Text = (string)comboBox2.Items[0];
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
                SQLConnection.SqlConnection.Open();
                sql = "select name from class where major=(select no from major where name=(@major))";//班级
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.Add("@major", SqlDbType.NVarChar, 255).Value = comboBox2.Text;
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox3.Items.Add(sqlDataReader[0].ToString());
                }

                comboBox3.Text = (string)comboBox3.Items[0];
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            SqlCommand sqlCommand = SQLConnection.SqlConnection.CreateCommand();
            try
            {
                SQLConnection.SqlConnection.Open();
                string sql = "select name from major where department=(select no from department where name=(@department))";//专业
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.Add("@department", SqlDbType.NVarChar, 255).Value = comboBox1.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox2.Items.Add(sqlDataReader[0].ToString());
                }

                comboBox2.Text = (string)comboBox2.Items[0];
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            SqlCommand sqlCommand = SQLConnection.SqlConnection.CreateCommand();
            try
            {
                SQLConnection.SqlConnection.Open();
                string sql = "select name from class where major=(select no from major where name=(@major))";//班级
                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.Add("@major", SqlDbType.NVarChar, 255).Value = comboBox2.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox3.Items.Add(sqlDataReader[0].ToString());
                }

                comboBox3.Text = (string)comboBox3.Items[0];
                sqlDataReader.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            string sql = "select grade.sno as '学号',student.name as '姓名',course.no as '课程',grade as '成绩' from grade,student,course where student.sno=grade.sno and grade.course=course.no and cno=(select no from class where name like '" + comboBox3.Text + "%' and major=(select no from major where name like '" + comboBox2.Text + "%'))";
            SqlCommand sqlCommand = SQLConnection.SqlConnection.CreateCommand();
            sqlCommand.CommandText = sql;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, SQLConnection.SqlConnection);
            DataSet dataSet = new DataSet();
            try
            {
                SQLConnection.SqlConnection.Open();
                sqlDataAdapter.Fill(dataSet);//将原表名作为默认表名
                dataGridView1.DataSource = dataSet.Tables[0];
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
