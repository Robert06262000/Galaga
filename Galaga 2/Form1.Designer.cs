namespace Galaga_2
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
            this.GShip = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GShip)).BeginInit();
            this.SuspendLayout();
            // 
            // GShip
            // 
            this.GShip.Image = global::Galaga_2.Properties.Resources._976ced117d8e39ac73d32b28f77b707b__space_ship__bit;
            this.GShip.Location = new System.Drawing.Point(230, 361);
            this.GShip.Name = "GShip";
            this.GShip.Size = new System.Drawing.Size(73, 62);
            this.GShip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GShip.TabIndex = 0;
            this.GShip.TabStop = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblScore.Location = new System.Drawing.Point(12, 410);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(55, 17);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Score: 0";
            // 
            // gameTime
            // 
            this.gameTime.Interval = 20;
            this.gameTime.Tick += new System.EventHandler(this.PrimaryGameTimer);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Galaga_2.Properties.Resources.shining_stars_messengers_in_churches1_1024x690;
            this.ClientSize = new System.Drawing.Size(567, 435);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.GShip);
            this.Name = "Form1";
            this.Text = "Galaga 2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.GShip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GShip;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer gameTime;
    }
}

