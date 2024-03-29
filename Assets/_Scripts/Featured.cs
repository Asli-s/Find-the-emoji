using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Featured : MonoBehaviour
{
    // Start is called before the first frame update
    public static Featured Instance;
    public GameObject showAlert;
    public GameObject showAlertNoCoin;
    public GameObject showAlertRestart;
    public Board _board;
    public GameObject findScreen;
    public GameObject findScreenObject;

    public GameObject health;


    //prevent Buttons from doubleClick
    bool coinLoseClicked = false;
    bool heartLoseClicked = false;

    bool noCoinScreenCoinClicked = false;

   public bool instruction = false;
    public bool firstTimeClickedOnce = false;


    private SpriteRenderer _prefabSpriteRenderer;
    private int _minRange = 0;
    private int _maxRange = 0;
    private int rnd = 0;
    private GameObject _tiles;
    private List<Tiles> _allTiles;
    public bool screenActive = false;
    bool findScreenActivePauseBoard = false;
    bool alreadyInPause = false;

    public bool lostGame = false;

    //    public int originalSeconds = 3;
    public int secondsLeft = 3;

    public int additionalSecond = 1;
    bool secondTimerEnd = false;

    public int anotherSecond = 1;
    bool thirdTimer = false;

    private IEnumerator disableSecondTiemr;
    private IEnumerator waitAnotherSecond;


    public bool takingAway = false;
    public IEnumerator FeatureTimer;
    bool instatiated = false;
    public FeaturedPrefab tile;

    // private FeaturedPrefab findScreenTile;

    public Image featureImage;
    public Image questionMarkImage;


    //ANIMATOR
    const string findScreenAnimForward = "findScreenAnim";
    const string findScreenAnimBack = "findScreenAnim 0";

    private string currentString;

    private Animator animator;
    // public List<Animation> FindScreenAnimations;




    [SerializeField] private GameObject _parentObject1;
    public FeaturedPrefab _featureTilePrefab;
    public GameManager coinCount;
    string coinCountText;
    public int coinCountNum;
    public int newNum;
    public GameObject questionMark;

    public GameObject BoxColliderChildOfPrefab;

    private GameObject qmObjectAssignment;

    public bool startCountDown = true;

    bool alreadyClicked = false;
    public bool clicked = false;
    public bool openTile = true;
    // Start is called before the first frame update

    public GameObject Instructions;
    bool functionCalled = false;



    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            _maxRange = _featureTilePrefab._gameObjects.Length;
            _prefabSpriteRenderer = _featureTilePrefab.GetComponent<SpriteRenderer>();
        }
        else
        {
            _maxRange = _featureTilePrefab._gameObjects.Length;
            _prefabSpriteRenderer = _featureTilePrefab.GetComponent<SpriteRenderer>();
        }

    }
    private void Start()
    {
       

    }

    public void choseFeatureTile()
    {


        _maxRange = _featureTilePrefab._gameObjects.Length;

        makeFeatureTile();

    }
    private void Update()
    {


        // print(screenActive);
        if (takingAway == false && secondsLeft > 0 && instatiated == true && startCountDown == true)
        {
            if (clicked == true)
            {                                            //activate findScreen



                //shake featureTile image

                if (health.GetComponent<HealthHearts>().health > 0  /*maybe comment out to have double pop sound*/ && alreadyClicked == true)
                {

                    LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, 7f), 0.1f);
                    LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, -7f), 0.1f).setDelay(0.1f);
                    LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, 7f), 0.1f).setDelay(0.2f); ;
                    LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, -7f), 0.1f).setDelay(0.3f).setOnComplete(deactivateQuestionMark);

                    findScreenActivePauseBoard = true;
                    alreadyClicked = false;
                }

             

            }
            openTile = true;
            FeatureTimer = Timer();
            StartCoroutine(FeatureTimer);

            //  additionalSecond = 1;

        }
        else if (takingAway == false && secondsLeft == 0 && instatiated == true && startCountDown == true)
        {


            openTile = false;

            //change Image to questionMark
            tile.transform.GetChild(0).gameObject.SetActive(true);
            //            findScreenObject.GetComponent<Animator>().Play(findScreenAnimForward);

            //   changeAnimationState(findScreenAnimForward);
            anotherSecond = 1;
            thirdTimer = false;


       

            //open tiles of board
            if (clicked == true)
            {
                clicked = false;
                print("enable questionmark");
                if (GameOver.Instance.lose == false && GameOver.Instance.win == false)
                {
                    heartLoseClicked = false;
                    FindObjectOfType<AudioManager>().Play("pop");
                    if (Instructions.activeSelf == true && functionCalled == false)
                    {
                        functionCalled = true;
                        clickedYesFirstTime();
                    }
                }
              

                _allTiles = _board._nodes;

                _allTiles.ForEach((tile) =>
                {

                    int lastChildIndex = tile.transform.childCount - 1;
                    tile.transform.GetChild(lastChildIndex).gameObject.SetActive(false);
                });

             
            }

            disableSecondTiemr = TimerOneSec();
            StartCoroutine(disableSecondTiemr);

            if (secondTimerEnd == true && additionalSecond == 0)
            {
                print("inside of second timer");

                waitAnotherSecond = TimerOneSec2();



                StartCoroutine(waitAnotherSecond);
            

                StopCoroutine(disableSecondTiemr);


                startCountDown = false;
            }






        }
    }


    private void deactivateQuestionMark()
    {
        print("play pop");
        if (GameOver.Instance.win == false && GameOver.Instance.lose == false)
        {

          //  FindObjectOfType<AudioManager>().Play("pop");
            FindObjectOfType<AudioManager>().Play("wrong");
        }
        qmObjectAssignment.SetActive(false);
        LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, 0f), 0f);


    }


    public void FeatureTileClicked()
    {


        if (openTile == false/*e && !EventSystem.current.IsPointerOverGameObject()*/ && screenActive == false && GameManager.Instance.glassSearch == false && firstTimeClickedOnce== false|| instruction ==true )
        {
           /* if(instruction == false)
            {
*/if(_board.paused == false)
            {

            _board.pauseBoard();
            }
            

            print("instruction" + instruction);
            _allTiles = _board._nodes;

            //        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
            coinCountText = GameManager.Instance.m_Object.text;
            coinCountNum = int.Parse(coinCountText);
            GameManager.Instance.coinNum = coinCountNum;
            showAlert.SetActive(true);

     
        }



    }
    public void restartClicked() //RESTART BUTTTON
    {
        print("restart function" + screenActive);
        if (GameManager.Instance.notClickable == false)
        {
            if (screenActive == false && Board.Instance.pausePanelActive == false)
            {
                print("Restart clicked");
                _allTiles = _board._nodes;


                coinCountText = GameManager.Instance.m_Object.text;

                coinCountNum = int.Parse(coinCountText);
                GameManager.Instance.coinNum = coinCountNum;

                if (coinCountNum > 0 && screenActive == false)
                {
                    _board.pauseBoard();

                    screenActive = true;
                    showAlertRestart.SetActive(true);
                }
                if (coinCountNum == 0 && screenActive == false)
                {
                    _board.pauseBoard();

                    screenActive = true;
                    showAlertNoCoin.SetActive(true);
                    GameManager.Instance.coinNotEnough = true;

                }




            }
        }



    }

 
    public void LoseCoinFromNoCoinScreen()
    {
        print("reestartscene from feature");
        coinCountText = GameManager.Instance.m_Object.text;
        coinCountNum = int.Parse(coinCountText);
        GameManager.Instance.coinNum = coinCountNum;

        if (coinCountNum > 0 && noCoinScreenCoinClicked== false)
        {
            noCoinScreenCoinClicked = true;
            print("coinnum" + coinCountNum);
            newNum = coinCountNum;
            newNum--;


            GameManager.Instance.coinNum = newNum;
            print("gameman coinnum" + GameManager.Instance.coinNum);

            GameManager.Instance.m_Object.text = newNum.ToString();
            //          CountdownTimer.Instance.StartTimer();
            FindObjectOfType<CountdownTimer>().StartTimer();
            //
        }
        DataPersistenceManager.Instance.SaveGame();
        Invoke("ActualRestart", 0.1f);


    }






    public void restartScene() //NEW SCENE   //lost game or clicked yes on coin restarrt button
    {
        if (lostGame == true)
        {
            print("reestartscene from feature");
            coinCountText = GameManager.Instance.m_Object.text;
            coinCountNum = int.Parse(coinCountText);
            GameManager.Instance.coinNum = coinCountNum;

            if (coinCountNum > 0)
            {
                print("coinnum" + coinCountNum);
                newNum = coinCountNum;
                newNum--;


                GameManager.Instance.coinNum = newNum;
                print(" restart gameman coinnum" + GameManager.Instance.coinNum);

                GameManager.Instance.m_Object.text = newNum.ToString();
                //          CountdownTimer.Instance.StartTimer();
                FindObjectOfType<CountdownTimer>().StartTimer();
                //  DataPersistenceManager.Instance.SaveGame();


                //
              

            }
            else if (coinCountNum == 0)
            {
                showAlertNoCoin.SetActive(true);
                screenActive = false;

                GameManager.Instance.coinNotEnough = true;
                print("lose coin but not enough from RESTART");
            
            }
            lostGame = false;


        }
    
        else
        {
            print("else restartfreature");
            FindObjectOfType<AudioManager>().Play("coin");

            startCountDown = true;
            screenActive = false;
            additionalSecond = 1;

            _board.pauseBoard();
            _allTiles = _board._nodes;

             coinCountText = GameManager.Instance.m_Object.text;
            coinCountNum = int.Parse(coinCountText);
            GameManager.Instance.coinNum = coinCountNum;

            if (coinCountNum > 0 && screenActive == false && coinLoseClicked==false)
            {
                coinLoseClicked = true;
                newNum = coinCountNum;
                newNum--;
                if (GameManager.Instance.currentStreak >= GameManager.Instance.bestStreak)
                {
                    GameManager.Instance.bestStreak = GameManager.Instance.currentStreak;
                }

                GameManager.Instance.currentStreak = 0;

                //    DataPersistenceManager.Instance.SaveGame();

                GameManager.Instance.coinNum = newNum;
                GameManager.Instance.m_Object.text = newNum.ToString();
                //      CountdownTimer.Instance.StartTimer();
                print("NEWNUM resteart" + GameManager.Instance.coinNum);
                FindObjectOfType<CountdownTimer>().StartTimer();
                //
            }
            if (coinCountNum == 0 && screenActive == false)
            {
                showAlertNoCoin.SetActive(true);
                //   screenActive = true;
                GameManager.Instance.coinNotEnough = true;

            }

        }
        DataPersistenceManager.Instance.SaveGame();
        print("SAVE GAME FROM LOSE RESTARTR");
        Invoke("ActualRestart", 0.2f);
      
    }


    void ActualRestart()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }

   void clickedYesFirstTime()  /// yes featuretile for instruction
    {
           instruction = false;
        if (GameManager.Instance.firstTime == true)
        {
            Instructions.SetActive(false);
            GameManager.Instance.firstFeatureTile = false;
            _allTiles = _board._nodes;

            _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = true; });
            Featured.Instance.screenActive = false;
            GameManager.Instance.notClickable = false;
            if (_board.appearCounter !=1 && _board.paused ==true )
                {
                print("appeared? " + _board.appearCounter);
                print("paused " + _board.paused);
              ;
                    _board.PauseButton();
                }
            print("pasued?? "+_board.paused);


        }

    }


    public void clickedYes()  //Feature tile yes button
    {
        if(heartLoseClicked == false)
        {
           if(GameManager.Instance.firstTime == false)
            {
                _board.pauseBoard();
            }
            else
            {
                // clickedYesFirstTime();
                firstTimeClickedOnce = true;
            }
         
            heartLoseClicked = true;

            FindObjectOfType<AudioManager>().Play("wrong");
            startCountDown = true;


            print("inside yes funct");
            additionalSecond = 1;


            HealthHearts.Instance.loseLife();

            showAlert.SetActive(false);
            screenActive = false;

            if (openTile == false)
            {
                alreadyClicked = true;
                secondsLeft = 2;

                openTile = true;
                clicked = true;

            }
        }
      



    }
    public void clickedNo()  //FEATURE TILE NO BUTTON
    {
        PopUpAnimFeature.Instance.CloseMenuAnimation();

        print("NOOOOO");
        if (Instructions.activeSelf ==false)
        {   

            _board.pauseBoard();
        }
    


    }
    public void clickedNoRestart()
    {

        print("close");

        PopUpAnimRestart.Instance.CloseMenuAnimation();


        _board.pauseBoard();

    }
    public void clickedNoNoCoin()
    {
        print("close");

        PopupAnimNoCOins.Instance.CloseMenuAnimation();


        _board.pauseBoard();

    }
    public void clickeBack()
    {
        _board.pauseBoard();
        PopupAnimNoCOins.Instance.CloseMenuAnimation();

    }


    void UpdateText()
    {
        GameManager.Instance.m_Object.text = GameManager.Instance.coinNum.ToString();
        DataPersistenceManager.Instance.SaveGame();
    }

    public void AddCoin()
    {
        coinCountText = GameManager.Instance.m_Object.text;
        coinCountNum = int.Parse(coinCountText);
      //  GameManager.Instance.coinNum = coinCountNum;
        newNum = coinCountNum;

        print("Addcoin function");
        if (GameManager.Instance.coinNum == 0 || GameManager.Instance.watchedAd ==true )
        {
            newNum += 1;
            GameManager.Instance.coinNum = newNum;
            UpdateText();
     
        }

        if (GameManager.Instance.adNoCoinScreenClicked == false)
        {
            clickedNoNoCoin();
        }
      else if(
             GameManager.Instance.adNoCoinScreenClicked == true)
        {
            FindObjectOfType<noCoinScreen>()?.ChangeButtonToAlreadyClicked();
        }
        Debug.Log("ADDCOIINN " + GameManager.Instance.coinNum);

        ///if nocoinscreen active --->deactivate ad button  ----> activate use coin button 
        ///little animation use coin button to grab attention


        DataPersistenceManager.Instance.SaveGame();
    }






    void makeFeatureTile()
    {
        rnd = Random.Range(_minRange, _maxRange);


        _prefabSpriteRenderer.sprite = _featureTilePrefab._gameObjects?[rnd];

        tile = Instantiate(_featureTilePrefab);

        featureImage.sprite = tile._gameObjects?[rnd];


        tile.transform.SetParent(_parentObject1.transform, false);
        tile.transform.localPosition = new Vector3(0, 0, 0);
        tile.GetComponent<BoxCollider2D>().enabled = false;

        screenActive = true;
        GameManager.Instance.ChangeState(GameState.ActivateFindScreen);
        instatiated = true;

        qmObjectAssignment =
              tile.transform.GetChild(0).gameObject;

    }


    public void setScreenActiveToTrue()
    {
        screenActive = true;
    }


    IEnumerator Timer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft--;
        // print(secondsLeft);
        takingAway = false;

    }

    IEnumerator TimerOneSec()
    {
        //  print("inside timeronesec");
        yield return new WaitForSeconds(1);
        additionalSecond--;
        if (additionalSecond < 0)
        {
            additionalSecond = 0;
            //     screenActive = false;
            secondTimerEnd = true;
        }


    }

    IEnumerator TimerOneSec2()
    {
        // print("inside third timer");
        anotherSecond--;
        yield return new WaitForSeconds(2);
        if (anotherSecond <= 0)
        {
            anotherSecond = 0;
            //     screenActive = false;
            thirdTimer = true;

        }


    }
}

