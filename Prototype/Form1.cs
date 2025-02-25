using System;
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

        Image bob = F1;
        static int y = 20;
        static int x = 20;
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
        public Form1()
        {
            InitializeComponent();
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
                if (!checkCollision())
                {
                    x = x - 10;
                }
                else
                {
                    x = x + 10;
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
                if (!checkCollision())
                {
                    x = x + 10;
                }
                else
                {
                    x = x - 10;
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
                if (!checkCollision())
                {
                    y = y - 10;
                }
                else
                {
                    y = y + 10;
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
                if (!checkCollision())
                {
                    y = y + 10;
                }
                else
                {
                    y = y - 10;
                }
            } // down

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bush1, 500, 300, 60, 40);
            e.Graphics.DrawRectangle(Pens.Red, bushBounds); 

            e.Graphics.DrawImage(bob, x, y, 30, 40);
        }

        private Boolean checkCollision()
        {
            Boolean collision = false;
            Rectangle manBound = new Rectangle(x, y, 30, 40);
            if (manBound.IntersectsWith(bushBounds))
            {
                collision = true;
            }
            return collision;
        }
    }
}
