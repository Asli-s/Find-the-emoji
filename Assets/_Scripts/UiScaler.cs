using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScaler : MonoBehaviour
{

    //Variables
    public static UiScaler Instance;
    bool isTablet = false;


    public GameObject Game;
    private RectTransform rectTransformGame;


    public GameObject ControlButtons;
    private RectTransform rectTransformControlButtons;

    //TODO  scale screens (Findscreen etc) +menu + FirstScreen

    //-findScreen
    public GameObject findScreen;
    private RectTransform rectTransformFindScreen;

    //-winScreen
    public GameObject winScreen;

    private RectTransform rectTransformWinScreen;  
    //-loseScreen
    public GameObject loseScreen;
    private RectTransform rectTransformLoseScreen;


    //-menuScreen
    public GameObject menuScreen;
    private RectTransform rectTransformMenuScreen;
    //-statsScreen
    public GameObject statsScreen;
    private RectTransform rectTransformStatsScreen;

    //menuPanel
    //hearts //coins // menubutton
    public GameObject menuBackgroundPanel; //--image
    private RectTransform rectTransformMenuBackgroundPanel;

    public GameObject menuMiddleObjects; //-- heart --streak
    private RectTransform rectTransformMenuMiddleObjects;

    public GameObject menuPanel; //-- whole Panel
    private RectTransform rectTransformMenuPanel;


    //hearts
    public GameObject hearts; 
    private RectTransform heartsRect;
    //coin
    public GameObject coins; 
    private RectTransform coinsRect; 
    //menuButton
    public GameObject menuBut;
    private RectTransform menuButRect;



    //FirstScreen

    public GameObject LogoImage; //-- whole Panel
    private RectTransform rectTransformLogoImage;

    public GameObject ButtonPos; //-- whole Panel
    private RectTransform rectTransformButtonPos;





    //popups










    //Functions

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("already an instance created");
        }
        Instance = this;
    }

    // Start is called before the first frame update
    public  void CheckResolution()
    {// presist tablet or phone settings? 
        if (GameManager.Instance.tablet == false && GameManager.Instance.phone == false)
        {
            var aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
             isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);
            print("tablet"+ isTablet);
            if (isTablet)
            {
                GameManager.Instance.tablet = true;
                // change ui scale

                //game
              rectTransformGame=  Game.GetComponent<RectTransform>();
                rectTransformGame.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                //control buttons
                rectTransformControlButtons = ControlButtons.GetComponent<RectTransform>();
                rectTransformControlButtons.localScale = new Vector3(0.8f, 0.8f, 1.0f);

                //Find Screen
                rectTransformFindScreen = findScreen.GetComponent<RectTransform>();
                rectTransformFindScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                //Win Screen
                rectTransformWinScreen = winScreen.GetComponent<RectTransform>();
                rectTransformWinScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                //Lose Screen
                rectTransformLoseScreen = loseScreen.GetComponent<RectTransform>();
                rectTransformLoseScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);


                //menu Screen
                rectTransformMenuScreen = menuScreen.GetComponent<RectTransform>();
                rectTransformMenuScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);      
                //Lose Screen
                rectTransformStatsScreen = statsScreen.GetComponent<RectTransform>();
                rectTransformStatsScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);

                //menuPanel Screen
                rectTransformMenuBackgroundPanel = menuBackgroundPanel.GetComponent<RectTransform>();
                rectTransformMenuBackgroundPanel.localScale = new Vector3(1f, 0.9f, 1.0f);

                //menuPanel Middle Objects
                rectTransformMenuMiddleObjects = menuMiddleObjects.GetComponent<RectTransform>();
                rectTransformMenuMiddleObjects.anchoredPosition=     new Vector3(0, 7, 0);

                //menuPanel Main!
                rectTransformMenuPanel = menuPanel.GetComponent<RectTransform>();          
                rectTransformMenuPanel.anchoredPosition = new Vector3(0, -112f, 0);
                rectTransformMenuPanel.localScale = new Vector3(1f, 1f, 1.0f);



                //hearts
                heartsRect = hearts.GetComponent<RectTransform>();
                heartsRect.localScale = new Vector3(1.7f, 1.7f, 1.0f);
                //coin
                coinsRect = coins.GetComponent<RectTransform>();
                coinsRect.localScale = new Vector3(0.8f, 0.8f, 1.0f);  
                //menuButton
                menuButRect = menuBut.GetComponent<RectTransform>();
                menuButRect.localScale = new Vector3(0.8f, 0.8f, 1.0f);


                //LOGO 
                rectTransformLogoImage = LogoImage.GetComponent<RectTransform>();
                rectTransformLogoImage.anchoredPosition = new Vector3(7, 247f, 1);
                rectTransformLogoImage.localScale = new Vector3(0.9f, 0.8f, 1.0f);

                //FirstScreenButton
                rectTransformButtonPos = ButtonPos.GetComponent<RectTransform>();
                rectTransformButtonPos.anchoredPosition = new Vector3(0,258f, 1);
                rectTransformButtonPos.localScale = new Vector3(0.8f, 0.8f, 1.0f);




            }
            else
            {
                GameManager.Instance.phone = true;
                // change ui scale
                //game
                rectTransformGame = Game.GetComponent<RectTransform>();
                rectTransformGame.localScale = new Vector3(1f, 1f, 1.0f);

                //control buttons
                rectTransformControlButtons = ControlButtons.GetComponent<RectTransform>();
                rectTransformControlButtons.localScale = new Vector3(1f, 1f, 1.0f);

                //Find Screen
                rectTransformFindScreen = findScreen.GetComponent<RectTransform>();
                rectTransformFindScreen.localScale = new Vector3(1f, 1f, 1.0f);
                //Win Screen
                rectTransformWinScreen = winScreen.GetComponent<RectTransform>();
                rectTransformWinScreen.localScale = new Vector3(1f, 1f, 1.0f);
                //Lose Screen
                rectTransformLoseScreen = loseScreen.GetComponent<RectTransform>();
                rectTransformLoseScreen.localScale = new Vector3(1f, 1f, 1.0f);

                //menu Screen
                rectTransformMenuScreen = menuScreen.GetComponent<RectTransform>();
                rectTransformMenuScreen.localScale = new Vector3(1f, 1f, 1.0f);
                //Lose Screen
                rectTransformStatsScreen = statsScreen.GetComponent<RectTransform>();
                rectTransformStatsScreen.localScale = new Vector3(1f,1f, 1.0f);
                //menuPanel Screen
                rectTransformMenuBackgroundPanel = menuBackgroundPanel.GetComponent<RectTransform>();
                rectTransformMenuBackgroundPanel.localScale = new Vector3(1f, 1f, 1.0f);


                //menuPanel Middle Objects
                rectTransformMenuMiddleObjects = menuMiddleObjects.GetComponent<RectTransform>();
                //    rectTransformMenuMiddleObjects.localPosition = new Vector3(0f,0f, 1.0f);
                rectTransformMenuMiddleObjects.anchoredPosition = new Vector3(0, 0, 0);


                //menuPanel Main!
                rectTransformMenuPanel = menuPanel.GetComponent<RectTransform>();
                //  rectTransformMenuPanel.localPosition = new Vector3(0f, -120f, 1.0f);
                rectTransformMenuPanel.anchoredPosition = new Vector3(0, -120f, 0);

                rectTransformMenuPanel.localScale = new Vector3(1f, 1.1f, 1.0f);


                //hearts
                heartsRect = hearts.GetComponent<RectTransform>();
                heartsRect.localScale = new Vector3(2f, 1.8f, 1.0f);
                //coin
                coinsRect = coins.GetComponent<RectTransform>();
                coinsRect.localScale = new Vector3(1f, 0.9f, 1.0f);
                //menuButton
                menuButRect = menuBut.GetComponent<RectTransform>();
                menuButRect.localScale = new Vector3(1f, 0.9f, 1.0f);

                //LOGO 
                rectTransformLogoImage = LogoImage.GetComponent<RectTransform>();
                rectTransformLogoImage.anchoredPosition = new Vector3(7, 400f, 1);
                rectTransformLogoImage.localScale = new Vector3(1.1f, 1, 1.0f);

                //FirstScreenButton
                rectTransformButtonPos = ButtonPos.GetComponent<RectTransform>();
                rectTransformButtonPos.anchoredPosition = new Vector3(0, 364f, 1);
                rectTransformButtonPos.localScale = new Vector3(1f, 1f, 1.0f);

            }

            GameManager.Instance.ChangeState(GameState.CheckTimer);
        }
        else
        {



            //temporarily
            var aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
            print(aspectRatio);
            isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);


            if (isTablet)
            {
                GameManager.Instance.tablet = true;
                GameManager.Instance.phone = false;

            }
            else
            {
                GameManager.Instance.phone = true;
                GameManager.Instance.tablet = false;


            }

            print("not both false , tablet" + GameManager.Instance.tablet);
            ////////////////////
            ///

            if (GameManager.Instance.tablet == true)
            {
                // change ui scale
                //game
                rectTransformGame = Game.GetComponent<RectTransform>();
                rectTransformGame.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                //control buttons
                rectTransformControlButtons = ControlButtons.GetComponent<RectTransform>();
                rectTransformControlButtons.localScale = new Vector3(0.8f, 0.8f, 1.0f);
                //Find Screen
                rectTransformFindScreen = findScreen.GetComponent<RectTransform>();
                rectTransformFindScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                //Win Screen
                rectTransformWinScreen = winScreen.GetComponent<RectTransform>();
                rectTransformWinScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                //Lose Screen
                rectTransformLoseScreen = loseScreen.GetComponent<RectTransform>();
                rectTransformLoseScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);

                //menu Screen
                rectTransformMenuScreen = menuScreen.GetComponent<RectTransform>();
                rectTransformMenuScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                //Lose Screen
                rectTransformStatsScreen = statsScreen.GetComponent<RectTransform>();
                rectTransformStatsScreen.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                //menuPanel Screen
                rectTransformMenuBackgroundPanel = menuBackgroundPanel.GetComponent<RectTransform>();
                rectTransformMenuBackgroundPanel.localScale = new Vector3(1f, 0.9f, 1.0f);

                //menuPanel Middle Objects
                rectTransformMenuMiddleObjects = menuMiddleObjects.GetComponent<RectTransform>();
                //    rectTransformMenuMiddleObjects.localPosition = new Vector3(0f, 7f, 1.0f);
                rectTransformMenuMiddleObjects.anchoredPosition = new Vector3(0, 7, 0);


                //menuPanel Main!
                rectTransformMenuPanel = menuPanel.GetComponent<RectTransform>();
                //  rectTransformMenuPanel.localPosition = new Vector3(0f, -112f, 1.0f);
                rectTransformMenuPanel.anchoredPosition = new Vector3(0, -112f, 0);

                rectTransformMenuPanel.localScale = new Vector3(1f, 1f, 1.0f);


                //hearts
                heartsRect = hearts.GetComponent<RectTransform>();
                heartsRect.localScale = new Vector3(1.7f, 1.7f, 1.0f);
                //coin
                coinsRect = coins.GetComponent<RectTransform>();
                coinsRect.localScale = new Vector3(0.8f, 0.8f, 1.0f);
                //menuButton
                menuButRect = menuBut.GetComponent<RectTransform>();
                menuButRect.localScale = new Vector3(0.8f, 0.8f, 1.0f);

                //LOGO 
                rectTransformLogoImage = LogoImage.GetComponent<RectTransform>();
                rectTransformLogoImage.anchoredPosition = new Vector3(7, 247f, 1);
                rectTransformLogoImage.localScale = new Vector3(0.9f, 0.8f, 1.0f);

                //FirstScreenButton
                rectTransformButtonPos = ButtonPos.GetComponent<RectTransform>();
                rectTransformButtonPos.anchoredPosition = new Vector3(0, 258f, 1);
                rectTransformButtonPos.localScale = new Vector3(0.8f, 0.8f, 1.0f);

            }
            else if(GameManager.Instance.phone == true)
            {
                rectTransformGame = Game.GetComponent<RectTransform>();
                rectTransformGame.localScale = new Vector3(1f, 1f, 1.0f);

                //control buttons
                rectTransformControlButtons = ControlButtons.GetComponent<RectTransform>();
                rectTransformControlButtons.localScale = new Vector3(1f, 1f, 1.0f);

                //Find Screen
                rectTransformFindScreen = findScreen.GetComponent<RectTransform>();
                rectTransformFindScreen.localScale = new Vector3(1f, 1f, 1.0f);
                //Win Screen
                rectTransformWinScreen = winScreen.GetComponent<RectTransform>();
                rectTransformWinScreen.localScale = new Vector3(1f, 1f, 1.0f);
                //Lose Screen
                rectTransformLoseScreen = loseScreen.GetComponent<RectTransform>();
                rectTransformLoseScreen.localScale = new Vector3(1f, 1f, 1.0f);

                //menu Screen
                rectTransformMenuScreen = menuScreen.GetComponent<RectTransform>();
                rectTransformMenuScreen.localScale = new Vector3(1f, 1f, 1.0f);
                //Lose Screen
                rectTransformStatsScreen = statsScreen.GetComponent<RectTransform>();
                rectTransformStatsScreen.localScale = new Vector3(1f, 1f, 1.0f);
                //menuPanel Screen
                rectTransformMenuBackgroundPanel = menuBackgroundPanel.GetComponent<RectTransform>();
                rectTransformMenuBackgroundPanel.localScale = new Vector3(1f, 1f, 1.0f);


                //menuPanel Middle Objects
                rectTransformMenuMiddleObjects = menuMiddleObjects.GetComponent<RectTransform>();
                //   rectTransformMenuMiddleObjects.localPosition = new Vector3(0f, 0f, 1.0f);
                rectTransformMenuMiddleObjects.anchoredPosition = new Vector3(0, 0, 0);


                //menuPanel Main!
                rectTransformMenuPanel = menuPanel.GetComponent<RectTransform>();
                //    rectTransformMenuPanel.localPosition = new Vector3(0f, -120f, 1.0f);
                rectTransformMenuPanel.anchoredPosition = new Vector3(0, -120f, 0);

                rectTransformMenuPanel.localScale = new Vector3(1f, 1.1f, 1.0f);

                //hearts
                heartsRect = hearts.GetComponent<RectTransform>();
                heartsRect.localScale = new Vector3(2f, 1.8f, 1.0f);
                //coin
                coinsRect = coins.GetComponent<RectTransform>();
                coinsRect.localScale = new Vector3(1f, 0.9f, 1.0f);
                //menuButton
                menuButRect = menuBut.GetComponent<RectTransform>();
                menuButRect.localScale = new Vector3(1f, 0.9f, 1.0f);

                //LOGO 
                rectTransformLogoImage = LogoImage.GetComponent<RectTransform>();
                rectTransformLogoImage.anchoredPosition = new Vector3(7, 400f, 1);
                rectTransformLogoImage.localScale = new Vector3(1.1f, 1, 1.0f);

                //FirstScreenButton
                rectTransformButtonPos = ButtonPos.GetComponent<RectTransform>();
                rectTransformButtonPos.anchoredPosition = new Vector3(0, 364f, 1);
                rectTransformButtonPos.localScale = new Vector3(1f,1f, 1.0f);

            }
            GameManager.Instance.ChangeState(GameState.CheckTimer);


        }
    }



    public static float DeviceDiagonalSizeInInches()
    {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;
        float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

        Debug.Log("Getting device inches: " + diagonalInches);

        return diagonalInches;
    }

}
