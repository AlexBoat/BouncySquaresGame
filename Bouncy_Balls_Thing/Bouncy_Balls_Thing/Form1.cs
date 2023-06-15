using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bouncy_Balls_Thing
{
    public partial class Form1 : Form
    {
        Color[] colors = new Color[7];
        List<Ball> bols;
        Random rnd = new Random();
        Bitmap bmp;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            colors[0]=Color.Yellow;
            colors[1]=Color.Aqua;
            colors[2]=Color.Red;
            colors[3]=Color.Magenta;
            colors[4]=Color.Lime;
            colors[5]=Color.Orange;
            colors[6] = Color.DarkOrchid;
        }

        bool start = false;
        private void button2_Click(object sender, EventArgs e)
        {
            start = !start;
            if(start==true)
            {
                button2.Text = "Pause";
                timer1.Start();
            }
            else
            {
                button2.Text = "Start";
                timer1.Stop();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            bols = new List<Ball>();
            int nrballs=rnd.Next(10, 26);
            int boltype;
            int razus;
            Point pozitius;
            Color culorus;
            int dxus;
            int dyus;
            for (int i=0; i<nrballs; i++)
            {
                boltype = rnd.Next(0, 7);
                switch(boltype)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        {
                            //regular
                            razus = rnd.Next(6, 21);
                            pozitius = new Point(rnd.Next(razus+5, pictureBox1.Width-razus-5), rnd.Next(razus+5, pictureBox1.Height-razus-5));
                            culorus = colors[rnd.Next(0, 7)];
                            viteza:
                            dxus=rnd.Next(-4, 5);
                            dyus=rnd.Next(-4, 5);
                            if (dxus == 0 && dyus == 0)
                                goto viteza;
                            bols.Add(new Ball(razus, pozitius, culorus, dxus, dyus));
                            break;
                        }
                    case 5:
                        {
                            //repelent
                            razus = rnd.Next(6, 10);
                            pozitius = new Point(rnd.Next(razus + 5, pictureBox1.Width - razus - 5), rnd.Next(razus + 5, pictureBox1.Height - razus - 5));
                            culorus = colors[rnd.Next(0, 7)];
                            vitezus:
                            dxus = rnd.Next(-4, 5);
                            dyus = rnd.Next(-4, 5);
                            if (dxus == 0 && dyus == 0)
                                goto vitezus;
                            bols.Add(new RepelentBall(razus, pozitius, dxus, dyus));
                            break;
                        }
                    case 6:
                        {
                            razus = rnd.Next(6, 17);
                            pozitius = new Point(rnd.Next(razus + 5, pictureBox1.Width - razus - 5), rnd.Next(razus + 5, pictureBox1.Height - razus - 5));
                            bols.Add(new MonsterBall(razus, pozitius));
                            //monster
                            break;
                        }
                }
            }
            foreach(Ball bol in bols)
            {
                g.FillEllipse(new SolidBrush(bol.culoare), bol.pozitie.X - 2, bol.pozitie.Y - 2, bol.raza, bol.raza);

            }
            pictureBox1.Image = bmp;
        }
        public double DistantaPuncte(Point A, Point B)
        {
            return Math.Sqrt(((B.X - A.X) * (B.X - A.X)) + ((B.Y - A.Y) * (B.Y - A.Y)));
        }
        int boltypus=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            foreach (Ball bol in bols.ToList())
            {
                bol.CalculatePoz();
                if (bol.pozitie.X + bol.raza >= pictureBox1.Width)
                {
                    bol.Invertdx();
                }
                if (bol.pozitie.X <= 1)
                {
                    bol.Invertdx();
                }
                if (bol.pozitie.Y + bol.raza >= pictureBox1.Height)
                {
                    bol.Invertdy();
                }
                if (bol.pozitie.Y <= 1)
                {
                    bol.Invertdy();
                }
                boltypus = bol.GetTip();

                foreach(Ball bolus in bols.ToList())
                {
                    if(bol==bolus)
                    {
                        continue;
                    }
                    if(DistantaPuncte(bol.pozitie, bolus.pozitie)<bol.raza+bolus.raza)
                    {
                        switch(boltypus)
                        {
                            case 0:
                                {
                                    if (bolus.GetTip() == 0)
                                    {
                                        if(bol.raza>bolus.raza)
                                        {
                                            bol.raza += bolus.raza;
                                            bols.Remove(bolus);
                                            if(bol.pozitie.X>pictureBox1.Width)
                                            {
                                                bol.pozitie.X = pictureBox1.Width - bol.raza - 1;
                                            }
                                            if (bol.pozitie.Y > pictureBox1.Height)
                                            {
                                                bol.pozitie.Y = pictureBox1.Height - bol.raza - 1;
                                            }
                                        }
                                        else
                                        {
                                            bolus.raza += bol.raza;
                                            bols.Remove(bol);
                                            if (bolus.pozitie.X > pictureBox1.Width)
                                            {
                                                bolus.pozitie.X = pictureBox1.Width - bolus.raza - 1;
                                            }
                                            if (bolus.pozitie.Y > pictureBox1.Height)
                                            {
                                                bolus.pozitie.Y = pictureBox1.Height - bolus.raza - 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (bolus.GetTip() == 1)
                                        {
                                            bol.Invertdx();
                                            bol.Invertdy();
                                        }
                                        else
                                        {
                                            bolus.raza += bol.raza;
                                            bols.Remove(bol);
                                            if (bolus.pozitie.X > pictureBox1.Width)
                                            {
                                                bolus.pozitie.X = pictureBox1.Width - bolus.raza - 1;
                                            }
                                            if (bolus.pozitie.Y > pictureBox1.Height)
                                            {
                                                bolus.pozitie.Y = pictureBox1.Height - bolus.raza - 1;
                                            }
                                        }
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (bolus.GetTip() == 0)
                                    {
                                        bolus.Invertdx();
                                        bolus.Invertdy();
                                    }
                                    else
                                    {
                                        if (bolus.GetTip() == 1)
                                        {
                                            //nimic
                                        }
                                        else
                                        {
                                            bol.raza /= 2;
                                            if (bol.raza >= 1)
                                                bols.Remove(bol);
                                        }
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (bolus.GetTip() == 0)
                                    {
                                        bol.raza += bolus.raza;
                                        bols.Remove(bolus);
                                        if (bol.pozitie.X > pictureBox1.Width)
                                        {
                                            bol.pozitie.X = pictureBox1.Width - bol.raza - 1;
                                        }
                                        if (bol.pozitie.Y > pictureBox1.Height)
                                        {
                                            bol.pozitie.Y = pictureBox1.Height - bol.raza - 1;
                                        }
                                    }
                                    else
                                    {
                                        if (bolus.GetTip() == 1)
                                        {
                                            bolus.raza /= 2;
                                            if (bolus.raza >= 1)
                                                bols.Remove(bolus);
                                        }
                                        else
                                        {
                                            //nimic
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            foreach (Ball bol in bols)
            {
                g.FillEllipse(new SolidBrush(bol.culoare), bol.pozitie.X - 2, bol.pozitie.Y - 2, bol.raza, bol.raza);
            }
            pictureBox1.Image = bmp;
        }
    }
}
