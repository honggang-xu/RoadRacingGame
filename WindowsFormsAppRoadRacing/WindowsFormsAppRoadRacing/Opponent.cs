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
        private Bitmap _bitmap;

        public Opponent(int x, int y, int speed, Bitmap bitmap) : base(x, y, _width, _height, speed)
        {
            _bitmap = bitmap;
        }

        public override void Display(Graphics paper)
        {
            //paper.FillRectangle(_brush, X, Y, _width, _height);
            paper.DrawImage(_bitmap, X, Y);
            
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
