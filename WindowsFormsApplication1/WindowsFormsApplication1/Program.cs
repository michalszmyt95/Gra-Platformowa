using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxy;
        private System.Windows.Forms.TextBox miny;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maxx;
        private System.Windows.Forms.TextBox minx;
        private System.Windows.Forms.PictureBox Fractal;
        private Graphics graph;

        //Describes places to render
        private double ratioX;
        private double ratioY;
        private double minX;
        private double minY;
        private double maxX;
        private double maxY;
        private int downX;
        private int downY;

        //Describes sets to color
        private complex_t[] results = new complex_t[10];
        private int resultsCnt;
        private bool cSet;

        private Pen[] penColors = new Pen[100];
        private System.Windows.Forms.Panel Selection;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox aIm;
        private System.Windows.Forms.TextBox aRe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton colorSpeed;
        private System.Windows.Forms.RadioButton colorSet;
        private System.Windows.Forms.TextBox pr0;
        private System.Windows.Forms.TextBox pi0;
        private System.Windows.Forms.TextBox pi1;
        private System.Windows.Forms.TextBox pr1;
        private System.Windows.Forms.TextBox pi2;
        private System.Windows.Forms.TextBox pr2;
        private System.Windows.Forms.TextBox pi3;
        private System.Windows.Forms.TextBox pr3;
        private System.Windows.Forms.TextBox pi4;
        private System.Windows.Forms.TextBox pr4;
        private System.Windows.Forms.TextBox pi5;
        private System.Windows.Forms.TextBox pr5;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.maxy = new System.Windows.Forms.TextBox();
            this.miny = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maxx = new System.Windows.Forms.TextBox();
            this.minx = new System.Windows.Forms.TextBox();
            this.Fractal = new System.Windows.Forms.PictureBox();
            this.Selection = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.aIm = new System.Windows.Forms.TextBox();
            this.aRe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pr0 = new System.Windows.Forms.TextBox();
            this.pi0 = new System.Windows.Forms.TextBox();
            this.pi1 = new System.Windows.Forms.TextBox();
            this.pr1 = new System.Windows.Forms.TextBox();
            this.pi2 = new System.Windows.Forms.TextBox();
            this.pr2 = new System.Windows.Forms.TextBox();
            this.pi3 = new System.Windows.Forms.TextBox();
            this.pr3 = new System.Windows.Forms.TextBox();
            this.pi4 = new System.Windows.Forms.TextBox();
            this.pr4 = new System.Windows.Forms.TextBox();
            this.pi5 = new System.Windows.Forms.TextBox();
            this.pr5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.colorSpeed = new System.Windows.Forms.RadioButton();
            this.colorSet = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(392, 408);
            this.button1.Name = "button1";
            this.button1.TabIndex = 15;
            this.button1.Text = "Generuj";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // label2
            //
            this.label2.Location = new System.Drawing.Point(376, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Zakres Y";
            //
            // maxy
            //
            this.maxy.Location = new System.Drawing.Point(440, 96);
            this.maxy.Name = "maxy";
            this.maxy.Size = new System.Drawing.Size(120, 20);
            this.maxy.TabIndex = 13;
            this.maxy.Text = "textBox3";
            //
            // miny
            //
            this.miny.Location = new System.Drawing.Point(440, 72);
            this.miny.Name = "miny";
            this.miny.Size = new System.Drawing.Size(120, 20);
            this.miny.TabIndex = 12;
            this.miny.Text = "textBox4";
            //
            // label1
            //
            this.label1.Location = new System.Drawing.Point(376, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Zakres X";
            //
            // maxx
            //
            this.maxx.Location = new System.Drawing.Point(440, 41);
            this.maxx.Name = "maxx";
            this.maxx.Size = new System.Drawing.Size(120, 20);
            this.maxx.TabIndex = 10;
            this.maxx.Text = "textBox2";
            //
            // minx
            //
            this.minx.Location = new System.Drawing.Point(440, 17);
            this.minx.Name = "minx";
            this.minx.Size = new System.Drawing.Size(120, 20);
            this.minx.TabIndex = 9;
            this.minx.Text = "textBox1";
            //
            // Fractal
            //
            this.Fractal.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Fractal.Location = new System.Drawing.Point(8, 8);
            this.Fractal.Name = "Fractal";
            this.Fractal.Size = new System.Drawing.Size(352, 352);
            this.Fractal.TabIndex = 8;
            this.Fractal.TabStop = false;
            this.Fractal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Fractal_MouseUp);
            this.Fractal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Fractal_MouseMove);
            this.Fractal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Fractal_MouseDown);
            //
            // Selection
            //
            this.Selection.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Selection.Location = new System.Drawing.Point(160, 160);
            this.Selection.Name = "Selection";
            this.Selection.Size = new System.Drawing.Size(48, 40);
            this.Selection.TabIndex = 16;
            this.Selection.Visible = false;
            //
            // button2
            //
            this.button2.Location = new System.Drawing.Point(480, 408);
            this.button2.Name = "button2";
            this.button2.TabIndex = 17;
            this.button2.Text = "Reset";
            this.button2.Click += new System.EventHandler(this.Form1_Load);
            //
            // label3
            //
            this.label3.Location = new System.Drawing.Point(16, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 48);
            this.label3.TabIndex = 18;
            this.label3.Text = "W oknie po lewej zaznacz fragment do powiekszenia, badz wpisz  zakres recznie i n" +
            "acisnij \"Generuj\"";
            //
            // aIm
            //
            this.aIm.Location = new System.Drawing.Point(440, 152);
            this.aIm.Name = "aIm";
            this.aIm.Size = new System.Drawing.Size(120, 20);
            this.aIm.TabIndex = 20;
            this.aIm.Text = "textBox3";
            //
            // aRe
            //
            this.aRe.Location = new System.Drawing.Point(440, 128);
            this.aRe.Name = "aRe";
            this.aRe.Size = new System.Drawing.Size(120, 20);
            this.aRe.TabIndex = 19;
            this.aRe.Text = "textBox4";
            //
            // label4
            //
            this.label4.Location = new System.Drawing.Point(400, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "a (Re)";
            //
            // label5
            //
            this.label5.Location = new System.Drawing.Point(400, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "a (Im)";
            //
            // label6
            //
            this.label6.Location = new System.Drawing.Point(376, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "n";
            //
            // label7
            //
            this.label7.Location = new System.Drawing.Point(424, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "p(Re)^n";
            //
            // label8
            //
            this.label8.Location = new System.Drawing.Point(496, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "p(Im)^n";
            //
            // pr0
            //
            this.pr0.Location = new System.Drawing.Point(408, 208);
            this.pr0.Name = "pr0";
            this.pr0.Size = new System.Drawing.Size(72, 20);
            this.pr0.TabIndex = 26;
            this.pr0.Text = "textBox3";
            //
            // pi0
            //
            this.pi0.Location = new System.Drawing.Point(488, 208);
            this.pi0.Name = "pi0";
            this.pi0.Size = new System.Drawing.Size(72, 20);
            this.pi0.TabIndex = 27;
            this.pi0.Text = "textBox3";
            //
            // pi1
            //
            this.pi1.Location = new System.Drawing.Point(488, 232);
            this.pi1.Name = "pi1";
            this.pi1.Size = new System.Drawing.Size(72, 20);
            this.pi1.TabIndex = 29;
            this.pi1.Text = "textBox3";
            //
            // pr1
            //
            this.pr1.Location = new System.Drawing.Point(408, 232);
            this.pr1.Name = "pr1";
            this.pr1.Size = new System.Drawing.Size(72, 20);
            this.pr1.TabIndex = 28;
            this.pr1.Text = "textBox3";
            //
            // pi2
            //
            this.pi2.Location = new System.Drawing.Point(488, 256);
            this.pi2.Name = "pi2";
            this.pi2.Size = new System.Drawing.Size(72, 20);
            this.pi2.TabIndex = 31;
            this.pi2.Text = "textBox3";
            //
            // pr2
            //
            this.pr2.Location = new System.Drawing.Point(408, 256);
            this.pr2.Name = "pr2";
            this.pr2.Size = new System.Drawing.Size(72, 20);
            this.pr2.TabIndex = 30;
            this.pr2.Text = "textBox3";
            //
            // pi3
            //
            this.pi3.Location = new System.Drawing.Point(488, 280);
            this.pi3.Name = "pi3";
            this.pi3.Size = new System.Drawing.Size(72, 20);
            this.pi3.TabIndex = 33;
            this.pi3.Text = "textBox3";
            //
            // pr3
            //
            this.pr3.Location = new System.Drawing.Point(408, 280);
            this.pr3.Name = "pr3";
            this.pr3.Size = new System.Drawing.Size(72, 20);
            this.pr3.TabIndex = 32;
            this.pr3.Text = "textBox3";
            //
            // pi4
            //
            this.pi4.Location = new System.Drawing.Point(488, 304);
            this.pi4.Name = "pi4";
            this.pi4.Size = new System.Drawing.Size(72, 20);
            this.pi4.TabIndex = 35;
            this.pi4.Text = "textBox3";
            //
            // pr4
            //
            this.pr4.Location = new System.Drawing.Point(408, 304);
            this.pr4.Name = "pr4";
            this.pr4.Size = new System.Drawing.Size(72, 20);
            this.pr4.TabIndex = 34;
            this.pr4.Text = "textBox3";
            //
            // pi5
            //
            this.pi5.Location = new System.Drawing.Point(488, 328);
            this.pi5.Name = "pi5";
            this.pi5.Size = new System.Drawing.Size(72, 20);
            this.pi5.TabIndex = 37;
            this.pi5.Text = "textBox3";
            //
            // pr5
            //
            this.pr5.Location = new System.Drawing.Point(408, 328);
            this.pr5.Name = "pr5";
            this.pr5.Size = new System.Drawing.Size(72, 20);
            this.pr5.TabIndex = 36;
            this.pr5.Text = "textBox3";
            //
            // label9
            //
            this.label9.Location = new System.Drawing.Point(376, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 23);
            this.label9.TabIndex = 38;
            this.label9.Text = "0";
            //
            // label10
            //
            this.label10.Location = new System.Drawing.Point(376, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 23);
            this.label10.TabIndex = 39;
            this.label10.Text = "1";
            //
            // label11
            //
            this.label11.Location = new System.Drawing.Point(376, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 23);
            this.label11.TabIndex = 40;
            this.label11.Text = "2";
            //
            // label12
            //
            this.label12.Location = new System.Drawing.Point(376, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 23);
            this.label12.TabIndex = 41;
            this.label12.Text = "3";
            //
            // label13
            //
            this.label13.Location = new System.Drawing.Point(376, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 23);
            this.label13.TabIndex = 42;
            this.label13.Text = "4";
            //
            // label14
            //
            this.label14.Location = new System.Drawing.Point(376, 328);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 23);
            this.label14.TabIndex = 43;
            this.label14.Text = "5";
            //
            // colorSpeed
            //
            this.colorSpeed.Checked = true;
            this.colorSpeed.Location = new System.Drawing.Point(384, 360);
            this.colorSpeed.Name = "colorSpeed";
            this.colorSpeed.Size = new System.Drawing.Size(176, 16);
            this.colorSpeed.TabIndex = 44;
            this.colorSpeed.TabStop = true;
            this.colorSpeed.Text = "Koloruj szybkosc przyciagania";
            //
            // colorSet
            //
            this.colorSet.Location = new System.Drawing.Point(384, 384);
            this.colorSet.Name = "colorSet";
            this.colorSet.Size = new System.Drawing.Size(176, 16);
            this.colorSet.TabIndex = 45;
            this.colorSet.Text = "Koloruj zbior rozwiazania";
            //
            // Form1
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(568, 443);
            this.Controls.Add(this.colorSet);
            this.Controls.Add(this.colorSpeed);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pi5);
            this.Controls.Add(this.pr5);
            this.Controls.Add(this.pi4);
            this.Controls.Add(this.pr4);
            this.Controls.Add(this.pi3);
            this.Controls.Add(this.pr3);
            this.Controls.Add(this.pi2);
            this.Controls.Add(this.pr2);
            this.Controls.Add(this.pi1);
            this.Controls.Add(this.pr1);
            this.Controls.Add(this.pi0);
            this.Controls.Add(this.pr0);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.aIm);
            this.Controls.Add(this.aRe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Selection);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxy);
            this.Controls.Add(this.miny);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxx);
            this.Controls.Add(this.minx);
            this.Controls.Add(this.Fractal);
            this.Name = "Form1";
            this.Text = "Fraktale Newtona - www.algorytm.org (c) 2009 by Tomasz Lubinski";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        //for HSV colors
        private void HSV2RGB(float hue, float sat, float val, out float red, out float grn, out float blu)
        {
            int i;
            float f, p, q, t;
            red = 0; grn = 0; blu = 0;
            if (val == 0) { return; }
            else
            {
                hue /= 60;
                i = (int)(hue);
                f = hue - i;
                p = val * (1 - sat);
                q = val * (1 - (sat * f));
                t = val * (1 - (sat * (1 - f)));
                if (i == 0) { red = val; grn = t; blu = p; }
                else if (i == 1) { red = q; grn = val; blu = p; }
                else if (i == 2) { red = p; grn = val; blu = t; }
                else if (i == 3) { red = p; grn = q; blu = val; }
                else if (i == 4) { red = t; grn = p; blu = val; }
                else if (i == 5) { red = val; grn = p; blu = q; }
            }
        }

        //initialize color pens
        private void initializeColors()
        {
            float r, g, b;

            for (int i = 0; i < penColors.Length - 1; i++)
            {
                HSV2RGB((float)2.5 * i, (float)0.85, (float)0.8, out r, out g, out b);
                penColors[i] = new Pen(Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255)));
            }
            penColors[penColors.Length - 1] = new Pen(Color.FromArgb(0, 0, 0));
        }

        //complex addition
        private complex_t add(complex_t a, complex_t b)
        {
            complex_t result = new complex_t();

            result.real = a.real + b.real;
            result.imaginary = a.imaginary + b.imaginary;

            return result;
        }

        //complex substraction
        private complex_t sub(complex_t a, complex_t b)
        {
            complex_t result = new complex_t();

            result.real = a.real - b.real;
            result.imaginary = a.imaginary - b.imaginary;

            return result;
        }


        //complex multiplication
        private complex_t mul(complex_t a, complex_t b)
        {
            complex_t result = new complex_t();

            result.real = a.real * b.real - a.imaginary * b.imaginary;
            result.imaginary = a.real * b.imaginary + a.imaginary * b.real;

            return result;
        }

        //complex divide
        private complex_t div(complex_t a, complex_t b)
        {
            complex_t result = new complex_t();
            double x = b.real * b.real + b.imaginary * b.imaginary;

            result.real = (a.real * b.real + a.imaginary * b.imaginary) / x;
            result.imaginary = (a.imaginary * b.real - a.real * b.imaginary) / x;

            return result;
        }

        //func = a[0] + a[1]*z^1 + a[2]*z^2 + ... a[n]*z^2
        private complex_t func(complex_t z, complex_t[] a)
        {
            int i;
            complex_t result = new complex_t();

            result.real = 0;
            result.imaginary = 0;

            for (i = a.Length - 1; i >= 0; i--)
            {
                result = add(a[i], mul(result, z));
            }

            return result;
        }

        private int findResult(complex_t a)
        {
            int i;

            for (i = 0; i < resultsCnt; i++)
            {
                if (sub(a, results[i]).complexModSq() < 0.1)
                {
                    return i + 1;
                }
            }

            results[resultsCnt] = a;
            resultsCnt++;
            return resultsCnt;
        }

        /// <summary>
        /// Generates newton's fractal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            int i, j, level;
            complex_t p = new complex_t();
            complex_t a = new complex_t();
            complex_t[] w = new complex_t[6];
            complex_t[] d = new complex_t[5];

            Fractal.Image = new Bitmap(Fractal.Width, Fractal.Height);
            Graphics graph = Graphics.FromImage(Fractal.Image);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, Fractal.Width, Fractal.Height);

            minX = double.Parse(minx.Text);
            minY = double.Parse(miny.Text);
            maxX = double.Parse(maxx.Text);
            maxY = double.Parse(maxy.Text);

            for (i = 0; i < w.Length; i++)
            {
                w[i] = new complex_t();
            }
            for (i = 0; i < d.Length; i++)
            {
                d[i] = new complex_t();
            }

            w[0].real = double.Parse(pr0.Text);
            w[0].imaginary = double.Parse(pi0.Text);
            w[1].real = double.Parse(pr1.Text);
            w[1].imaginary = double.Parse(pi1.Text);
            w[2].real = double.Parse(pr2.Text);
            w[2].imaginary = double.Parse(pi2.Text);
            w[3].real = double.Parse(pr3.Text);
            w[3].imaginary = double.Parse(pi3.Text);
            w[4].real = double.Parse(pr4.Text);
            w[4].imaginary = double.Parse(pi4.Text);
            w[5].real = double.Parse(pr5.Text);
            w[5].imaginary = double.Parse(pi5.Text);

            d[0].real = double.Parse(pr1.Text);
            d[0].imaginary = double.Parse(pi1.Text);
            d[1].real = 2.0 * double.Parse(pr2.Text);
            d[1].imaginary = 2.0 * double.Parse(pi2.Text);
            d[2].real = 3.0 * double.Parse(pr3.Text);
            d[2].imaginary = 3.0 * double.Parse(pi3.Text);
            d[3].real = 4.0 * double.Parse(pr4.Text);
            d[3].imaginary = 4.0 * double.Parse(pi4.Text);
            d[4].real = 5.0 * double.Parse(pr5.Text);
            d[4].imaginary = 5.0 * double.Parse(pi5.Text);

            a.real = double.Parse(aRe.Text);
            a.imaginary = double.Parse(aIm.Text);

            ratioX = (maxX - minX) / Fractal.Width;
            ratioY = (maxY - minY) / Fractal.Height;

            resultsCnt = 0;
            cSet = colorSet.Checked;

            for (i = 0; i < Fractal.Height; i++)
            {
                p.imaginary = i * ratioY + minY;
                for (j = 0; j < Fractal.Width; j++)
                {
                    p.real = j * ratioX + minX;
                    level = levelSet(a, p, w, d);
                    graph.DrawRectangle(penColors[level - 1], j, i, 1, 1);
                }
            }
            Fractal.Invalidate();
        }

        //value is inside set in the returned level
        private int levelSet(complex_t a, complex_t p, complex_t[] w, complex_t[] d)
        {
            complex_t z = new complex_t();
            complex_t z_prev = new complex_t();
            int iteration;

            iteration = 0;
            z = p;

            do
            {
                z_prev = z;
                z = sub(z, mul(a, div(func(z, w), func(z, d))));
                iteration++;
            } while (sub(z_prev, z).complexModSq() > 0.0001 && iteration < 100);

            if (cSet == true)
            {
                if (iteration < 100)
                {
                    return 10 * findResult(z);
                }
            }

            return iteration;
        }

        //intialize form
        private void Form1_Load(object sender, System.EventArgs e)
        {
            minx.Text = ((double)-1.5).ToString();
            maxx.Text = ((double)1.5).ToString();
            miny.Text = ((double)-1.5).ToString();
            maxy.Text = ((double)1.5).ToString();

            aRe.Text = ((double)1.0).ToString();
            aIm.Text = ((double)0.0).ToString();

            pr0.Text = ((double)-1.0).ToString();
            pr1.Text = ((double)0.0).ToString();
            pr2.Text = ((double)0.0).ToString();
            pr3.Text = ((double)1.0).ToString();
            pr4.Text = ((double)0.0).ToString();
            pr5.Text = ((double)0.0).ToString();

            pi0.Text = ((double)0.0).ToString();
            pi1.Text = ((double)0.0).ToString();
            pi2.Text = ((double)0.0).ToString();
            pi3.Text = ((double)0.0).ToString();
            pi4.Text = ((double)0.0).ToString();
            pi5.Text = ((double)0.0).ToString();

            minX = double.Parse(minx.Text);
            minY = double.Parse(miny.Text);
            maxX = double.Parse(maxx.Text);
            maxY = double.Parse(maxy.Text);

            ratioX = (maxX - minX) / Fractal.Width;
            ratioY = (maxY - minY) / Fractal.Height;

            initializeColors();

            Fractal.Image = new Bitmap(Fractal.Width, Fractal.Height);
            graph = Graphics.FromImage(Fractal.Image);

            //render new fractal
            button1_Click(sender, e);
        }

        //draw selection
        private void Fractal_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                downX = e.X;
                downY = e.Y;

                Selection.Width = 0;
                Selection.Height = 0;
                Selection.Visible = true;
            }
        }

        //redraw selection
        private void Fractal_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Selection.Width = Math.Abs(downX - e.X);
                Selection.Height = Math.Abs(downY - e.Y);
                Selection.Left = Fractal.Left + Math.Min(downX, e.X);
                Selection.Top = Fractal.Top + Math.Min(downY, e.Y);
            }
        }

        //clear selection - render new fractal for given selection
        private void Fractal_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //remove selection
            Selection.Visible = false;

            //get new range to render
            minx.Text = (Math.Min(downX, e.X) * ratioX + minX).ToString();
            maxx.Text = (Math.Max(downX, e.X) * ratioX + minX).ToString();
            miny.Text = (Math.Min(downY, e.Y) * ratioY + minY).ToString();
            maxy.Text = (Math.Max(downY, e.Y) * ratioY + minY).ToString();

            minX = double.Parse(minx.Text);
            minY = double.Parse(miny.Text);
            maxX = double.Parse(maxx.Text);
            maxY = double.Parse(maxy.Text);

            //render new fractal
            button1_Click(sender, e);
        }
    }

    /// <summary>
    /// Class for complex numbers x = x.real + i*x.imaginary
    /// </summary>
    public class complex_t
    {
        public double real;
        public double imaginary;

        //calculate squared modus of given complex c
        public double complexModSq()
        {
            return (real * real + imaginary * imaginary);
        }
    }
}