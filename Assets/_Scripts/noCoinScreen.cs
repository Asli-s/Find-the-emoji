using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noCoinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Button coinButtonCover;
    [SerializeField] public Button coinButton;

    [SerializeField] public Button AdButton;

    public static noCoinScreen Instance;
 //   public GameObject adGameObject;



    [SerializeField] private GameObject ParentBoard;
    [SerializeField] private GameObject ParentFeatureTile;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject ParentBoardBackground;
    [SerializeField] private GameObject featureTileBackground;
    [SerializeField] private GameObject rectBackGround;


    [SerializeField] private GameObject blockText;

   
    

    public GameObject mainBlock;
    bool coinButtonActive = false;
    bool startGameClicked = false;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

        }
    }


    void OnEnable()
    {
       // adGameObject.SetActive(true);
FindObjectOfType<HealthHearts>().setMaxHealth();

        GameManager.Instance.InvCoverHammer.SetActive(false);
        GameManager.Instance.ShopCoverGlass.SetActive(false);

        GameManager.Instance.SweetCoverGlass.SetActive(true);
        GameManager.Instance.SweetCoverHammer.SetActive(true);

        Featured.Instance.screenActive = false;
        GameManager.Instance.noCoinSCreenActive = true;
        //destroy feature tile && all nodes in board!!
        if(GameOver.Instance.lose == true)
        {
          
            ParentFeatureTile.SetActive(false);
            ParentBoard.SetActive(false);
     

        }
        ParentBoardBackground.SetActive(false);
        featureTileBackground.SetActive(false);
        //DEACTIVATE PAUSE AND RESTART BUTTOnS
        PauseButton.SetActive(false);
        RestartButton.SetActive(false);
        rectBackGround.SetActive(false);

        coinButtonCover.enabled = true;
        coinButtonCover.interactable = false;

        coinButton.interactable = false;


       
     

        if (GameManager.Instance.tablet == true)
        {
            LeanTween.scale(mainBlock, new Vector3(0.7f, 0.7f, 1), 2.3f).setEase(LeanTweenType.easeOutElastic);

        }
        else
        {

            LeanTween.scale(mainBlock, new Vector3(1, 1, 1), 2.3f).setEase(LeanTweenType.easeOutElastic);
        }
     //   LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1f), 2.3f).setEase(LeanTweenType.easeOutElastic);//.setOnComplete(animateStars);


        // disable when coin is one

    }

    // Update is called once per frame

    void PlayCoinSound()
    {
        FindObjectOfType<AudioManager>().Play("coin");

    }



    public void StartGame()
    {
        if(GameManager.Instance.coinNum > 0 &&startGameClicked ==false)
        {
            startGameClicked = true;
            GameManager.Instance.gameActive = true;

            FindObjectOfType<AudioManager>().Play("coin");

            LeanTween.scale(mainBlock, new Vector3(0f, 0f, 0f), .4f).setEase(LeanTweenType.easeOutElastic);//.setOnComplete(animateStars);
            PlayCoinSound();


            Invoke("ChangeToPlay", 0.4f);


        }
    }

    private void ChangeToPlay()
    
    {
        rectBackGround.SetActive(true);
        startGameClicked = false;

        Featured.Instance.LoseCoinFromNoCoinScreen();
        /*
        PauseButton.SetActive(true);
        RestartButton.SetActive(true);
        ParentBoardBackground.SetActive(true);
        featureTileBackground.SetActive(true);
        GameManager.Instance.ChangeState(GameState.FeatureTile);*/

    }



    public void ChangeToAdButtonClicked()
    {
        GameManager.Instance.adNoCoinScreenClicked = true;
        //activate ad gamobject
      //  adGameObject.SetActive(true);
    //    GoogleAdsScript.Instance.UserChoseToWatchAd();


        //call ad

    }

    private void Update()
    {
        if (coinButton.interactable == true && coinButtonActive ==false)
        {
            // animate 
           
            coinButtonActive = true;
            if (startGameClicked == false)
            {
                FindObjectOfType<AudioManager>().Play("stretch");

            }

            LeanTween.scale(coinButton.gameObject, new Vector3(2.5f, 3.1f, 1), 3f).setEaseInOutElastic().setOnComplete(scaleBackUp);
        }
    }

    void scaleBackUp()
    {
        if(startGameClicked == false)
        {
            FindObjectOfType<AudioManager>().Play("bubble");

        }

        LeanTween.scale(coinButton.gameObject, new Vector3(2.3f, 3.4f, 1), 1.3f).setEaseOutElastic().setOnComplete(ActivateCoinButton);

    }
    void ActivateCoinButton()
    {
        if (coinButton.interactable == true)
        {
            coinButtonActive = false;
        }

    }


    public void ChangeButtonToAlreadyClicked()
    {
        if(GameManager.Instance.coinNum > 0)
        {
            AdButton.interactable = false;
            coinButton.interactable = true;
            coinButtonCover.gameObject.SetActive( false);
            GameManager.Instance.adNoCoinScreenClicked = false;

            //darken text of adbutton

        }

    }

    /*   public void RestartButtonNoCoinScreen()
       {

       }
   */

}
