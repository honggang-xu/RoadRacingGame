using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppRoadRacing
{
    class Lane : Sprite
    {
        //instance variables
        Brush _brush = new SolidBrush(Color.White);
        private const int _width = 20;
        private const int _height = 100;

        //constructor
        public Lane(int x, int y, int speed) : base(x, y, _width, _height, speed)
        {

        }

        //methods
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
