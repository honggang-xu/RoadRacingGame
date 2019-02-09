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
    public partial class Game : Form
    {
        List<Lane> _listLane;
        List<Opponent> _listOpponent;
        User _user;
        int _score;
        int _bestScore;
        int _difficulty;

        public Game()
        {
            InitializeComponent();

            _listLane = new List<Lane>();
            _listOpponent = new List<Opponent>();
            _user = new User(135, 350);

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
            _bestScore = 0;
            _difficulty = 5;
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

            _user.Display(paper);
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
                if (randomAppearance < _difficulty)
                {
                    Bitmap bitmap0 = Properties.Resources.opponent_blue;
                    Bitmap bitmap1 = Properties.Resources.opponent_orange;
                    Bitmap bitmap2 = Properties.Resources.opponent_green;

                    int randomNumber = _rand.Next(0, 3);
                    Bitmap bitmap = Properties.Resources.opponent_blue;
                    switch (randomNumber)
                    {
                        case 0:
                            bitmap = bitmap0;
                            break;
                        case 1:
                            bitmap = bitmap1;
                            break;
                        case 2:
                            bitmap = bitmap2;
                            break;
                    }

                    //opponent appear in three possible x position randomly and at random speed
                    Opponent opponent = new Opponent(arrayPositionOpponent[randomIndex], -100, randomSpeed, bitmap);
                    if (!CheckOpponentOverlap(opponent) && AllowUserToSurvive(opponent))
                    {
                        _listOpponent.Add(opponent);
                    }
                }
            }

            foreach (Opponent opponent in _listOpponent)
            {
                opponent.Move();
                
                if (_user.Collide(opponent))
                {
                    timerAnimation.Enabled = false;
                    timerSpeedUp.Enabled = false;
                    labelGameOver.Visible = true;

                    if (_bestScore < _score)
                    {
                        _bestScore = _score;
                    }
                }

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
            
            if (_score % 10 == 0)
            {
                if (_difficulty < 100)
                {
                    _difficulty++;
                }
            }

            labelCurrentScore.Text = "Score: " + _score.ToString();
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

        private bool AllowUserToSurvive(Opponent opponent)
        {
            if (_listOpponent.Count >= 2)
            {
                for (int i = 0; i < _listOpponent.Count; i++)
                {
                    Opponent opponent1 = _listOpponent[i];
                    for (int j = i + 1; j < _listOpponent.Count; j++)
                    {
                        Opponent opponent2 = _listOpponent[j];
                        if (opponent.Y + opponent.Height > opponent1.Y - 105 && opponent.Y < opponent1.Y + opponent1.Height + 105 &&
                            opponent.Y + opponent.Height > opponent2.Y - 105 && opponent.Y < opponent2.Y + opponent2.Height + 105)
                        {
                            return false;
                        }
                        else if (opponent.Speed != opponent1.Speed && opponent.Speed != opponent2.Speed)
                        {
                            return false;
                        }
                        else if (Math.Abs(opponent.X - opponent1.X) == 240 && opponent1.Y > opponent2.Y || Math.Abs(opponent.X - opponent2.X) == 240 && opponent2.Y > opponent1.Y )
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void PictureBoxRoadRacingMouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X - 35;
            if (x + _user.Width <= _pictureBoxRoadRacing.Width && x >= 0)
            {
                _user.Move(x);
            }
        }

        private void buttonStartClick(object sender, EventArgs e)
        {
            _difficulty = 5;

            if (_listOpponent != null)
            {
                _listOpponent.Clear();
            }

            foreach (Lane lane in _listLane)
            {
                lane.Speed = 1;
            }

            timerAnimation.Enabled = true;
            timerSpeedUp.Enabled = true;
            labelGameOver.Visible = false;
            if (_bestScore != 0)
            {
                labelBestScore.Text = "Best Score: " + _bestScore.ToString();
            }
            if (_score != 0)
            {
                _score = 0;
                labelCurrentScore.Text = "Score: ";
            }
        }
    }
}
