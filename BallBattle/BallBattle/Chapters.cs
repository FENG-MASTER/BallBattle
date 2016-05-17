using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BallBattle.Model.Interface;

namespace BallBattle
{
    class Chapters
    {
        private  class Chapter {
            public int point;//关卡要求分数
            public Color color;//关卡初始颜色
            public int speed;//关卡的球的基准速度
            public int genRate;//生成频率
            public List<BaseBall> balls;
            public List<int> rates;

            public Chapter(int p,Color c,int speed,int genRate,List<BaseBall> balls,List<int> rates){
                point=p;
                color=c;
                this.speed=speed;
                this.genRate=genRate;
                this.balls=balls;
                this.rates=rates;
            }

        }

        private int level=1;//当前关卡数

        private static List<Chapter> chapters;//关卡信息

        private static Chapters instance = new Chapters();

        public static Chapters getInstance() {
            return instance;
        }

        private Chapters(){
            //初始化关卡信息
            BaseBall ball1=new BaseBall();
            ball1.setRoad(new Rush(ball1));

            BaseBall ball2=new BaseBall();
            ball2.setRoad(new RandomRoad(ball2));
            chapters = new List<Chapter>{
                                        new Chapter(0,Color.Yellow,3,40,new List<BaseBall>{ball1,ball2},new List<int>{1,2}),
                                       new Chapter(0,Color.Red,8,10,new List<BaseBall>{ball1,ball2},new List<int>{1,20}),    
                                        };


        
        }

        private  Chapter getChapter(int num){
            if(num>chapters.Count){
                return null;
            }
            return chapters[num-1];
        }

        private Chapter getCurrentChapter() {
            return getChapter(level);
        }

        public int getLevel() {
            return level;
        }

        public int getCurrentChapterPoint() {
            return getCurrentChapter().point;
        }

        public int getCurrentChapterSpeed() {
            return getCurrentChapter().speed;
        }

        public int getCurrentChapterGenRate()
        {
            return getCurrentChapter().genRate;
        }

        public Color getCurrentChapterColor()
        {
            return getCurrentChapter().color;
        }

        public BaseBall getBaseBall(){
            int sum = 0;
            Random r = new Random();
            List<int> rates=getCurrentChapter().rates;
            foreach(int each in rates){
                sum += each;            
            }

            int ran=r.Next(0,sum);


            for (int i = 0; i < rates.Count;i++ )
            {
                

            }
            

            return null;
        }

        public void check() {
            PlayerBall player = PlayerBall.getInstance();

            if(player.getVal()>=getCurrentChapterPoint()){
                level++;
            }

            if(level==chapters.Count){
                //TODO:游戏胜利

            }

        
        }
        
        

    }
}
