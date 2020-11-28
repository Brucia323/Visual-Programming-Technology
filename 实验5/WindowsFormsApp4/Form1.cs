using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode treeNode = treeView1.SelectedNode;
            listView1.Items.Clear();
            foreach (TreeNode treeNode1 in treeNode.Nodes)
                listView1.Items.Add(treeNode1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("第一章 C#语言概述");
            treeView1.Nodes[0].Nodes.Add("1.1 什么是C#语言");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("1.1.1 C#语言的发展历程");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("1.1.2 C#语言的特点");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("1.1.3 用C#编写的应用程序类型");
            treeView1.Nodes[0].Nodes.Add("1.2 .NET Framework");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("1.2.1 什么是.NET Framework");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("1.2.2 开发托管代码的过程");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("1.2.3 C#语言与.NET Framework");
            treeView1.Nodes[0].Nodes.Add("1.3 Visual Studio 2012的安装、启动和退出");
            treeView1.Nodes[0].Nodes[2].Nodes.Add("1.3.1 Visual Studio 2012的安装");
            treeView1.Nodes[0].Nodes[2].Nodes.Add("1.3.2 配置Visual C#开发环境");
            treeView1.Nodes[0].Nodes[2].Nodes.Add("1.3.3 Visual Studio 2012的启动");
            treeView1.Nodes[0].Nodes[2].Nodes.Add("1.3.4 Visual Studio 2012的退出");
            treeView1.Nodes[0].Nodes.Add("1.4 Visual C#集成开发环境");
            treeView1.Nodes[0].Nodes[3].Nodes.Add("1.4.1 启动Visual C#集成开发环境");
            treeView1.Nodes[0].Nodes[3].Nodes.Add("1.4.2 Visual C#的菜单栏");
            treeView1.Nodes[0].Nodes[3].Nodes.Add("1.4.3 Visual C#的工具栏");
            treeView1.Nodes[0].Nodes[3].Nodes.Add("1.4.4 解决方案资源管理器");
            treeView1.Nodes[0].Nodes[3].Nodes.Add("1.4.5 编辑器的设置");
            treeView1.Nodes[0].Nodes.Add("1.5 一个简单的C#程序");
            treeView1.Nodes[0].Nodes[4].Nodes.Add("1.5.1 代码分析");
            treeView1.Nodes[0].Nodes[4].Nodes.Add("1.5.2 项目的构成");
            treeView1.Nodes[0].Nodes[4].Nodes.Add("1.5.3 控制台应用程序中的基本元素");
        }
    }
}
