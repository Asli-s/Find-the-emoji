using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public int gameCount =1;
    [SerializeField] public TMPro.TextMeshProUGUI m_Object;
    public int coinNum;
    public int score= 0;
    public int lastPosition; // loaded pos
    public int lastPositionCurrent; // get currentPos
    public string positionStringLoad = "";
    public string positionStringSave = "";

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

        //  LoadedData();
        //print("lastPosition"+lastPosition);
       

        gameCount += 1;
        print(gameCount);

        m_Object.text = coinNum.ToString();
        ChangeState(
            GameState.FeatureTile);
       //loaad gameCount
       //load coinNum
    }

    public void LoadData(GameData gameData)
    {
        this.coinNum = gameData.coinNumber;
        //lastPosition = gameData.lastPos;
        positionStringLoad = gameData.lastPos;
      
    }
    public void SaveData( GameData gameData)
    {
        //temporarily turned off
        // gameData.coinNumber = this.coinNum;
        gameData.coinNumber = 5;

        gameData.lastPos = positionStringSave;
    
      //  gameData.lastPos = lastPositionCurrent;

    }


    /*public void SaveData()
    {
        SaveSystem.saveData(this);
    }
    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadData()?? null
            ;
        if(data == null) { 

            m_Object.text = "6";
        coinNum = 6;
            gameCount = 0;
            score = 0;
            SaveData();
            print(coinNum);
            print(gameCount);
            print(score);


    }
        else
        {
            coinNum = data.coinNum;
            gameCount = data.gameNum;
            score = data.score;
            print("else data saved");
            print(coinNum);
            print(gameCount);
            print(score);
        }
      
    }
*/

    public void ChangeState(GameState newState)
    {
        GameState = newState;
       
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
                GameOver.Instance.Win();
                print("score"+ score);
           //     SaveData();

                break;
            case GameState.Lose:
                GameOver.Instance.Lose();
                print("score" + score);

          //      SaveData();
                break;
            case GameState.Restart:
                coinNum -= 1;

                GameOver.Instance.Restart();
                score = 0;
                gameCount -= 1;
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
