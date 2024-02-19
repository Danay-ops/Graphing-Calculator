using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калькулятор
{
    public partial class Form2 : Form
    {
        public double x1, x2;
        public string l1, t1;
        public Form2(double yu_2, double yu_1, string t, string l)
        {
            InitializeComponent();
            x1 = yu_1; x2 = yu_2;
            l1 = l;
            t1 = t;
        }
        Graphics gr;//=panel1.CreateGraphics();
        private void button2_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Close();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Значение " + t1 + ":";
            textBox1.Text = Convert.ToString(x1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //label1.Text = "Значение " + t1 + ":";
            //textBox1.Text = Convert.ToString(x1);
            x2=x2%(Math.PI*2);
            gr = panel1.CreateGraphics();
            Color col = Color.Black;
            Pen pen = new Pen(col);
            Pen pen1 = new Pen(Color.CadetBlue);
            Pen pen2 = new Pen(Color.Red);
            pen.Width = 3; pen1.Width = 3;
            pen2.Width = 5;
            String drawString = "X";
            Font drawFont = button1.Font;
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new PointF(panel1.Width - 10, (panel1.Size.Height - 10) / 2);
            gr.DrawString(drawString, drawFont, drawBrush, drawPoint);
            gr.DrawString("Y", drawFont, drawBrush, 10, 5);
            label1.Text = "Значение " + t1 + ":";
            gr.DrawLine(pen, 0, 0, 0, panel1.Height);
            gr.DrawLine(pen, 0, (panel1.Size.Height - 10) / (2), panel1.Width, (panel1.Size.Height - 10) / (2));
            float
                    x0 = 0,
                    h0 = (float)Math.PI / 6,
                    kx0 = panel1.Size.Width / (2 * (float)Math.PI),
                    ky0 = 10 + (panel1.Size.Height - 40) / (2);
            float xs0, y0_ = (panel1.Size.Height - 10) / (2);
            for (int i = 0; i < 12; i++)
            {
                xs0 = x0 * kx0;
                gr.DrawLine(pen, xs0, y0_ + 5, xs0, y0_ - 5);
                x0 += h0;
            }
            gr.DrawString("π\n6", drawFont, drawBrush, 26, 115);
            gr.DrawString("_", drawFont, drawBrush, 26, 114.5f);
            gr.DrawString("График  " + l1, drawFont, drawBrush, panel1.Width - 229, 10);
            if (l1 == "sin()")
            {
                //gr.DrawLine(pen, 0, 0, 0, panel1.Height);
                //gr.DrawLine(pen, 0, (panel1.Size.Height - 10) / (2), panel1.Width, (panel1.Size.Height - 10) / (2));
                gr.DrawString("0,5", drawFont, drawBrush, 10, 50);
                float
                    x = 0, y, y0 = 0,
                    h = 2 * (float)Math.PI / 2000,
                    kx = panel1.Size.Width / (2 * (float)Math.PI),
                    ky = 10 + (panel1.Size.Height - 40) / (2);
                float xs, ys, x_ = 0, y_ = (panel1.Size.Height - 10) / (2);
                for (int i = 0; i < 2000; i++)
                {
                    gr.DrawLine(pen, 0, 5 + y0, 10, 5 + y0);
                    y0 += ky / 2;
                    y = (float)Math.Sin(x);
                    xs = x * kx;
                    ys = (panel1.Size.Height - 10) / (2) - y * ky;
                    //if (y >= x1 - 0.03 && y <= x1 + 0.03 && x >= x2 - 0.03 && x <= x2 + 0.03)
                    //    gr.DrawLine(pen2, x_, y_, xs, ys);
                    //else
                    gr.DrawLine(pen1, x_, y_, xs, ys);
                    //                    gr.DrawLine(pen2, (float)(x2*kx - 2), (float)((panel1.Size.Height - 10) / (2) - x1 * ky), (float)((x2)*kx + 2), (float)((panel1.Size.Height - 10) / (2) - x1 * ky));
                    x += h;
                    x_ = xs; y_ = ys;
                }
                gr.DrawLine(pen2, (float)(x2 * kx - 2.5), (float)((panel1.Size.Height - 10) / (2) - x1 * ky), (float)((x2) * kx + 2.5), (float)((panel1.Size.Height - 10) / (2) - x1 * ky));
            }
            else
            {
                if (l1 == "cos()")
                {
                    //gr.DrawLine(pen, 0, 0, 0, panel1.Height);
                    //gr.DrawLine(pen, 0, (panel1.Size.Height - 10) / (2), panel1.Width, (panel1.Size.Height - 10) / (2));
                    gr.DrawString("0,5", drawFont, drawBrush, 10, 50);
                    float
                        x = 0, y, y0 = 0,
                        h = 2 * (float)Math.PI / 2000,
                        kx = panel1.Size.Width / (2 * (float)Math.PI),
                        ky = 10 + (panel1.Size.Height - 40) / (2);
                    float xs, ys, x_ = 0, y_ = (panel1.Size.Height - 10) / (2) - ky;
                    for (int i = 0; i < 2000; i++)
                    {
                        gr.DrawLine(pen, 0, 5 + y0, 10, 5 + y0);
                        y0 += ky / 2;
                        y = (float)Math.Cos(x);
                        xs = x * kx;
                        ys = (panel1.Size.Height - 10) / (2) - y * ky;
                        //if (y >= x1 - 0.03 && y <= x1 + 0.03 && x >= x2 - 0.03 && x <= x2 + 0.03)
                        //    gr.DrawLine(pen2, x_, y_, xs, ys);
                        //else
                        gr.DrawLine(pen1, x_, y_, xs, ys);
                        x += h;
                        x_ = xs; y_ = ys;
                    }
                    gr.DrawLine(pen2, (float)(x2 * kx - 2.5), (float)((panel1.Size.Height - 10) / (2) - x1 * ky), (float)((x2) * kx + 2.5), (float)((panel1.Size.Height - 10) / (2) - x1 * ky));
                }
                else
                {
                    if (l1 == "tg()")
                    {
                        //gr.DrawLine(pen, 0, 0, 0, panel1.Height);
                        //gr.DrawLine(pen, 0, (panel1.Size.Height - 10) / (2), panel1.Width, (panel1.Size.Height - 10) / (2));
                        gr.DrawString("1", drawFont, drawBrush, 10, 87);
                        float
                            x = 0, y, y0 = 0,
                            h = 2 * (float)Math.PI / 20000,
                            kx = panel1.Size.Width / (2 * (float)Math.PI),
                            ky = 10 + (panel1.Size.Height - 40) / (23);
                        float xs, ys, x_ = 0, y_ = (panel1.Size.Height - 10) / (2);
                        for (int i = 0; i < 20000; i++)
                        {

                            gr.DrawLine(pen, 0, 5 + y0, 10, 5 + y0);
                            y0 += ky / 0.8f - 4.6f;
                            y = (float)Math.Tan(x);
                            xs = x * kx;
                            ys = (panel1.Size.Height - 10) / (2) - y * ky;
                            if (x < 1.5 || x > 1.6 && x < 4.7 || x > 4.8)
                            {
                                //if (y >= x1 - 0.05 && y <= x1 + 0.05 && x >= x2 - 0.05 && x <= x2 + 0.05)
                                //    gr.DrawLine(pen2, x_, y_, xs, ys);
                                //else
                                    gr.DrawLine(pen1, x_, y_, xs, ys);
                            }
                            x += h;
                            x_ = xs; y_ = ys;
                        }
                        if (x2 < 1.5 || x2 > 1.6 && x2 < 4.7 || x2 > 4.8)
                            gr.DrawLine(pen2, (float)(x2 * kx - 2.5), (float)((panel1.Size.Height - 10) / (2) - x1 * ky), (float)((x2) * kx + 2.5), (float)((panel1.Size.Height - 10) / (2) - x1 * ky));
                    }
                    else
                    {
                        if (l1 == "ctg()")
                        {
                            //gr.DrawLine(pen, 0, 0, 0, panel1.Height);
                            //gr.DrawLine(pen, 0, (panel1.Size.Height - 10) / (2), panel1.Width, (panel1.Size.Height - 10) / (2));
                            gr.DrawString("1", drawFont, drawBrush, 10, 87);
                            float
                                x = 0.05f, y, y0 = 0,
                                h = 2 * (float)Math.PI / 20000,
                                kx = panel1.Size.Width / (2 * (float)Math.PI),
                            ky = 10 + (panel1.Size.Height - 40) / (23);
                            float xs, ys, x_ = 0, y_ = (panel1.Size.Height - 10) / (2);
                            for (int i = 0; i < 20000; i++)
                            {
                                gr.DrawLine(pen, 0, 5 + y0, 10, 5 + y0);
                                y0 += ky / 0.8f - 4.6f; y = (float)(Math.Tan(Math.PI / 2 - x));
                                xs = x * kx;
                                ys = (panel1.Size.Height - 10) / (2) - ky * y;
                                if (x > 0.075 && x < 3.14 || x > 3.18 && x < 6.2)
                                {
                                    //if (y >= x1 - 0.075 && y <= x1 + 0.075 && x >= x2 - 0.075 && x <= x2 + 0.075)
                                    //    gr.DrawLine(pen2, x_, y_, xs, ys);
                                    //else
                                    gr.DrawLine(pen1, x_, y_, xs, ys);
                                }
                                x += h;
                                x_ = xs; y_ = ys;

                            }
                            if (x2 > 0.075 && x2 < 3.14 || x2 > 3.18 && x2 < 6.2)
                                gr.DrawLine(pen2, (float)(x2 * kx - 2.5), (float)((panel1.Size.Height - 10) / (2) - x1 * ky), (float)((x2) * kx + 2.5), (float)((panel1.Size.Height - 10) / (2) - x1 * ky));
                        }
                    }
                }
            }
        }
    }
}
