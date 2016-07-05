using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace BallBattle
{
    class Resourse
    {
       
        public  class MyTexture {
            public Texture2D texture;
            public Point frameSize;//每个动画大小
            public Point sheetSize;//动画表大小

            public MyTexture(Texture2D t,Point fs,Point ss) {
                texture = t;
                frameSize = fs;
                sheetSize = ss;
            }
        
        }

        private static Resourse instance;

        public MyTexture baseBallTexture;

        public MyTexture playerBallTexture;

        public MyTexture gameBackground;

        public SpriteFont bigFont;

        public SpriteFont scoreFont;

        public SpriteFont startFont;

        public SoundEffect eat;

        public SoundEffect bgm;

        public SoundEffect deadSound;

        public SoundEffect endSound;

        public SoundEffect levelUp;

        public SoundEffect victory;

        public static void init(ContentManager cm)
        {
        
            instance = new Resourse(
                cm.Load<Texture2D>(@"Images\\bg"),
                cm.Load<Texture2D>(@"Images\\ball"),
                cm.Load<Texture2D>(@"Images\\player"),
                cm.Load<SpriteFont>(@"Fonts\\BigFont"),
                cm.Load<SpriteFont>(@"Fonts\\ScoreFont"),
                cm.Load<SpriteFont>(@"Fonts\\StartFont"),
                cm.Load<SoundEffect>(@"Sound\\eat"),
                cm.Load<SoundEffect>(@"Sound\\dead"),
                cm.Load<SoundEffect>(@"Sound\\end"),
                cm.Load<SoundEffect>(@"Sound\\bgm"),
                cm.Load<SoundEffect>(@"Sound\\levelUp"),
                cm.Load<SoundEffect>(@"Sound\\victory")
            );   
            
        
        }

        public static Resourse getInstance()
        {
            return instance;
        }

        private Resourse(Texture2D bg,Texture2D t1,Texture2D t2,
            SpriteFont bigFont,SpriteFont scoreFont,SpriteFont startFont,
            SoundEffect eat, SoundEffect deadsound,SoundEffect endSound,SoundEffect bgm,
            SoundEffect levelUp,SoundEffect v
            )
        {
            baseBallTexture = new MyTexture(t1,new Point(512, 298), new Point(2, 2));
            playerBallTexture = new MyTexture(t2, new Point(512, 298), new Point(2, 2));
            gameBackground = new MyTexture(bg, new Point(800,600), new Point(1, 1));
            this.bigFont = bigFont;
            this.scoreFont = scoreFont;
            this.startFont = startFont;
            this.eat = eat;
            this.bgm = bgm;
            this.deadSound = deadsound;
            this.endSound = endSound;
            this.levelUp = levelUp;
            this.victory = v;

        }

        public static Color getRandomColor() {
            Random r = new Random();
            return new Color(r.Next(255),r.Next(255),r.Next(255));
        }


    }
}
