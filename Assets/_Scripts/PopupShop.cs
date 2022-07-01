using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupShop : MonoBehaviour
{

    // Start is called before the first frame update
    public static PopupShop Instance;
    public GameObject mainBlock;
    public Board _board;
    public GameObject closingX;

    bool buyCoinCLicked = false;
    bool buyHeartCLicked = false;
    bool buyHammerCLicked = false;
    bool buyGlassCLicked = false;

    public GameObject successAlert;
    public GameObject notEnoughGoldAlert;


    int coinCost = 150;
    int heartCost = 100;
    int hammerCost = 200;
    int glassCost = 300;

    [SerializeField] TMPro.TextMeshProUGUI goldDisplay;

    [SerializeField] TMPro.TextMeshProUGUI hammerText;
    [SerializeField] TMPro.TextMeshProUGUI glassText;



    private void Awake()

    {
        if (Instance == null)
        {
            Instance = this;
        }
        //   this.GetComponent<RectTransform>().localPosition = new Vector3(0, 1846, 89501.99f);
    }
    private void OnEnable()


    {
        GameManager.Instance.shopActive = true;
        mainBlock.transform.localScale = Vector3.zero;

        goldDisplay.text = GameManager.Instance.goldBag.ToString();

        Time.timeScale = 1;


        FindObjectOfType<AudioManager>().Play("appear");


        if (GameManager.Instance.tablet == true)
        {
            LeanTween.scale(mainBlock, new Vector3(0.7f, 0.7f, 1), 1.7f).setEaseOutElastic().setOnComplete(ChangeScreenActive);
            Invoke("AnimateX", 0.2f);



        }
        else
        {

            LeanTween.scale(mainBlock, new Vector3(0.9f, 0.9f, 1), 1f).setEaseOutExpo().setOnComplete(ChangeScreenActive);
            LeanTween.scale(mainBlock, new Vector3(1, 1, 1), 1.2f).setDelay(.2f).setEaseOutElastic().setOnComplete(ChangeScreenActive);

            Invoke("AnimateX", 0.2f);


        }
        Featured.Instance.screenActive = false;


        if (_board.paused == false)
        {
            print("pausing board");
            _board.pauseBoard();
        }
        Featured.Instance.screenActive = true;

        /*  if (LeanTween.isTweening() ==false)
          {

          LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1f), 1.2f).setDelay(0.3f).setEaseOutElastic();
          }*/
    }




    private void ChangeScreenActive()
    {
        Featured.Instance.screenActive = true;

    }


    private void SetFalse()

    {
        Featured.Instance.screenActive = false;

        GameManager.Instance.shopActive = false;
        gameObject.SetActive(false);

        //  LeanTween.moveLocal(gameObject/*.GetComponent<RectTransform>()*/,new Vector3(0,1846, 89501.99f), 1f).setEaseInExpo();
    }
    void AnimateX()
    {


        LeanTween.scale(closingX, new Vector3(1.7f, 1.7f, 1), 0.3f).setEaseInOutExpo();

    }

    public void CloseMenuAnimation()
    {
        if (_board.paused == true)
        {
            print("was paused , starrt again ");

            _board.pauseBoard();
        }
        LeanTween.scale(mainBlock, new Vector3(0f, 0f, 0f), .8f).setEaseInExpo().setOnComplete(SetFalse);
        LeanTween.scale(closingX, new Vector3(0, 0, 0), 0.8f).setEaseOutExpo();
        print("close");

    }

    public void ActivatePOP()
    {
   /*  if(Board.Instance.gridPopulation == true)
        {


        }
*/
        gameObject.SetActive(true);
    }


    //BUTTONS
    #region Buttons


    public void BuyHammer()
    {

        if(buyHammerCLicked == false)
        {

            buyHammerCLicked = true;
            if(GameManager.Instance.goldBag >= hammerCost)
            {
                FindObjectOfType<AudioManager>().Play("coin");

                FindObjectOfType<PlayExtraSound>().Play("success");

                GameManager.Instance.goldBag -= hammerCost;
                goldDisplay.text = GameManager.Instance.goldBag.ToString();

                GameManager.Instance.ExtraSweetLolli += 1;
                hammerText.text = GameManager.Instance.ExtraSweetLolli.ToString();

                buyHammerCLicked = false;
                successAlert.SetActive(true);
                

            }
            else
            {
                notEnoughGoldAlert.SetActive(true);

                buyHammerCLicked = false;


            }

        }
    }

    public void BuyGlass()
    {
        if (buyGlassCLicked == false)
        {

            buyGlassCLicked = true;
            if (GameManager.Instance.goldBag >= glassCost)
            {
                FindObjectOfType<AudioManager>().Play("coin");

                FindObjectOfType<PlayExtraSound>().Play("success");

                GameManager.Instance.goldBag -= glassCost;
                goldDisplay.text = GameManager.Instance.goldBag.ToString();

                GameManager.Instance.ExtraSweetBonbon += 1; // bonbon -> glass
                glassText.text = GameManager.Instance.ExtraSweetBonbon.ToString();

                buyGlassCLicked = false;
                successAlert.SetActive(true);


            }
            else
            {
                notEnoughGoldAlert.SetActive(true);

                buyGlassCLicked = false;


            }

        }
    }
    public void BuyHealth()
    {
        if (buyHeartCLicked == false)
        {

            buyHeartCLicked = true;
            if (GameManager.Instance.goldBag >= heartCost)
            {
                FindObjectOfType<AudioManager>().Play("coin");



                FindObjectOfType<PlayExtraSound>().Play("success");

                GameManager.Instance.goldBag -= heartCost;
                goldDisplay.text = GameManager.Instance.goldBag.ToString();

                GameManager.Instance.ExtraLife += 1; // bonbon -> glass
             //   glassText.text = GameManager.Instance.ExtraSweetBonbon.ToString();

                buyHeartCLicked = false;
                successAlert.SetActive(true);
                GameManager.Instance.buyEssential = true;


            }
            else
            {
                notEnoughGoldAlert.SetActive(true);

                buyHeartCLicked = false;


            }

        }
    }
    public void BuyCoin()
    {
        if (buyCoinCLicked == false)
        {

            buyCoinCLicked = true;
            if (GameManager.Instance.goldBag >= coinCost)
            {
                FindObjectOfType<AudioManager>().Play("coin");


                FindObjectOfType<PlayExtraSound>().Play("success");

                GameManager.Instance.goldBag -= coinCost;
                goldDisplay.text = GameManager.Instance.goldBag.ToString();

                GameManager.Instance.ExtraCoin += 1; // bonbon -> glass
              //  glassText.text = GameManager.Instance.ExtraCoin.ToString();

                buyCoinCLicked = false;
                successAlert.SetActive(true);
                GameManager.Instance.buyEssential = true;



            }
            else
            {
                FindObjectOfType<AudioManager>().Play("close");

                notEnoughGoldAlert.SetActive(true);

                buyCoinCLicked = false;


            }

        }
    }

















    #endregion



}
