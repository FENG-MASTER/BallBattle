using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBattle.Factory
{
    class BallFactory
    {

        private String impactType;
        private String roadType;
        public BallFactory(Vector2 postion, int speed, Texture2D texture, Point frameSize, Point sheetSize, int val, String impactType, String roadType)
        {
            this.impactType = impactType;
            this.roadType = roadType;
        }

        public BaseBall built() {
            BaseBall ball = new BaseBall();
            return null;
        
        
        }




    }
}
