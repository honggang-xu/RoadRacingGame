using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsAppRoadRacing
{
    class Opponent : Sprite
    {
        Brush _brush = new SolidBrush(Color.Black);
        private const int _width = 60;
        private const int _height = 100;
        public Opponent(int x, int y, int speed): base(x, y, _width, _height, speed)
        {

        }

        public override void Display(Graphics paper)
        {
            paper.FillRectangle(_brush, X, Y, _width, _height);
        }

        public override int SpeedUp()
        {
            if (Speed < 15)
            {
                Speed++;
            }
            return Speed;
        }
    }
}
