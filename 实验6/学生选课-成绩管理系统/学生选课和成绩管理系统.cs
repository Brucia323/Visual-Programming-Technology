using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            院系信息管理 yx = new 院系信息管理();
            yx.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            专业_方向信息管理 zy_fx = new 专业_方向信息管理();
            zy_fx.Show();
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
    }
}
