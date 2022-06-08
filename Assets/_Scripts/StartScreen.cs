using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    string coinCountText;
    private int coinCountNum;
    private int newNum;

    bool clicked = false;
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

                playCoinSound();
            }
            else
            {

                    GameManager.Instance.coinNum = newNum;
                    GameManager.Instance.m_Object.text = newNum.ToString();

                    FindObjectOfType<AudioManager>().Play("coin");
                playCoinSound();
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
        GameManager.Instance.ChangeState(GameState.FeatureTile);

        gameObject.SetActive(false);

    }
}
