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
    public class BallComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {

        private List<BaseBall> ballList = new List<BaseBall>();

        private SpriteBatch sb;
        private PlayerBall player;
        private WallManager wallmg;

        public BallComponent(Game game)
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
            player.upDate(Game.Window.ClientBounds);

            ScoreBoard.getInstance().upDate();


            if (wallmg.checkBall(player))
            {
                //越界要做的事情,默认把位置修改回   
            }

            foreach(BaseBall ball in ballList){
                ball.upDate(Game.Window.ClientBounds);
          
                
                if(ball.getRect().Intersects(player.getRect())){

                    if (ball.impactBall(player))
                    {
                        //小球被吃
                        removeList.Add(ball);

                    }
                    else
                    {
                        //被大的球吃到了
                        if(player.impactBall(ball)){//交给player处理事件,返回true表示游戏结束
                            //游戏结束


                        }
                        
                        Console.WriteLine("end");
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

           
            
            base.Update(gameTime);
        }
        

        protected override void LoadContent()
        {
            Textures.init(Game.Content.Load<Texture2D>(@"Images\\ball"), Game.Content.Load<Texture2D>(@"Images\\ball"));     //初始化全局纹理类      

            wallmg = new WallManager(Game.Window.ClientBounds);
            sb = new SpriteBatch(Game.GraphicsDevice);

         

            BaseBall ball1 = new BaseBall(Vector2.Zero,1,Textures.getInstance().baseBallTexture,40);
           // ball1.setRoad(new Rush(ball1));
            ball1.setRoad(new RandomRoad(ball1));
            ballList.Add(ball1);

            PlayerBall.init(new Vector2(100, 100), 6, Textures.getInstance().playerBallTexture, 50);
            player = PlayerBall.getInstance();
            
            base.LoadContent();
        }


        public override void Draw(GameTime gameTime)
        {

            sb.Begin(SpriteSortMode.FrontToBack,BlendState.AlphaBlend);
            player.Draw(sb);
            foreach (BaseBall ball in ballList)
            {
                ball.Draw(sb);
            }
            sb.End();

            base.Draw(gameTime);
        }
    }
}
