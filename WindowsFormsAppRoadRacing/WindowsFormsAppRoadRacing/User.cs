using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsAppRoadRacing
{
    class User : Sprite
    {
        //instance variables
        Brush _brush = new SolidBrush(Color.Red);
        private const int _width = 70;
        private const int _height = 100;
        private const int _speed = 0;
        private static Bitmap BITMAP = Properties.Resources.user_car;

        //constructor
        public User(int x, int y) : base(x, y, _width, _height, _speed)
        {

        }

        //methods
        public override void Display(Graphics paper)
        {
            paper.DrawImage(BITMAP, X, Y);
        }

        public void Move(int x)
        {
            this.X = x;
        }
        /// <summary>
        /// Detect whether user collide with another opponent
        /// </summary>
        /// <param name="opponent"></param>
        /// <returns></returns>
        public bool Collide(Opponent opponent)
        {
            if (this.X + this.Width > opponent.X && this.X < opponent.X + opponent.Width &&
                this.Y + this.Height > opponent.Y && this.Y < opponent.Y + opponent.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
