using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingScreen : MonoBehaviour
{

    public Toggle toggleButton;
    public GameObject mainBlock;
    bool wasPuased = false;
    public bool dontShowAgain =false;


    public void OnEnable()
    {
        dontShowAgain = false;
        if(Board.Instance.paused == true)
        {
            wasPuased = true;
        }
        else
        {
            wasPuased = false;
            Featured.Instance.screenActive = false;


            if (Board.Instance.paused == false)
            {
                print("pausing board");
                Board.Instance.pauseBoard();
            }
            Featured.Instance.screenActive = true;
        }
        toggleButton.isOn = false;
        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 0.5f).setEaseOutExpo();


    }
    public void Toggle()
    {

        if (dontShowAgain == false)
        {
            dontShowAgain = true;
            toggleButton.isOn = true;

        }
        else
        {
            toggleButton.isOn = false;
            dontShowAgain = false;

        }
    }

    public void RateClick()
    {
        Application.OpenURL("market://details?id=com.AdsApp.FindTheEmoji");


        //Application.OpenURL("market://details?q=pname:com.AdsApp.FindTheEmoji/");
        GameManager.Instance.rated = true;
        if (wasPuased == true)
        {
            print("was paused , starrt again ");

            Board.Instance.pauseBoard();
        }
        Featured.Instance.screenActive = false;
        gameObject.SetActive(false);
    }



    public void Close()
    {
        if (toggleButton.isOn == true)
        {

        GameManager.Instance.rated = true;
            print("rated = true");
        }
        if (wasPuased == true)
        {
            print("was paused , starrt again ");

            Board.Instance.pauseBoard();
        }
        Featured.Instance.screenActive = false;
        LeanTween.scale(mainBlock, new Vector3(0f, 0f, 0f), .8f).setEaseInExpo().setOnComplete(SetFalse);




    }
    void SetFalse(
)
    {

        gameObject.SetActive(false);

    }
}
