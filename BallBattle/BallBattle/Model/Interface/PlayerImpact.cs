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
        public PlayerImpact(BaseBall p):base(p) {
            player = (PlayerBall)p;
        }


        public override bool impact(BaseBall otherBall)
        {
            if(player.getVal()<otherBall.getVal()){
                //玩家被大球吃
                player.dead();
            }else if(player.getVal()==otherBall.getVal()){
                //TODO:相等的时候处理,现在这个不太好
                otherBall.addVal(-new Random().Next(otherBall.getVal()/2));
                player.addVal(-new Random().Next(player.getVal() / 2));
              
            }

            return true;
        }

        

    }
}
