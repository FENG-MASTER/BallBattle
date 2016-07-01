using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BallBattle.Model.Interface
{
     class RoadInterface
    {

        protected BaseBall ball;

         protected int times_out=0;
         
        public RoadInterface(BaseBall ball)
        {
            this.ball = ball;
        }
        public virtual Vector2 getDirection()
        {
            return Vector2.Zero;
       }

        public virtual Vector2 getPosition()
        {
            return getRandPostion(new Rectangle(0, 0, 
                (int)(ball.getRect().Width*ball.scale),
                (int)(ball.getRect().Height*ball.scale)));
        }

         
        public virtual Boolean isOutDo()
        {
            //该方法在球超界后调用,返回值表示是否清除
            times_out++;
            if (times_out < 5)
            {
                return false;
            }
            else {

                return true;
            }
            
        }

        public  Vector2 getRandPostion(Rectangle rect)
        {
            //默认球生成位置算法 (随机)
            int ran = new Random().Next() % 4;
            Vector2 v = Vector2.Zero;
            switch (ran)
            {


                case 0:
                    v = new Vector2(rect.Width,
                        (float)(new Random().Next((int)(WallManager.wallRect.Height - rect.Width))));
                    break;

                case 1:
                    v = new Vector2(new Random().Next((int)(WallManager.wallRect.Width - rect.Width)),
                        rect.Width);
                    break;
                case 2:
                    v = new Vector2(WallManager.wallRect.Width - rect.Width,
                        new Random().Next((int)(WallManager.wallRect.Height - rect.Height)));
                    break;
                case 3:
                    v = new Vector2(new Random().Next((int)(WallManager.wallRect.Width - rect.Width)),
                        WallManager.wallRect.Height - rect.Height);
                    break;


            }


            return v;

        }

    }
}
