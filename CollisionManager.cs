using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenOverlay
{
    class CollisionManager
    {

        int upperBounds;
        int lowerBounds;
        int rightBounds;
        int leftBounds;

        List<Rectangle> objects;


        public CollisionManager(Rectangle worldSpace, List<Rectangle> objects)
        {
            this.upperBounds = worldSpace.Top;
            this.lowerBounds = worldSpace.Bottom;
            this.rightBounds = worldSpace.Right;
            this.leftBounds = worldSpace.Left;

            this.objects = objects;
        }

        public bool objectCollisionCheck(PongBall ball)
        {
            foreach (Rectangle r in this.objects)
            {
                if (ball.getBallPanel().Bounds.IntersectsWith(r))
                {
                    ball.onPaddleCollision();
                    return true;
                }
            }
            return false;
        }

        public bool wallCollisionCheck(PongBall ball)
        {
            Rectangle ballBounds = ball.getBallPanel().Bounds;
            if (ballBounds.Top < this.upperBounds || ballBounds.Bottom > this.lowerBounds)
            {
                ball.onWallCollision();
                return true;
            }
            return false;
        }

        public bool winCheck(PongBall ball)
        {
            Rectangle ballBounds = ball.getBallPanel().Bounds;
            if (ballBounds.Right > this.rightBounds || ballBounds.Left < this.leftBounds)
            {
                return true;
            }
            return false;
        }
    }
}
