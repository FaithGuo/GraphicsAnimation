using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using demo.Properties;

namespace demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            TransparencyKey = this.BackColor;
            InitializeComponent();

            MaxX = Screen.PrimaryScreen.Bounds.Width;
            MaxY = Screen.PrimaryScreen.Bounds.Height;
            x = 0;
            y = MaxY - 50;
        }

        private Image img = Resources.小火箭;
        private int MaxX, MaxY, x, y;
        private Thread th;

        private void Form1_Load(object sender, EventArgs e)
        {
            th = new Thread(() => draw());
            th.IsBackground = true;
            th.Start();
        }

        public void draw()
        {
            while (true)
            {
                var g = this.CreateGraphics();
                g.Clear(this.BackColor);
                g.DrawImage(img, new Rectangle(new Point(x, y), new Size(50, 50)));
                    
                g.Dispose();
                x++;
                y--;
                if (x + 1 > MaxX)
                    x = 0;
                if (y - 1 < 0)
                    y = MaxY;
                Thread.Sleep(20);
            }
        }
    }
}
