using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBattle.Model.Interface
{
    class RandomRoad :
         RoadInterface
    {

        private Vector2 lastV;//上次的方向
        private Boolean isOut = false;//标记是否出界

        private int randomTime;

        public RandomRoad(BaseBall ball)
            : base(ball)
        {
            randomTime = new Random().Next(100);
        }

        public override Vector2 getDirection()
        {
            randomTime--;
            Random r = new Random();
            if (randomTime <= 0)
            {
                randomTime = new Random().Next(100);
                lastV = new Vector2(r.Next(-2, 2), r.Next(-2, 2));
            }
           
                return lastV;
        }

        public override bool isOutDo()
        {
            if (!base.isOutDo())
            {
                lastV = -lastV;
                isOut = true;
                return false;
            }
            else {
                return true;
            }
            
        }

    }
}
