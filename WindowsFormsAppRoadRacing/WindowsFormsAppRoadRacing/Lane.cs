using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppRoadRacing
{
    class Lane: Sprite
    {
        Brush _brush = new SolidBrush(Color.Black);
        private const int _width = 20;
        private const int _height = 100;
        public Lane(int x, int y, int speed): base(x, y, _width, _height, speed)
        {

        }

        public override void Display(Graphics paper)
        {
            paper.FillRectangle(_brush, X, Y, _width, _height);
        }

    }
}
