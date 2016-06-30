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

        private Color r = Textures.getRandomColor();

        private SpriteFont font;

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
            font = Game.Content.Load<SpriteFont>(@"Fonts\\StartFont");
        

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

            GraphicsDevice.Clear(r);
            Color c = new Color(1, 1, 1);
            String str = "Eat More";
            sb.Begin();

            sb.DrawString(font, str, new Vector2(Game.Window.ClientBounds.Width / 2 - font.MeasureString(str).X / 2,
                Game.Window.ClientBounds.Height / 2 - font.MeasureString(str).Y / 2), Color.White);

            sb.End();
            base.Draw(gameTime);
        }



    }
}
