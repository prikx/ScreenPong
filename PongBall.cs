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
        int xSpeed;
        int ySpeed;
        
        public PongBall(Panel ballPanel, int width, int height)
        {
            this.ballPanel = ballPanel;
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
