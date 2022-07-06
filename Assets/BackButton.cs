using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{

    public GameObject mainBlock;


    private void OnEnable()


    {
        if (Board.Instance.paused == false)
        {
            print("pausing board");
            Board.Instance.pauseBoard();
        }
        Featured.Instance.screenActive = true;
        //
        mainBlock.transform.localScale = Vector3.zero;
        //  LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 1.7f).setEaseOutElastic();
        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 0.8f), 2.3f).setEase(LeanTweenType.easeOutElastic);//.setOnComplete(animateStars);




        Featured.Instance.screenActive = false;


       
    }


    public void ContinueButton()
    {
        LeanTween.scale(mainBlock, new Vector3(0f, 0f, 1), .2f).setEaseOutElastic().setOnComplete(Deactivate);
        if (Board.Instance.paused == true)
        {
         

            Board.Instance.pauseBoard();
        }
        

    }
    void Deactivate()
    {
        gameObject.SetActive(false);
        Featured.Instance.screenActive = false;
        GameManager.Instance.backAlertActive = false;

    }



    public void QuitButton()
    {
        Application.Quit();

    }

}
