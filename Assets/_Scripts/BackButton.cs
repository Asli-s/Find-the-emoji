using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{

    public GameObject mainBlock;
    bool wasPaused = false;

    private void OnEnable()


    {
        FindObjectOfType<AudioManager>().Play("close");

        if (Board.Instance.paused == false)
        {
            wasPaused = false;
            print("pausing board");
            Board.Instance.pauseBoard();
        }
        Featured.Instance.screenActive = true;
        //
        mainBlock.transform.localScale = Vector3.zero;
        //  LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 1.7f).setEaseOutElastic();
        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 0.8f), 2.3f).setEase(LeanTweenType.easeOutElastic);//.setOnComplete(animateStars);




      //  Featured.Instance.screenActive = false;


       
    }


    public void ContinueButton()
    {
        LeanTween.scale(mainBlock, new Vector3(0f, 0f, 1), .2f).setEaseOutElastic().setOnComplete(Deactivate);
        if (wasPaused==false)
        {
         

            Board.Instance.pauseBoard();
        }
        Featured.Instance.screenActive = false;
        GameManager.Instance.backAlertActive = false;

        

    }
    void Deactivate()
    {
        gameObject.SetActive(false);
        
    }



    public void QuitButton()
    {
        Application.Quit();

    }

}
