using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 学生选课_成绩管理系统
{
    public partial class 教师信息管理 : Form
    {
        public 教师信息管理()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand sqlCommand = SQLConnection.SqlConnection.CreateCommand();
            try
            {
                SQLConnection.SqlConnection.Open();
                string sql = "select name from course where department=(select no from department where name=(@department))";//课程
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

        private void 教师信息管理_Load(object sender, EventArgs e)
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
                sql = "select name from course where department=(select no from department where name=(@department))";//课程
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
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            string sql = "select teacher.no as '编号',teacher.name as '姓名',department.name as '学院',course.name as '课程',Counsellor as '是否辅导员',title as '职称' from teacher,course,department where teacher.course=course.no and teacher.department=department.no and teacher.department=(select no from department where name like '" + comboBox1.Text + "%') and teacher.course=(select no from course where name like '" + comboBox2.Text + "%')";
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
