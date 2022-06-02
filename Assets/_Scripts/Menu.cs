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

    private bool openMenu = false;
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
        MenuButtons();
    }


    private void MenuButtons()
    {
     //   levelName = SceneManager.GetActiveScene().name;

        /*COLORING BUTTONS*/

        
        if (GameManager.Instance.positionStringLoad == "slow")
        {
            buildIndex = 0;
        }
        else if (GameManager.Instance.positionStringLoad == "med")
        {
            buildIndex = 1;
        }
        else if (GameManager.Instance.positionStringLoad == "hard")
        {
            buildIndex = 2;
        }
        print(GameManager.Instance.positionStringLoad);


        //   print(buildIndex);
        for (int i = 0; i < Buttons.Length; i++)
        {
            //  print(Buttons[i]);
            if (i == buildIndex)
            {
                singleButton = Buttons[i].GetComponent<Image>();
                //   singleButton.color = new Color32(86,140,210,230);
                singleButton.color = new Color32(92, 209, 209, 255);

                // new Color32(207,91, 177,255);

            }
            else
            {
                Buttons[i].GetComponent<Image>().color = new Color32(138, 253, 255, 255);
                //new Color32(255,116,220,255);


            }
        }

    }
    public void showScreen()
    {
        //  print("now");
        /*   if (Featured.Instance.screenActive == false &&findFeatureScreenAnim.Instance.animEnded ==true)
           {*/

        print("inside showscreen");

        /* NO OTHER SCREENS ACTIVE*/
        if (openMenu == false && additionalMenu == false && _board.paused == false && findScreen.activeSelf == false && Featured.Instance.screenActive == false)//&& Board.Instance.pausePanelActive == false)
        {
            ThemeSound.Instance.audio.volume = 0.04f;
            //  print("first");

            _board.pauseBoard();
            _allTiles = _board._nodes;
            /* _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
             featureTile.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;*/



            //   StopCoroutine(_board.StartTimer); -->>test this 03.05
            openMenu = true;
            //   Featured.Instance.screenActive = true;
            MenuScreen.SetActive(true);
            Button.GetComponent<Image>().sprite = closeMenuSprite;


        }

        /* NO OTHER SCREENS ACTIVE but board is already paused*/

        else if (openMenu == false && additionalMenu == false && _board.paused == true && findScreen.activeSelf == false && Featured.Instance.screenActive == false)// && Board.Instance.pausePanelActive == false)
        {
            _allTiles = _board._nodes;

            openMenu = true;
            //      Featured.Instance.screenActive = true;

            MenuScreen.SetActive(true);
            Button.GetComponent<Image>().sprite = closeMenuSprite;
        }

        /*MENU IS ACTIVE AND STATS IS ACTIVE --open stats*/
        else if (additionalMenu == true && openMenu == true && findScreen.activeSelf == false && Featured.Instance.screenActive == true)// && Board.Instance.pausePanelActive == false)
        {
            //   print("third");

            Button.GetComponent<Image>().sprite = closeMenuSprite;
            additionalMenu = false;
            additionalScreenStats.SetActive(false);
            //         Featured.Instance.screenActive = true;



        }
        /*MENU IS ACTIVE / STATS IS NOT ACTIVE --close the menu*/
        else if (openMenu == true && additionalMenu == false && findScreen.activeSelf == false && Featured.Instance.screenActive == true)
        {


            MenuButtons();

            openMenu = false;
            // MenuScreen.SetActive(false); -----> call close from menu script
            MenuAnim.Instance.CloseMenuAnim();

            ThemeSound.Instance.audio.volume = 0.1f;

            Button.GetComponent<Image>().sprite = openMenuSprite;

            _board.pauseBoard();

        }

        /*    else { return; }*/

    }


    public void addditionalMenuPopUp()
    {
        Featured.Instance.screenActive = true;

        additionalMenu = true;
        additionalScreenStats.SetActive(true);
        Button.GetComponent<Image>().sprite = backSprite;

    }


    /*MUSIC SOUND FUNCTIONS */



    void SoundToggle()
    {
        DataPersistenceManager.Instance.SaveGame();

    }

    void MusicToggle()
    {
        DataPersistenceManager.Instance.SaveGame();


    }


/*
    public void slowSceneLoaderClicked()
    {

        GameManager.Instance.ChangeState(GameState.changeToSlowScene);

    }

    public void medSceneLoaderClicked()
    {

        GameManager.Instance.ChangeState(GameState.changeToMedScene);
    }
    public void hardSceneLoaderClicked()
    {

        GameManager.Instance.ChangeState(GameState.changeToHardScene);
    }

*/
    public void LoadSceneSlow()
    {
        GameManager.Instance.positionStringLoad="slow";
        Board.Instance.timeSpeed =1.1f;
        DataPersistenceManager.Instance.SaveGame();
        showScreen();

      //  StopAllCoroutines();
        /* GameManager.Instance.*/

    }
    public void LoadSceneMedium()
    {

        GameManager.Instance.positionStringLoad = "med";
        Board.Instance.timeSpeed =0.8f;
        DataPersistenceManager.Instance.SaveGame();
        showScreen();



    }
    public void LoadSceneFast()
    {
        GameManager.Instance.positionStringLoad = "hard";
        Board.Instance.timeSpeed =0.5f;

        DataPersistenceManager.Instance.SaveGame();
        showScreen();

    }





    /*
        public void LoadSceneSlow()
        {
            DataPersistenceManager.Instance.SaveGame();

            StopAllCoroutines();
            *//* GameManager.Instance.*//*
            SceneManager.LoadScene("slow");

        }
        public void LoadSceneMedium()
        {
            DataPersistenceManager.Instance.SaveGame();

            StopAllCoroutines();

            SceneManager.LoadScene("med");


        }
        public void LoadSceneFast()
        {
            DataPersistenceManager.Instance.SaveGame();

            StopAllCoroutines();

            SceneManager.LoadScene("hard");

        }
    */


}
