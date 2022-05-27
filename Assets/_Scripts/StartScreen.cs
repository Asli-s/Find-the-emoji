using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{

    public void StrartScreen()
    {
        if (GameManager.Instance.coinNum <= 5 && GameManager.Instance.restarted == true && GameManager.Instance.coinNum != 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.ChangeState(GameState.FeatureTile);
            print("firstscreen coin not 0");
        }
        else if (GameManager.Instance.coinNum == 0 && GameManager.Instance.restarted == true)
        {
            gameObject.SetActive(false);
            print("firstscreen coin == 0");

            GameManager.Instance.coinNotEnoughScreen.SetActive(true);


        }
    }

}
