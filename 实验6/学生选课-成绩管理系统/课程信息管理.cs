using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 学生选课_成绩管理系统
{
    public partial class 课程信息管理 : Form
    {
        public 课程信息管理()
        {
            InitializeComponent();
        }

        private void 课程信息管理_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = SQLConnection.SqlConnection.CreateCommand();
            try
            {
                SQLConnection.SqlConnection.Open();
                string sql = "select name from department";//学院
                sqlCommand.CommandText = sql;
                SqlDataReader sqlDataReader1 = sqlCommand.ExecuteReader();
                while (sqlDataReader1.Read())
                {
                    comboBox1.Items.Add(sqlDataReader1[0].ToString());
                }

                comboBox1.Text = (string)comboBox1.Items[0];
                sqlDataReader1.Close();
                SQLConnection.SqlConnection.Close();
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            string sql = "select course.no as '编号',course.name as '名称',hour as '学时',credit as '学分',type as '课程类型',department.name as '开课学院' from course,department where course.department=department.no and type like '" + comboBox2.Text + "%' and course.department=(select no from department where name like '" + comboBox1.Text + "%')";
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
