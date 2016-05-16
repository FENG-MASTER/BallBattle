using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BallBattle.Model.Interface
{
    class Rush:
         RoadInterface
    {

        public Rush(BaseBall ball):base(ball)
        {
           
        }

        public override Vector2 getDirection()
        {
            Vector2 v=new Vector2(0,1);
            return v;
        }

    }
}
