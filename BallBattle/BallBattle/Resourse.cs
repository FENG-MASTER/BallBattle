using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

        public MyTexture startBackground;

        public MyTexture gameBackground;

        public static void init(Texture2D bg,Texture2D t1, Texture2D t2)
        {
            instance = new Resourse(bg,t1,t2);   
        
        }

        public static Resourse getInstance()
        {
            return instance;
        }

        private Resourse(Texture2D bg,Texture2D t1,Texture2D t2) {
            baseBallTexture = new MyTexture(t1,new Point(512, 298), new Point(2, 2));
            playerBallTexture = new MyTexture(t2, new Point(512, 298), new Point(2, 2));
            gameBackground = new MyTexture(bg, new Point(800,600), new Point(1, 1)); ;

        }

        public static Color getRandomColor() {
            Random r = new Random();
            return new Color(r.Next(255),r.Next(255),r.Next(255));
        }


    }
}
