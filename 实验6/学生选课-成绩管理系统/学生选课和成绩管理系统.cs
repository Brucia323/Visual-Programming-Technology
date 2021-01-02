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
    public partial class 学生选课和成绩管理系统 : Form
    {
        public 学生选课和成绩管理系统()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            选课信息管理 xk = new 选课信息管理();
            xk.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            成绩信息管理 cj = new 成绩信息管理();
            cj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            班级信息管理 bj = new 班级信息管理();
            bj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            学生信息管理 xs = new 学生信息管理();
            xs.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            课程信息管理 kc = new 课程信息管理();
            kc.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            教师信息管理 js = new 教师信息管理();
            js.Show();
        }

        private void 学生选课和成绩管理系统_Load(object sender, EventArgs e)
        {
            //SqlConnection SQLConnection.SqlConnection = new SqlConnection(ConnectionString.connectionstring);
            //try
            //{
            //    SQLConnection.SqlConnection.Open();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    SQLConnection.SqlConnection.Close();
            //}
        }
    }
}
