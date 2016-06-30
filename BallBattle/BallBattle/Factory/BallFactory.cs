using BallBattle.Model.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBattle.Factory
{
    class BallFactory
    {

        private String impactType;
        private String roadType;
        private Textures.MyTexture texture;
        private Color color=Color.White;
        private int val;
        public BallFactory(Textures.MyTexture texture,Color c ,int val, String impactType, String roadType)
        {
            this.color = c;
            this.val = val;
            this.texture = texture;
            this.impactType = impactType;
            this.roadType = roadType;
            
        }

        public BaseBall built() {
            BaseBall ball = new BaseBall(color,Vector2.Zero,0,texture,val);
            ball.setColor(color);
            switch(impactType){
                default:
                    ball.setImpact(new ImpactInterface(ball));
                    break;
            
            }

            switch(roadType){
            
                case "Rush":
                    ball.setRoad(new Rush(ball));
                    break;
            
                case "RandomRoad":
                    ball.setRoad(new RandomRoad(ball));
                    break;

                default:
                    ball.setRoad(new RandomRoad(ball));
                    break;
            }


            return ball;
        
        
        }




    }
}
