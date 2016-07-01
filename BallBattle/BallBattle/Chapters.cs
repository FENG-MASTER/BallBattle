﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BallBattle.Model.Interface;
using BallBattle.Factory;

namespace BallBattle
{

    /*
     *关卡类,用于存储和控制所有关卡相关内容,
     * 包括
     * 1.关卡要求分数
     * 2,关卡的颜色
     * 3.关卡中的球的基础速度
     * 4.关卡中球生成的频率
     * 5.关卡中球的种类
     * 6.对应球的种类的生成比例
     * 
     */
    class Chapters
    {
        private  class Chapter {
            public int point;//关卡要求分数
            public Color color;//关卡初始颜色
            public int speed;//关卡的球的基准速度
            public int genRate;//生成频率
            public List<BallFactory> ballsf;
            public List<int> rates;

            public Chapter(int p, Color c, int speed, int genRate, List<BallFactory> ballsf, List<int> rates)
            {
                point=p;
                color=c;
                this.speed=speed;
                this.genRate=genRate;
                this.ballsf=ballsf;
                this.rates=rates;
            }

        }

        private int level=1;//当前关卡数

        private static List<Chapter> chapters;//关卡信息

        private static Chapters instance = new Chapters();

        private int times=0;
        public static Chapters getInstance() {
            return instance;
        }

        private Chapters(){
            //初始化关卡信息
            BallFactory f1 = new BallFactory(Textures.getInstance().baseBallTexture, Color.White, 10, "", "LinerRoad");

            BallFactory f2 = new BallFactory(Textures.getInstance().baseBallTexture, Color.White, 120, "", "LinerRoad");

            chapters = new List<Chapter>{
                                          new Chapter(0,Color.White,3,50,new List<BallFactory>{f1,f2},new List<int>{1,0}),                                        
                                          new Chapter(100,Color.Blue,4,50,new List<BallFactory>{f1,f2},new List<int>{8,3}),
                                          new Chapter(130,Color.Red,8,50,new List<BallFactory>{f1,f2},new List<int>{1,20}),    
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
            times++;
            if(times<getCurrentChapterGenRate()){
                return null;
            }
            times = 0;

            BaseBall gBall=null;


            int sum = 0;
            Random r = new Random();//随机数,用于随机取一个球
            List<int> rates=getCurrentChapter().rates;
            
      

            foreach(int each in rates){
                sum += each;            
            }
      
            int ran=r.Next(0,sum);



            int a=0;
            for (int i = 0; i < rates.Count; i++)
            {
               
                if(a<=ran&&(a+rates[i])>=ran){
                    gBall = getCurrentChapter().ballsf[i].built();
                    break;
                }
                a += rates[i];         
            }

   

            gBall.setSpeed(getCurrentChapterSpeed());
            gBall.setColor(getCurrentChapterColor());

            return gBall;
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
