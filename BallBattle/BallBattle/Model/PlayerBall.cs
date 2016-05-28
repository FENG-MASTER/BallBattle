using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BallBattle.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using BallBattle.Model.Interface;


namespace BallBattle
{
    class PlayerBall:
        BaseBall
    {
        private static PlayerBall bb;

        public static PlayerBall getInstance() {
            return bb;
        }

        public static void init(Vector2 postion, int speed, Textures.MyTexture myTexture, int val)
        {
            bb = new PlayerBall(postion, speed, myTexture, val);
            bb.setImpact(new PlayerImpact(bb));
        }
        
        
        private PlayerBall(Vector2 postion, int speed, Textures.MyTexture myTexture,int val) 
            :base(postion,speed, myTexture,val)
        {
            
        
        
        }

       

        public override Vector2 getDirection()
        {
            Vector2 v = new Vector2(0,0);
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Up))
            {
                v.Y = -1;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                v.Y = 1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                v.X = 1;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                v.X = -1;
            }
            return v;
        
        }


        public void dead() {
               //死亡
            val = 20;

        
        }



        

    }
}
