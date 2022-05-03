using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour   //   ,IDataPersistence

{
    public static Menu Instance;


    public Board _board;
    public GameObject MenuScreen;
    public GameObject additionalScreenStats;
  //  public GameObject additionalScreenStats;
  //  public GameObject additionalScreenStats;

    

    public GameObject Button;
    public Sprite openMenuSprite;
    public Sprite closeMenuSprite;
    public Sprite backSprite;
    public GameObject featureTile;
    private List<Tiles> _allTiles;
    public GameObject[] Buttons;
    private Image singleButton;
    private int buildIndex;
    private string levelName;

    public GameObject findScreen;

    private bool openMenu=false;
    public bool additionalMenu = false;
    // Start is called before the first frame update


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
    }
    private void Update()
    {
      //  print(Featured.Instance.screenActive );
    }



    private void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        if(levelName == "slow")
        {
            buildIndex = 0;
        }else  if (levelName == "med")
            {
                buildIndex = 1;
            }
        else if (levelName == "hard")
        {
            buildIndex = 2;
        }


        print(buildIndex);
        for (int i = 0; i < Buttons.Length; i++)
        {
            print(Buttons[i]);
         if(i == buildIndex)
            {
                singleButton = Buttons[i].GetComponent<Image>();
                singleButton.color = new Color32(86,140,210,230);
                    
                    // new Color32(207,91, 177,255);

            }
            else
            {
                Buttons[i].GetComponent<Image>().color = new Color32(128,183,255,230);
                    //new Color32(255,116,220,255);

            }
        }
        
    }
    public void showScreen()
    {
            print("now");
        
        if(openMenu == false && additionalMenu ==false && _board.paused == false && findScreen.activeSelf==false && Featured.Instance.screenActive==false)
        {

            _board.pauseBoard();
            _allTiles = _board._nodes;
           /* _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
            featureTile.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;*/
            StopCoroutine(_board.StartTimer);
            openMenu = true;
            Featured.Instance.screenActive = true;
            MenuScreen.SetActive(true);
            Button.GetComponent<Image>().sprite = closeMenuSprite;


        }
        else if (openMenu == false && additionalMenu == false && _board.paused == true && findScreen.activeSelf == false && Featured.Instance.screenActive == false)
        {
            _allTiles = _board._nodes;
          /*  _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
            featureTile.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;*/
            StopCoroutine(_board.StartTimer);
            openMenu = true;
            Featured.Instance.screenActive = true;

            MenuScreen.SetActive(true);
            Button.GetComponent<Image>().sprite = closeMenuSprite;
        }
       else if(additionalMenu == true &&openMenu ==true && findScreen.activeSelf == false   && Featured.Instance.screenActive == true)
        {
            Button.GetComponent<Image>().sprite = closeMenuSprite;
            additionalMenu = false;
            additionalScreenStats.SetActive(false);
            Featured.Instance.screenActive = true;



        }
        else if(openMenu ==true && additionalMenu == false && findScreen.activeSelf == false &&  Featured.Instance.screenActive == true) 
        {
            print("close");

           /* _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = true; });
            featureTile.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;*/
            StartCoroutine(_board.StartTimer);

            openMenu = false;
            // MenuScreen.SetActive(false); -----> call close from menu script
            LoadMenu.Instance.CloseMenuAnim();


            Button.GetComponent<Image>().sprite = openMenuSprite;

            _board.pauseBoard();

        }


    }


    public void addditionalMenuPopUp()
    {
            Featured.Instance.screenActive = true;

        additionalMenu = true;
        additionalScreenStats.SetActive(true);
        Button.GetComponent<Image>().sprite = backSprite;

    }





    public void slowSceneLoaderClicked()
    {
       GameManager.Instance.ChangeState( GameState.changeToSlowScene);
    }


    public void medSceneLoaderClicked()
    {
        GameManager.Instance.ChangeState(GameState.changeToMedScene);
    }
    public void hardSceneLoaderClicked()
    {
        GameManager.Instance.ChangeState(GameState.changeToHardScene);
    }



    public void LoadSceneSlow()
    {
        StopAllCoroutines();
        /* GameManager.Instance.*/
        SceneManager.LoadScene("slow");
   //     GameManager.Instance.lastPosition = 0;

    }
    public void LoadSceneMedium()
    {
        StopAllCoroutines();

        SceneManager.LoadScene("med");
     //   GameManager.Instance.lastPosition = 1;


    }
    public void LoadSceneFast()
    {
        StopAllCoroutines();

        SceneManager.LoadScene("hard");
      //  GameManager.Instance.lastPosition =2;


    }


    //data save/load functions
    /*   public void LoadData(GameData gameData)
       {
           this.coinNum = gameData.coinNumber;
           lastPosition = gameData.lastPos;
       }
       public void SaveData(GameData gameData)
       {
           gameData.coinNumber = this.coinNum;
           gameData.lastPos = lastPosition;
       }*/
}
