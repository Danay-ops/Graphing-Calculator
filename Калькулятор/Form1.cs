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
    public partial class Form1 : Form
    {
        Button[,] tb;
        double yu = 0,x9=0;
        Button tmp_1;
        bool ger = false,gerw=false;
        string t = "", uyi=")";
        Button tmp;
        Char[] skob;
        Char[] znak;
        Double[] skobi;
        public Form1()
        {
            InitializeComponent();
        }
        // хабрхабр, интуит ру, 
        private void Form1_Load(object sender, EventArgs e)
        {
            int k = 0, ra = 4, le = 3, l = 0, i = 0, j = 0;
            tb = new Button[ra, le];
            for (i = 0; i < ra; i++)
                for (j = 0; j < le; j++)
                {
                    k++;
                    tb[i, j] = new Button();
                    tb[i, j].Size = button1.Size; //tb[i, j].Width = 60; tb[i, j].Height = 25;
                    if (k < 10)
                        tb[i, j].Text = k.ToString();
                    else
                    {
                        if (k == 10)
                            tb[i, j].Text = "0";
                        if (k == 11)
                            tb[i, j].Text = ",";
                        if (k == 12)
                            tb[i, j].Text = "+/-";
                    }
                    tb[i, j].Left = button1.Left + 60 * j;
                    tb[i, j].Top = button1.Top + 30 * i;
                    tb[i, j].Parent = this; // this.Controls.Add(tb[i,j]);
                    tb[i, j].Click += new EventHandler(button1_Click);
                }
            k = 0;
            Button[] tb_1 = new Button[4];
            for (i = 0; i < 4; i++)
            {
                k++;
                for (j = 0; j < 2; j++)
                {
                    l++;
                    tb_1[i] = new Button();
                    tb_1[i].Size = button2.Size;
                    //tb_1[i].Width =45; tb_1[i].Height = 25;
                    if (k == 1 && l == 1)
                        tb_1[i].Text = "+";
                    if (k == 2 && l == 3)
                        tb_1[i].Text = "-";
                    if (k == 3 && l == 5)
                        tb_1[i].Text = "*";
                    if (k == 4 && l == 7)
                        tb_1[i].Text = "/";
                    if (k == 1 && l == 2)
                        tb_1[i].Text = "x^n";
                    if (k == 2 && l == 4)
                        tb_1[i].Text = "x!";
                    if (k == 3 && l == 6)
                        tb_1[i].Text = "√x";
                    if (k == 4 && l == 8)
                        tb_1[i].Text = "π";
                    tb_1[i].Top = button2.Top + 30 * i;
                    tb_1[i].Left = button2.Left + 45 * j;
                    tb_1[i].Parent = this; // this.Controls.Add(tb_1[i,j]);
                    tb_1[i].Click += new EventHandler(button2_Click);
                }
            }
            k = 0; l = 0;
            Button[,] tb_2 = new Button[4, 2];
            for (i = 0; i < 4; i++)
            {
                l++;
                for (j = 0; j < 2; j++)
                {
                    k++;
                    tb_2[i, j] = new Button();
                    tb_2[i, j].Size = button3.Size; //tb_2[i, j].Width = 60; tb_2[i, j].Height = 25;
                    if (k == 1 && l == 1)
                        tb_2[i, j].Text = "sin()";
                    if (k == 2 && l == 1)
                        tb_2[i, j].Text = "cos()";
                    if (k == 3 && l == 2)
                        tb_2[i, j].Text = "tg()";
                    if (k == 4 && l == 2)
                        tb_2[i, j].Text = "ctg()";
                    if (k == 5 && l == 3)
                        tb_2[i, j].Text = "my_sin()";
                    if (k == 6 && l == 3)
                        tb_2[i, j].Text = "my_cos()";
                    if (k == 7 && l == 4)
                        tb_2[i, j].Text = "my_tg()";
                    if (k == 8 && l == 4)
                        tb_2[i, j].Text = "my_ctg()";
                    tb_2[i, j].Left = button3.Left + 60 * j; tb_2[i, j].Top = button3.Top + 30 * i;
                    tb_2[i, j].Parent = this; // this.Controls.Add(tb[i,j]);
                    tb_2[i, j].Click += new EventHandler(button3_Click);
                }
            }
            skob = new char[40];
            znak = new char[40];
            skobi = new double[40];
            for (i = 0; i < 40; i++)
            {
                skob[i] = new char ();
                znak[i] = new char();
                skobi[i] = new double ();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            double xa;
            tmp = (Button)sender;
            if (textBox1.Text == "0"&&tmp.Text!=",")
            {
                textBox1.Text = "0,"+tmp.Text;
            }
            else
            {
                if (tmp.Text == ",")
                {
                    if (textBox1.Text == "")
                    {
                        textBox1.Text = "0,";
                    }
                    else
                    {
                        for (int i = 0; i < textBox1.Text.Length; i++)
                        {
                            if ((int)textBox1.Text[i] == ',')
                                k++;
                        }
                        if (k == 0)
                        {
                            textBox1.Text += tmp.Text;
                        }
                    }
                }
                else
                {
                    if (tmp.Text == "+/-")
                    {
                        if (textBox1.Text != "")
                        {
                            xa = Convert.ToDouble(textBox1.Text);
                            xa *= -1;
                            textBox1.Text = xa.ToString();
                        }
                    }
                    else
                    {
                        textBox1.Text = textBox1.Text + tmp.Text;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tmp_1 = (Button)sender;
            if (t == "/" && textBox1.Text == "0")
            {
                MessageBox.Show("на ноль делить нельзя");
                textBox1.Text = "";
            }
            else
            {
                if (ger == true)
                {
                    ger = false;
                    label1.Text = "";
                }
                if (tmp_1.Text == "π")
                {
                    textBox1.Text = (Math.PI-Math.PI % 0.001).ToString();
                }
                else
                {
                    if (tmp_1.Text == "x^n")
                    {
                        if (textBox1.Text != "")

                            if (gerw == true)
                            {
                                if (Math.Abs(Convert.ToDouble(textBox1.Text)-(int)Convert.ToDouble(textBox1.Text)) >0 && x9 < 0)
                                {
                                    textBox1.Text = "";
                                    MessageBox.Show("Корень из отрицательных чисел не извлекается! Введите значения заново!");
                                    gerw = false;
                                }
                                else
                                {
                                    x9 = Math.Pow(x9, Convert.ToDouble(textBox1.Text));
                                    textBox1.Text = x9.ToString();
                                    gerw = false;
                                }
                            }
                            else
                            {
                                gerw = true;
                                x9 = Convert.ToDouble(textBox1.Text);
                                textBox1.Text = "";
                            }
                    }
                    else
                    {
                        if (tmp_1.Text == "x!")
                        {
                            int ar = 1;
                            if (Convert.ToDouble(textBox1.Text) % (int)Convert.ToDouble(textBox1.Text) == 0 && Convert.ToDouble(textBox1.Text) >= 0)
                            {
                                for (int i = 2; i <= Convert.ToInt32(textBox1.Text); i++)
                                {
                                    ar *= i;
                                }
                                textBox1.Text = ar.ToString();
                            }
                            else
                            {
                                if (Convert.ToDouble(textBox1.Text) == 0)
                                    textBox1.Text = "0";
                                else
                                {
                                    textBox1.Text = "";
                                    MessageBox.Show("Введите натуральное число");
                                }
                            }
                        }
                        else
                        {
                            if (tmp_1.Text == "√x")
                            {
                                if (Convert.ToDouble(textBox1.Text) >= 0)
                                    textBox1.Text = Math.Sqrt(Convert.ToDouble(textBox1.Text)).ToString();
                                else
                                {
                                    textBox1.Text = "";
                                    MessageBox.Show("Корень из отрицательных чисел не извлекается!");
                                }
                            }
                            else {
                                if (textBox1.Text != "")
                                {
                                    if (t == "+")
                                    {
                                        yu += Convert.ToDouble(textBox1.Text);
                                        if (Convert.ToDouble(textBox1.Text) >= 0)
                                            label1.Text += t + textBox1.Text;
                                        else
                                            label1.Text += t + "(" + textBox1.Text + ")";
                                        textBox1.Text = "";
                                    }
                                    else
                                    {
                                        if (t == "-")
                                        {
                                            yu -= Convert.ToDouble(textBox1.Text);
                                            if (Convert.ToDouble(textBox1.Text) >= 0)
                                                label1.Text += t + textBox1.Text;
                                            else
                                                label1.Text += t + "(" + textBox1.Text + ")";
                                            textBox1.Text = "";
                                        }
                                        else
                                        {
                                            if (t == "/")
                                            {
                                                yu /= Convert.ToDouble(textBox1.Text);
                                                if (Convert.ToDouble(textBox1.Text) >= 0)
                                                    label1.Text = "(" + label1.Text + ")" + t + textBox1.Text;
                                                else
                                                    label1.Text = "(" + label1.Text + ")" + t + "(" + textBox1.Text + ")";
                                                textBox1.Text = "";

                                            }
                                            else
                                            {
                                                if (t == "*")
                                                {
                                                    yu *= Convert.ToDouble(textBox1.Text);
                                                    if (Convert.ToDouble(textBox1.Text) >= 0)
                                                        label1.Text = "(" + label1.Text + ")" + t + textBox1.Text;
                                                    else
                                                        label1.Text = "(" + label1.Text + ")" + t + "(" + textBox1.Text + ")";
                                                    textBox1.Text = "";
                                                }
                                                else
                                                {
                                                    yu = Convert.ToDouble(textBox1.Text);
                                                    label1.Text += t + textBox1.Text;
                                                    textBox1.Text = "";
                                                }
                                            }
                                        }
                                    }
                                }
                                if (tmp != null || label1.Text != "")
                                {
                                    t = tmp_1.Text;
                                    tmp = null;
                                }
                            }
                        }
                    }
                }
            }
        }      
   
        private void button3_Click(object sender, EventArgs e)
        {
            double yu_1,yu_2;
            tmp_1 = (Button)sender;
            if (textBox1.Text != "")
            {
                yu_2 = Convert.ToDouble(textBox1.Text);
                string t = textBox1.Text;
                if (tmp_1.Text == "sin()")
                {
                    t = "sin(" + t + ")";
                    yu_1 = Math.Sin(yu_2);
                    textBox1.Text = Convert.ToString(yu_1);
                }
                else
                {
                    if (tmp_1.Text == "cos()")
                    {
                        t = "cos(" + t + ")";
                        yu_1 = Math.Cos(yu_2);
                        textBox1.Text = Convert.ToString(yu_1);
                    }
                    else
                    {
                        if (tmp_1.Text == "tg()")
                        {
                            
                            yu_1 = Math.Tan(yu_2);
                            textBox1.Text = Convert.ToString(yu_1);
                            t = "tg(" + t + ")";
                        }

                        else
                        {
                            if (tmp_1.Text == "ctg()")
                            {
                                if (yu_2> 0)
                                {
                                    yu_1 = Math.Cos(yu_2) / Math.Sin(yu_2);
                                    t = "ctg(" + t + ")";
                                    textBox1.Text = Convert.ToString(yu_1);
                                }
                                else
                                {
                                    textBox1.Text = "";
                                    MessageBox.Show("Недопустимое значение");
                                }
                            }
                            else
                            {
                                double x = yu_2, xsin = x, xcos = 1;
                                yu_1 = x;
                                int k = -1;
                                if (tmp_1.Text == "my_sin()")
                                {
                                    t = "my_sin(" + t + ")";
                                    for (int i = 1; i <= 150; i++)
                                    {
                                        xsin = xsin * x * x / (2 * i) / (2 * i + 1);
                                        yu_1 += k * xsin;
                                        k = -k;
                                    }
                                    textBox1.Text = Convert.ToString(yu_1);
                                }
                                else
                                {
                                    if (tmp_1.Text == "my_cos()")
                                    {
                                        t = "my_cos(" + t + ")";
                                        yu_1 = 1;
                                        for (int i = 1; i <= 150; i++)
                                        {
                                            xcos = xcos * x * x / (2 * i) / (2 * i - 1);
                                            yu_1 += k * xcos;
                                            k = -k;
                                        }
                                        textBox1.Text = Convert.ToString(yu_1);
                                    }
                                    else
                                    {
                                        double yu1 = 1;
                                        for (int i = 1; i <= 150; i++)
                                        {
                                            xsin = xsin * x * x / (2 * i) / (2 * i + 1);
                                            yu_1 += k * xsin;
                                            xcos = xcos * x * x / (2 * i) / (2 * i - 1);
                                            yu1 += k * xcos;
                                            k = -k;
                                        }
                                        if (tmp_1.Text == "my_tg()")
                                        {
                                            t = "my_tg(" + t + ")";
                                            yu_1 /= yu1;
                                            textBox1.Text = Convert.ToString(yu_1);
                                        }
                                        else
                                        {
                                            if (tmp_1.Text == "my_ctg()")
                                            {
                                                t = "my_ctg(" + t + ")";
                                                yu1 /= yu_1;
                                                textBox1.Text = Convert.ToString(yu1);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                string l = tmp_1.Text;
                if (textBox1.Text != "")
                {
                    yu_1 = Convert.ToDouble(textBox1.Text);
                    if (l == "sin()" || l == "cos()" || l == "ctg()" || l == "tg()")
                    {
                        Form Form2 = new Form2(yu_2, yu_1, t, l);
                        Form2.Show();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (t == "/" && textBox1.Text == "0")
            {
                MessageBox.Show("на ноль делить нельзя");
                textBox1.Text = "";
            }
            else
            {
                if (tmp_1.Text == "x^n")
                {
                    if (textBox1.Text != "")
                    {
                        if (Convert.ToDouble(textBox1.Text) > 0 && Convert.ToDouble(textBox1.Text) < 1 && x9 < 0)
                        {
                            textBox1.Text = "";
                            MessageBox.Show("Корень из отрицательных чисел не извлекается! Введите значения заново!");
                            gerw = false;
                        }
                        else
                        {
                            x9 = Math.Pow(x9, Convert.ToDouble(textBox1.Text));
                            textBox1.Text = x9.ToString();
                            gerw = false;
                        }
                    }
                }
                if (textBox1.Text != "")
                {
                    if (t == "+")
                    {
                        if (Convert.ToDouble(textBox1.Text) >= 0)
                            label1.Text += t + textBox1.Text;
                        else
                            label1.Text += t + "(" + textBox1.Text + ")";
                        yu = (yu + Convert.ToDouble(textBox1.Text));
                        label1.Text += "=" + yu;
                        textBox1.Text = "";
                        textBox1.Text += yu;
                    }
                    if (t == "-")
                    {
                        if (Convert.ToDouble(textBox1.Text) >= 0)
                            label1.Text += t + textBox1.Text;
                        else
                            label1.Text += t + "(" + textBox1.Text + ")";
                        yu = (yu - Convert.ToDouble(textBox1.Text));
                        label1.Text += "=" + yu;
                        textBox1.Text = "";
                        textBox1.Text += yu;
                    }
                    if (t == "/")
                    {
                        if (Convert.ToDouble(textBox1.Text) >= 0)
                            label1.Text = "(" + label1.Text + ")" + t + textBox1.Text;
                        else
                            label1.Text = "(" + label1.Text + ")" + t + "(" + textBox1.Text + ")";
                        yu = (yu / Convert.ToDouble(textBox1.Text));
                        label1.Text += "=" + yu;
                        textBox1.Text = "";
                        textBox1.Text += yu;
                    }
                    if (t == "*")
                    {
                        if (Convert.ToDouble(textBox1.Text) >= 0)
                            label1.Text = "(" + label1.Text + ")" + t + textBox1.Text;
                        else
                            label1.Text = "(" + label1.Text + ")" + t + "(" + textBox1.Text + ")";
                        yu = (yu * Convert.ToDouble(textBox1.Text));
                        label1.Text += "=" + yu;
                        textBox1.Text = "";
                        textBox1.Text += yu;
                    }
                    t = ""; ger = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            yu = 0; t = "";
            textBox1.Text = "";
            label1.Text = "";
            tmp = null;
        }
    }
}