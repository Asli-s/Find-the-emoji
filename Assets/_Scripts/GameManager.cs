using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Globalization;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public int gameCount =0;
    [SerializeField] public TMPro.TextMeshProUGUI m_Object;
    public int coinNum;
    public int score= 0;
    public int lastPosition; // loaded pos
    public int lastPositionCurrent; // get currentPos
    public string positionStringLoad = "";
    public string positionStringSave = "";

    public bool sound;
    public bool music;

    public int win;
    public int lose;
    public int score1;
    public int score2;
    public int score3;

    public DateTime toSaveDatetime;
    public string toSaveDatetimeString;
    public string savedate;

    public DateTime toLoadDatetime;
    public string toLoadDatetimeString;
    string loadDateStr;

    int prevlose;
    int nextlose;


    public int secondsLeft=0;
    public int minutesLeft=0;
    public bool activeCountDown;

    public GameObject findScreen;

    public static GameManager Instance;
    public GameState GameState;

     void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Debug.Log("error");
       
    }
    void Start()
    {
      
        //set current scene as the one who gets saved
        // lastPositionCurrent = SceneManager.GetActiveScene().buildIndex;
        positionStringSave = SceneManager.GetActiveScene().name;


        toLoadDatetime = DateTime.ParseExact(loadDateStr, "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("de-DE"));


        print(gameCount);

        m_Object.text = coinNum.ToString();
        ChangeState(
            GameState.FeatureTile);
        //loaad gameCount
        //load coinNum

      //  toSaveDatetime = DateTime.Now;
    }

    public void LoadData(GameData gameData)
    {
        this.gameCount = gameData.gameNumber;

        this.coinNum = gameData.coinNumber;
        this.sound = gameData.sound;
        this.music = gameData.music;
        this.win = gameData.win;
        this.lose = gameData.lose;

        this.score1 = gameData.score1;
        this.score2 = gameData.score2;
        this.score3 = gameData.score3;

        this.loadDateStr = gameData.savedTIme;

        this.minutesLeft = gameData.minutesLeft;
        this.secondsLeft = gameData.secondsLeft;

        this.activeCountDown = gameData.timerActive;

        positionStringLoad = gameData.lastPos;

        print(gameData);
      
    }
    public void SaveData( GameData gameData)
    {
        Debug.Log("gamemanager savedata" + this.lose);

        savedate = DateTime.Now.ToString(/*CultureInfo.InvariantCulture*/ CultureInfo.GetCultureInfo("de-DE"));
     

        gameData.lastPos = positionStringSave;
        //temporarily turned off

        /*RESET*/

        /* gameData.gameNumber = 0;
        gameData.coinNumber = 5;
          gameData.lose = 0;
          gameData.win = 0;
          gameData.score1 = 0 ;
         gameData.score2=  0 ;
         gameData.score3 = 0;*/
        gameData.timerActive = this.activeCountDown;

        gameData.gameNumber = this.gameCount;
      gameData.coinNumber = this.coinNum;
        //gameData.coinNumber = 5;




        gameData.win = this.win;
        gameData.lose = this.lose;

        gameData.score1 = this.score1;
        gameData.score2 = this.score2;
        gameData.score3 = this.score3;

        gameData.sound = this.sound ;
        gameData.music = this.music;

        gameData.savedTIme = this.savedate;

        gameData.secondsLeft = this.secondsLeft;
        gameData.minutesLeft = this.minutesLeft;

    /*    gameData.secondsLeft = 3;

        gameData.minutesLeft = 2;*/


    }


  

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        print("GAMEMANAGER minLeft" + minutesLeft);
        print("GAMEMANAGER secLeft" + secondsLeft);
        print(loadDateStr);
  

        switch ( newState)
        {
            case GameState.FeatureTile:
             
                Featured.Instance?.choseFeatureTile();

                break;
            case GameState.ActivateFindScreen:
                findScreen.SetActive(true);
                findFeatureScreenAnim.Instance?.startFindScreenAnimation();

                break;

            case GameState.GenerateGrid:
               
                Board.Instance?.GenerateGrid();

                break;
            case GameState.ChoseTile:

                Tiles.Instance.checkForClicks();

                break;

            case GameState.Win:
                gameCount+= 1;
               
                win += 1;
                GameOver.Instance.Win();
                print("score"+ score);
                //     SaveData();
              
                break;
            case GameState.Lose:
                print("change state prevlose" + prevlose);

                print("change state lose"+lose);
                //lose = prevlose;
                lose+=1;
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
        }



    }

    //onTileClicked
    
   
}
public enum GameState
{
    FeatureTile = 0,
    GenerateGrid =1,
    ChoseTile = 2,
    Win= 3,
    Lose=4,
    Restart=5,
    changeToSlowScene=6,
    changeToMedScene = 7,
    changeToHardScene = 8,
    ActivateFindScreen =9,

}
