using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Globalization;



/**/


public class GameManager : MonoBehaviour, IDataPersistence
{
    public int gameCount = 0;
    [SerializeField] public TMPro.TextMeshProUGUI m_Object;
    public int coinNum;
    public int score = 0;
    public int lastPosition; // loaded pos
    public int lastPositionCurrent; // get currentPos
    public string positionStringLoad = "";
    public string positionStringSave = "";

    public int win;
    public int lose;
    public int score1;
    public int score2;
    public int score3;

    [SerializeField] public GameObject BonusBackGroundImage;


    public int ExtraLife=0;
    public int ExtraCoin=0;
    public int ExtraSweetBonbon=0;
    public int ExtraSweetLolli=0; //hammer?


    public int goldBag = 0;

    public bool bonusOn =false;
    public bool yellowPresentBonus = false;
    public bool greenPresentBonus = false;
    public bool bluePresentBonus = false;
    public bool darkBluePresentBonus = false;
    public bool redPresentBonus = false;
    public bool lilaPresentBonus = false;
    public bool rainbowPresentBonus = false;
    public bool rainbowPresentBonus2 = false;
    public bool rainbowPresentBonus3 = false;
    public bool rainbowPresentBonus4 = false;
    public bool rainbowPresentBonus5 = false;
    public bool rainbowPresentBonus6 = false;
   


    public bool watchedAd = false;

    public bool bonusCollectAsManyAlertActive = false;

    public GameObject SweetCoverHammer;
    public GameObject SweetCoverGlass;
    public GameObject InvCoverHammer;
    public GameObject ShopCoverGlass;

    public GameObject BonusScreen;
    public GameObject BonusFirstAlert;

    public GameObject EssentialScreen;
    public int presTimerSeconds = 0;

    public bool popBonus =false;

    public bool adNoCoinScreenClicked = false;


    public bool notClickable = false;


    public bool firstTime = false;
    public bool firstFindScreen = false;
    public bool firstFeatureTile = false;
    public bool firstFeatureTileAlreadyShown = false;
    

    public bool firstBoardTile = false;
    public bool firstWin = false;


    public DateTime toSaveDatetime;
    public string toSaveDatetimeString;
    public string savedate;

    public bool findScreenGameActive = false;

    public bool tablet = false;
    public bool phone = false;

    public bool minimizedApp = false;

    public DateTime toLoadDatetime;
    public string toLoadDatetimeString;
    public string loadDateStr;

    int prevlose;
    int nextlose;

    public bool soundActive = true;
    public bool musicActive = true;


    public bool noCoinSCreenActive = false;

    public bool nextEssentialHeart=false;
    public bool nextEssentialCoin=false;


    public bool gameActive;

    public int bestStreak;
    public int bestStreakStats;
    public int currentStreak;

    public bool glassSearch = false;


    public int secondsLeft = 0;
    public int minutesLeft = 0;
    public bool activeCountDown;

    public GameObject findScreen;

    public static GameManager Instance;
    public GameState GameState;

    [SerializeField] public GameObject coinNotEnoughScreen;
    public bool coinNotEnough = false;

    public bool restarted = false;

    public bool firstPresent = false;

