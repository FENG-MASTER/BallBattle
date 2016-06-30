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

        public static void init(Texture2D t1, Texture2D t2,Texture2D startBg)
        {
            instance = new Textures(t1,t2,startBg);   
        
        }

        public static Textures getInstance()
        {
            return instance;
        }

        private Textures(Texture2D t1,Texture2D t2,Texture2D startBg) {
            baseBallTexture = new MyTexture(t1,new Point(200, 200), new Point(1, 1));
            playerBallTexture = new MyTexture(t2, new Point(200, 200), new Point(1, 1));
            startBackground = new MyTexture(startBg,new Point(800,600),new Point(1,1));

        }


    }
}
