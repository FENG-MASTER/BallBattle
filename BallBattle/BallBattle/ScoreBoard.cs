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

        private static ScoreBoard instance=null;

        private ScoreBoard(SpriteFont font) {
            this.font = font;
        }

        public void upDate() {
            score = PlayerBall.getInstance().getVal();
        }

        public static void init(SpriteFont font) {
            instance = new ScoreBoard(font);
        }

        public static ScoreBoard getInstance() {
            return instance;
        }

        public void addScore(int add){
            score += add;
        }

        public void subScore(int sub) {
            score -= sub;
        }

        public void onDraw(SpriteBatch sb) {
            sb.DrawString(font, "score:" + score.ToString()+" \n life:" + PlayerBall.getInstance().getLife().ToString(), Vector2.Zero, Color.White);
 
        }

    }
}
