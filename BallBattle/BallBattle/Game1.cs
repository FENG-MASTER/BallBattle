using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BallBattle
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameComponent startComponent;//��Ϸ��ʼ
        MyGameComponent gameComponent;//��Ϸ
        GameComponent endComponent;//��Ϸ����

        SoundEffectInstance bgm;

        public static int gameState = 0;//��¼��Ϸ״̬,0�ǿ�ʼ����,1����Ϸ����ʱ��,2����Ϸ��������(ʧ��) 3��ͨ�ػ���

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;    // ���÷ֱ���
            graphics.PreferredBackBufferHeight = 600;
            //  graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            startComponent = new StartComponent(this);
            gameComponent = new MyGameComponent(this);
            endComponent = new EndComponent(this);
            Components.Add(startComponent);

            Resourse.init(Content);     //��ʼ��ȫ�������� ,Ӧ�÷���LoadContent��,�����Ե�ʱ���ֻ��ָ��,Ӧ������ִ����  Components��LoadContent,�Ż�����

            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            ScoreBoard.init(Resourse.getInstance().scoreFont, Resourse.getInstance().bigFont);
            bgm = Resourse.getInstance().bgm.CreateInstance();
            
            base.LoadContent();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

      

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
           
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            KeyboardState keystate = Keyboard.GetState();

            switch (gameState)
            {
                case 0:

                    //����ڿ�ʼ����
                    if (keystate.IsKeyDown(Keys.Enter))
                    {
                        gameState = 1;//������Ϸ״̬
                        Components.RemoveAt(0);
                        Components.Add(gameComponent);
                        Chapters.getInstance().init();
                        gameComponent.clear();
                        PlayerBall.init(new Vector2(100, 100), 6, Resourse.getInstance().playerBallTexture, 50);
                        bgm.Play();
                    }
                    break;
                case 1:
                    break;
                case 2:
                case 3:
                         bgm.Stop();
                        Components.RemoveAt(0);
                        Components.Add(endComponent);
                    if(keystate.IsKeyDown(Keys.Enter)){
                        gameState = 0;
                    }
                        
                    break;
            }





            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //���ְ�
            //  spriteBatch.Begin();
            //ScoreBoard.getInstance().onDraw(spriteBatch);
            // spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
