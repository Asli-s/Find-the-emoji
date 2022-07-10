using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject findScreenText;
    public GameObject featureTileText;
    public GameObject boardText;
    public GameObject winText;

    public GameObject FeatureTile;
    private GameObject FeatureTileObj;
    public GameObject HeartPopUp;
    public GameObject Button;

    private List<Tiles> _allTiles;

    public Board Board;

    public GameObject MenuButton;
    public GameObject PauseButton;
    public GameObject RestartButton;



    private void OnEnable()
    {



        GameManager.Instance.notClickable = true;



      //  if() coming from findscreen activate obj1
      if(GameManager.Instance.firstFindScreen == true)
        {
            findScreenText.SetActive(true);
        }
      else if (GameManager.Instance.firstFeatureTile == true)
        { // featureprefab sorting 
            featureTileText.SetActive(true);
            Featured.Instance.instruction = true;
          
           FeatureTileObj= FeatureTile.transform.GetChild(0).gameObject;
              FeatureTileObj.GetComponent<SpriteRenderer>().sortingOrder = 30000;
            FeatureTileObj.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 30005;
          //HeartPopUp.GetComponent<Canvas>().sortingOrder = 310000;
            Board.pauseBoard();
          //  Button.SetActive(true);


            _allTiles = Board._nodes;

                 _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });


        }
        else if (GameManager.Instance.firstBoardTile == true)
        {
          

            featureTileText.SetActive(false);
            FeatureTileObj = FeatureTile.transform.GetChild(0).gameObject;
            FeatureTileObj.GetComponent<BoxCollider2D>().enabled = false;


            boardText.SetActive(true);

            Button.SetActive(false);
            FeatureTileObj = FeatureTile.transform.GetChild(0).gameObject;

            FeatureTileObj.GetComponent<SpriteRenderer>().sortingOrder = 2;
            FeatureTileObj.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 4;

            Board.pauseBoard();

    

        }
        else if (GameManager.Instance.firstWin == true)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Canvas>().sortingOrder = 200;
            boardText.SetActive(false) ;
            winText.SetActive(true);
        }
    }
    private void Update()
    {

        if (Input.GetMouseButtonUp(0)) { 
        print("mouseClick");

        if (findScreenText.activeSelf == true)
        {
            print("yess");
            gameObject.SetActive(false);

                GameManager.Instance.notClickable = false;

            findScreenText.SetActive(false);
            Time.timeScale = 1;
                GameManager.Instance.firstFindScreen = false;
                findScreenText.SetActive(false);
                Featured.Instance.screenActive = false;

            }
            if (winText.activeSelf ==true)
            {
                GameManager.Instance.notClickable = false;

                gameObject.SetActive(false);
                Featured.Instance.screenActive = false;
            }
       /* else if (featureTileText.activeSelf == true)
            {
                print("featureClicked");
                FindObjectOfType<ClickSound>().Click();
                //print("feauturetiile clicked");

                Featured.Instance.FeatureTileClicked();
            }*/
        }
    }


  
    
}



//steps

//find screen
//featuretile open
//findinboard and show when appeared