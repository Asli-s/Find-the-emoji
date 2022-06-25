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
    public GameObject Particles;
    public GameObject Button;

    public GameObject coinBackground;
  //  public RawImage 

    private void OnEnable()
    {
        coinBackground.GetComponent<RawImage>().enabled = false;
        Particles.SetActive(true);
        LeanTween.scale(Button, new Vector3(0,1f,1f), 0);
        if (GameManager.Instance.phone)
        {

        LeanTween.scale(Button, new Vector3(0.8f, 1f, 1f), 1.8f).setDelay(0.6f).setEase(LeanTweenType.easeOutElastic);
        }
        else
        {
        LeanTween.scale(Button, new Vector3(0.8f, 0.8f, 1f), 1.8f).setDelay(0.6f).setEase(LeanTweenType.easeOutElastic);

        }
        Invoke("PlaySlide", 0.3f);
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
    private void DeactivateStartScreen()
    {
        coinBackground.GetComponent<RawImage>().enabled = true;
        GameManager.Instance.ChangeState(GameState.FeatureTile);
        GameManager.Instance.gameActive = true;

        gameObject.SetActive(false);
        Particles.SetActive(false);
    }
    void PlaySlide()
    {
      
        FindObjectOfType<AudioManager>().Play("swoosh");

    }
}
