using System.Drawing;
using System.Windows.Forms;

namespace 抛物线
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.DrawArc(Pens.Black, 60, 200, 600, 300, 190, 160);
        }
    }
}
