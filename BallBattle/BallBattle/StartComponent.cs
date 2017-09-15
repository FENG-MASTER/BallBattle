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

        private Color r = Resourse.getRandomColor();

        private SpriteFont font;

        private bool pressed=false;

        private Rectangle stringRect;

        String str = "Eat More";

        public static bool start=false;

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
            font = Resourse.getInstance().startFont;
            stringRect = new Rectangle((int)(Game.Window.ClientBounds.Width / 2 - font.MeasureString(str).X / 2),
                (int)(Game.Window.ClientBounds.Height / 2 - font.MeasureString(str).Y / 2),
                (int)(font.MeasureString(str).X),
                (int)(font.MeasureString(str).Y));

        }


        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            
            MouseState state = Mouse.GetState();
            if ((state.X > stringRect.X && state.X < stringRect.X + stringRect.Width) && (state.Y > stringRect.Y && state.Y < stringRect.Height + stringRect.Y))
            {
                pressed = true;
                str = "start game";
                if(state.LeftButton==ButtonState.Pressed){
                    start = true;
                }          
            }
            else {
                pressed = false;
                str = "Eat More";
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

         //   GraphicsDevice.Clear(r);
            GraphicsDevice.Clear(Color.CadetBlue);
            Color c = new Color(1, 1, 1);
            
            sb.Begin();
            sb.DrawString(font, str, new Vector2(Game.Window.ClientBounds.Width / 2 - font.MeasureString(str).X / 2,
                Game.Window.ClientBounds.Height / 2 - font.MeasureString(str).Y / 2), pressed?Color.Yellow:Color.White);

            sb.End();
            base.Draw(gameTime);
        }



    }
}
