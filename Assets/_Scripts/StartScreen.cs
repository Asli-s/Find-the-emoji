using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    string coinCountText;
    private int coinCountNum;
    private int newNum;

    bool clicked = false;
  //  public GameObject Particles;
    public GameObject Button;

    public GameObject coinBackground;
    public GameObject Logo;
    bool coinButtonActive = true;
    public GameObject coin;
    
  //  public RawImage 

    private void OnEnable()
    {
        Logo.transform.localScale = Vector3.zero;
        coinBackground.GetComponent<RawImage>().enabled = false;
        //    Particles.SetActive(true);

        coin.GetComponent<Canvas>().sortingOrder = 15;



        LeanTween.scale(Button, new Vector3(0,1f,1f), 0);
        
        if (GameManager.Instance.phone && GameManager.Instance.squarish == false)
        {

        LeanTween.scale(Logo, new Vector3(0.9f, 0.8f, 1), 0.1f).setEaseOutBounce();
        LeanTween.scale(Button, new Vector3(0.65f, 1f, 1f), 1.8f).setDelay(1f).setEase(LeanTweenType.easeOutElastic).setOnComplete(activateAnim);
        }
        else if(GameManager.Instance.tablet ==true )
        {
            LeanTween.scale(Logo, new Vector3(0.7f, 0.6f, 1), 0.1f).setEaseOutBounce();

            LeanTween.scale(Button, new Vector3(0.55f, 0.7f, 1f), 1.8f).setDelay(1f).setEase(LeanTweenType.easeOutElastic).setOnComplete(activateAnim);

        }
        else if (GameManager.Instance.squarish == true)
        {
            LeanTween.scale(Logo, new Vector3(0.85f, 0.75f, 1), 0.1f).setEaseOutBounce();

            LeanTween.scale(Button, new Vector3(0.65f, 0.8f, 1f), 1.8f).setDelay(1f).setEase(LeanTweenType.easeOutElastic).setOnComplete(activateAnim);
        }
        Invoke("PlaySlide", 0.3f);
        Invoke("playStretchSound", 0.6f);
       
    }
    void activateAnim()
    {
        coinButtonActive = false;
    }

    public void StrartScreen()
    {
       if (clicked == false)
        {
            clicked = true;
            TestTime.Instance.alreadyInGame = true;

        if (GameManager.Instance.coinNum <= 5 &&/* GameManager.Instance.restarted == true &&*/ GameManager.Instance.coinNum > 0)
        {
            Invoke("DeactivateStartScreen", 0.7f);


            coinCountText = GameManager.Instance.m_Object.text;
            coinCountNum = int.Parse(coinCountText);
            GameManager.Instance.coinNum = coinCountNum;


            print("coinnum" + coinCountNum);
            newNum = coinCountNum;
            newNum--;

            if (coinCountNum == 5)
            {
                    print("coin num 5 startscreen");
                    GameManager.Instance.coinNum = newNum;
                    GameManager.Instance.m_Object.text = newNum.ToString();

                    GameManager.Instance.minutesLeft = 30;
                    GameManager.Instance.secondsLeft = 0;
                    GameManager.Instance.activeCountDown = true;
                    FindObjectOfType<CountdownTimer>().StartTimer(30, 0);

                    PresentTimer.Instance.StartPresentTimer();

                playCoinSound();
            }
            else
            {

                    GameManager.Instance.coinNum = newNum;
                    GameManager.Instance.m_Object.text = newNum.ToString();

                    FindObjectOfType<AudioManager>().Play("coin");
                playCoinSound();
                    PresentTimer.Instance.StartPresentTimer();

                    //       print("coinSOUND!" );

                    //  FindObjectOfType<CountdownTimer>().StartTimer();

                }

                print("gameman coinnum" + GameManager.Instance.coinNum);


            DataPersistenceManager.Instance.SaveGame();

            print("firstscreen coin not 0");
        }

        else if (GameManager.Instance.coinNum == 0 )
        {
            FindObjectOfType<AudioManager>().Play("noCoin");
                coinBackground.GetComponent<RawImage>().enabled = true;

                gameObject.SetActive(false);
            print("firstscreen coin == 0");

            GameManager.Instance.coinNotEnoughScreen.SetActive(true);


        }


        }

    }
    private void playCoinSound()
    {
        FindObjectOfType<AudioManager>().Play("coin");


    }

    private void playStretchSound()
    {
        FindObjectOfType<AudioManager>().Play("pop");


    }
    private void DeactivateStartScreen()
    {
        coinBackground.GetComponent<RawImage>().enabled = true;
        GameManager.Instance.ChangeState(GameState.FeatureTile);
        GameManager.Instance.gameActive = true;

        gameObject.SetActive(false);
      
    }
    void PlaySlide()
    {
      
        FindObjectOfType<AudioManager>().Play("swoosh");

    }




    private void Update()
    {
        if ( coinButtonActive == false)
        {
            // animate 
            //   blockText.SetActive(false);
            if(clicked == false)
            {

            FindObjectOfType<AudioManager>().Play("stretch");
            }

            coinButtonActive = true;
            //  LeanTween.scale(Button, new Vector3(0.6f, 1.2f, 1), 1f).setEaseInElastic().setOnComplete(scaleBackUp);
           if (GameManager.Instance.tablet)
            {
                LeanTween.scale(Button, new Vector3(0.58f, .6f, 1), 2.6f).setEaseInOutElastic().setOnComplete(scaleBackUp);

            }
           else if(GameManager.Instance.phone || GameManager.Instance.squarish )
            {

              LeanTween.scale(Button, new Vector3(0.8f, .7f, 1), 2.6f).setEaseInOutElastic().setOnComplete(scaleBackUp);
            }
        }
    }

    void scaleBackUp()
    {
        //  LeanTween.scale(Button, new Vector3(.8f, 0.9f, 1), 1.6f).setEaseOutElastic().setOnComplete(ActivateCoinButton);
        if(clicked == false)
        {

        FindObjectOfType<AudioManager>().Play("bubble");
        }

       if (GameManager.Instance.tablet)
        {
            LeanTween.scale(Button, new Vector3(0.5f, .7f, 1), 2.6f).setEaseInOutElastic().setOnComplete(scaleBackUp);

        }
      else  if (GameManager.Instance.phone || GameManager.Instance.squarish)
        { 
            LeanTween.scale(Button, new Vector3(0.65f,.9f, 1), 1.6f).setEaseOutElastic().setOnComplete(ActivateCoinButton);
        
        }


    }
    void ActivateCoinButton()
    {
       
            coinButtonActive = false;
        

    }



}
