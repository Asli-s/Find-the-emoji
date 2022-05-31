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
    [SerializeField] private GameObject ParentBoardBackground;
    [SerializeField] private GameObject featureTileBackground;


    public GameObject mainBlock;


    void OnEnable()
    {
        Featured.Instance.screenActive = false;
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

        coinButtonCover.enabled = true;
        coinButtonCover.interactable = false;

        coinButton.interactable = false;
        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1f), 2.3f).setEase(LeanTweenType.easeOutElastic);//.setOnComplete(animateStars);


        // disable when coin is one

    }

    // Update is called once per frame

    void PlayCoinSound()
    {
        FindObjectOfType<AudioManager>().Play("coin");

    }


    public void StartGame()
    {
        if(GameManager.Instance.coinNum > 0)
        {
            FindObjectOfType<AudioManager>().Play("coin");

            LeanTween.scale(mainBlock, new Vector3(0f, 0f, 0f), .4f).setEase(LeanTweenType.easeOutElastic);//.setOnComplete(animateStars);
            PlayCoinSound();


            Invoke("ChangeToPlay", 0.4f);


        }
    }

    private void ChangeToPlay()
    
    {
        Featured.Instance.LoseCoinFromNoCoinScreen();
        /*
        PauseButton.SetActive(true);
        RestartButton.SetActive(true);
        ParentBoardBackground.SetActive(true);
        featureTileBackground.SetActive(true);
        GameManager.Instance.ChangeState(GameState.FeatureTile);*/

    }


    /*   public void RestartButtonNoCoinScreen()
       {

       }
   */

}
