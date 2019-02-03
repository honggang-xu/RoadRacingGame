using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppRoadRacing
{
    public partial class Form1 : Form
    {
        List<Lane> _listLane;
        List<Opponent> _listOpponent;
        int _score;

        public Form1()
        {
            InitializeComponent();

            _listLane = new List<Lane>();
            _listOpponent = new List<Opponent>();

            Lane _lane1 = new Lane(100, 0, 1);
            Lane _lane2 = new Lane(100, 200, 1);
            Lane _lane3 = new Lane(100, 400, 1);
            Lane _lane4 = new Lane(220, 0, 1);
            Lane _lane5 = new Lane(220, 200, 1);
            Lane _lane6 = new Lane(220, 400, 1);

            _listLane.Add(_lane1);
            _listLane.Add(_lane2);
            _listLane.Add(_lane3);
            _listLane.Add(_lane4);
            _listLane.Add(_lane5);
            _listLane.Add(_lane6);
            _score = 0;
        }

        private void PictureBoxRoadRacingPaint(object sender, PaintEventArgs e)
        {
            Graphics paper = e.Graphics;
            
            foreach (Lane lane in _listLane)
            {
                lane.Display(paper);
            }

            foreach (Opponent opponent in _listOpponent)
            {
                opponent.Display(paper);
            }

        }

        private void TimerAnimationTick(object sender, EventArgs e)
        {
            int index= -1;
            //store three x position for opponent in an array
            int[] arrayPositionOpponent = { 20, 140, 260 };

            Random _rand = new Random();

            foreach (Lane lane in _listLane)
            {
                lane.Move();

                if (lane.Y > _pictureBoxRoadRacing.Height)
                {
                    lane.Y -= _pictureBoxRoadRacing.Height + lane.Height;
                }
            }

            if (_listOpponent.Count < 6)
            {
                int randomIndex = _rand.Next(0, 3);
                int randomAppearance = _rand.Next(100);
                int randomSpeed = _rand.Next(1, 10);
                if (randomAppearance < 4)
                {
                    //opponent appear in three possible x position randomly and at random speed
                    Opponent opponent = new Opponent(arrayPositionOpponent[randomIndex], -100, randomSpeed);
                    if (!CheckOpponentOverlap(opponent))
                    {
                        _listOpponent.Add(opponent);
                    }
                }
            }

            foreach (Opponent opponent in _listOpponent)
            {
                opponent.Move();
                if (opponent.Y > _pictureBoxRoadRacing.Height)
                {
                    index = _listOpponent.IndexOf(opponent);
                }
            }

            if (index != -1)
            {
                _listOpponent.RemoveAt(index);
            }

            _pictureBoxRoadRacing.Refresh();
        }

        private void TimerSpeedUpTick(object sender, EventArgs e)
        {
            foreach (Lane lane in _listLane)
            {
                lane.SpeedUp();
            }

            foreach (Opponent opponent in _listOpponent)
            {
                opponent.SpeedUp();
            }
            _score++;
            textBox1.Text = _score.ToString();
        }

        private bool CheckOpponentOverlap(Opponent opponent)
        {
            if (_listOpponent != null)
            {
                foreach (Opponent existedOpponent in _listOpponent)
                {
                    if (opponent.X == existedOpponent.X)
                    {
                        if (opponent.Y + opponent.Height > existedOpponent.Y - 1 && opponent.Y < existedOpponent.Y + existedOpponent.Height + 1)
                        {
                            return true;
                        }
                        else if (opponent.Speed > existedOpponent.Speed)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
