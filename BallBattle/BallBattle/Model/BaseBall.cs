using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BallBattle.Model.Interface;

namespace BallBattle
{
    class BaseBall
    {
        protected Vector2 postion;//当前位置
        protected int speed;//速度
        protected Vector2 direction;

        protected Texture2D texture;//图像纹理

        protected Rectangle rect;//球的大小(检测碰撞)
        private float scale;//用于缩放

        protected int val;//先假设val从1-100分吧,分数决定大小


        private Point currentFrame;//当前播放到的动画位置
        private Point frameSize;//每个动画大小
        private Point sheetSize;//动画表大小


        private ImpactInterface impactInterface;//碰撞器

        private RoadInterface roadInterface;//路径器


        public BaseBall(Vector2 postion, int speed,Vector2 direction, Texture2D texture, Point frameSize, Point sheetSize,int val)
        {
            this.postion = postion;
            this.speed = speed;
            this.direction = direction;
            this.texture = texture;
            this.frameSize = frameSize;
            this.sheetSize = sheetSize;
            impactInterface = new ImpactInterface(this);
            roadInterface = new RoadInterface(this);
            this.rect = new Rectangle((int)postion.X,(int)postion.Y,(int)texture.Width,(int)texture.Height);
            this.val = val;
        }

        public BaseBall() {
            this.postion = Vector2.Zero;
            this.speed = 1;
            this.direction = Vector2.Zero;
            this.texture = null ;
            this.currentFrame = new Point(1,1);
            this.frameSize = new Point(0, 0);
            this.sheetSize = new Point(1, 1);
            val = 1;
        }

      


        /*
         更新动画状态
         */

        public void upDate(Rectangle rect) {

            postion += (getDirection() * speed);

            this.rect.X = (int)postion.X;
            this.rect.Y = (int)postion.Y;
            this.rect.Height = (int)(val * (100 / (WallManager.wallRect.Height / 4.0)));
            this.rect.Width = this.rect.Height;
            scale =( (float)this.rect.Height) / texture.Height;
           

           
            currentFrame.X++;
            if(currentFrame.X>sheetSize.X){
                currentFrame.X = 1;
                currentFrame.Y++;
                if(currentFrame.Y>sheetSize.Y){
                    currentFrame.Y = 1;
                    currentFrame.X = 1;
                }
            }
        
        }

        public void addVal(int add)
        {
            val += add;

        }

        public Boolean impactBall(BaseBall ball) {
           return impactInterface.impact(ball);
        
        }

       virtual public Vector2 getDirection() {
           return roadInterface.getDirection();
        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(texture,
                postion,
                new Rectangle((currentFrame.X - 1) * sheetSize.X, (currentFrame.Y - 1) * sheetSize.Y, frameSize.X, frameSize.Y),
                Color.White,
                0,
                Vector2.Zero,
                scale,
                SpriteEffects.None,
                0);

        }


        public Vector2 getPosition() {
            return postion;
        
        }

        public void setPosition(Vector2 position) {
            this.postion = position;
        }

        public void setImpact(ImpactInterface impactInterface) {
            this.impactInterface = impactInterface;
        }

        public void setRoad(RoadInterface road) {
            this.roadInterface = road;
        }

        public Rectangle getRect() {
            return this.rect;
        }

        public int getVal() {
            return val;
        }

       virtual public Boolean isOutDo() {
           if (roadInterface == null)
           {
               return true;
           }
           else {
               return roadInterface.isOutDo();
           }
        
        }

        

    }
}
