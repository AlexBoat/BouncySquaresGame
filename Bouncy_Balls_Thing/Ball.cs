using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncy_Balls_Thing
{
    internal class Ball
    {
        public int raza;
        public Point pozitie;
        public Color culoare;
        public int dx;
        public int dy;
        private Random rnd = new Random();
        public Ball(int razus, Point pozitius, Color culorus, int dxus, int dyus)
        {
            this.raza = razus;
            this.pozitie = pozitius;
            this.culoare = culorus;
            this.dx = dxus;
            this.dy = dyus;
        }
    }
}
