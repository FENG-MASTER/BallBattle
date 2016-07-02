using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BallBattle.Model.Interface
{
    class SubImpact:ImpactInterface
    {
        public SubImpact(BaseBall ball):base(ball) {

            ball.setColor(Color.Red);
        }


        public override bool impact(BaseBall otherBall)
        {
            
            if (ball.getVal() < otherBall.getVal())
            {
                otherBall.addVal(-ball.getVal() / 10);
                return true;
            }
            else
            {

                return false;
            }
        }


    }
}
