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
            this.pictureBoxRoadRacing = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRoadRacing)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRoadRacing
            // 
            this.pictureBoxRoadRacing.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxRoadRacing.Name = "pictureBoxRoadRacing";
            this.pictureBoxRoadRacing.Size = new System.Drawing.Size(340, 500);
            this.pictureBoxRoadRacing.TabIndex = 0;
            this.pictureBoxRoadRacing.TabStop = false;
            this.pictureBoxRoadRacing.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxRoadRacingPaint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.pictureBoxRoadRacing);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRoadRacing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRoadRacing;
    }
}

