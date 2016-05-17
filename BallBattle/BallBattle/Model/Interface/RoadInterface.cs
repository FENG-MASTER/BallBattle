using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BallBattle.Model.Interface
{
     class RoadInterface
    {

        protected BaseBall ball;
        public RoadInterface(BaseBall ball)
        {
            this.ball = ball;
        }
        public virtual Vector2 getDirection()
        {
            return Vector2.Zero;
       }

         
        public virtual Boolean isOutDo()
        {
            //该方法在球超界后调用,返回值表示是否清除
            return true;
        }
    }
}
