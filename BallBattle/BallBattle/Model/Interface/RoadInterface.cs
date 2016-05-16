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
    }
}
