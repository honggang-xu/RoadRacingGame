namespace WindowsFormsAppRoadRacing
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxRoadRacing)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBoxRoadRacing
            // 
            this._pictureBoxRoadRacing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pictureBoxRoadRacing.Location = new System.Drawing.Point(12, 12);
            this._pictureBoxRoadRacing.Name = "_pictureBoxRoadRacing";
            this._pictureBoxRoadRacing.Size = new System.Drawing.Size(340, 500);
            this._pictureBoxRoadRacing.TabIndex = 0;
            this._pictureBoxRoadRacing.TabStop = false;
            this._pictureBoxRoadRacing.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxRoadRacingPaint);
            // 
            // timerAnimation
            // 
            this.timerAnimation.Enabled = true;
            this.timerAnimation.Interval = 1;
            this.timerAnimation.Tick += new System.EventHandler(this.TimerAnimationTick);
            // 
            // timerSpeedUp
            // 
            this.timerSpeedUp.Enabled = true;
            this.timerSpeedUp.Interval = 1000;
            this.timerSpeedUp.Tick += new System.EventHandler(this.TimerSpeedUpTick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(428, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this._pictureBoxRoadRacing);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxRoadRacing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBoxRoadRacing;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Timer timerSpeedUp;
        private System.Windows.Forms.TextBox textBox1;
    }
}

