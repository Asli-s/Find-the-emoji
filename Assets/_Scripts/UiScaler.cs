using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScaler : MonoBehaviour
{

    //Variables
    public static UiScaler Instance;
    bool isTablet = false;



    // public GameObject Controls;
    //  public Camera cam;
    public GameObject canvas;

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



    //instructions


    public GameObject FindInstr;
    private RectTransform FindInstrRect;

    public GameObject FeatureInstr;
    private RectTransform FeatureInstrRect;

    public GameObject BoardInstr;
    private RectTransform BoardInstrRect;

    public GameObject WinInstr;
    private RectTransform WinInstrRect;

    //shop
    //inventar
    public GameObject Shop;
    public GameObject Inventar;

   
    public GameObject LowerPanel;
    public GameObject SafeArea;


    public GameObject ShopIcon;
    public GameObject InvIcon;
    public GameObject GlassIcon;
    public GameObject HammerIcon;

    public GameObject InvShopParent;
    public GameObject ToolsParent;



    new Vector3 transformedVector;
    //popups


    //Alerts!








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

        /* print("screen height is " + Screen.height);
         print("lower position of height is " + ( (Screen.height / 4) -50));
         Vector3 screenPos = cam.WorldToScreenPoint(ControlButtons.transform.position);
         print("screen position" + screenPos);
         Debug.Log("target is " + screenPos.y + " pixels from the top??");
         print("target vector" +ControlButtons.transform.tr(screenPos.x, (Screen.height / 4) - 50, screenPos.z));*/


      

        //    transformedVector = cam.transform.TransformPoint(screenPos.x, (Screen.height / 4) - 50, screenPos.z);


        if (GameManager.Instance.tablet == false && GameManager.Instance.phone == false)
        {
            var aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
             isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);



            print("aspectratio" + aspectRatio);

            print("tablet"+ isTablet);


            if(aspectRatio < 2) // tablet or squarish phone
            {
                GameManager.Instance.squarish = true;
                float h = canvas.GetComponent<RectTransform>().rect.height;
                print("canvas height" + h);


                //buttons
                float targetHeight = h / 7;
                float ultimateTargetHeight = targetHeight * 6;
                print("target height" + targetHeight);
                print("ultimate target height" + ultimateTargetHeight);


                //LOGO POs
                //    LogoImage.GetComponent<RectTransform>().transform.localPosition += new Vector3(0, -(targetHeight*2), 1);
                LogoImage.GetComponent<RectTransform>().transform.localPosition += new Vector3(0, -(targetHeight + targetHeight+targetHeight/3 ), 1);





                // C. Button Pos
                if(isTablet == false)
                {
                ControlButtons.GetComponent<RectTransform>().transform.localPosition += new Vector3(0, -(ultimateTargetHeight), 1);

                }
                else
                {
                     targetHeight = h / 6;
                     ultimateTargetHeight = targetHeight * 5;
                    ControlButtons.GetComponent<RectTransform>().transform.localPosition += new Vector3(0, -(ultimateTargetHeight), 1);

                }

                print("control buttons position " + ControlButtons.GetComponent<RectTransform>().transform.localPosition);
            }

            else // rect longer phones
            {
                float h = canvas.GetComponent<RectTransform>().rect.height;
                print("canvas height" + h);
          
                float targetHeight = h / 5;
                float ultimateTargetHeight = targetHeight * 4;
                print("target height" + targetHeight);
                print("ultimate target height" + ultimateTargetHeight);


                LogoImage.GetComponent<RectTransform>().transform.localPosition += new Vector3(0, -(targetHeight + (targetHeight/2)), 1);

                ControlButtons.GetComponent<RectTransform>().transform.localPosition += new Vector3(0, -(ultimateTargetHeight), 1);

                print("control buttons position " + ControlButtons.GetComponent<RectTransform>().transform.localPosition);
            } //phone


/*TABLET*/

            if (isTablet)
            {
                GameManager.Instance.tablet = true;
                // change ui scale

                //game
              rectTransformGame=  Game.GetComponent<RectTransform>();
                rectTransformGame.localScale = new Vector3(0.63f, 0.63f, 1.0f);
                //control buttons
                rectTransformControlButtons = ControlButtons.GetComponent<RectTransform>();
                rectTransformControlButtons.localScale = new Vector3(0.7f, 0.7f, 1.0f);

                //Find Scree7
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
                rectTransformMenuScreen.localScale = new Vector3(0.6f, 0.6f, 1.0f);      
                //Lose Screen
                rectTransformStatsScreen = statsScreen.GetComponent<RectTransform>();
                rectTransformStatsScreen.localScale = new Vector3(0.6f, 0.6f, 1.0f);

                //menuPanel Screen
                rectTransformMenuBackgroundPanel = menuBackgroundPanel.GetComponent<RectTransform>();
                rectTransformMenuBackgroundPanel.localScale = new Vector3(1f, 0.9f, 1.0f);

                //menuPanel Middle Objects
                rectTransformMenuMiddleObjects = menuMiddleObjects.GetComponent<RectTransform>();
                
                rectTransformMenuMiddleObjects.anchoredPosition=     new Vector3(0, 7, 0);
                rectTransformMenuMiddleObjects.localScale=     new Vector3(0.8f, 0.8f, 1);

                //menuPanel Main!
                rectTransformMenuPanel = menuPanel.GetComponent<RectTransform>();          
                rectTransformMenuPanel.anchoredPosition = new Vector3(0, -70, 0);
                rectTransformMenuPanel.localScale = new Vector3(1f, 1f, 1.0f);



                //hearts
                heartsRect = hearts.GetComponent<RectTransform>();
                heartsRect.localScale = new Vector3(1.7f, 1.7f, 1.0f);
                //coin
                coins.GetComponent<Canvas>().sortingOrder = 15;
                coinsRect = coins.GetComponent<RectTransform>();
                coinsRect.localScale = new Vector3(0.6f, 0.6f, 1.0f);
                coinsRect.anchoredPosition = new Vector3(-111, -87, -1);
                //menuButton
                menuButRect = menuBut.GetComponent<RectTransform>();
                menuButRect.localScale = new Vector3(0.8f, 0.8f, 1.0f);
                menuButRect.anchoredPosition = new Vector3(58, 112f, 1.0f);


                //LOGO 
                rectTransformLogoImage = LogoImage.GetComponent<RectTransform>();
            //    rectTransformLogoImage.anchoredPosition = new Vector3(7, 247f, 1);
            //    rectTransformLogoImage.localScale = new Vector3(1f,1f, 1.0f);

                //FirstScreenButton
                rectTransformButtonPos = ButtonPos.GetComponent<RectTransform>();
                rectTransformButtonPos.anchoredPosition = new Vector3(0,258f, 1);
                rectTransformButtonPos.localScale = new Vector3(0.8f, 0.8f, 1.0f);

                // instructions
                FindInstrRect = FindInstr.GetComponent<RectTransform>();
                FindInstrRect.localScale = new Vector3(0.8f, 0.8f, 1);


                FeatureInstrRect = FeatureInstr.GetComponent<RectTransform>();
                FeatureInstrRect.localScale = new Vector3(0.8f, 0.8f, 1);


                BoardInstrRect = BoardInstr.GetComponent<RectTransform>();
                BoardInstrRect.localScale = new Vector3(0.8f, 0.8f, 1);


                WinInstrRect = WinInstr.GetComponent<RectTransform>();
                WinInstrRect.localScale = new Vector3(0.8f, 0.8f, 1);

                Shop.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                Inventar.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);


                // LOWERPANEL
                LowerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,18,0);

                //SafeArea
                SafeArea.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -30, 0);




                InvIcon.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1);
                ShopIcon.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1);
                ShopIcon.GetComponent<RectTransform>().anchoredPosition = new Vector3(42, 10.6f, 1);
                GlassIcon.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1);
                HammerIcon.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1);


                InvShopParent.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 518f, 1);
                ToolsParent.GetComponent<RectTransform>().anchoredPosition = new Vector3(247, 884, 1);


                //change ALeerts!!!!



            }


            /*PHONE*/

        if(GameManager.Instance.squarish == true)
            {



                //game
                rectTransformGame = Game.GetComponent<RectTransform>();
                rectTransformGame.localScale = new Vector3(0.8f, 0.8f, 1.0f);
                //control buttons
                rectTransformControlButtons = ControlButtons.GetComponent<RectTransform>();
                rectTransformControlButtons.localScale = new Vector3(0.85f, 0.85f, 1.0f);

                //Find Screen
                rectTransformFindScreen = findScreen.GetComponent<RectTransform>();
                rectTransformFindScreen.localScale = new Vector3(0.85f, 0.85f, 1.0f);
                //Win Screen
                rectTransformWinScreen = winScreen.GetComponent<RectTransform>();
                rectTransformWinScreen.localScale = new Vector3(0.85f, 0.85f, 1.0f);
                //Lose Screen
                rectTransformLoseScreen = loseScreen.GetComponent<RectTransform>();
                rectTransformLoseScreen.localScale = new Vector3(0.85f, 0.85f, 1.0f);


                //menu Screen
                rectTransformMenuScreen = menuScreen.GetComponent<RectTransform>();
                rectTransformMenuScreen.localScale = new Vector3(0.8f, 0.8f, 1.0f);
                //Lose Screen
                rectTransformStatsScreen = statsScreen.GetComponent<RectTransform>();
                rectTransformStatsScreen.localScale = new Vector3(0.8f, 0.8f, 1.0f);

                //menuPanel Screen
                rectTransformMenuBackgroundPanel = menuBackgroundPanel.GetComponent<RectTransform>();
                rectTransformMenuBackgroundPanel.localScale = new Vector3(1f, 0.9f, 1.0f);

                //menuPanel Middle Objects
                rectTransformMenuMiddleObjects = menuMiddleObjects.GetComponent<RectTransform>();
                rectTransformMenuMiddleObjects.anchoredPosition = new Vector3(0, 18, 0);

                //menuPanel Main!
                rectTransformMenuPanel = menuPanel.GetComponent<RectTransform>();
                rectTransformMenuPanel.anchoredPosition = new Vector3(0, -100f, 0);
                rectTransformMenuPanel.localScale = new Vector3(1f, 1f, 1.0f);



                //hearts
                heartsRect = hearts.GetComponent<RectTransform>();
                heartsRect.localScale = new Vector3(1.7f, 1.7f, 1.0f);
         
                //menuButton
                menuButRect = menuBut.GetComponent<RectTransform>();
                menuButRect.localScale = new Vector3(0.9f, 0.9f, 1.0f);


            /*    //LOGO 
                rectTransformLogoImage = LogoImage.GetComponent<RectTransform>();
                //    rectTransformLogoImage.anchoredPosition = new Vector3(7, 247f, 1);
                rectTransformLogoImage.localScale = new Vector3(1f, 1f, 1.0f);*/

                //FirstScreenButton
                rectTransformButtonPos = ButtonPos.GetComponent<RectTransform>();
                rectTransformButtonPos.anchoredPosition = new Vector3(0, 258f, 1);
                rectTransformButtonPos.localScale = new Vector3(0.8f, 0.8f, 1.0f);

                // instructions
                FindInstrRect = FindInstr.GetComponent<RectTransform>();
                FindInstrRect.localScale = new Vector3(0.85f, 0.85f, 1);


                FeatureInstrRect = FeatureInstr.GetComponent<RectTransform>();
                FeatureInstrRect.localScale = new Vector3(0.85f, 0.85f, 1);


                BoardInstrRect = BoardInstr.GetComponent<RectTransform>();
                BoardInstrRect.localScale = new Vector3(0.85f, 0.85f, 1);


                WinInstrRect = WinInstr.GetComponent<RectTransform>();
                WinInstrRect.localScale = new Vector3(0.85f, 0.85f, 1);

                Shop.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                print("squarish");
                Inventar.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);



                ShopIcon.GetComponent<RectTransform>().localScale = new Vector3(1.96f,1.96f,1);



            }

            else
            {
                GameManager.Instance.phone = true;
                // change ui scale
                //game
                rectTransformGame = Game.GetComponent<RectTransform>();
                rectTransformGame.localScale = new Vector3(0.84f, 0.84f, 1.0f);

                //control buttons
                rectTransformControlButtons = ControlButtons.GetComponent<RectTransform>();
                rectTransformControlButtons.localScale = new Vector3(0.9f,0.9f, 1.0f);

                //Find Screen
                rectTransformFindScreen = findScreen.GetComponent<RectTransform>();
                rectTransformFindScreen.localScale = new Vector3(1f, 1f, 1.0f);
                //Win Screen
                rectTransformWinScreen = winScreen.GetComponent<RectTransform>();
                rectTransformWinScreen.localScale = new Vector3(0.9f,0.9f, 1.0f);
                //Lose Screen
                rectTransformLoseScreen = loseScreen.GetComponent<RectTransform>();
                rectTransformLoseScreen.localScale = new Vector3(0.9f, 0.9f, 1.0f);

                //menu Screen
                rectTransformMenuScreen = menuScreen.GetComponent<RectTransform>();
                rectTransformMenuScreen.localScale = new Vector3(0.85f, 0.85f, 1.0f);
                //Lose Screen
                rectTransformStatsScreen = statsScreen.GetComponent<RectTransform>();
                rectTransformStatsScreen.localScale = new Vector3(0.85f,0.85f, 1.0f);
                //menuPanel Screen
                rectTransformMenuBackgroundPanel = menuBackgroundPanel.GetComponent<RectTransform>();
                rectTransformMenuBackgroundPanel.localScale = new Vector3(1f, .85f, 1.0f);


                //menuPanel Middle Objects
                rectTransformMenuMiddleObjects = menuMiddleObjects.GetComponent<RectTransform>();
                //    rectTransformMenuMiddleObjects.localPosition = new Vector3(0f,0f, 1.0f);
                rectTransformMenuMiddleObjects.anchoredPosition = new Vector3(0, 20, 0);


                //menuPanel Main!
                rectTransformMenuPanel = menuPanel.GetComponent<RectTransform>();
                //  rectTransformMenuPanel.localPosition = new Vector3(0f, -120f, 1.0f);
                rectTransformMenuPanel.anchoredPosition = new Vector3(0, -120f, 0);

                rectTransformMenuPanel.localScale = new Vector3(1f, 1.12f, 1.0f);


                //hearts
                heartsRect = hearts.GetComponent<RectTransform>();
                heartsRect.localScale = new Vector3(2f, 1.8f, 1.0f);
                //coin
                coinsRect = coins.GetComponent<RectTransform>();
                coinsRect.localScale = new Vector3(0.9f, 0.8f, 1.0f);
                //menuButton
                menuButRect = menuBut.GetComponent<RectTransform>();
                menuButRect.localScale = new Vector3(1f, 0.9f, 1.0f);

                //LOGO 
                rectTransformLogoImage = LogoImage.GetComponent<RectTransform>();
               // rectTransformLogoImage.anchoredPosition = new Vector3(7, 400f, 1);
                rectTransformLogoImage.localScale = new Vector3(1f, 0.9f, 1.0f);

                //FirstScreenButton
                rectTransformButtonPos = ButtonPos.GetComponent<RectTransform>();
                rectTransformButtonPos.anchoredPosition = new Vector3(0, 364f, 1);
                rectTransformButtonPos.localScale = new Vector3(1f, 1f, 1.0f);

                //instructions

                FindInstrRect = FindInstr.GetComponent<RectTransform>();
                FindInstrRect.localScale = new Vector3(1f, 1f, 1);


                FeatureInstrRect = FeatureInstr.GetComponent<RectTransform>();
                FeatureInstrRect.localScale = new Vector3(1f, 1f, 1);


                BoardInstrRect = BoardInstr.GetComponent<RectTransform>();
                BoardInstrRect.localScale = new Vector3(1f, 1f, 1);


                WinInstrRect = WinInstr.GetComponent<RectTransform>();
                WinInstrRect.localScale = new Vector3(1f,1f, 1);

            }
         
            GameManager.Instance.ChangeState(GameState.CheckTimer);
           
        }

        // if(not saved)
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
            //    rectTransformLogoImage.anchoredPosition = new Vector3(7, 247f, 1);
                rectTransformLogoImage.localScale = new Vector3(0.9f, 0.8f, 1.0f);

                //FirstScreenButton
                rectTransformButtonPos = ButtonPos.GetComponent<RectTransform>();
                rectTransformButtonPos.anchoredPosition = new Vector3(0, 258f, 1);
                rectTransformButtonPos.localScale = new Vector3(0.8f, 0.8f, 1.0f);


                // instructions
                FindInstrRect = FindInstr.GetComponent<RectTransform>();
                FindInstrRect.localScale = new Vector3(0.8f, 0.8f, 1);


                FeatureInstrRect = FeatureInstr.GetComponent<RectTransform>();
                FeatureInstrRect.localScale = new Vector3(0.8f, 0.8f, 1);


                BoardInstrRect = BoardInstr.GetComponent<RectTransform>();
                BoardInstrRect.localScale = new Vector3(0.8f, 0.8f, 1);


                WinInstrRect = WinInstr.GetComponent<RectTransform>();
                WinInstrRect.localScale = new Vector3(0.8f, 0.8f, 1);

                //SafeArea



            }
            else if(GameManager.Instance.phone == true)
            {
                rectTransformGame = Game.GetComponent<RectTransform>();
                rectTransformGame.localScale = new Vector3(0.84f, 0.84f, 1.0f);

                //control buttons
                rectTransformControlButtons = ControlButtons.GetComponent<RectTransform>();
                rectTransformControlButtons.localScale = new Vector3(0.9f, 0.9f, 1.0f);

                //Find Screen
                rectTransformFindScreen = findScreen.GetComponent<RectTransform>();
                rectTransformFindScreen.localScale = new Vector3(1f, 1f, 1.0f);
                //Win Screen
                rectTransformWinScreen = winScreen.GetComponent<RectTransform>();
                rectTransformWinScreen.localScale = new Vector3(.9f, .9f, 1.0f);
                //Lose Screen
                rectTransformLoseScreen = loseScreen.GetComponent<RectTransform>();
                rectTransformLoseScreen.localScale = new Vector3(.9f, .9f, 1.0f);

                //menu Screen
                rectTransformMenuScreen = menuScreen.GetComponent<RectTransform>();
                rectTransformMenuScreen.localScale = new Vector3(0.85f, 0.851f, 1.0f);
                //Lose Screen
                rectTransformStatsScreen = statsScreen.GetComponent<RectTransform>();
                rectTransformStatsScreen.localScale = new Vector3(0.85f, 0.85f, 1.0f);
                //menuPanel Screen
                rectTransformMenuBackgroundPanel = menuBackgroundPanel.GetComponent<RectTransform>();
                rectTransformMenuBackgroundPanel.localScale = new Vector3(1f, 0.85f, 1.0f);


                //menuPanel Middle Objects
                rectTransformMenuMiddleObjects = menuMiddleObjects.GetComponent<RectTransform>();
                //   rectTransformMenuMiddleObjects.localPosition = new Vector3(0f, 0f, 1.0f);
                rectTransformMenuMiddleObjects.anchoredPosition = new Vector3(0,20, 0);


                //menuPanel Main!
                rectTransformMenuPanel = menuPanel.GetComponent<RectTransform>();
                //    rectTransformMenuPanel.localPosition = new Vector3(0f, -120f, 1.0f);
                rectTransformMenuPanel.anchoredPosition = new Vector3(0, -120f, 0);

                rectTransformMenuPanel.localScale = new Vector3(1f, 1.12f, 1.0f);

                //hearts
                heartsRect = hearts.GetComponent<RectTransform>();
                heartsRect.localScale = new Vector3(2f, 1.8f, 1.0f);
                //coin
                coinsRect = coins.GetComponent<RectTransform>();
                coinsRect.localScale = new Vector3(0.9f, 0.8f, 1.0f);
                //menuButton
                menuButRect = menuBut.GetComponent<RectTransform>();
                menuButRect.localScale = new Vector3(1f, 0.9f, 1.0f);

                //LOGO 
                rectTransformLogoImage = LogoImage.GetComponent<RectTransform>();
             //   rectTransformLogoImage.anchoredPosition = new Vector3(7, 400f, 1);
                rectTransformLogoImage.localScale = new Vector3(1f, 0.9f, 1.0f);

                //FirstScreenButton
                rectTransformButtonPos = ButtonPos.GetComponent<RectTransform>();
                rectTransformButtonPos.anchoredPosition = new Vector3(0, 364f, 1);
                rectTransformButtonPos.localScale = new Vector3(1f,1f, 1.0f);


                //instructions

                FindInstrRect = FindInstr.GetComponent<RectTransform>();
                FindInstrRect.localScale = new Vector3(1f, 1f, 1);


                FeatureInstrRect = FeatureInstr.GetComponent<RectTransform>();
                FeatureInstrRect.localScale = new Vector3(1f, 1f, 1);


                BoardInstrRect = BoardInstr.GetComponent<RectTransform>();
                BoardInstrRect.localScale = new Vector3(1f, 1f, 1);


                WinInstrRect = WinInstr.GetComponent<RectTransform>();
                WinInstrRect.localScale = new Vector3(1f, 1f, 1);


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
