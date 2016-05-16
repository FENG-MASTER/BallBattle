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
        private Texture2D texture;
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

            if (wallmg.checkBall(player))
            {
                //越界要做的事情,默认把位置修改回   
            }

            foreach(BaseBall ball in ballList){
                ball.upDate(Game.Window.ClientBounds);
                Console.WriteLine("Player:"+player.getRect());
                Console.WriteLine("Ball:" + ball.getRect());
                
                if(ball.getRect().Intersects(player.getRect())){
                    //检测碰撞
                    ScoreBoard.getInstance().addScore(ball.getVal());
                    removeList.Add(ball);
                }
                
                
                if (!wallmg.checkBall(ball))
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
            wallmg = new WallManager(Game.Window.ClientBounds);
            sb = new SpriteBatch(Game.GraphicsDevice);
            texture = Game.Content.Load<Texture2D>(@"Images\\ball");
            BaseBall ball1 = new BaseBall(Vector2.Zero,1, Vector2.Zero, texture, new Point(200, 200), new Point(1, 1),10);
            ball1.setRoad(new Rush(ball1));
            ballList.Add(ball1);
            player = new PlayerBall(new Vector2(100,100),6,texture,new Point(200,200),new Point(1,1),50);
            
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
