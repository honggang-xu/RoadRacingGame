using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppRoadRacing
{
    abstract class Sprite
    {
        //instance variables
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _speed;

        //constructor
        public Sprite(int x, int y, int width, int height, int speed)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _speed = speed;
        }

        //properties
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        //methods
        public abstract void Display(Graphics paper);

        public void Move()
        {
            _y += _speed;
        }

        public virtual int SpeedUp()
        {
            return _speed;
        }
    }
}
