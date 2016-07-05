using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBattle.Model.Interface
{
    /*
     * 线性路径器,按照竖着方向行走
     * 
     */
    class PlayerImpact
        :ImpactInterface
    {

        private PlayerBall player;
        public PlayerImpact(BaseBall p):base(p) {
            player = (PlayerBall)p;
        }


        public override bool impact(BaseBall otherBall)
        {
            if(player.getVal()<=otherBall.getVal()){
                //玩家被大球吃
                player.dead();
            }

            return true;
        }

        

    }
}
