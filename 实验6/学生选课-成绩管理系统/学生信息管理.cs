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

namespace 学生选课_成绩管理系统
{
    public partial class 学生信息管理 : Form
    {
        public 学生信息管理()
        {
            InitializeComponent();
        }
        string[] HeaderText = { "Sno", "Name", " Sex", " Birthday", " Origin", " PFace", " Duty", " Tel", " Class", " DateA", " MajorD", " ID Status" };
        public int row;
        public int cell;
        public string changevalue = "empty";
        public string strcolumn;
        public string sno;
        private void 学生信息管理_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"server=.;database=JWGLDB;integrated security=sspi");
            string sql = "select Sno as 学号, student.Name as 姓名, Sex as 性别, Birthday as 出生日期, Origin as 籍贯, PFace as 政治面貌, Duty as 职位 ,Tel as 电话 , Class.name as 班级, DateA as 入学日期, Major.name as 专业, ID as 身份,Status as 状态 from Student,class,major where student.class=class.no and student.major=major.no and student.class=(select no from class where name like '@class%' and major=(select no from major where name like '@major%')) and student.major=(select no from major where name like '@major%')";
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = sql;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlCommand.Parameters.Add("@class", SqlDbType.NVarChar, 255).Value = comboBox3.Text;
            sqlCommand.Parameters.Add("@major", SqlDbType.NVarChar, 255).Value = comboBox2.Text;
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

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            row = dataGridView1.CurrentCellAddress.Y;
            cell = dataGridView1.CurrentCellAddress.X;
            strcolumn = HeaderText[cell];
            sno = dataGridView1.Rows[row].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            changevalue = dataGridView1.Rows[row].Cells[cell].Value.ToString();
            if (dataGridView1.Rows[0].Cells[cell].Value != null)
            {
                string sql = "update Student set " + strcolumn + " =  " + changevalue + " where Sno = " + sno;
                SqlConnection sqlConnection = new SqlConnection(@"server=.;database=JWGLDB;integrated security=sspi");
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand= new SqlCommand(sql, sqlConnection);
                    sqlConnection.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
            else
            {
                string sql = "insert  into  Student (" + strcolumn + ") values ( " + changevalue + " )";
                SqlConnection sqlConnection = new SqlConnection(@"server=.;database=JWGLDB;integrated security=sspi");
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlConnection.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }

            }
        }
    }
}
