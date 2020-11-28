using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (flag1.flag)
            {
                this.Hide(); //先隐藏主窗体
                Form1 form1 = new Form1(); //重新实例化此窗体
                form1.ShowDialog();//已模式窗体的方法重新打开
                this.Close();//原窗体关闭
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Config.listboxvalue == null)
                toolStrip2.Visible = true;
            else if (Config.listboxvalue == "RTF文档")
                toolStrip2.Visible = true;
            else
                toolStrip2.Visible = false;
            System.Drawing.Text.InstalledFontCollection installedFontCollection = new System.Drawing.Text.InstalledFontCollection();
            foreach(System.Drawing.FontFamily fontFamily in installedFontCollection.Families)
            {
                toolStripComboBox1.Items.Add(fontFamily.Name.ToString());
            }
            toolStripComboBox1.SelectedItem = "宋体";
            toolStripComboBox2.SelectedIndex = 3;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "RTF文档(*.rtf)|*.rtf|文本文档(*.txt)|*.txt";
            openFileDialog.ShowDialog();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "RTF文档(*.rtf)|*.rtf|文本文档(*.txt)|*.txt";
            saveFileDialog.ShowDialog();
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "RTF文档(*.rtf)|*.rtf|文本文档(*.txt)|*.txt";
            saveFileDialog.ShowDialog();
        }

        private void 打印PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = richTextBox1.Font;
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void 工具栏TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (工具栏TToolStripMenuItem.Checked)
            {
                工具栏TToolStripMenuItem.Checked = false;
                toolStrip1.Visible = false;
            }
            else
            {
                工具栏TToolStripMenuItem.Checked = true;
                toolStrip1.Visible = true;
            }
        }

        private void 格式栏FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(格式栏FToolStripMenuItem.Checked)
            {
                格式栏FToolStripMenuItem.Checked = false;
                toolStrip2.Visible = false;
            }
            else
            {
                格式栏FToolStripMenuItem.Checked = true;
                toolStrip2.Visible = true;
            }
        }

        private void 状态栏SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(状态栏SToolStripMenuItem.Checked)
            {
                状态栏SToolStripMenuItem.Checked = false;
                statusStrip1.Visible = false;
            }
            else
            {
                状态栏SToolStripMenuItem.Checked = true;
                statusStrip1.Visible = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (flag1.flag)
            {
                this.Hide(); //先隐藏主窗体
                Form1 form1 = new Form1(); //重新实例化此窗体
                form1.ShowDialog();//已模式窗体的方法重新打开
                this.Close();//原窗体关闭
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "RTF文档(*.rtf)|*.rtf|文本文档(*.txt)|*.txt";
            openFileDialog.ShowDialog();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "RTF文档(*.rtf)|*.rtf|文本文档(*.txt)|*.txt";
            saveFileDialog.ShowDialog();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();

        }

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void 清除AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText!="")
            {
                Clipboard.SetDataObject(richTextBox1.SelectedText);
            }
        }

        private void 全选LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetDataObject(richTextBox1.SelectedText);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font("宋体", 11, richTextBox1.Font.Style);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (toolStripButton12.Checked == true)
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Bold);
            else
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Bold);

        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (toolStripButton13.Checked == true)
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Italic);
            else
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Italic);

        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (toolStripButton14.Checked == true)
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Underline);
            else
                richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Underline);

        }

        private void 关于写字板AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }
    }
}
