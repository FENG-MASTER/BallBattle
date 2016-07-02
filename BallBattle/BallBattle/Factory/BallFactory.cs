using BallBattle.Model.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBattle.Factory
{

    /*球工厂类,用于生成特定组合形式的球
     */
    class BallFactory
    {

        private String impactType;//碰撞器
        private String roadType;//路径器
        private Resourse.MyTexture texture;//纹理
        private Color color=Color.White;//颜色
        private int val;
        public BallFactory(Resourse.MyTexture texture,Color c , String impactType, String roadType)
        {
            this.color = c;
            this.texture = texture;
            this.impactType = impactType;
            this.roadType = roadType;
            
        }

        public BaseBall built(int val) {
            BaseBall ball = new BaseBall(color,Vector2.Zero,0,texture,val);
            ball.setColor(color);
            switch(impactType){
                case "SubImpact":
                    ball.setImpact(new SubImpact(ball));
                    break;
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

                case "LinerRoad":
                    ball.setRoad(new LinerRoad(ball));
                    break;

                default:
                    ball.setRoad(new RandomRoad(ball));
                    break;
            }


            return ball;
        
        
        }




    }
}
