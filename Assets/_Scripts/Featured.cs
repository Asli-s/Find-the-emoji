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


    private SpriteRenderer _prefabSpriteRenderer;
    private int _minRange = 0;
    private int _maxRange = 0;
    private int rnd = 0;
    private GameObject _tiles;
    private List<Tiles> _allTiles;
   public bool screenActive = false;
    bool findScreenActivePauseBoard = false;
    bool alreadyInPause = false;
    //    public int originalSeconds = 3;
    public int secondsLeft =3;

    public int additionalSecond =1;
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
  public  int coinCountNum;
    public int newNum;
    public GameObject questionMark;

    public GameObject BoxColliderChildOfPrefab;
   

    public bool startCountDown = true;

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
        if (takingAway == false && secondsLeft > 0 && instatiated == true  &&startCountDown ==true)
        {
            if (clicked == true)
            {                                            //activate findScreen
               findScreen.SetActive(true);
               screenActive = true;
              //  screenActive = true;
              
                questionMark.SetActive(false);
                findScreenActivePauseBoard = true;

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

                tile.transform.GetChild(0).gameObject.SetActive(false);
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
      else  if (takingAway == false && secondsLeft == 0 && instatiated == true   &&startCountDown ==true &&thirdTimer ==false)
        {
               

            openTile = false;

            tile.transform.GetChild(0).gameObject.SetActive(true);
            //            findScreenObject.GetComponent<Animator>().Play(findScreenAnimForward);

         //   changeAnimationState(findScreenAnimForward);
            anotherSecond = 1;
            thirdTimer = false;

            //change Image to questionMark
            questionMark.SetActive(true);
            disableSecondTiemr = TimerOneSec();
             StartCoroutine(disableSecondTiemr);

            print("secondTimerEnd"+secondTimerEnd);
            print("additionalSecond" + additionalSecond);

                                                 //after a sec enable

            //disable findScreen
            if (secondTimerEnd == true && additionalSecond ==0)
            {
                print("inside of right section");

           // changeAnimationState(findScreenAnimBack);


                //  _parentObject1.GetComponent<BoxCollider2D>().enabled = true;

              /*  _featureTilePrefab.GetComponent<BoxCollider2D>().enabled = true;
                tile.GetComponent<BoxCollider2D>().enabled = true;
                _allTiles = _board._nodes;
                _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = true; });*/


       

          

                waitAnotherSecond = TimerOneSec2();

              

                StartCoroutine(waitAnotherSecond);

                print(thirdTimer );
                print(anotherSecond);

             
                StopCoroutine(disableSecondTiemr);


                startCountDown = false;
            }
         

            //      StopCoroutine(FeatureTimer);
            //  tile.GetComponent<BoxCollider2D>().enabled = true;
            //    tile.transform.GetChild(1).gameObject.SetActive(true);

            //            _featureTilePrefab.GetComponent<BoxCollider2D>().enabled = true;






        }/*
            * 
            * 
            * 
            * update function end
            * 
            * 
            * 
            * 
            * 
            * 
     else   if (thirdTimer == true && anotherSecond == 0)
        {
            *//* anotherSecond = 1;
             secondTimerEnd = false;

             additionalSecond = 1;
 *//*

          
            clicked = false;

            print("insideeeeee");

            findScreen.SetActive(false);

            print(findScreen.activeSelf);
        
            StopCoroutine(waitAnotherSecond);

            thirdTimer = false;

            StopCoroutine(FeatureTimer);
         //   startCountDown = false;

            screenActive = false;


            if (clicked)// &&screenActive ==true)
            {
                clicked = false;
                _board.pauseBoard();

            }


        }*/


    }

/*
    public void changeAnimationState (string newState)
    {

        if (newState == currentString) return;

        animator.Play(newState);
        currentString = newState;


    }*/




    public void FeatureTileClicked()
    {


        //   tile.GetComponent<BoxCollider2D>().enabled = false;  // <-- feature tile disabled
        //   _featureTilePrefab.GetComponent<BoxCollider2D>().enabled = false;  // <-- feature tile disabled
        print(screenActive);
        if (openTile == false/*e && !EventSystem.current.IsPointerOverGameObject()*/ && screenActive ==false)
        {
        screenActive = true;



            _board.pauseBoard();
            _allTiles = _board._nodes;

    //        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
          coinCountText=  GameManager.Instance.m_Object.text;
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
       if(screenActive == false) { 
        print("Restart clicked");
            _allTiles = _board._nodes;
      /*  tile.GetComponent<BoxCollider2D>().enabled = false;  // <-- feature tile disabled
        _featureTilePrefab.GetComponent<BoxCollider2D>().enabled = false;  // <-- feature tile disabled


        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });*/

        coinCountText = GameManager.Instance.m_Object.text;

        coinCountNum = int.Parse(coinCountText);
        GameManager.Instance.coinNum = coinCountNum;

        if (coinCountNum > 0 && screenActive ==false)
            {
                _board.pauseBoard();

                screenActive = true;
                showAlertRestart.SetActive(true);
            }
            if (coinCountNum == 0 && screenActive==false )
            {
                _board.pauseBoard();

                screenActive = true;
                showAlertNoCoin.SetActive(true);
            }
        
        


        }



    }

    public void restartScene() //NEW SCENE
    {
        print("restartscene funct");
        startCountDown = true;
        screenActive = false;
        additionalSecond = 1;

        if (openTile == false/*e && !EventSystem.current.IsPointerOverGameObject()*/)
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

    }
    public void clickedYes()
    {
        startCountDown = true;

        screenActive = true;
        print("inside yes funct");
        additionalSecond = 1;
                                                                  //start only after coroutíne ends
        _board.pauseBoard();
 
      /*  _featureTilePrefab.GetComponent<BoxCollider2D>().enabled = false;
        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });*/


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
        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = true; });

    }
    public void clickeBack()
    {
       // screenActive = false;

        tile.GetComponent<BoxCollider2D>().enabled = true;
        _board.pauseBoard();
        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = true; });
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

        print(tile.transform.localPosition);



     
        tile.transform.parent = _parentObject1.transform;

        //tile.transform.localPosition = new Vector3(0,27, 0);
        tile.transform.localPosition = new Vector3(0, 0, 0);


    //    tile.GetComponent<BoxCollider2D>().enabled = false;
  
        GameManager.Instance.ChangeState(GameState.ActivateFindScreen);
        instatiated = true;
       

    }
/*
void    activateQuestionMark(FeaturedPrefab tile)
    {

        secondsLeft = 3;
        while (takingAway == false && secondsLeft > 0 && instatiated == true)
        {
          //  print("new");
            FeatureTimer = Timer();
            // questionMark.SetActive(true);
            StartCoroutine(FeatureTimer);
          //  print("inside activate");
            //ParentGameObject.transform.GetChild (1).gameObject;
        }
         if (takingAway == false && secondsLeft == 0 && instatiated == true)
        {

            //     GameObject.FindGameObjectWithTag("question");
            tile.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
*/


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
        print("inside timeronesec");
        yield return new WaitForSeconds(1);
        additionalSecond--;
        if(additionalSecond < 0)
        {
            additionalSecond = 0;
       //     screenActive = false;
        secondTimerEnd = true;
        }
   

    }

    IEnumerator TimerOneSec2()
    {
        print("inside third timer");
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
