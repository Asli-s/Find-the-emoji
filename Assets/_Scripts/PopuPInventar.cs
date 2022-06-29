using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopuPInventar : MonoBehaviour
{
   
    // Start is called before the first frame update
    public static PopuPInventar Instance;
    public GameObject mainBlock;
    public Board _board;

    public GameObject closingX;

    [SerializeField] TMPro.TextMeshProUGUI HeartDisplay;
    [SerializeField] TMPro.TextMeshProUGUI CoinDisplay;

    [SerializeField] public GameObject notEnoughCoinsAlert;
    [SerializeField] public GameObject notEnoughHeartsAlert;
    [SerializeField] public GameObject successAlert;

  //  [SerializeField] public GameObject maxCoinAlert;
    [SerializeField] public GameObject maxHeartAlert;
    [SerializeField] public GameObject notInGameYet;



    bool coinUseClicked = false;
    bool heartUseCLicked = false;





    // [SerializeField] TMPro.TextMeshProUGUI TimerText;

    /*
        private int newNum = 0;
        private int  coinCountNum =0;

    */


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
      
        FindObjectOfType<AudioManager>().Play("appear");

        print("Hearts" + GameManager.Instance.ExtraLife);
        print("Cois" + GameManager.Instance.ExtraCoin);



        HeartDisplay.text = GameManager.Instance.ExtraLife.ToString();
        CoinDisplay.text = GameManager.Instance.ExtraCoin.ToString();



        Time.timeScale = 1;

      
        

        if (GameManager.Instance.tablet == true)
        {
            LeanTween.scale(mainBlock, new Vector3(0.7f, 0.7f, 1), 1.7f).setEaseOutElastic().setOnComplete(ChangeScreenActive);
            Invoke("AnimateX", 0.2f);


        }
        else
        {

            // LeanTween.scale(mainBlock, new Vector3(1, 1, 1), 1.7f).setEaseOutElastic().setOnComplete(ChangeScreenActive);
            LeanTween.scale(mainBlock, new Vector3(0.9f, 0.9f, 1), 1f).setEaseOutExpo().setOnComplete(ChangeScreenActive);
            LeanTween.scale(mainBlock, new Vector3(1, 1, 1), 1.2f).setDelay(.2f).setEaseOutElastic().setOnComplete(ChangeScreenActive);

            Invoke("AnimateX", 0.2f);

        }
    
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
        if(Board.Instance.gridPopulation == true)
        {

        gameObject.SetActive(true);
            Featured.Instance.screenActive = false;

            if (_board.paused == false)
            {
                print("pausing board");
                _board.pauseBoard();
            }
            Featured.Instance.screenActive = true;


        }
        else if (GameManager.Instance.noCoinSCreenActive ==true)
        {
            gameObject.SetActive(true);

        }

    }


    public void UseCoin()
    {
        print("clicked " + coinUseClicked);

        if (coinUseClicked == false)
        {
            coinUseClicked = true;

            print("GameManager.Instance.coinNum + GameManager.Instance.ExtraCoin" + GameManager.Instance.coinNum + GameManager.Instance.ExtraCoin);

            if (GameManager.Instance.coinNum < 5 && GameManager.Instance.ExtraCoin > 0)
            {
                GameManager.Instance.ExtraCoin -= 1;
                FindObjectOfType<CountdownTimer>().AddLife();
                CoinDisplay.text = GameManager.Instance.ExtraCoin.ToString();
                DataPersistenceManager.Instance.SaveGame();
                successAlert.SetActive(true);
                coinUseClicked = false;
                //success alert
            }
            /* newNum = GameManager.Instance.coinNum; 

             newNum += 1;


             //after adding life
             if (newNum == 5)
             {
                 print("newnum >5 with added lifes");
                // newNum = 5;
                 GameManager.Instance.coinNum = newNum;

                 GameManager.Instance.m_Object.text = newNum.ToString();
                 TimerText.text = "  full";

                 print(newNum);
             }
             else if (newNum < 5)
             {
                 GameManager.Instance.coinNum = newNum;
                 GameManager.Instance.m_Object.text = newNum.ToString();



             }*/

            /*  if (lifesToAdd ==1 && newNum== 1)
              {
                  GameManager.Instance.coinNotEnough = false;
                  Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);




            CoinDisplay.text = GameManager.Instance.ExtraCoin.ToString();
    }
            */
            //alert successfullly added coin



            else if (GameManager.Instance.coinNum == 5)
            {
                //max coins setactive
                maxHeartAlert.SetActive(true);
                coinUseClicked = false;

            }
            else if (GameManager.Instance.ExtraCoin == 0)
            {
                //not enough coins
                notEnoughCoinsAlert.SetActive(true);
                coinUseClicked = false;

            }
        }
    }



    public void UseHeart()
    {

        if (heartUseCLicked == false)
        {
            heartUseCLicked = true;

            if (HealthHearts.Instance.health < 3 && GameManager.Instance.ExtraLife > 0 && GameManager.Instance.noCoinSCreenActive ==false)//health <3)
            {
                GameManager.Instance.ExtraLife -= 1;
                HeartDisplay.text = GameManager.Instance.ExtraLife.ToString();
                HealthHearts.Instance.addHealth();
                successAlert.SetActive(true);
                DataPersistenceManager.Instance.SaveGame();
                heartUseCLicked = false;


            }
            else if(GameManager.Instance.noCoinSCreenActive == true)
            {
                // alert not in game yet
                notInGameYet.SetActive(true);
                heartUseCLicked = false;
            }

            else if (GameManager.Instance.ExtraLife == 0)
            {
                //not enough setactive
                notEnoughHeartsAlert.SetActive(true);
                heartUseCLicked = false;


            }
            else if (HealthHearts.Instance.health == 3)
            {
                maxHeartAlert.SetActive(true);
                heartUseCLicked = false;

                //already max
            }

        }

    }
}
