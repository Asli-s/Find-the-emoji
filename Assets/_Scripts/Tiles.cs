using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class Tiles : MonoBehaviour
{
    public static Tiles Instance;
    public Sprite[] _gameObjects;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private Featured _featureTile;
    private SpriteRenderer _featureTileSprite;
    private Sprite clickedTile;
   // bool clicked = false;
    public GameObject health;
    private bool win = false;
    public Board _board;
    public Tiles _tile;
    private int positionInArray;

    public GameObject glassObject;

  


    public GameObject Instructions;
    public GameObject firstSprite;
    SpriteRenderer TileSpriteRenderer;


    public GameObject glassScreen;

    void Awake()
       
    {
        if (Instance == null) {
            Instance = this;
            _featureTileSprite = _featureTile._featureTilePrefab.GetComponent<SpriteRenderer>();
         
          //   healthSet.healthFunction(health);
        }
        else
        {
            _featureTileSprite = _featureTile._featureTilePrefab.GetComponent<SpriteRenderer>();
         
            //   GetComponent<HealthHearts>().healthFunction(health);


        }

    }
     void Start()
    {
     
        _highlight.SetActive(false);

   


    }
    public void checkForClicks()
    {
        if(win)
        {
            //Debug.Log("true");
        }
    }
  
/*
    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {

            _highlight.SetActive(true);

        }

        
        

    
    }
*/
   
    public void OnMouseDown()
    {
        /*  if (!EventSystem.current.IsPointerOverGameObject())
          {*/

        if (EventSystem.current.IsPointerOverGameObject()&& Featured.Instance.screenActive == true || Board.Instance.pausePanelActive == true && EventSystem.current.IsPointerOverGameObject())
        {
            //It means clicked on panel. So we do not consider this as click on game Object. Hence returning. 
            print("gui"+ EventSystem.current.IsPointerOverGameObject());
            return;
        }
       
        else if(Featured.Instance.screenActive == false && GameManager.Instance.bonusCollectAsManyAlertActive == false)
        {
            clickedTile = GetComponent<SpriteRenderer>().sprite;
            TileSpriteRenderer = GetComponent<SpriteRenderer>();
            //  print(clickedTile);

            if (win == false && GameOver.Instance.lose ==false && GameManager.Instance.bonusOn ==false && clickedTile != Board.Instance.randomPresent)
            {

              
           FindObjectOfType<AudioManager>().Play("jump", false);
            }
     
            //   FindObjectOfType<AudioManager>().Play("right");


            //       print("stillClicked!");
          
            if (GameManager.Instance.bonusOn == false)
            {
                if (clickedTile == _featureTileSprite.sprite)
                {
                    //  FindObjectOfType<AudioManager>().Play("yes",false);

                    if (GameManager.Instance.firstTime == true)
                    {
                        print("win screen sorting order");
                        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                        Instructions.SetActive(false);
                        GameManager.Instance.notClickable = false;

                        GameManager.Instance.firstBoardTile = false;
                        Featured.Instance.screenActive = false;
                    }

                    if (GameManager.Instance.glassSearch == true)
                    {
                        print("win screen sorting order");
                        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;

                        GameManager.Instance.notClickable = false;
                        glassScreen.SetActive(false);

                        //deactivate backPanel 
                        //deactivate glassanim

                        glassObject.SetActive(false);


                        Featured.Instance.screenActive = false;
                    }


                    FindObjectOfType<PlayExtraSound>().Play("win"); /// play yes sound


                    Debug.Log("win!");
                    win = true;
                    GameManager.Instance.ChangeState(GameState.Win);
                    // enable highlight 
                    _highlight.SetActive(true);

                }
                else if (clickedTile != _featureTileSprite.sprite && clickedTile != Board.Instance.randomPresent)
                {
                    positionInArray =
                          _board._nodes.FindIndex(x => x.Equals(_tile));
                    //     health.GetComponent<HealthHearts>().loseLife();
                    HealthHearts.Instance.loseLife();
                    //  print(health.GetComponent<HealthHearts>().health);




                    // }



                }
                else if(clickedTile == Board.Instance.randomPresent)
                {

                    //anim get essential
                    FindObjectOfType<AudioManager>().Play("right", false);

                    positionInArray =
                         _board._nodes.FindIndex(x => x.Equals(_tile));
                    GameManager.Instance.ChangeState(GameState.GetEssential);
                    Board.Instance.changeClickedSingleTile(positionInArray);

                }



            }

            else if (GameManager.Instance.bonusOn == true)
            {
                if(clickedTile != Board.Instance.blackSprite && gameObject.transform.childCount!=4)
                {

                   
                    if(Board.Instance.stopCounting == false)
                    {
                        FindObjectOfType<AudioManager>().Play("jump", false);

                        _highlight.SetActive(true);

                        positionInArray = _board._nodes.FindIndex(x => x.Equals(_tile));
                        Board.Instance.changeBonusClickedSingleTile(positionInArray);

                        Board.Instance.bonusCounter += 1;
                    }

                    print("bonuscounter " + Board.Instance.bonusCounter);
                }
            
                // counter 
                            }
        }



     

    }
    /*    private void OnMouseExit()
        {


            _highlight?.SetActive(false);

        }*/
  







}
