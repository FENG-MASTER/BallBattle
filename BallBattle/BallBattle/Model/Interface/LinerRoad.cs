using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BallBattle.Model.Interface
{
    class LinerRoad : RoadInterface
    {


        private int direction = 1;//
        
        public LinerRoad(BaseBall ball)
            : base(ball)
        {

        }

        public override Vector2 getDirection()
        {

            return new Vector2(direction*1,0 );
        }

        public override Vector2 getPosition()
        {
            return getLinerPostion(new Rectangle(0, 0,
                (int)(ball.getRect().Width * ball.scale),
                (int)(ball.getRect().Height * ball.scale)));
        }

        public override bool isOutDo()
        {
            times_out++;
            if (times_out < 6)
            {
                direction *= -1;
                return false;
            }
            else
            {

                return true;
            }

            
        }

        private Vector2 getLinerPostion(Rectangle rect)
        {
            return new Vector2(rect.Width,
                        (float)(new Random().Next((int)(WallManager.wallRect.Height - rect.Width))));
        }

    }
}
