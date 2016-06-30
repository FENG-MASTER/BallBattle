using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BallBattle
{
    class Textures
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

        private static Textures instance;

        public MyTexture baseBallTexture;

        public MyTexture playerBallTexture;

        public MyTexture startBackground;

        public static void init(Texture2D t1, Texture2D t2)
        {
            instance = new Textures(t1,t2);   
        
        }

        public static Textures getInstance()
        {
            return instance;
        }

        private Textures(Texture2D t1,Texture2D t2) {
            baseBallTexture = new MyTexture(t1,new Point(200, 200), new Point(1, 1));
            playerBallTexture = new MyTexture(t2, new Point(200, 200), new Point(1, 1));
          

        }

        public static Color getRandomColor() {
            Random r = new Random();
            return new Color(r.Next(255),r.Next(255),r.Next(255));
        }

        public static Color getBgcolor(Color c) {
            return new Color(255-c.R,255-c.G,255-c.B);
        }


    }
}
