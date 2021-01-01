using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 动态时钟
{
    public partial class Form1 : Form
    {
        Timer Timer;//定义时钟，定时重新绘制
        Graphics Graphics;//创建画布
        Pen Pen;//创建画笔
        int width;//画布高度
        int height;//画布宽度
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics = e.Graphics;
            Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//抗锯齿
            Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//高质量
            width = this.Width - 75;//时钟宽度
            height = this.Height - 75;//时钟高度
            int x1 = 0;//起点坐标
            int y1 = 0;//起点坐标
            Graphics.FillEllipse(new SolidBrush(Color.Black), x1 + 2, y1 + 2, width, height);//表盘背景
            Pen = new Pen(new SolidBrush(Color.White), 2);
            Graphics.DrawEllipse(Pen, x1 + 7, y1 + 7, width - 10, height - 10);//内圆
            Graphics.TranslateTransform(x1 + (width / 2), y1 + (height / 2));//更新坐标系
            Graphics.FillEllipse(new SolidBrush(Color.White), -5, -5, 10, 10);//绘制表盘中心
            for (int x = 0; x < 60; x++)
            {
                Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(-2, (Convert.ToInt32(height - 8) / 2 - 2) * (-1), 3, 10));
                Graphics.RotateTransform(6);
            }
            for (int x = 12; x > 0; x--)
            {
                string mystring = x.ToString();
                Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(-2, (Convert.ToInt32(height - 8) / 2 - 2) * (-1), 6, 20));
                Graphics.RotateTransform(-30);
            }
            int second = DateTime.Now.Second;
            int minute = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;
            Pen = new Pen(Color.Yellow, 1);
            Graphics.RotateTransform(6 * second);
            float y = (float)((-1) * (height / 2.75));
            Graphics.DrawLine(Pen, new PointF(0, 0), new PointF((float)0, y));
            Pen = new Pen(Color.White, 4);
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics.RotateTransform(-6 * second);
            Graphics.RotateTransform((float)(second * 0.1 + minute * 6));
            y = (float)((-1) * ((height - 30) / 2.75));
            Graphics.DrawLine(Pen, new PointF(0, 0), new PointF((float)0, y));
            Pen = new Pen(Color.White, 6);
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics.RotateTransform((float)(-second * 0.1 - minute * 6));
            Graphics.RotateTransform((float)(second * 0.01 + minute * 0.1 + hour * 30));
            y = (float)((-1) * ((height - 45) / 2.75));
            Graphics.DrawLine(Pen, new PointF(0, 0), new PointF((float)0, y));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
