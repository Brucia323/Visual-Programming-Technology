using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 学生选课_成绩管理系统
{
    public partial class 学生信息管理 : Form
    {
        public 学生信息管理()
        {
            InitializeComponent();
        }

        private readonly string[] HeaderText = { "Sno", "Name", " Sex", " Birthday", " Origin", " PFace", " Duty", " Tel", " Class", " DateA", " Major", " ID Status" };
        public int row;
        public int cell;
        public string changevalue;
        public string strcolumn;
        public string sno;
        private void 学生信息管理_Load(object sender, EventArgs e)
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
            string sql = "select Sno as 学号, student.Name as 姓名, Sex as 性别, Birthday as 出生日期, Origin as 籍贯, PFace as 政治面貌, Duty as 职位 ,Tel as 电话 , Class.name as 班级, DateA as 入学日期, Major.name as 专业, ID as 身份,Status as 状态 from Student,class,major where student.class=class.no and student.major=major.no and student.class=(select no from class where name like '" + comboBox3.Text + "%' and major=(select no from major where name like '" + comboBox2.Text + "%')) and student.major=(select no from major where name like '" + comboBox2.Text + "%')";
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

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            row = dataGridView1.CurrentCellAddress.Y;//行
            cell = dataGridView1.CurrentCellAddress.X;//列
            strcolumn = HeaderText[cell];//列名
            sno = dataGridView1.Rows[row].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            changevalue = dataGridView1.Rows[row].Cells[cell].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[0].Value != null && dataGridView1.CurrentRow.Cells[0].Value.ToString() != "")
            {
                string sql = "update Student set " + strcolumn + " =  '" + changevalue + "' where Sno = " + sno;
                try
                {
                    SQLConnection.SqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
                    string check = sqlCommand.ExecuteNonQuery().ToString();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                //插入一条信息
                string major, Classno;
                int size;
                SqlCommand sqlCommand = SQLConnection.SqlConnection.CreateCommand();
                try
                {
                    //获取专业编码
                    SQLConnection.SqlConnection.Open();
                    sqlCommand.CommandText = "Select no from major where name like '" + comboBox2.Text + "'";
                    SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();
                    sqlDataReader2.Read();
                    major = sqlDataReader2[0].ToString();
                    sqlDataReader2.Close();
                    SQLConnection.SqlConnection.Close();
                    //获取班级编码
                    SQLConnection.SqlConnection.Open();
                    sqlCommand.CommandText = "Select no from class where name like '" + comboBox3.Text + "' and major=(Select no from major where name like '" + comboBox2.Text + "')";
                    SqlDataReader sqlDataReader3 = sqlCommand.ExecuteReader();
                    sqlDataReader3.Read();
                    Classno = sqlDataReader3[0].ToString();
                    sqlDataReader3.Close();
                    SQLConnection.SqlConnection.Close();
                    //获取班级当前人数
                    SQLConnection.SqlConnection.Open();
                    sqlCommand.CommandText = "Select count(*) from student where class=(Select no from class where name like '" + comboBox3.Text + "' and major=(Select no from major where name like '" + comboBox2.Text + "'))";
                    SqlDataReader sqlDataReader4 = sqlCommand.ExecuteReader();
                    sqlDataReader4.Read();
                    size = Convert.ToInt32(sqlDataReader4[0]);
                    sqlDataReader4.Close();
                    SQLConnection.SqlConnection.Close();
                    size++;
                    string Sno;
                    if (size >= 10)
                    {
                        Sno = Classno + size.ToString();
                    }
                    else
                    {
                        Sno = Classno + "0" + size.ToString();
                    }

                    string sql = "INSERT INTO student ( " + strcolumn + ",  Class,  Major, Sno ) VALUES (  '" + changevalue + "', '" + Classno + "', '" + major + "', '" + Sno + "' )";
                    SQLConnection.SqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(sql, SQLConnection.SqlConnection);
                    string check = cmd.ExecuteNonQuery().ToString();
                    SQLConnection.SqlConnection.Close();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
