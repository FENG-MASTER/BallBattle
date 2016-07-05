using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BallBattle
{
    class ScoreBoard
    {
        private int score = 0;
        private SpriteFont font;
        private SpriteFont bigFont;

        private static ScoreBoard instance=null;

        private ScoreBoard(SpriteFont font,SpriteFont bigFont) {
            this.font = font;
            this.bigFont = bigFont;
        }

        public void init() {
            score = 0;        
        }

        public void upDate() {
            if(Game1.gameState!=1){
                init();
            }
           // score = PlayerBall.getInstance().getVal();
        }

        public static void init(SpriteFont font,SpriteFont bigFont) {
            instance = new ScoreBoard(font,bigFont);
        }

        public static ScoreBoard getInstance() {
            return instance;
        }

        public int addScore(int add){
            score += add;
            return score;
        }

        


        public void onDraw(SpriteBatch sb) {
            sb.DrawString(
                font, 
                "score:" + score.ToString()+" \n life:" + PlayerBall.getInstance().getLife().ToString(), 
                Vector2.Zero,
                Color.White,
                0,
                Vector2.Zero,
                1,
                SpriteEffects.None,
                1);
            
            sb.DrawString(
                 bigFont,
                 Chapters.getInstance().getLevel()+"",
                 new Vector2(WallManager.wallRect.Width/2,WallManager.wallRect.Height/2),
                 Chapters.getInstance().getCurrentChapterColor(),
                 0,
                 Vector2.Zero,
                 1,
                 SpriteEffects.None,
                 1);
 
        }

    }
}
