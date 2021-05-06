using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenOverlay
{
    class PongBall
    {
        private Panel ballPanel;
        private int originalX;
        private int originalY;
        int xSpeed;
        int ySpeed;

        public int OriginalX { get => originalX; set => originalX = value; }
        public int OriginalY { get => originalY; set => originalY = value; }

        public PongBall(Panel ballPanel)
        {
            this.ballPanel = ballPanel;
            this.originalX = ballPanel.Location.X;
            this.originalY = ballPanel.Location.Y;
            this.xSpeed = 8;
            this.ySpeed = 8;
        }

        public void moveTick()
        {
            int x = ballPanel.Location.X;
            int y = ballPanel.Location.Y;
            Point newPos = new Point(x + xSpeed, y + ySpeed);
            ballPanel.Location = newPos;
        }

        public void onWallCollision()
        {
            this.ySpeed = this.ySpeed * (-1);
        }

        public void onPaddleCollision()
        {
            this.xSpeed = this.xSpeed * (-1);
        }

        public Panel getBallPanel()
        {
            return this.ballPanel;
        }
    }
}
