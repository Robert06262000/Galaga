using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galaga_2
{
    public partial class Form1 : Form
    {
        bool moveLeft, moveRight, IsShooting, gameOver; //movement, shooting and game checks.
        int pSpd = 12; //player speed
        int eSpd = 3; //enemy speed
        int score = 0;
        int eShotTimer = 300; 

        PictureBox[] enemy; //Array for creating enemies

        private void Form1_KeyDown(object sender, KeyEventArgs e) //movement controls
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (IsShooting == false && e.KeyCode == Keys.Space) //Press space to shoot.
            {
                IsShooting = true;
                CreateShot("bullet");
            }
            if (gameOver == true && e.KeyCode == Keys.Enter) //Press enter to reset the game if it is over.
            {
                Reset();
                GameStart();
            }
        }
        public Form1()
        {
            InitializeComponent();
            GameStart();
        }

        private void PrimaryGameTimer(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score; //creates the score.
            if (moveLeft)
            {
                GShip.Left -= pSpd; //Left movement.
            }
            if (moveRight)
            {
                GShip.Left += pSpd; //Right movement.
            }

            eShotTimer -= 10; //constantly reduces.

            if (eShotTimer < 1)
            {
                eShotTimer = 300;
                CreateShot("enemyBullet"); //when the timer is back to defualt; the enemies fire a bullet.
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    x.Left += eSpd;
                    if (x.Left > 730) //if the enemy moves too far right, they are lowered.
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if (x.Bounds.IntersectsWith(GShip.Bounds)) //game over if you collide with the enemy.
                    {
                        GameOver("Game Over! You collided with an enemy!");
                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && (string)y.Tag == "bullet")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds)) //if you shoot an enemy.
                            {
                                //removes both the bullet and the enemy.
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                score += 1; //Increases score.
                                IsShooting = false; //reset ability to shoot.
                            }
                        }
                    }
                }

                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 20; //moves the bullet up.

                    if (x.Top < 15) //removes the bullet if it is too high.
                    {
                        this.Controls.Remove(x);
                        IsShooting = false; //resets shooting ability.
                    }
                }

                if (x is PictureBox && (string)x.Tag == "enemyBullet")
                {
                    x.Top += 20; //moves the bullet down.

                    if (x.Top > 620) //removes the bullet if it is too low.
                    {
                        this.Controls.Remove(x);
                    }

                    if (x.Bounds.IntersectsWith(GShip.Bounds)) //if the enemybullet collides with your ship.
                    {
                        this.Controls.Remove(x);
                        GameOver("Game Over! You have been shot down!"); //Gives the game over messaage.
                    }
                }
            }

            if (score > 8)
            {
                eSpd = 12; //Enemies speed up when a higher score is achieved!
            }

            if (score == (enemy.Length)) //if all enemies are destroyed.
            {
                GameOver("You have defeated the space villiany!"); //victory message. 
            }
        }
        private void GameStart()
        {
            //resets stats and score to default.
            lblScore.Text = "Score: 0"; //default 0 score.
            score = 0;
            eShotTimer = 300;
            pSpd = 12;
            eSpd = 3; //Enemy speed.
            gameOver = false;
            IsShooting = false;

            gameTime.Start(); //Starts the timer.
            CreateEnemy(); //spawns enemies.
        }

        private void GameOver(string end) //end = Message as to how you lost or won
        {
            gameOver = true;
            gameTime.Stop(); //stops the game
            lblScore.Text = "Your score was " + score + " " + end;
        }

        private void Reset()
        {
            foreach (PictureBox i in enemy)
            {
                this.Controls.Remove(i); //removes enemies.
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "bullet" || (string)x.Tag == "enemyBullet")
                    {
                        this.Controls.Remove(x); //removes bullets.
                    }
                }
            }
        }

        private void CreateShot(string shotTag) //bullet creation function.
        {
            PictureBox bullet = new PictureBox(); //creates a new picturebox for a bullet.
            bullet.Image = Properties.Resources.bulletgalaga; //adds image.
            bullet.Size = new Size(5, 20); //image size (width, height)
            bullet.Tag = shotTag; //creates tag for determining location of the bullet
            bullet.Left = GShip.Left + GShip.Width / 2; //sets starting location of bullet to the kiddle of the player.

            if ((string)bullet.Tag == "bullet")
            {
                bullet.Top = GShip.Top - 20; //places player bullet on top of player.
            }
            else if ((string)bullet.Tag == "enemyBullet")
            {
                bullet.Top = -100; //places enemy bullet off screen somewhat.
            }

            this.Controls.Add(bullet); //creates the bullet.
            bullet.BringToFront(); //ensures the bullet is in the front.
        }

        private void CreateEnemy()
        {
            enemy = new PictureBox[10]; //Creates enemies!

            int left = 0; //allows enemies to be off screen when just spawned

            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] = new PictureBox();
                enemy[i].Size = new Size(50, 40); //Sets the size
                enemy[i].Image = Properties.Resources.galagaenemyedited; //Picture
                enemy[i].Top = 5; //Position
                enemy[i].Tag = "enemy";
                enemy[i].Left = left; //causes enemies to appear from the left side of the screen.
                enemy[i].SizeMode = PictureBoxSizeMode.StretchImage; //allows image to appear full size in the picturebox.
                this.Controls.Add(enemy[i]); //creates enemy.
                left = left - 80; //Distances the enemies from each other.
            }
        }
    }
}
