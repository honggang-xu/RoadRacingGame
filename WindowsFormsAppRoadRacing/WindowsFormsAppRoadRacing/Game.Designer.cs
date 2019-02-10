namespace WindowsFormsAppRoadRacing
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._pictureBoxRoadRacing = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.timerSpeedUp = new System.Windows.Forms.Timer(this.components);
            this.labelGameOver = new System.Windows.Forms.Label();
            this.labelCurrentScore = new System.Windows.Forms.Label();
            this.labelBestScore = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxRoadRacing)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBoxRoadRacing
            // 
            this._pictureBoxRoadRacing.BackColor = System.Drawing.SystemColors.GrayText;
            this._pictureBoxRoadRacing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pictureBoxRoadRacing.Location = new System.Drawing.Point(12, 12);
            this._pictureBoxRoadRacing.Name = "_pictureBoxRoadRacing";
            this._pictureBoxRoadRacing.Size = new System.Drawing.Size(340, 500);
            this._pictureBoxRoadRacing.TabIndex = 0;
            this._pictureBoxRoadRacing.TabStop = false;
            this._pictureBoxRoadRacing.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxRoadRacingPaint);
            this._pictureBoxRoadRacing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxRoadRacingMouseMove);
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 1;
            this.timerAnimation.Tick += new System.EventHandler(this.TimerAnimationTick);
            // 
            // timerSpeedUp
            // 
            this.timerSpeedUp.Interval = 1000;
            this.timerSpeedUp.Tick += new System.EventHandler(this.TimerSpeedUpTick);
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameOver.ForeColor = System.Drawing.Color.Red;
            this.labelGameOver.Location = new System.Drawing.Point(384, 357);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(174, 47);
            this.labelGameOver.TabIndex = 2;
            this.labelGameOver.Text = "Game Over";
            this.labelGameOver.Visible = false;
            // 
            // labelCurrentScore
            // 
            this.labelCurrentScore.AutoSize = true;
            this.labelCurrentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentScore.Location = new System.Drawing.Point(398, 116);
            this.labelCurrentScore.Name = "labelCurrentScore";
            this.labelCurrentScore.Size = new System.Drawing.Size(55, 20);
            this.labelCurrentScore.TabIndex = 3;
            this.labelCurrentScore.Text = "Score:";
            // 
            // labelBestScore
            // 
            this.labelBestScore.AutoSize = true;
            this.labelBestScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBestScore.Location = new System.Drawing.Point(398, 62);
            this.labelBestScore.Name = "labelBestScore";
            this.labelBestScore.Size = new System.Drawing.Size(96, 20);
            this.labelBestScore.TabIndex = 4;
            this.labelBestScore.Text = "Best Score: ";
            // 
            // buttonStart
            // 
            this.buttonStart.AutoSize = true;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(435, 265);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 39);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStartClick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelBestScore);
            this.Controls.Add(this.labelCurrentScore);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this._pictureBoxRoadRacing);
            this.Name = "Game";
            this.Text = "Road Racing";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxRoadRacing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBoxRoadRacing;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Timer timerSpeedUp;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.Label labelCurrentScore;
        private System.Windows.Forms.Label labelBestScore;
        private System.Windows.Forms.Button buttonStart;
    }
}

