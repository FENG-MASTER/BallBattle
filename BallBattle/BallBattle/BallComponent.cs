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

        private WallManager wallmg;//ǽ������

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

            if(PlayerBall.isEnd==true){
                Game1.gameState = 2;
                //Game.Exit();
           
            }
            
            List<BaseBall> removeList = new List<BaseBall>();
            PlayerBall.getInstance().upDate(Game.Window.ClientBounds);

            ScoreBoard.getInstance().upDate();

            if (wallmg.checkBall(PlayerBall.getInstance()))
            {
                //Խ��Ҫ��������,Ĭ�ϰ�λ���޸Ļ�   
            }

            foreach(BaseBall ball in ballList){
                ball.upDate(Game.Window.ClientBounds);


                if (ball.getRect().Intersects(PlayerBall.getInstance().getRect()))
                {

                    if (ball.impactBall(PlayerBall.getInstance()))
                    {
                        //С�򱻳�
                        removeList.Add(ball);

                    }
                    else
                    {
                        //�������Ե���
                        if (PlayerBall.getInstance().impactBall(ball))
                        {//����player�����¼�,����true��ʾ��Ϸ����
                            //�������
                            
                            
                        }
                        removeList.Add(ball);
                        
                    }
                    
                }
                
                
                if (!wallmg.checkBall(ball)&&ball.isOutDo())//��ⳬ��,���ҽ����������¼�
                {//����Ƿ񳬳��߽�
                    removeList.Add(ball);
                }
                
            }

           foreach(BaseBall rball in  removeList){
               ballList.Remove(rball);//ɾ�������߽����
           }

            //�����ؿ��� ���������
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
            PlayerBall.init(new Vector2(100, 100), 6, Textures.getInstance().playerBallTexture, 50);
            
            base.LoadContent();
        }


        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Textures.getBgcolor(Chapters.getInstance().getCurrentChapterColor()));
            sb.Begin(SpriteSortMode.FrontToBack,BlendState.AlphaBlend);

            PlayerBall.getInstance().Draw(sb);
            foreach (BaseBall ball in ballList)
            {
                ball.Draw(sb);
            }

            //�Ʒְ�
            ScoreBoard.getInstance().onDraw(sb);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
