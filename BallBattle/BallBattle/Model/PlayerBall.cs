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
        public const int DEF_LIFE=1;

        private static PlayerBall bb;

        private static int life = DEF_LIFE;

     //   public static int gameState=0;//0游戏中 1失败 2通关

        public static PlayerBall getInstance() {
            return bb;
        }

        public static void init(Vector2 postion, int speed, Resourse.MyTexture myTexture, int val)
        {
            bb = new PlayerBall(postion, speed, myTexture, val);
            bb.setImpact(new PlayerImpact(bb));
       //     gameState = 0;
            life = DEF_LIFE;

        }
        
        
        private PlayerBall(Vector2 postion, int speed, Resourse.MyTexture myTexture,int val) 
            :base(Color.Black,postion,speed, myTexture,val)
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
            life--;
            val = 20;
            postion.X = WallManager.wallRect.Height / 2;
            postion.Y = WallManager.wallRect.Width / 2;
            if(life<=0){
                Game1.gameState = 2;
               // gameState=1;
            }
            
        
        }


        public int getLife() {
            return life;
        }


       



        

    }
}
