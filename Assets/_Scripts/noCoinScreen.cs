using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noCoinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Button coinButton;
    [SerializeField] private GameObject ParentBoard;
    [SerializeField] private GameObject ParentFeatureTile;

    void OnEnable()
    {

        //destroy feature tile && all nodes in board!!
        if(GameOver.Instance.lose == true)
        {
          
            ParentFeatureTile.SetActive(false);
            ParentBoard.SetActive(false);
     

        }

        //DEACTIVATE PAUSE AND RESTART BUTTOnS
        coinButton.enabled = true;
        coinButton.interactable = false;


        // disable when coin is one

    }

    // Update is called once per frame
    
    public void StartGame()
    {
        if(GameManager.Instance.coinNum > 0)
        {
            GameManager.Instance.ChangeState(GameState.FeatureTile);
        }
    }



 /*   public void RestartButtonNoCoinScreen()
    {

    }
*/

}
