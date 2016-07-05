using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBattle.Model.Interface
{
     class ImpactInterface
    {

        protected BaseBall ball;
        public ImpactInterface(BaseBall ball)
        {
            this.ball = ball;
        }

       public virtual Boolean impact(BaseBall otherBall) {
           if (ball.getVal() < otherBall.getVal())
           {
               otherBall.addVal(ball.getVal() / 10);
               ScoreBoard.getInstance().addScore(ball.getVal() / 10);
               return true;
           }
           else {
               
               return false;
           }
        }


    }
}
