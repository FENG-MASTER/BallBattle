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

       public virtual void impact() {
        
        }
    }
}
