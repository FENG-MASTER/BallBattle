using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBattle.Model.Interface
{
    class PlayerImpact
        :ImpactInterface
    {

        private PlayerBall player;
        public PlayerImpact(PlayerBall player):base(player) {
        
        }


        public override bool impact(BaseBall otherBall)
        {
            if(player.getVal()<otherBall.getVal()){
                //玩家被大球吃

                
            }

            return true;
        }

        

    }
}
