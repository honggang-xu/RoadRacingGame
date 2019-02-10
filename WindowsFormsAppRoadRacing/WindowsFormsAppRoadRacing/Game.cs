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
        //instance variables
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
            //create a user
            _user = new User(135, 350);
            //create lanes
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
        /// <summary>
        /// Picture box paint event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxRoadRacingPaint(object sender, PaintEventArgs e)
        {
            Graphics paper = e.Graphics;
            //display every lane in the list for lane
            foreach (Lane lane in _listLane)
            {
                lane.Display(paper);
            }
            //display every opponent in the list for opponent
            foreach (Opponent opponent in _listOpponent)
            {
                opponent.Display(paper);
            }
            //display user
            _user.Display(paper);
        }
        /// <summary>
        /// Timer for the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerAnimationTick(object sender, EventArgs e)
        {
            int index= -1;
            //store three x position for opponent in an array
            int[] arrayPositionOpponent = { 20, 140, 260 };
            //create a random number
            Random _rand = new Random();
            foreach (Lane lane in _listLane)
            {
                //move all the lanes
                lane.Move();
                //if the lane is outside of the picture box, move it back to the top
                if (lane.Y > _pictureBoxRoadRacing.Height)
                {
                    lane.Y -= _pictureBoxRoadRacing.Height + lane.Height;
                }
            }
            //if the count of the list for opponent is less than 6
            if (_listOpponent.Count < 6)
            {
                int randomIndex = _rand.Next(0, 3);
                int randomAppearance = _rand.Next(100);
                int randomSpeed = _rand.Next(1, 10);
                //if the random number is less than the difficulty, then an opponent is created
                if (randomAppearance < _difficulty)
                {
                    Bitmap bitmap0 = Properties.Resources.opponent_blue;
                    Bitmap bitmap1 = Properties.Resources.opponent_orange;
                    Bitmap bitmap2 = Properties.Resources.opponent_green;
                    Bitmap bitmap = Properties.Resources.opponent_blue;
                    int randomNumber = _rand.Next(0, 3);
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

                    //opponent appear in three possible x position randomly and at random speed and using one of the three bitmaps
                    Opponent opponent = new Opponent(arrayPositionOpponent[randomIndex], -100, randomSpeed, bitmap);
                    //if opponent doesnot overlap with another opponent and there is space for user to pass between opponents
                    if (!CheckOpponentOverlap(opponent) && AllowUserToSurvive(opponent))
                    {
                        //add the created opponent to the list for opponent
                        _listOpponent.Add(opponent);
                    }
                }
            }
            foreach (Opponent opponent in _listOpponent)
            {
                //move every opponent in the list for opponent
                opponent.Move();
                //if user collide with an opponent
                if (_user.Collide(opponent))
                {
                    //stop all the timers
                    timerAnimation.Enabled = false;
                    timerSpeedUp.Enabled = false;
                    //show the label of Game Over
                    labelGameOver.Visible = true;
                    //store the best score
                    if (_bestScore < _score)
                    {
                        _bestScore = _score;
                    }
                }
                //if opponent is outside of the picture box, store its index value
                if (opponent.Y > _pictureBoxRoadRacing.Height)
                {
                    index = _listOpponent.IndexOf(opponent);
                }
            }
            //remove the opponent from the list
            if (index != -1)
            {
                _listOpponent.RemoveAt(index);
            }
            _pictureBoxRoadRacing.Refresh();
        }
        /// <summary>
        /// Timer for speed up the movement of object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSpeedUpTick(object sender, EventArgs e)
        {
            //speed up every lane
            foreach (Lane lane in _listLane)
            {
                lane.SpeedUp();
            }
            //speed up every opponent
            foreach (Opponent opponent in _listOpponent)
            {
                opponent.SpeedUp();
            }
            //increase the score
            _score++;
            //if the score is the power of 10
            if (_score % 10 == 0)
            {
                //if difficulty is less than 100, increase the difficulty
                if (_difficulty < 100)
                {
                    _difficulty++;
                }
            }
            labelCurrentScore.Text = "Score: " + _score.ToString();
        }
        /// <summary>
        /// Check whether two opponents overlap with each other
        /// </summary>
        /// <param name="opponent"></param>
        /// <returns></returns>
        private bool CheckOpponentOverlap(Opponent opponent)
        {
            if (_listOpponent != null)
            {
                foreach (Opponent existedOpponent in _listOpponent)
                {
                    //if they have the same x position
                    if (opponent.X == existedOpponent.X)
                    {
                        //if they overlap based on the y postion
                        if (opponent.Y + opponent.Height > existedOpponent.Y - 1 && opponent.Y < existedOpponent.Y + existedOpponent.Height + 1)
                        {
                            return true;
                        }
                        //if this opponent has faster speed than the existed opponent, they could still overlap later
                        else if (opponent.Speed > existedOpponent.Speed)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Check whether there is enough space for user to pass
        /// </summary>
        /// <param name="opponent"></param>
        /// <returns></returns>
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
                        //if the y postion of this opponent is not 105 larger than the one of other two opponents already existed in the list
                        if (opponent.Y + opponent.Height > opponent1.Y - 105 && opponent.Y + opponent.Height > opponent2.Y - 105)
                        {
                            return false;
                        }
                        //if the speed of this opponent is faster than both the existed opponents 
                        else if (opponent.Speed >= opponent1.Speed && opponent.Speed >= opponent2.Speed)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Move user according to the mouse move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxRoadRacingMouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X - 35;
            if (x + _user.Width <= _pictureBoxRoadRacing.Width && x >= 0)
            {
                _user.Move(x);
            }
        }
        /// <summary>
        /// Start button to start the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartClick(object sender, EventArgs e)
        {
            _difficulty = 5;
            //empty the list for opponent
            if (_listOpponent != null)
            {
                _listOpponent.Clear();
            }
            //set the speed of all the lanes to 1
            foreach (Lane lane in _listLane)
            {
                lane.Speed = 1;
            }
            timerAnimation.Enabled = true;
            timerSpeedUp.Enabled = true;
            labelGameOver.Visible = false;
            //display the best score
            if (_bestScore != 0)
            {
                labelBestScore.Text = "Best Score: " + _bestScore.ToString();
            }
            //set the score to 0
            if (_score != 0)
            {
                _score = 0;
                labelCurrentScore.Text = "Score: ";
            }
        }
    }
}
