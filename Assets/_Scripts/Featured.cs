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

    bool alreadyClicked= false;
    public bool clicked = false;
    public bool openTile = true;
    // Start is called before the first frame update
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
        Debug.Log("new inside");


        //    animator= findScreenObject.GetComponent<Animator>();


        //   secondsLeft = originalSeconds;

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
             


                //temp change 04.05
                /*   findScreen.SetActive(true);*/
                // screenActive = true;


                /*DEACTIVATE QUESTIONMARK*/
              

                if (health.GetComponent<HealthHearts>().health > 0  /*maybe comment out to have double pop sound*/ && alreadyClicked ==true)
                {

                    LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, 7f), 0.1f);
                    LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, -7f), 0.1f).setDelay(0.1f);
                    LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, 7f), 0.1f).setDelay(0.2f); ;
                    LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, -7f), 0.1f).setDelay(0.3f).setOnComplete(deactivateQuestionMark);

                    findScreenActivePauseBoard = true;
                    alreadyClicked = false;
                }

                //pause the grid


                /*             *//*  if (findScreenActivePauseBoard ==true &&alreadyInPause==false)
                               {
                                   alreadyInPause = true;
                                   findScreenActivePauseBoard = false;
                                   _board.pauseBoard();
                               }
               *//**/
                //     print("activate findscreen gameobj");
                //

                //  _featureTilePrefab.GetComponent<BoxCollider2D>().enabled = false;
                /*     tile.GetComponent<BoxCollider2D>().enabled = false;  // <-- feature tile disabled
                     _featureTilePrefab.GetComponent<BoxCollider2D>().enabled = false;  // <-- feature tile disabled*/


                //    _parentObject1.GetComponent<BoxCollider2D>().enabled = false;

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


     //       questionMark.SetActive(true);
       

            //open tiles of board
            if (clicked==true)
            {
                clicked = false;
             print("enable questionmark");
                FindObjectOfType<AudioManager>().Play("pop");

                _allTiles = _board._nodes;

                _allTiles.ForEach((tile) =>
                {

                    int lastChildIndex = tile.transform.childCount - 1;
                    tile.transform.GetChild(lastChildIndex).gameObject.SetActive(false);
                });

                //       tile.transform.GetChild(-1).gameObject.SetActive(false); });
            }

            disableSecondTiemr = TimerOneSec();
            StartCoroutine(disableSecondTiemr);

            if (secondTimerEnd == true && additionalSecond == 0)
            {
                   print("inside of second timer"); 

                waitAnotherSecond = TimerOneSec2();



                StartCoroutine(waitAnotherSecond);
                /*
                                print(thirdTimer );
                                print(anotherSecond);*/


                StopCoroutine(disableSecondTiemr);


                startCountDown = false;
            }


        



        }
    }


    private void deactivateQuestionMark()
    {
        print("play pop");
        FindObjectOfType<AudioManager>().Play("pop");
        qmObjectAssignment.SetActive(false);
        LeanTween.rotate(qmObjectAssignment, new Vector3(0, 0f, 0f), 0f);
   

    }


    public void FeatureTileClicked()
    {


        if (openTile == false/*e && !EventSystem.current.IsPointerOverGameObject()*/ && screenActive == false)
        {

            _board.pauseBoard();
            _allTiles = _board._nodes;

            //        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
            coinCountText = GameManager.Instance.m_Object.text;
            coinCountNum = int.Parse(coinCountText);
            GameManager.Instance.coinNum = coinCountNum;

            if (coinCountNum > 0)
            {

                showAlert.SetActive(true);
            }
            if (coinCountNum == 0)
            {
                showAlertNoCoin.SetActive(true);
            }

        }



    }
    public void restartClicked() //RESTART BUTTTON
    {
        print("restart function" + screenActive);
        if (screenActive == false && Board.Instance.pausePanelActive == false)
        {
            print("Restart clicked");
            _allTiles = _board._nodes;
            /*  tile.GetComponent<BoxCollider2D>().enabled = false;  // <-- feature tile disabled
              _featureTilePrefab.GetComponent<BoxCollider2D>().enabled = false;  // <-- feature tile disabled


              _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });*/

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
            }




        }



    }

    /* public void restartScene() //NEW SCENE
     {
         print("restartscene funct");
         startCountDown = true;
         screenActive = false;
         additionalSecond = 1;

         if (openTile == false*//*e && !EventSystem.current.IsPointerOverGameObject()*//*)
         {
         //    tile.GetComponent<BoxCollider2D>().enabled = false;

             _board.pauseBoard();
             _allTiles = _board._nodes;

 //_allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
             coinCountText = GameManager.Instance.m_Object.text;
             coinCountNum = int.Parse(coinCountText);
             GameManager.Instance.coinNum = coinCountNum;

             if (coinCountNum > 0 &&screenActive ==false)
             {

                 screenActive= true;
                 showAlert.SetActive(true);
             }
             if (coinCountNum == 0 &&screenActive ==false)
             {
                 showAlertNoCoin.SetActive(true);
                 screenActive = true;
             }
         }


         Time.timeScale = 1f;
                                                                //cALL SAVEDATA AT THIS POINT
         DataPersistenceManager.Instance.SaveGame();
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

     }*/




    public void restartScene() //NEW SCENE
    {
/*restart coming from losing the game*/
        if (lostGame == true)
        {
            print("reestartscene from feature");
            coinCountText = GameManager.Instance.m_Object.text;
            coinCountNum = int.Parse(coinCountText);
            GameManager.Instance.coinNum = coinCountNum;

            if (coinCountNum > 0 )
            {
                print("coinnum"+coinCountNum);
                newNum = coinCountNum;
                newNum--;


                GameManager.Instance.coinNum = newNum;
                print("gameman coinnum" + GameManager.Instance.coinNum);

                GameManager.Instance.m_Object.text = newNum.ToString();
      //          CountdownTimer.Instance.StartTimer();
                FindObjectOfType<CountdownTimer>().StartTimer();
                //
            }
            if (coinCountNum == 0)
            {
                showAlertNoCoin.SetActive(true);
                screenActive = true;
            }
            lostGame = false;
           
        }
/*restart coming from restart button*/

        else
        {
            FindObjectOfType<AudioManager>().Play("coin");

            startCountDown = true;
            screenActive = false;
            additionalSecond = 1;

            _board.pauseBoard();
            _allTiles = _board._nodes;

            //_allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
            coinCountText = GameManager.Instance.m_Object.text;
            coinCountNum = int.Parse(coinCountText);
            GameManager.Instance.coinNum = coinCountNum;

            if (coinCountNum > 0 && screenActive == false)
            {
                newNum = coinCountNum;
                newNum--;


                GameManager.Instance.coinNum = newNum;
                GameManager.Instance.m_Object.text = newNum.ToString();
                //      CountdownTimer.Instance.StartTimer();
                print("NEWNUM resteart" + newNum);
               FindObjectOfType<CountdownTimer>().StartTimer();
                //
            }
            if (coinCountNum == 0 && screenActive == false)
            {
                showAlertNoCoin.SetActive(true);
                screenActive = true;
            }

        }
            DataPersistenceManager.Instance.SaveGame();
            Invoke("ActualRestart", 0.2f);
        //changed this 04.05
        //   Time.timeScale = 1f;


        //cALL SAVEDATA AT THIS POINT
      
    //    Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }

    void ActualRestart()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }

    public void clickedYes()
    {
        FindObjectOfType<AudioManager>().Play("wrong");
        startCountDown = true;


        print("inside yes funct");
        additionalSecond = 1;
        //start only after coroutíne ends
        _board.pauseBoard();


        /* _allTiles = _board._nodes;

         _allTiles.ForEach((tile) => {

             int lastChildIndex = tile.transform.childCount - 1;
             tile.transform.GetChild(lastChildIndex).gameObject.SetActive(true);

             // tile.transform.GetChild(3).gameObject.SetActive(true)

         });*/

        /*  _featureTilePrefab.GetComponent<BoxCollider2D>().enabled = false;
          _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });*/


        ///////////changed 06.05 --instead coin lose life
        /// extra
        /// 

        //    health.GetComponent<HealthHearts>().loseLife();
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



        ///////////changed 06.05 --instead coin lose life
        ///
        /*

        showAlert.SetActive(false);
        coinCountText = GameManager.Instance.m_Object.text;
        

        coinCountNum = int.Parse(coinCountText);

        if (coinCountNum > 0 && openTile == false)
        {
             newNum = coinCountNum;
            newNum--;

        GameManager.Instance.coinNum = newNum;
            GameManager.Instance.m_Object.text = newNum.ToString();

        }
        if (openTile == false)
        {
            secondsLeft = 3;
        }
        if (coinCountNum > 0)
        {

            openTile = true;
            clicked = true;
        }


        */
        //////


    }
    public void clickedNo()  //FEATURE TILE NO BUTTON
    {
        // screenActive = false;
        //   tile.GetComponent<BoxCollider2D>().enabled = true;
        // showAlert.SetActive(false);  --> control from LoadMEnu() animation
        PopUpAnimFeature.Instance.CloseMenuAnimation();

        print("NOOOOO");

        _board.pauseBoard();
        //   _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = true; });


    }
    public void clickedNoRestart()
    {
        //   screenActive = false;

        //    tile.GetComponent<BoxCollider2D>().enabled = true;
        //  showAlertRestart.SetActive(false); --> control from LoadMEnu() animation
        print("close");

        PopUpAnimRestart.Instance.CloseMenuAnimation();


        _board.pauseBoard();
        // _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = true; });

    }
    public void clickeBack()
    {
        // screenActive = false;

        //  tile.GetComponent<BoxCollider2D>().enabled = true;
        _board.pauseBoard();
        //    _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = true; });
        PopupAnimNoCOins.Instance.CloseMenuAnimation();


        //  showAlertNoCoin.SetActive(false);
    }
    //function showAd



    void makeFeatureTile()

    {

        rnd = Random.Range(_minRange, _maxRange);

        //random sprite given to tileprefab

        _prefabSpriteRenderer.sprite = _featureTilePrefab._gameObjects?[rnd];

        //  tile = Instantiate(_featureTilePrefab, new Vector2((float)3 / 2, (10 / 2)-0.23f), Quaternion.identity);
        tile = Instantiate(_featureTilePrefab/*, new Vector3((float)0,0,0), Quaternion.identity*/) /*as GameObject*/;

        // findScreenImage 

        featureImage.sprite = tile._gameObjects?[rnd];

        // print(tile.transform.localPosition);
     
        // tile.transform.localScale = new Vector3(2.22f,2.22f,2.22f);

        //  tile.rectTransform.localScale = new Vector3(newScale, 1.0f, 1.0f);//This works




        // tile.transform.parent = _parentObject1.transform;

        tile.transform.SetParent(_parentObject1.transform, false);
        //tile.transform.localPosition = new Vector3(0,27, 0);
        tile.transform.localPosition = new Vector3(0, 0, 0);
        tile.GetComponent<BoxCollider2D>().enabled = false;


        //    tile.GetComponent<BoxCollider2D>().enabled = false;
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

