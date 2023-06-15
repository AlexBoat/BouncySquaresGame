using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncy_Balls_Thing
{
    internal class RepelentBall: Ball
    {
        public RepelentBall(int razus, Point pozitius, int dxus, int dyus)
        {
            this.raza = razus;
            this.pozitie = pozitius;
            this.culoare=Color.Gray;
            this.dx = dxus;
            this.dy = dyus;
            this.tip = 1;
        }

    }
}
