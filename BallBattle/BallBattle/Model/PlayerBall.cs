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
        public const int DEF_LIFE=3;

        private static PlayerBall bb;

        private static int life = DEF_LIFE;

       

   

        public static PlayerBall getInstance() {
            return bb;
        }

        public static void init(Vector2 postion, int speed, Resourse.MyTexture myTexture, int val)
        {
            bb = new PlayerBall(postion, speed, myTexture, val);
            bb.setImpact(new PlayerImpact(bb));
            life = DEF_LIFE;

        }
        
        
        private PlayerBall(Vector2 postion, int speed, Resourse.MyTexture myTexture,int val) 
            :base(Color.White,postion,speed, myTexture,val)
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
                LR = -1;
                v.X = 1;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                LR = 1;
                v.X = -1;
            }
            return v;
        
        }


        public void dead() {
               //死亡
            life--;
            if (life <= 0)
            {
                Game1.gameState = 2;
                Resourse.getInstance().endSound.Play();//播放死亡音效
                return;
            }

            val = 50;
            postion.X = WallManager.wallRect.Height / 2;
            postion.Y = WallManager.wallRect.Width / 2;

        
        }


        public int getLife() {
            return life;
        }


        public override void addVal(int add)
        {
            if(add>0){
              Resourse.getInstance().eat.Play();
            }else{
               Resourse.getInstance().deadSound.Play();
            }
            
            base.addVal(add);
        }


       



        

    }
}
