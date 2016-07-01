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

            return new Vector2(0, direction*1);
        }

        public override Vector2 getPosition()
        {
            Vector2 v = new Vector2(new Random().Next(WallManager.wallRect.Width), ball.getRect().Height * ball.scale);
            Console.WriteLine(v);
            return v;
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

            return base.isOutDo();
        }

    }
}
