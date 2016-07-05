using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using BallBattle.Model.Interface;


namespace BallBattle
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class MyGameComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {

        private List<BaseBall> ballList = new List<BaseBall>();

        private SpriteBatch sb;

        private WallManager wallmg;//墙管理类

        public MyGameComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

       
            
            List<BaseBall> removeList = new List<BaseBall>();
            PlayerBall.getInstance().upDate(Game.Window.ClientBounds);

            ScoreBoard.getInstance().upDate();

            if (wallmg.checkBall(PlayerBall.getInstance()))
            {
                //越界要做的事情,默认把位置修改回   
            }

            foreach(BaseBall ball in ballList){
                ball.upDate(Game.Window.ClientBounds);


                if (ball.getRect().Intersects(PlayerBall.getInstance().getRect()))
                {

                    if (ball.impactBall(PlayerBall.getInstance()))
                    {
                        //小球被吃
                   
                
                        removeList.Add(ball);

                    }
                    else
                    {
                        //被大的球吃到了
                        if (PlayerBall.getInstance().impactBall(ball))
                        {//交给player处理事件,返回true表示游戏结束
                            //玩家死亡
                            
                            
                        }
                        removeList.Add(ball);
                        
                    }
                    
                }
                
                
                if (!wallmg.checkBall(ball)&&ball.isOutDo())//检测超界,并且交给球处理超界事件
                {//检测是否超出边界
                    removeList.Add(ball);
                }
                
            }

           foreach(BaseBall rball in  removeList){
               ballList.Remove(rball);//删除超出边界的球
           }

            //交给关卡类 随机生成球
           BaseBall newball = Chapters.getInstance().getBaseBall();
           if (newball != null)
           {
               ballList.Add(newball);
           }

           Chapters.getInstance().check();
            
            base.Update(gameTime);
        }
        

        protected override void LoadContent()
        {
         
            wallmg = new WallManager(Game.Window.ClientBounds);
            sb = new SpriteBatch(Game.GraphicsDevice);
            PlayerBall.init(new Vector2(100, 100), 6, Resourse.getInstance().playerBallTexture, 50);
            
            base.LoadContent();
        }


        public override void Draw(GameTime gameTime)
        {
            
            sb.Begin(SpriteSortMode.FrontToBack,BlendState.AlphaBlend);


            sb.Draw(Resourse.getInstance().gameBackground.texture,
                 Vector2.Zero,
                new Rectangle(0,0,
                   Resourse.getInstance().gameBackground.frameSize.X,
                    Resourse.getInstance().gameBackground.frameSize.Y),
                Color.White,
                0,
                Vector2.Zero,
                1,
                SpriteEffects.None,
                0);




            PlayerBall.getInstance().Draw(sb);
            foreach (BaseBall ball in ballList)
            {
                ball.Draw(sb);
            }

            //计分板
            ScoreBoard.getInstance().onDraw(sb);
            sb.End();

            base.Draw(gameTime);
        }

        public void clear() {
            ballList.Clear();
        }
    }
}