    public bool presTimerActive;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Debug.Log("error");

      

    }



 




    void Start()
    {
/**/
        
/**/

        Screen.sleepTimeout = (int)0f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //set current scene as the one who gets saved
        // lastPositionCurrent = SceneManager.GetActiveScene().buildIndex;
        BonusBackGroundImage.SetActive(false);

        findScreenGameActive = false;
        bonusOn = false;
        noCoinSCreenActive = false;

        if (positionStringLoad == "med")
        {
   
            Board.Instance.timeSpeed = 0.8f;
        }
        else
            if (positionStringLoad == "hard")
            {

                Board.Instance.timeSpeed = 0.5f;
            
        }
        else
            if (positionStringLoad == "easy")
        {

            Board.Instance.timeSpeed = 1.1f;

        }
        // positionStringSave = SceneManager.GetActiveScene().name;


        //   toLoadDatetime = DateTime.ParseExact(loadDateStr, "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("de-DE"));
        if (loadDateStr != "")
        {

            //   toLoadDatetime = DateTime.ParseExact(loadDateStr, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            toLoadDatetime = DateTime.ParseExact(loadDateStr, "MM/dd/yyyy HH:mm:ss zzz", CultureInfo.InvariantCulture);

        }

        bestStreakStats = bestStreak;
        print(gameCount);

        m_Object.text = coinNum.ToString();
        /*  if (coinNum
         *  > 0 || coinNotEnough == false)
          {*/

        if(firstTime == true ||phone == false && tablet == false)
        {

        ChangeState(

            GameState.CheckScreenSize);
        }
        else
        {
            ChangeState(

           GameState.CheckTimer);
        }

    }

    public void callLoadAgain()
    {
        if (minimizedApp == true)
        {
            toLoadDatetime = DateTime.ParseExact(loadDateStr, "MM/dd/yyyy HH:mm:ss zzz", CultureInfo.InvariantCulture);


            TestTime.Instance.CalculateTime();
        }

    }


    public void LoadData(GameData gameData)
    {
        this.gameCount = gameData.gameNumber;

        this.coinNum = gameData.coinNumber;

        this.win = gameData.win;
        this.lose = gameData.lose;

        this.score1 = gameData.score1;
        this.score2 = gameData.score2;
        this.score3 = gameData.score3;

        this.loadDateStr = gameData.savedTIme;

        this.minutesLeft = gameData.minutesLeft;
        this.secondsLeft = gameData.secondsLeft;

        this.gameActive = gameData.gameActive;

        this.activeCountDown = gameData.timerActive;

        this.soundActive = gameData.sound;
        this.musicActive = gameData.music;

        this.bestStreakStats = gameData.bestStreakStat;
        this.bestStreak = gameData.bestStreak;
          this.currentStreak = gameData.currentStreak;
       

        /*  this.bestStreakStats =0;
          this.bestStreak =0;
          this.currentStreak = 0;*/
        this.ExtraSweetLolli = gameData.ExtraSweetLolli;
        this.ExtraSweetBonbon = gameData.ExtraSweetBonBon;
        this.ExtraLife = gameData.ExtraLive;
        this.ExtraCoin = gameData.ExtraCoin;

        this.goldBag = gameData.goldBag;


        positionStringLoad = gameData.lastPos;

        this.coinNotEnough = gameData.notEnoughCoins;

        this.restarted = gameData.restarted;

        this.phone = gameData.isPhone;
        this.tablet = gameData.isTablet;

        this.firstPresent = gameData.firstPresent;

       this.presTimerSeconds = gameData.presentTimerSec;

        print(gameData);

        this.findScreenGameActive = gameData.findScreenActiveGame;


        this.firstTime = gameData.firstTime;
        this.presTimerActive = gameData.presTImerActive;

        this.noCoinSCreenActive = gameData.noCoinScreenActive;


    }
    public void SaveData(GameData gameData)
    {
        Debug.Log("gamemanager savedata" + this.lose);

        //  savedate = DateTime.Now.ToString(/*CultureInfo.InvariantCulture*/ CultureInfo.GetCultureInfo("de-DE"));
        savedate = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss zzz", CultureInfo.InvariantCulture);//DateTimeStyles.AdjustToUniversal); //CultureInfo.GetCultureInfo("de-DE"));



        gameData.lastPos = positionStringLoad;



        gameData.gameNumber = this.gameCount;

        gameData.bestStreakStat = this.bestStreakStats;
       gameData.bestStreak = this.bestStreak;
        gameData.currentStreak = this.currentStreak;
      //  gameData.currentStreak = 1274;




        gameData.gameActive = this.gameActive;

      /*  gameData.bestStreakStat = 0;
        gameData.bestStreak = 0;*/
   /*     gameData.currentStreak = 0;
*/

        gameData.win = this.win;
        gameData.lose = this.lose;

        gameData.findScreenActiveGame = this.findScreenGameActive;

        /*  
          gameData.ExtraSweetLolli = 1;
        gameData.ExtraSweetBonBon = 1;*/
         gameData.goldBag = this.goldBag;
        // gameData.goldBag = 1000;


        gameData.firstPresent= this.firstPresent ;
  gameData.presentTimerSec = this.presTimerSeconds     ;

        gameData.presTImerActive = this.presTimerActive;

        gameData.ExtraSweetLolli = this.ExtraSweetLolli;
        gameData.ExtraSweetBonBon = this.ExtraSweetBonbon;

        /*  gameData.ExtraSweetLolli = 50;
          gameData.ExtraSweetBonBon = 50;*/


        gameData.ExtraLive= this.ExtraLife ;
      gameData.ExtraCoin = this.ExtraCoin ;
     //  gameData.ExtraCoin =50;


        gameData.score1 = this.score1;
        gameData.score2 = this.score2;
        gameData.score3 = this.score3;

        gameData.sound = this.soundActive;
        gameData.music = this.musicActive;

        gameData.savedTIme = this.savedate;

        //

        gameData.timerActive = this.activeCountDown;
        gameData.secondsLeft = this.secondsLeft;
        gameData.minutesLeft = this.minutesLeft;



        gameData.restarted = this.restarted;



        gameData.notEnoughCoins = this.coinNotEnough;

        /*
                gameData.secondsLeft = 00;
                gameData.timerActive = true;
                gameData.minutesLeft = 2;*/

    //    gameData.coinNumber = 5;
        gameData.isTablet = false;
        gameData.isPhone = false;

         gameData.coinNumber = this.coinNum;
      //  gameData.coinNumber = 5;

        /*  gameData.isTablet = this.tablet;
          gameData.isPhone = this.phone;*/


        gameData.firstTime = this.firstTime;

        gameData.noCoinScreenActive = this.noCoinSCreenActive;

        /*  gameData.firstTime =this.firstTime;*/
    }




    public void ChangeState(GameState newState)
    {
        GameState = newState;
        print("GAMEMANAGER minLeft" + minutesLeft);
        print("GAMEMANAGER secLeft" + secondsLeft);


     
    
        switch (newState)
        {
            case GameState.CheckScreenSize:
                UiScaler.Instance.CheckResolution();
                break;
            case GameState.CheckTimer:
                TestTime.Instance.CalculateTime();
                Sweets.Instance.DisplaySweetCount();
                break;

            case GameState.FeatureTile:
                print("streak" + currentStreak);
               noCoinSCreenActive = false;

                currentStreak += 1;
              /*  if (currentStreak == 2 || currentStreak ==3 || currentStreak == 4 || currentStreak == 5 ||currentStreak ==6 || currentStreak == 7|| currentStreak == 8)//currentstreak== 20)
                {*/

                //yellow 
                //green
                //blue
                //darkBlue
                //red
                //lila 
                //rainbow



                    if(currentStreak == 25 || currentStreak == 50 || currentStreak == 75 || currentStreak == 100  ) // 20
                    {

                    // 0-100

                         yellowPresentBonus = true;
                    // rainbowPresentBonus = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);

                }
                    else if( currentStreak == 125 || currentStreak == 150 || currentStreak == 175 || currentStreak == 200) // 60
                    {
                    //100-200
                        greenPresentBonus = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                    //  rainbowPresentBonus = true;


                }
                    else if (currentStreak == 300 || currentStreak == 225 || currentStreak == 250 || currentStreak == 275) //110
                    {
                    //200-300
                        bluePresentBonus = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                    else if (currentStreak == 400 || currentStreak == 325|| currentStreak == 350|| currentStreak == 375) // 170  //1730 //1760 //1830 //1860
                    {
                    //300-400
                        darkBluePresentBonus = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                    else if (currentStreak == 500 || currentStreak == 425 || currentStreak == 450 || currentStreak == 475/* || currentStreak == 1350 || currentStreak == 1450 || currentStreak == 1550 || currentStreak == 1650 || currentStreak == 1930 || currentStreak == 1960*/) // 240 //1050 // 1150 //1250//1350 // 1450 //1550 // 1650 //1930 // 1960
                    {
                    //400-500
                        redPresentBonus = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                    else if (currentStreak == 600 || currentStreak == 525 || currentStreak == 575 || currentStreak == 550 /*|| currentStreak == 800 || currentStreak == 900 || currentStreak == 1100 || currentStreak == 1200 || currentStreak == 1300 || currentStreak == 1400 || currentStreak == 1500 || currentStreak == 1600 || currentStreak == 1700 || currentStreak == 1800 || currentStreak == 1900*/)  // <200 >500 && cstreak % 100 ==0
                    // 320 //410 // 600 // 700 //800 //900 // 1100 //1200 //1300 /1400 //1600 //1700 /1800 //1900
                    {
                    //525-600
                        lilaPresentBonus = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                    else if (currentStreak ==625 || currentStreak == 700 || currentStreak == 650 || currentStreak == 675  /*|| currentStreak == 2100 || currentStreak == 2200 || currentStreak == 2300 || currentStreak == 2400 || currentStreak == 2500 || currentStreak == 2600 || currentStreak == 2700 || currentStreak == 2800 || currentStreak == 2900 || currentStreak == 3000 || currentStreak == 3100 || currentStreak == 3200 || currentStreak == 3300 || currentStreak == 3400 || currentStreak == 3500 || currentStreak == 3600 || currentStreak == 3700 || currentStreak == 3800 || currentStreak == 3900 || currentStreak == 4000*/ ) //500 // 1000 //1500 //2000 //2100 //2200 //2300 //2400 // 2500 // 2600 //2700 // 2800 //2900 //3000...
                    {
                    //625-700
                        rainbowPresentBonus = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                else if (currentStreak == 725 || currentStreak == 750 || currentStreak == 775 || currentStreak == 800 /*|| currentStreak == 2100 || currentStreak == 2200 || currentStreak == 2300 || currentStreak == 2400 || currentStreak == 2500 || currentStreak == 2600 || currentStreak == 2700 || currentStreak == 2800 || currentStreak == 2900 || currentStreak == 3000 || currentStreak == 3100 || currentStreak == 3200 || currentStreak == 3300 || currentStreak == 3400 || currentStreak == 3500 || currentStreak == 3600 || currentStreak == 3700 || currentStreak == 3800 || currentStreak == 3900 || currentStreak == 4000*/ ) //500 // 1000 //1500 //2000 //2100 //2200 //2300 //2400 // 2500 // 2600 //2700 // 2800 //2900 //3000...
                {
                    //725-800
                    rainbowPresentBonus2 = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                else if (currentStreak == 825 || currentStreak == 850 || currentStreak == 875 || currentStreak == 900 /*|| currentStreak == 2100 || currentStreak == 2200 || currentStreak == 2300 || currentStreak == 2400 || currentStreak == 2500 || currentStreak == 2600 || currentStreak == 2700 || currentStreak == 2800 || currentStreak == 2900 || currentStreak == 3000 || currentStreak == 3100 || currentStreak == 3200 || currentStreak == 3300 || currentStreak == 3400 || currentStreak == 3500 || currentStreak == 3600 || currentStreak == 3700 || currentStreak == 3800 || currentStreak == 3900 || currentStreak == 4000*/ ) //500 // 1000 //1500 //2000 //2100 //2200 //2300 //2400 // 2500 // 2600 //2700 // 2800 //2900 //3000...
                {
                    //800-900
                    rainbowPresentBonus3 = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                else if (currentStreak == 925 || currentStreak == 950 || currentStreak == 975 || currentStreak == 1000/*|| currentStreak == 2100 || currentStreak == 2200 || currentStreak == 2300 || currentStreak == 2400 || currentStreak == 2500 || currentStreak == 2600 || currentStreak == 2700 || currentStreak == 2800 || currentStreak == 2900 || currentStreak == 3000 || currentStreak == 3100 || currentStreak == 3200 || currentStreak == 3300 || currentStreak == 3400 || currentStreak == 3500 || currentStreak == 3600 || currentStreak == 3700 || currentStreak == 3800 || currentStreak == 3900 || currentStreak == 4000*/ ) //500 // 1000 //1500 //2000 //2100 //2200 //2300 //2400 // 2500 // 2600 //2700 // 2800 //2900 //3000...
                {
                    //1025 50 75 
                    // 900 -1000
                    rainbowPresentBonus4 = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                else if (currentStreak >= 1010 && currentStreak % 100 == 0 /*|| currentStreak == 2100 || currentStreak == 2200 || currentStreak == 2300 || currentStreak == 2400 || currentStreak == 2500 || currentStreak == 2600 || currentStreak == 2700 || currentStreak == 2800 || currentStreak == 2900 || currentStreak == 3000 || currentStreak == 3100 || currentStreak == 3200 || currentStreak == 3300 || currentStreak == 3400 || currentStreak == 3500 || currentStreak == 3600 || currentStreak == 3700 || currentStreak == 3800 || currentStreak == 3900 || currentStreak == 4000*/ ) //500 // 1000 //1500 //2000 //2100 //2200 //2300 //2400 // 2500 // 2600 //2700 // 2800 //2900 //3000...
                {
                    //1100 //1200 //1300 ....
                    rainbowPresentBonus5 = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                else if ( currentStreak >= 1010 &&  (((float)currentStreak / 100) - (double) Math.Floor((double)currentStreak / 100)) *100==25  
                    || currentStreak >= 1010 && ((float)currentStreak / 100 - (double)Math.Floor((double)currentStreak / 100)) * 100 == 50
                    ||currentStreak >= 1010 && ((float)currentStreak / 100 - (double)Math.Floor((double)currentStreak / 100)) * 100 == 75
                   )
                {
                    //1025 50 75 
                    
                    rainbowPresentBonus6 = true;

                    BonusBackGroundImage.SetActive(true);
                    BonusFirstAlert.SetActive(true);
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                    bonusOn = true;
                    SweetCoverGlass.SetActive(false);
                    SweetCoverHammer.SetActive(false);
                }
                /*  else if (currentStreak == 600 || currentStreak == 700 || currentStreak == 800 || currentStreak >= 900 && currentStreak % 100 == 0 *//*|| currentStreak == 2100 || currentStreak == 2200 || currentStreak == 2300 || currentStreak == 2400 || currentStreak == 2500 || currentStreak == 2600 || currentStreak == 2700 || currentStreak == 2800 || currentStreak == 2900 || currentStreak == 3000 || currentStreak == 3100 || currentStreak == 3200 || currentStreak == 3300 || currentStreak == 3400 || currentStreak == 3500 || currentStreak == 3600 || currentStreak == 3700 || currentStreak == 3800 || currentStreak == 3900 || currentStreak == 4000*//* ) //500 // 1000 //1500 //2000 //2100 //2200 //2300 //2400 // 2500 // 2600 //2700 // 2800 //2900 //3000...
                  {
                      rainbowPresentBonus6 = true;

                      BonusBackGroundImage.SetActive(true);
                      BonusFirstAlert.SetActive(true);
                      //  currentStreak += 1;
                      FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                      bonusOn = true;
                      SweetCoverGlass.SetActive(false);
                      SweetCoverHammer.SetActive(false);
                  }*/



                //   rainbowPresentBonus = true;
                /*
                                    BonusBackGroundImage.SetActive(true);
                                    BonusFirstAlert.SetActive(true);
                                    //  currentStreak += 1;
                                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                                    bonusOn = true;
                                    SweetCoverGlass.SetActive(false);
                                  SweetCoverHammer.SetActive(false);*/
                //bonus 
                //  generategrrid bonus

                else
                {
                    //  currentStreak += 1;
                    print("is it 25? " + (((float)currentStreak / 100) - (double)Math.Floor((double)currentStreak / 100)) * 100);
                    bonusOn = false;
                    findScreenGameActive = true;

                    Featured.Instance?.choseFeatureTile();
                    //  currentStreak += 1;
                    FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                }
                break;
            case GameState.ActivateFindScreen:
                print("gamestate activateFindScreen");
                SweetCoverGlass.SetActive(true);
                SweetCoverHammer.SetActive(true); //---> deactivate in board / checktiles
                InvCoverHammer.SetActive(true);
                ShopCoverGlass.SetActive(true); //---> deactivate in board / checktiles or nocoinSCreen

                findScreen.SetActive(true);
                findFeatureScreenAnim.Instance?.startFindScreenAnimation();
                /*if (coinNum==0)
                {
                    coinNotEnough = true;
                }*/
                break;

            case GameState.GenerateGrid:

                Board.Instance?.GenerateGrid();

                break;
            case GameState.ChoseTile:

                Tiles.Instance.checkForClicks();

                break;

            case GameState.Win:
                gameCount += 1;
                FindObjectOfType<AudioManager>().Play("yes");

                win += 1;
                GameOver.Instance.Win();
                print("score" + score);
                //     SaveData();

                break;
            case GameState.Lose:
                print("change state prevlose" + prevlose);

                print("change state lose" + lose);
                //lose = prevlose;
                lose += 1;
                // nextlose = lose;
                gameCount += 1;
                //      this.lose = prevlose;
                print("change state lose" + nextlose);

                GameOver.Instance.Lose();
                //   DataPersistenceManager.Instance.SaveGame();
                print("score" + score);

                //      SaveData();
                break;
            case GameState.Restart:
                coinNum -= 1;

                GameOver.Instance.Restart();

                print("restart" + coinNum);
                //      SaveData();
                break;


            case GameState.changeToSlowScene:

                Menu.Instance.LoadSceneSlow();

                //      SaveData();
                break;

            case GameState.changeToMedScene:


                Menu.Instance.LoadSceneMedium();

                break;
            case GameState.changeToHardScene:

                Menu.Instance.LoadSceneFast();
                break;
            case GameState.WinBonus:

                //show win screen continue
                //
                BonusScreen.SetActive(true);
                BonusWin.Instance.ActivateBonusScreen();

                //      SaveData();
                break;
            case GameState.GetEssential:

                //activate essentialscreen 
                //if essential activate this else that
                EssentialScreen.SetActive(true);

                break;

        }
    }

}



public enum GameState
{
    CheckTimer = 0,
    FeatureTile = 1,
    GenerateGrid = 2,
    ChoseTile = 3,
    Win = 4,
    Lose = 5,
    Restart = 6,
    changeToSlowScene = 7,
    changeToMedScene = 8,
    changeToHardScene = 9,
    ActivateFindScreen = 10,
    NotEnoughCoins = 11,
    CheckScreenSize = 12,
    WinBonus=13,
    GetEssential=14,

}
