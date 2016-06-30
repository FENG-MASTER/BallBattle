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


namespace BallBattle
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class StartComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch sb;

        private Textures.MyTexture bgTexture;//纹理对象,这个用来存开场背景

        private Point currentFrame = new Point(1, 1);//当前播放到的动画位置

        public StartComponent(Game game)
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

        protected override void LoadContent()
        {
            sb = new SpriteBatch(Game.GraphicsDevice);
            bgTexture = Textures.getInstance().startBackground;

        }


        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            sb.Begin();
            //             sb.Draw(bgTexture.texture,
            //                 new Vector2(Game.Window.ClientBounds.Width/2-bgTexture.texture.Width/2,
            //                 Game.Window.ClientBounds.Height/2-bgTexture.texture.Height/2),
            //                 
            //                 Color.White);
            sb.Draw(bgTexture.texture,
                     Vector2.Zero,
                       new Rectangle((currentFrame.X - 1) * bgTexture.sheetSize.X,
                    (currentFrame.Y - 1) * bgTexture.sheetSize.Y, bgTexture.frameSize.X, bgTexture.frameSize.Y),
                   Color.White,
                     0,
                     Vector2.Zero,
                     Game.Window.ClientBounds.Width / bgTexture.texture.Width,
                     SpriteEffects.None,
                     0);

            sb.End();


            base.Draw(gameTime);
        }



    }
}
