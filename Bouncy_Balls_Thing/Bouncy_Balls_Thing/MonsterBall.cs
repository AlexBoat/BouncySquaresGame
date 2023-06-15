using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncy_Balls_Thing
{
    internal class MonsterBall: Ball
    {
        public MonsterBall(int razus, Point pozitius)
        {
            this.raza = razus;
            this.pozitie = pozitius;
            this.culoare = Color.Black;
            this.dx = 0;
            this.dy = 0;
            this.tip = 2;
        }
    }
}
