using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bouncy_Balls_Thing
{
    internal class Ball
    {
        public int raza;
        public Point pozitie;
        public Color culoare;
        protected int dx;
        protected int dy;
        protected int tip;

        public Ball()
        {
            this.raza = 3;
            this.pozitie=new Point(0, 0);
            this.culoare = Color.Blue;
            this.dx = 1;
            this.dy = 1;
            this.tip = 0;
        }
        public Ball(int razus, Point pozitius, Color culorus, int dxus, int dyus)
        {
            this.raza = razus;
            this.pozitie = pozitius;
            this.culoare = culorus;
            this.dx = dxus;
            this.dy = dyus;
            this.tip = 0;
        }
        
        public void SetRaza(int amount)
        {
            this.raza = amount;
        }
        public void CalculatePoz()
        {
            this.pozitie.X = this.pozitie.X + this.dx;
            this.pozitie.Y = this.pozitie.Y + this.dy;
        }
        public void Invertdx()
        {
            this.dx = -dx;
        }
        public void Invertdy()
        {
            this.dy = -dy;
        }
        public int GetTip()
        {
            return this.tip;
        }
    }
}
