using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noCoinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Button coinButtonCover;
    [SerializeField] public Button coinButton;
    [SerializeField] private GameObject ParentBoard;
    [SerializeField] private GameObject ParentFeatureTile;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject RestartButton;



    void OnEnable()
    {
        Featured.Instance.screenActive = false;
        //destroy feature tile && all nodes in board!!
        if(GameOver.Instance.lose == true)
        {
          
            ParentFeatureTile.SetActive(false);
            ParentBoard.SetActive(false);
     

        }

        //DEACTIVATE PAUSE AND RESTART BUTTOnS
        PauseButton.SetActive(false);
        RestartButton.SetActive(false);

        coinButtonCover.enabled = true;
        coinButtonCover.interactable = false;

        coinButton.interactable = false;

        // disable when coin is one

    }

    // Update is called once per frame

    public void StartGame()
    {
        if(GameManager.Instance.coinNum > 0)
        {
            GameManager.Instance.ChangeState(GameState.FeatureTile);
            PauseButton.SetActive(true);
            RestartButton.SetActive(true);

        }
    }



 /*   public void RestartButtonNoCoinScreen()
    {

    }
*/

}
