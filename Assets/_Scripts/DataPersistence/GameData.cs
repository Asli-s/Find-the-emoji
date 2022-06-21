using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public string lastPos;
    public int coinNumber;

    public int gameNumber;
    public int win;
    public int lose;


    public int score3;
    public int score2;
    public int score1;

    public bool sound;
    public bool music;
    public string savedTIme;

   public  int  secondsLeft;
    public int minutesLeft;

  public  bool timerActive;

    public bool restarted ;
    public bool notEnoughCoins;

    public int bestStreakStat;
    public int bestStreak;
    public int currentStreak;

    public bool isTablet ;
    public bool isPhone ;


    public bool firstTime;

    public int ExtraLive;
    public int ExtraCoin;

    public int ExtraSweetLolli;
    public int ExtraSweetBonBon;

    public int goldBag;

    public bool firstPresent;
      public int presentTimerSec;
    public bool presTImerActive;

    public bool gameActive;

    public bool findScreenActiveGame;


   /* public bool nextEssentialHeart;
    public bool nextEssential;

*/

    public GameData()
    {
        this.lastPos = "med";
        this.coinNumber  = 5;
        this.gameNumber = 0;

        this.win = 0;
        this.lose = 0;

        this.savedTIme ="";

        this.score3 = 0;
        this.score2 = 0;
        this.score1 = 0;

        this.sound = true;
        this.music = true;

        this.timerActive = false;

        this.secondsLeft = 0;
        this.minutesLeft = 0;

        this.sound = true;
        this.music = true;

        this.restarted = false;

        this.notEnoughCoins = false;

        this.bestStreakStat = 0;
        this.bestStreak = 0;
        this.currentStreak = 0;

        this.isPhone = false;
        this.isTablet = false;

        this.firstTime = true;


        this.ExtraCoin = 0;
        this.ExtraLive = 0;
        this.ExtraSweetBonBon = 0;
        this.ExtraSweetLolli = 0;

        this.goldBag = 0;

        this.firstPresent = false;

        this.presentTimerSec = 0;
        this.presTImerActive = false;
        this.gameActive= false;

        this.findScreenActiveGame = false;

    }


}
