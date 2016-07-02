using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BallBattle
{
    class WallManager
    {
       static public Rectangle wallRect;

        public WallManager(Rectangle rect) {
            wallRect = rect;
            
        }

        public Boolean checkBall(BaseBall ball) {
            if (ball is PlayerBall)
            {
                Vector2 oldPo = ball.getPosition();
        
                if (oldPo.X < 0)
                {
                    oldPo.X = wallRect.Width - ball.getRect().Width;
                }
                if (oldPo.Y < 0)
                {
                    oldPo.Y = 0;
                }
                if (oldPo.X >( wallRect.Width-ball.getRect().Width))
                {
                    oldPo.X = (ball.getRect().Width);
                }
                if (oldPo.Y > (wallRect.Height-ball.getRect().Height))
                {
                    oldPo.Y = (wallRect.Height - ball.getRect().Height);
                }

                
                ball.setPosition(oldPo);
                return true;
            }
            else 
            {

                Vector2 oldPo = ball.getPosition();

                if (oldPo.X < 0 || oldPo.Y < 0 || oldPo.X > wallRect.Width-ball.getRect().Width || oldPo.Y > wallRect.Height-ball.getRect().Height)
                {
                    return false;
                }
                else 
                {
                    return true;
                }
                
            
            }

        }
    }
}
