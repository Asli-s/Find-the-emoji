using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Board : MonoBehaviour
{
    public static Board Instance;
    public Featured featureTile;
    public GameObject particleInstance;
    private GameObject particleName;

    private SpriteRenderer featureTileSpriteRenderer;
    // Start is called before the first frame update
    [SerializeField] private int _width = 4;
    [SerializeField] private int _height = 4;
    [SerializeField] private Tiles _tilesPrefab;
    /*[SerializeField] private SpriteRenderer _boardPrefab;*/
    private SpriteRenderer _tileSpriteRenderer;
    private int _minRange = 0;
    private int _maxRange = 65;

    public GameObject PausePanel;
    public bool pausePanelActive = false;



    //bonus
    public Sprite presentSpriteYellow;
    public Sprite presentSpriteGreen;
    public Sprite presentSpriteBlue;
    public Sprite presentSpriteDarkBlue;
    public Sprite presentSpriteRed;
    public Sprite presentSpriteLila;
    public Sprite presentSpriteRainbow;
    public Sprite presentSpriteRainbow2;
    public Sprite presentSpriteRainbow3;
    public Sprite presentSpriteRainbow4;
    public Sprite presentSpriteRainbow5;
    public Sprite presentSpriteRainbow6;

    private Sprite currentPresentSprite;




    public Sprite blackSprite;


    public GameObject Test;


    public int bonusTileCount = 0;
    public int bonusCounter = 0;
    public bool stopCounting = false;


    public Sprite randomPresent;


    bool checkParentBoard = false;

    SpriteRenderer chosenTileFirstAppear;
    Tiles chosenTileFirst;


    public float timeSpeed = 0.4f;

    [SerializeField] public GameObject _parentObject;
    private int rnd = 0;
    private bool alreadyAssigned = false;
    private int randomChosenTile = 0;
    public int appearCounter = 0;

    public GameObject button;
    public Sprite buttonSpritePlay;
    public Sprite buttonSpritePause;

    //start board change after 4sec
    public int secondsToStart = 5;
    public IEnumerator toStartTimer;

    public List<Sprite> chosenSpritesArray;


    public int originalSeconds = 2;
    public int secondsLeft; public bool takingAway = false;
    public IEnumerator StartTimer;
    public List<Tiles> _nodes;
    public bool paused = false;
    public bool findScreenFinished = false;
    public bool gridPopulation = false;

    AudioManager audioManager;
    public Sound[] sounds;

    int count = 0;

    public bool checkForPopFinish = false;

    GameObject singleNode;

    public GameObject Instructions;
    bool showFeatureText = false;

    bool firstTimeapaused = false;
    bool startPause = false;


    bool instSetActive = false;
    bool running = false;
    bool activated = false;

    bool promo = false;

    public int appearedForSeach = 0;
    public bool resetappearedForSeachCounter = false;
    bool pauseOnce = false;

    public bool foundSearchedTile = false;
    public GlassAnim GlassAnim;

    bool bonusPopped = false;

    void Awake()
    {



        if (Instance == null)
        {
            Instance = this;

            _tileSpriteRenderer = _tilesPrefab?.GetComponent<SpriteRenderer>();
        }
        else
        {
            _tileSpriteRenderer = _tilesPrefab?.GetComponent<SpriteRenderer>();

        }



    }
    private void Start()
    {
        checkForPopFinish = false;
        secondsLeft = originalSeconds;
        audioManager = FindObjectOfType<AudioManager>();
        if (GameManager.Instance?.firstTime == true)
        {
            _maxRange = 16;
        }

        else
        {
            _maxRange = 55;
        }
        print("check " + _maxRange);
    }
    private void Update()
    {


        if (gridPopulation == true)
        {
            if (GameManager.Instance.bonusOn == true)
            {
            }


            if (checkForPopFinish == false && GameManager.Instance.bonusOn == false)
            {
                checkTiles();
            }
            // first play featuretile instr 
            else if (checkForPopFinish == true && GameManager.Instance.firstTime == true && showFeatureText == false && GameManager.Instance.firstFeatureTileAlreadyShown == false && instSetActive == false)
            {
                instSetActive = true;
                GameManager.Instance.firstFeatureTile = true;
                showFeatureText = true;
                Instructions.SetActive(true);
                GameManager.Instance.firstFeatureTileAlreadyShown = true;
                Time.timeScale = 0;

            }


            //if found in board           

            if (GameManager.Instance.firstFeatureTileAlreadyShown == true && GameManager.Instance.firstTime == true && Instructions.activeSelf == false && appearCounter == 1)
            {
                if (featureTile.openTile == false && activated == false)
                {
                    activated = true;
                    GameManager.Instance.firstBoardTile = true;
                    Instructions.SetActive(true);

                    _nodes.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
                    chosenTileFirstAppear.sortingOrder = 30000;
                    chosenTileFirst.GetComponent<BoxCollider2D>().enabled = true;
                }



            }

            if (appearedForSeach == 1 && GameManager.Instance.glassSearch == true && resetappearedForSeachCounter == true && foundSearchedTile == false)
            {
                foundSearchedTile = true;

                if (paused == false && pauseOnce == false)
                {
                    Featured.Instance.screenActive = false;
                    pauseOnce = true;
                    pauseBoard();

                }
                _nodes.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
                chosenTileFirst.GetComponent<BoxCollider2D>().enabled = true;
                chosenTileFirstAppear.sortingOrder = 30000;


                print("place vector of searched tile");
                GlassAnim.goalVector = chosenTileFirst.transform.localPosition;
                print("transf localpos" + chosenTileFirst.transform.localPosition);
                // bring glass to position
            }



            if (secondsToStart > 0)
            {
                toStartTimer = StartingTimer();
                StartCoroutine(toStartTimer);
            }

            else if (secondsToStart <= 0)
            {

                StopCoroutine(toStartTimer);        // <-- starting timer
                if (takingAway == false && secondsLeft > 0 && paused == false)
                {
                    StartTimer = Timer();

                    StartCoroutine(StartTimer);
                }
                else if (takingAway == false && secondsLeft == 0 && paused == false)
                {
                    if (GameManager.Instance.firstTime == true)
                    {
                        if (GameManager.Instance.firstFeatureTileAlreadyShown == true)
                        {
                            secondsLeft = originalSeconds;
                            changeSingleTile();
                        }
                    }
                    else if (GameManager.Instance.bonusOn == true)
                    {
                        secondsLeft = originalSeconds;
                        changeSingleBonusTile();
                    }
                    else
                    {
                        secondsLeft = originalSeconds;
                        changeSingleTile();
                    }

                }

            }
        }
        else if (gridPopulation == false && GameManager.Instance.bonusOn == true && bonusPopped == false && GameManager.Instance.popBonus == true)
        {
            print("gridPop ==false");


            bonusPopped = true;
            if (checkForPopFinish == false)
            {

                checkTiles();
            }

        }
    }


    public void checkCurrentNodes()
    {

        _nodes.ForEach((t) =>
        {
            if (t.GetComponent<SpriteRenderer>().sprite == featureTileSpriteRenderer.sprite)
            {
                // isINCurrentNodes
                appearedForSeach = 1;
                chosenTileFirstAppear = t.GetComponent<SpriteRenderer>();
                chosenTileFirst = t;

            }



        });
        if (paused == true && appearedForSeach == 0) //start board again
        {
            Featured.Instance.screenActive = true;

            print("start board again");
            pauseBoard();
            timeSpeed = 0.1f;
        }
    }



    public void PopSprite()
    {
        count = 0;


        if (GameManager.Instance.firstTime)
        {
            _nodes.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });

        }



        for (int i = 3; i < _nodes.Count; i += 4)
        {

            singleNode = _nodes[i].transform.GetChild(0).gameObject;


         
            LeanTween.scale(singleNode, new Vector3(.57f, .57f, 1.45f), 0.15f).setDelay(count / 9.5f).setEaseOutElastic(); //.setOnComplete(DestroyTileChild);


            DestroyTileChild();

        }

        for (int x = 2; x < _nodes.Count - 1; x += 4)
        {


            singleNode = _nodes[x].transform.GetChild(0).gameObject;

         
            LeanTween.scale(singleNode, new Vector3(.57f, .57f, 1.45f), 0.15f).setDelay(count / 9.5f).setEaseOutElastic(); //.setOnComplete(DestroyTileChild);

            DestroyTileChild();


        }

        for (int y = 1; y < _nodes.Count - 2; y += 4)
        {

            singleNode = _nodes[y].transform.GetChild(0).gameObject;


            LeanTween.scale(singleNode, new Vector3(.57f, .57f, 1.45f), 0.15f).setDelay(count / 9.5f).setEaseOutElastic(); //.setOnComplete(DestroyTileChild);

            DestroyTileChild();

        }

        for (int z = 0; z < _nodes.Count - 3; z += 4)
        {


            singleNode = _nodes[z].transform.GetChild(0).gameObject;

            LeanTween.scale(singleNode, new Vector3(.57f, .57f, 1.45f), 0.15f).setDelay(count / 9.5f).setEaseOutElastic(); //.setOnComplete(DestroyTileChild);
            DestroyTileChild();


        }


        if (count == 16)
        {
            gridPopulation = true;
            print("gridPopulation" + gridPopulation);
        }



        Featured.Instance.tile.GetComponent<BoxCollider2D>().enabled = true;
    }



    /*PLAY POP AUDIO*/
    void HideShowGameobject()
    {
        if (GameOver.Instance.win == false && GameOver.Instance.lose == false)
        {

            FindObjectOfType<AudioManager>().Play("pop");
        }

    }


    void DestroyTileChild()
    {
        Invoke("HideShowGameobject", (count + 0.019f) / 9.5f);

        print("Destroy!!");
        Destroy(singleNode, (count + 1.3f) / 9.5f);
        count += 1;
    }

    void checkTiles()  //check if everything popped
    {
        int childCountFour = 0;
        print("checktiles");

        for (int i = 0; i < 16; i++)
        {
            if (_nodes[i].transform.childCount == 4)
            {
                childCountFour = 4;
            }
            print("childcounter should not be 4" + childCountFour);

        }
        if (childCountFour == 0)
        {
            checkForPopFinish = true;
            print("checktiles finished");

            if (GameManager.Instance.bonusOn == false)
            {
                print("checktiles bonus on ==false");

                GameManager.Instance.SweetCoverGlass.SetActive(false);
                GameManager.Instance.SweetCoverHammer.SetActive(false);
                GameManager.Instance.ShopCoverGlass.SetActive(false);
                GameManager.Instance.InvCoverHammer.SetActive(false); //---> deactivate in board / checktiles
            }



        }


    }




    private Tiles getTile()
    {

        alreadyAssigned = false;
        Sprite firstSprite = Tiles.Instance.firstSprite.GetComponent<SpriteRenderer>().sprite;

      
        rnd = UnityEngine.Random.Range(_minRange, _maxRange);

        _tileSpriteRenderer.sprite = chosenSpritesArray[rnd];


        if (_nodes != null)
        {
            _nodes.ForEach((t) =>
            {
                //check duplicate
                if (t.GetComponent<SpriteRenderer>().sprite == _tileSpriteRenderer.sprite)
                {
                    alreadyAssigned = true;


                }
            
                //check if featureTile sprite appeared
                if (alreadyAssigned == false && t.GetComponent<SpriteRenderer>().sprite == featureTileSpriteRenderer.sprite)
                {
                    appearCounter = 1;
                    appearedForSeach = 1;
                    print("appeared onstart " + appearCounter);
                    if (appearCounter == 1 && GameManager.Instance.firstTime)
                    {
                        if (Featured.Instance.openTile == false && paused == false)
                        {
                            pauseBoard();
                        }
                        chosenTileFirstAppear = t.GetComponent<SpriteRenderer>();
                        chosenTileFirst = t;
                    }
                    if (appearedForSeach == 1 && GameManager.Instance.glassSearch == true)
                    {
                        if (Featured.Instance.openTile == false && paused == false)
                        {
                            Featured.Instance.screenActive = false;
                            pauseBoard();
                        }
                        chosenTileFirstAppear = t.GetComponent<SpriteRenderer>();
                        chosenTileFirst = t;
                    }
                
                }



            });
        }

     
        return _tilesPrefab;



    }


    public void ResizeArray()
    {
       
        print("first object in array" + chosenSpritesArray[0]);


        _maxRange = 30;
        chosenSpritesArray = chosenSpritesArray.GetRange(0, 30);
        // chosenSpritesArray = newArray;
        print("chosenArray count " + chosenSpritesArray.Count);

    }


    private List<Sprite> makeSpritesArray()
    {
       

        if (GameManager.Instance.firstTime == false)
        {

            _maxRange = 55;

            featureTileSpriteRenderer = featureTile._featureTilePrefab.GetComponent<SpriteRenderer>();
         
            chosenSpritesArray.Add(featureTileSpriteRenderer.sprite);


            for (int i = 0; i < _maxRange - 1; i++)
            {
                rnd = UnityEngine.Random.Range(_minRange, _maxRange);
                chosenSpritesArray.Add(_tilesPrefab?._gameObjects?[rnd]);
            }

        }

        else
        {
            _maxRange = 20;

            featureTileSpriteRenderer = featureTile._featureTilePrefab.GetComponent<SpriteRenderer>();


            //first sprite --> choseArray[0]  = f TIle
            chosenSpritesArray.Add(featureTileSpriteRenderer.sprite);


            for (int i = 0; i < _maxRange - 1; i++)
            {
                rnd = UnityEngine.Random.Range(_minRange, 80);
                chosenSpritesArray.Add(_tilesPrefab?._gameObjects?[rnd]);
            }


        }


        return chosenSpritesArray;
    }

    public void GenerateGrid()
    {


        makeSpritesArray();

        print("MAXX range" + _maxRange);


        if (checkParentBoard == false)
        {
            checkParentBoard = true;
            if (_parentObject.transform.childCount > 0)

            {
                var childCount = _parentObject.transform.childCount;
                for (int i = childCount - 1; i >= 0; i--)
                {
                    GameObject.DestroyImmediate(_parentObject.transform.GetChild(i).gameObject);
                }
                _nodes.Clear();
            }


        }

        _nodes = new List<Tiles>();
        int count = 0;

        if (_nodes.Count < 16 && _parentObject.transform.childCount < 16)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    count = x + y;

                    Instance.getTile();
                    while (alreadyAssigned == true)
                    {
                        getTile();
                        /*appearCounter = 1;*/
                        Debug.Log(" tile already in board");

                        //little fix?!
                        if (alreadyAssigned == false)
                        {
                            break;
                        }

                    }
                    print("Count" + count);

                    //     Tiles node = Instantiate(_tilesPrefab, new Vector2(x*0.82f, y*0.82f),Quaternion.identity);
                    //   node.transform.parent = _parentObject.transform;
                    Tiles node = Instantiate(_tilesPrefab);

                    node.transform.SetParent(_parentObject.transform, false);
                    //tile.transform.localPosition = new Vector3(0,27, 0);
                    node.transform.localPosition = new Vector3((x * 7f) - 10.5f, (y * 7f) - 10.5f, 1);

                    node.transform.localScale = new Vector3(0.642f, 0.642f, 0.65f);

                    _nodes.Add(node);
                    print(node);

                }



            }
        }




        //  var center = new Vector2((float)_width / 2 - 0.5f, _height / 2 + 0.5f);
        var center = new Vector2((float)_width / 2 - 0.81f, _height / 2 + 0.2f);
        Camera.main.transform.position = new Vector3(center.x, center.y, -10);


        // _nodes.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });

        //  Debug.Log("ft inst");
        /* FeatureTile.Instance?.choseFeatureTile();*/
        GameManager.Instance.ChangeState(GameState.ChoseTile);

    }





    private Tiles getBonusTile()
    {


        // _tileSpriteRenderer.sprite = _tilesPrefab?._gameObjects?[rnd];

        bonusTileCount += 1;

        if (GameManager.Instance.yellowPresentBonus)
        {
            currentPresentSprite = presentSpriteYellow;
        }
        else if (GameManager.Instance.greenPresentBonus)
        {
            currentPresentSprite = presentSpriteGreen;

        }
        else if (GameManager.Instance.bluePresentBonus)
        {
            currentPresentSprite = presentSpriteBlue;

        }
        else if (GameManager.Instance.darkBluePresentBonus)
        {
            currentPresentSprite = presentSpriteDarkBlue;

        }
        else if (GameManager.Instance.redPresentBonus)
        {
            currentPresentSprite = presentSpriteRed;

        }
        else if (GameManager.Instance.lilaPresentBonus)
        {
            currentPresentSprite = presentSpriteLila;

        }
        else if (GameManager.Instance.rainbowPresentBonus)
        {
            currentPresentSprite = presentSpriteRainbow;

        }
        else if (GameManager.Instance.rainbowPresentBonus2)
        {
            currentPresentSprite = presentSpriteRainbow2;

        }
        else if (GameManager.Instance.rainbowPresentBonus3)
        {
            currentPresentSprite = presentSpriteRainbow3;

        }
        else if (GameManager.Instance.rainbowPresentBonus4)
        {
            currentPresentSprite = presentSpriteRainbow4;

        }
        else if (GameManager.Instance.rainbowPresentBonus5)
        {
            currentPresentSprite = presentSpriteRainbow5;

        }
        else if (GameManager.Instance.rainbowPresentBonus6)
        {
            currentPresentSprite = presentSpriteRainbow6;

        }


        _tileSpriteRenderer.sprite = currentPresentSprite;


        return _tilesPrefab;



    }


    public void GenerateBonusGrid()
    {
       

        Featured.Instance.screenActive = false;



        timeSpeed = .1f;
    

        if (checkParentBoard == false)
        {
            checkParentBoard = true;
            if (_parentObject.transform.childCount > 0)

            {
                var childCount = _parentObject.transform.childCount;
                for (int i = childCount - 1; i >= 0; i--)
                {
                    GameObject.DestroyImmediate(_parentObject.transform.GetChild(i).gameObject);
                }
                _nodes.Clear();
            }


        }

        _nodes = new List<Tiles>();
        int count = 0;

        if (_nodes.Count < 16 && _parentObject.transform.childCount < 16)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    count = x + y;

                    Instance.getBonusTile();
                    //getBonusTIle


                    Tiles node = Instantiate(_tilesPrefab);

                    node.transform.SetParent(_parentObject.transform, false);
                    //tile.transform.localPosition = new Vector3(0,27, 0);
                    node.transform.localPosition = new Vector3((x * 7f) - 10.5f, (y * 7f) - 10.5f, 1);

                    node.transform.localScale = new Vector3(0.6559f, 0.6559f, 0.65f);

                    _nodes.Add(node);
                    print(node);

                }



            }
        }




        var center = new Vector2((float)_width / 2 - 0.81f, _height / 2 + 0.2f);
        Camera.main.transform.position = new Vector3(center.x, center.y, -10);

        GameManager.Instance.ChangeState(GameState.ChoseTile);

    }

    public void changeSingleTile()
    {


        randomChosenTile = UnityEngine.Random.Range(_minRange, _width * _width);
        alreadyAssigned = false;
        rnd = UnityEngine.Random.Range(_minRange, _maxRange);

        var randomChosenSprite = chosenSpritesArray[rnd];

        if (PresentTimer.Instance.changeToBonus == true)
        {
            _nodes[randomChosenTile].GetComponent<SpriteRenderer>().sprite = randomPresent;
            GameManager.Instance.presTimerActive = false;

            PresentTimer.Instance.changeToBonus = false;

        }
        else
        {


            //chose random tile
            _nodes.ForEach((t) =>
            {
                //random tile check duplicate
                if (t.GetComponent<SpriteRenderer>().sprite == randomChosenSprite)
                {
                    alreadyAssigned = true;


                    // var freeNodes = _nodes.Where();
                }
            });

            if (alreadyAssigned)
            {
                changeSingleTile();
            }
            else if (alreadyAssigned == false)
            {
                //set new sprite for single tile
                if (_nodes[randomChosenTile].GetComponent<SpriteRenderer>().sprite == randomPresent)
                {
                    print("present sprite changed");
                    PresentTimer.Instance.StartPresentTimer();
                }
                _nodes[randomChosenTile].GetComponent<SpriteRenderer>().sprite = randomChosenSprite;
            

                if (_nodes[randomChosenTile].GetComponent<SpriteRenderer>().sprite == featureTileSpriteRenderer.sprite)
                {

                    appearCounter += 1;
                    appearedForSeach += 1;
                    print("appeared changed tile" + appearCounter);
                    if (appearCounter == 1 && GameManager.Instance.firstTime)
                    {
                        if (Featured.Instance.openTile == true && paused == false)
                        {
                            pauseBoard();
                        }
                        chosenTileFirstAppear = _nodes[randomChosenTile].GetComponent<SpriteRenderer>();
                        chosenTileFirst = _nodes[randomChosenTile];
                    }
                    if (appearedForSeach == 1 && GameManager.Instance.glassSearch == true)
                    {
                        if (paused == false)
                        {
                            Featured.Instance.screenActive = false;
                            pauseBoard();
                        }
                        chosenTileFirstAppear = _nodes[randomChosenTile].GetComponent<SpriteRenderer>();
                        chosenTileFirst = _nodes[randomChosenTile];
                    }
                  
                }

            }

        }

    }




    public void PopBonus()
    {
        print("POP iTT");
        GameManager.Instance.bonusCollectAsManyAlertActive = false;
        GameManager.Instance.SweetCoverGlass.SetActive(true);
        GameManager.Instance.SweetCoverHammer.SetActive(true);
        GameManager.Instance.ShopCoverGlass.SetActive(true);
        GameManager.Instance.InvCoverHammer.SetActive(true); //---> deactivate in board / checktiles

        Board.Instance.PopSprite();
 
    }

    public void changeSingleBonusTile()
    {

        bonusTileCount += 1;

        //    var randomChosenSprite = _tilesPrefab._gameObjects?[rnd];
        randomChosenTile = UnityEngine.Random.Range(_minRange, _width * _width);


        // get random nodes sprite
        var nodeSprite = _nodes[randomChosenTile].GetComponent<SpriteRenderer>().sprite;
        //chose random tile
        _nodes.ForEach((t) =>
        {

            if (t.GetComponent<SpriteRenderer>().sprite == blackSprite)
            {

                //deactivate highlight?
                t.transform.GetChild(1).gameObject.SetActive(false);
            }
        });
        _nodes[randomChosenTile].GetComponent<SpriteRenderer>().sprite = currentPresentSprite;






        if (bonusTileCount == 50)
        {
            stopCounting = true;
            if (paused == false)
            {
                pauseBoard();
                GameManager.Instance.ChangeState(GameState.WinBonus);
            }
        }



    }




    public void pauseBoard()
    {
        if (gridPopulation == true)
        {
            //normal mode 
            if (paused == false && Featured.Instance.screenActive == false)
            {
                //    print(paused);
                button.GetComponent<Image>().sprite = buttonSpritePlay;
                paused = true;
                if (takingAway == true && secondsLeft > 0)
                {

                    StopCoroutine(StartTimer);
                }



            }
         
            else if (paused == true && Featured.Instance.screenActive == false)
            {
                if (takingAway == true && secondsLeft > 0)
                {

                    StopCoroutine(StartTimer);
                }
            }
            // 

            else if (paused == true && Featured.Instance.screenActive == true)
            {
                button.GetComponent<Image>().sprite = buttonSpritePause;
                //  print(paused);

                paused = false;

                StartTimer = Timer();

                StartCoroutine(StartTimer);
                secondsLeft = originalSeconds;

                if (Featured.Instance.openTile == true || Featured.Instance.clicked == true)
                {
                    Featured.Instance.StartCoroutine(Featured.Instance.FeatureTimer);
                    //decrease coin after warning
                }

            }
        }
    }
    public void PauseButton()
    {

        //only after popanimation

        if (GameManager.Instance.notClickable == false)
        {

            /*PAUSE IF NOT ALREADY PAUSED*/
            if (paused == false && pausePanelActive == false && Featured.Instance.screenActive == false && gridPopulation == true && checkForPopFinish == true)
            {
                ThemeSound.Instance.audio.volume = 0.04f;

                button.GetComponent<Image>().sprite = buttonSpritePlay;
                paused = true;
                StopCoroutine(StartTimer);
                pausePanelActive = true;


                PausePanel.SetActive(true);
            }

            else if (paused == true && Featured.Instance.screenActive == false && gridPopulation == true && checkForPopFinish == true)
            {
                ThemeSound.Instance.audio.volume = 0.1f;

                button.GetComponent<Image>().sprite = buttonSpritePause;
                //  print(paused);

                paused = false;
                pausePanelActive = false;

                StartTimer = Timer();

                StartCoroutine(StartTimer);
                secondsLeft = originalSeconds;



            }
        }
    }


    public void changeBonusClickedSingleTile(int positionIndex)
    {
        randomChosenTile = UnityEngine.Random.Range(_minRange, _width * _width);
        alreadyAssigned = false;
        rnd = UnityEngine.Random.Range(_minRange, _maxRange);

        var randomChosenSprite = _tilesPrefab._gameObjects?[rnd];

        _nodes.ForEach((t) =>
        {

            _nodes[positionIndex].GetComponent<SpriteRenderer>().sprite = blackSprite;

        });
    }


    public void changeClickedSingleTile(int positionIndex)
    {
        randomChosenTile = UnityEngine.Random.Range(_minRange, _width * _width);
        alreadyAssigned = false;
        rnd = UnityEngine.Random.Range(_minRange, _maxRange);

        var randomChosenSprite = _tilesPrefab._gameObjects?[rnd];

        _nodes.ForEach((t) =>
        {
            if (t.GetComponent<SpriteRenderer>().sprite == randomChosenSprite)
            {
                alreadyAssigned = true;


            }
        });
        if (alreadyAssigned)
        {
            changeClickedSingleTile(positionIndex);
        }
        else
        {
            _nodes[positionIndex].GetComponent<SpriteRenderer>().sprite = randomChosenSprite;
            if (_nodes[randomChosenTile].GetComponent<SpriteRenderer>().sprite == featureTileSpriteRenderer.sprite)
            {
                appearCounter += 1;
                appearedForSeach += 1;
            }

        }
    }


    IEnumerator Timer()
    {
        takingAway = true;
        yield return new WaitForSeconds(timeSpeed);
        secondsLeft--;
        takingAway = false;
    }

    IEnumerator StartingTimer()
    {

        yield return new WaitForSeconds(1);
        secondsToStart--;

    }
}
