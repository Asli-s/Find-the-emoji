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


    public GameObject Instructions;
    public GameObject firstSprite;
    SpriteRenderer TileSpriteRenderer;


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
        else if(Featured.Instance.screenActive == false)
        {
            if (win == false && GameOver.Instance.lose ==false)
            {


           FindObjectOfType<AudioManager>().Play("jump", false);
            }
         //   FindObjectOfType<AudioManager>().Play("right");


     //       print("stillClicked!");
            clickedTile = GetComponent<SpriteRenderer>().sprite;
            TileSpriteRenderer = GetComponent<SpriteRenderer>();
            //  print(clickedTile);

            if (clickedTile == _featureTileSprite.sprite)
            {
                //  FindObjectOfType<AudioManager>().Play("yes",false);

                if(GameManager.Instance.firstTime == true)
                {
                    print("win screen sorting order");
                    gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    Instructions.SetActive(false);
                    GameManager.Instance.notClickable = false;

                    GameManager.Instance.firstBoardTile = false;
                    Featured.Instance.screenActive = false;
                }



               FindObjectOfType<PlayExtraSound>().Play("win"); /// play yes sound


                Debug.Log("win!");
                win = true;
                GameManager.Instance.ChangeState(GameState.Win);
                // enable highlight 
                _highlight.SetActive(true);

            }
            else if (clickedTile != _featureTileSprite.sprite)
            {
                positionInArray =
                      _board._nodes.FindIndex(x => x.Equals(_tile));
           //     health.GetComponent<HealthHearts>().loseLife();
                HealthHearts.Instance.loseLife();
              //  print(health.GetComponent<HealthHearts>().health);




                // }



            }




        }





    }
    /*    private void OnMouseExit()
        {


            _highlight?.SetActive(false);

        }*/
  







}
