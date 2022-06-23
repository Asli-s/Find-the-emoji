using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughSweetsPopup : MonoBehaviour
{
    public GameObject mainBlock;





    bool animCompleted = false;
    bool clicked = false;

    // Update is called once per frame

    private void OnEnable()
    {
        clicked = false;
        animCompleted = false;


        if (Board.Instance.paused == false)
        {
            print("was paused , starrt again ");
            Featured.Instance.screenActive = false;
            Board.Instance.pauseBoard();
        }

        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 0.5f).setEaseOutExpo().setOnComplete(ChangeScreenActive);
        Featured.Instance.screenActive = true;

    }

    void ChangeScreenActive()
    {
        animCompleted = true;
    }

    private void changeScreenActive()
    {

        animCompleted = false;
        clicked = false;
        gameObject.SetActive(false);



    }


    private void Update()
    {

        if (Input.GetMouseButtonUp(0) && animCompleted == true)
        {


            if (clicked == false)
            {
                clicked = true;
                LeanTween.scale(mainBlock, new Vector3(0f, 0f, 1), 0.5f).setEaseOutExpo().setOnComplete(changeScreenActive);

                if (Board.Instance.paused == true)
                {
                    print("was paused , starrt again ");
                    Board.Instance.pauseBoard();
                    Featured.Instance.screenActive = false;
                }

            }
        }

    }
}


