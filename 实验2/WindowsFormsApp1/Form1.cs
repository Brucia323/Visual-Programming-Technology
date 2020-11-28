using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        struct Goods
        {
            public string name;
            public string describe;
            public string image;
            public int price;
        }
        int pp, i;
        Goods[] goods = new Goods[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "重新开始";
            textBox1.Clear();
            Random random = new Random();
            i = random.Next(0, 5);
            label1.Text = goods[i].name;
            label3.Text = goods[i].describe;
            pictureBox1.Image = System.Drawing.Image.FromFile("..\\..\\image\\" + goods[i].image);
            pp = goods[i].price;
            textBox1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int p = int.Parse(textBox1.Text);
                if (p < pp)
                    MessageBox.Show("低了，我们不做亏本生意！");
                else if (p > pp)
                    MessageBox.Show("优秀的公司赚取利润，\n伟大的公司赢得人心。\n没这么贵！");
                else
                    MessageBox.Show("恭喜你，猜对了！");
            }
            catch
            {
                MessageBox.Show("你输的什么？");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            goods[0].name = "小米10至尊纪念版 16GB+512GB";
            goods[0].image = "Ultra.jpg";
            goods[0].describe = "120X 超远变焦 / 120W 秒充科技 / 120Hz刷新率 + 240Hz采样率 / 骁龙865旗舰处理器 / 双模5G / 10倍混合光学变焦 / OIS光学防抖+EIS数字防抖 / 2000万超清前置相机 / 双串蝶式石墨烯基锂离子电池 / 等效4500mAh大电量 / 120W 有线秒充+50W无线秒充+10W无线反充 / WiFi 6 / 多功能NFC / 红外遥控";
            goods[0].price = 6999;

            goods[1].name = "小米10青春版 8GB+256GB";
            goods[1].image = "青春版.jpg";
            goods[1].describe = "向往的生活同款/ 50倍潜望式超远变焦 / 双模5G / 骁龙765G处理器 / 三星AMOLED原色屏 / 180Hz采样率 / 4160mAh大电池 / 多功能NFC / 红外遥控器";
            goods[1].price = 2799;

            goods[2].name = "小米10 Pro 12GB+512GB";
            goods[2].image = "Pro.jpg";
            goods[2].describe = "向往的生活同款 / 骁龙865处理器 / 1亿像素8K电影相机，50倍数字变焦，10倍混合光学变焦 / 双模5G / 新一代LPDDR5内存 / 50W极速闪充+30W无线闪充+10W无线反充 / 对称式立体声 / 90Hz刷新率+180Hz采样率 / UFS 3.0高速存储 / 全面适配WiFi 6 / 超强VC液冷散热 / 4500mAh大电量 / 多功能NFC";
            goods[2].price = 5999;

            goods[3].name = "小米10 12GB+256GB";
            goods[3].image = "10.jpg";
            goods[3].describe = "骁龙865处理器 / 1亿像素8K电影相机 / 双模5G / 新一代LPDDR5内存 / 对称式立体声 / 90Hz刷新率+180Hz采样率 / UFS 3.0高速存储 / 全面适配Wi-Fi 6 / 超强VC液冷散热 / 30W极速闪充+30W无线闪充+10W无线反充 / 4780mAh大电量 / 多功能NFC";
            goods[3].price = 4699;

            goods[4].name = "小米MIX Alpha 512GB";
            goods[4].image = "Alpha.jpg";
            goods[4].describe = "创新环绕屏，极具未来感的智能交互体验 / 1亿像素超高清相机，超大感光元件 / 5G双卡全网通超高速网络 / 骁龙855Plus旗舰处理器 / 纳米硅基锂离子4050mAh电池，40W超级快充 / 钛合金+精密陶瓷+蓝宝石镜片前沿工艺";
            goods[4].price = 19999;
        }
    }
}
