using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Prototype
{
    public partial class Form1 : Form
    {

        static Image F1 = Prototype.Properties.Resources.walkF1;
        static Image F2 = Prototype.Properties.Resources.walkF2;
        static Image B1 = Prototype.Properties.Resources.walkB1;
        static Image B2 = Prototype.Properties.Resources.walkB2;
        static Image L1 = Prototype.Properties.Resources.walkL1;
        static Image L2 = Prototype.Properties.Resources.walkL2;
        static Image R1 = Prototype.Properties.Resources.walkR1;
        static Image R2 = Prototype.Properties.Resources.walkR2;
        static Image bush1 = Prototype.Properties.Resources.bush1;
        static Image fence = Prototype.Properties.Resources.fence;
        static Image coinFront = Prototype.Properties.Resources.coin;

        Image bob = F1;
        static int y = 100;
        static int x = 100;
        Rectangle bushBounds = new Rectangle(500, 300, 60, 40);

        struct obstacle
        {
            public Image imageName;
            public int xLoc;
            public int yLoc;
            public int width;
            public int height;
            public Rectangle bounds;
        }

        obstacle[] obstacles = new obstacle[3];
        List<obstacle> coinList = new List<obstacle>();
        int coins;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadObstaclesAndCoins()
        {
            obstacles[0] = new obstacle { imageName = fence, xLoc = 500, yLoc = 450, width = 48, height = 22, bounds = new Rectangle(500, 450, 48, 22) };
            obstacles[1] = new obstacle { imageName = fence, xLoc = 350, yLoc = 400, width = 48, height = 22, bounds = new Rectangle(350, 400, 48, 22) };
            obstacles[2] = new obstacle { imageName = fence, xLoc = 580, yLoc = 300, width = 48, height = 22, bounds = new Rectangle(580, 300, 48, 22) };

            

            coins = 0;
            int coinx = 400;
            for (int i = 0; i < 10; i++)
            {
                coinList.Add(new obstacle { imageName = coinFront, xLoc = coinx, yLoc = 400, width = 20, height = 20, bounds = new Rectangle(coinx, 400, 20, 20) });
                coinx += 40;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                if (bob == L1)
                {
                    bob = L2;
                }
                else
                {
                    bob = L1;
                }
                if (checkCollision())
                {
                    x = x + 7;
                }
                else if (checkCoins())
                {
                    x = x - 7;
                    if (x < 0)
                    {
                        x = pictureBox1.Width;
                    }
                }
            } // left

            pictureBox1.Refresh();
            pictureBox1.Update();

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                if (bob == R1)
                {
                    bob = R2;
                }
                else
                {
                    bob = R1;
                }
                if (checkCollision())
                {
                    x = x - 7;
                }
                else if (checkCoins())
                {
                    x = x + 7;

                    if (x < 0)
                    {
                        x = pictureBox1.Width;
                    }
                }
            } // right

            pictureBox1.Refresh();
            pictureBox1.Update();

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                if (bob == B1)
                {
                    bob = B2;
                }
                else
                {
                    bob = B1;
                }
                if (checkCollision())
                {
                    y = y + 7;
                }
                else if (checkCoins())
                {
                    y = y - 7;
                    if (x < 0)
                    {
                        x = pictureBox1.Width;
                    }
                }
            } // up

            pictureBox1.Refresh();
            pictureBox1.Update();

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                if (bob == F1)
                {
                    bob = F2;
                }
                else
                {
                    bob = F1;
                }
                if (checkCollision())
                {
                    y = y - 7;
                }
                else if (checkCoins())
                {
                    y = y + 7;
                    if (x < 0)
                    {
                        x = pictureBox1.Width;
                    }
                }
            } // down

            pictureBox1.Refresh();
            pictureBox1.Update();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bush1, 500, 300, 60, 40);
            e.Graphics.DrawRectangle(Pens.Red, bushBounds);

            for (int i = 0; i < 3; i++)
            {
                e.Graphics.DrawImage(obstacles[i].imageName, obstacles[i].xLoc, obstacles[i].yLoc, obstacles[i].width, obstacles[i].height);
            }
           
            e.Graphics.DrawImage(bob, x, y, 30, 40);
            
            if (coinList.Count > 0)
            {
                for (int i = 0; i < coinList.Count; i++)
                {
                    e.Graphics.DrawImage(coinList[i].imageName, coinList[i].xLoc, coinList[i].yLoc, coinList[i].width, coinList[i].height);
                }
            }

 
        }

        private Boolean checkCollision()
        {
            Boolean collision = false;
            Rectangle manBound = new Rectangle(x, y, 30, 40);
            for (int i = 0; i < 3; i++)
            {
                if (manBound.IntersectsWith(obstacles[i].bounds) || manBound.IntersectsWith(bushBounds))
                {
                    collision = true;
                }
            }
            return collision;
        }

        private Boolean checkCoins()
        {
            RectangleF manBound = new RectangleF(x, y, 30, 40);
            if (coinList.Count > 0)
            {
                for (int i = 0; i < coinList.Count; i++)
                {
                    if (manBound.IntersectsWith(coinList[i].bounds))
                    {
                        coinList.RemoveAt(i);
                        coins++;
                        label2.Text = coins.ToString();
                    }
                }
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            obstacles[0] = new obstacle
            {
                imageName = fence,
                xLoc = 500,
                yLoc = 450,
                width = 48,
                height = 22,
                bounds = new Rectangle(500, 450, 48, 22)
            };

            obstacles[1] = new obstacle
            {
                imageName = fence,
                xLoc = 350,
                yLoc = 400,
                width = 48,
                height = 22,
                bounds = new Rectangle(350, 400, 48, 22)
            };

            obstacles[2] = new obstacle
            {
                imageName = fence,
                xLoc = 580,
                yLoc = 300,
                width = 48,
                height = 22,
                bounds = new Rectangle(580, 300, 48, 22)
            };

            coins = 0;
            int coinx = 400;
            for (int i = 0; i < 10; i++)
            {
                coinList.Add(new obstacle()
                {
                    imageName = coinFront,
                    xLoc = coinx,
                    yLoc = 400,
                    width = 20,
                    height = 20,
                    bounds = new Rectangle(coinx, 400, 20, 20)
                });
                coinx = coinx + 40;
            }
        }
    }
}
