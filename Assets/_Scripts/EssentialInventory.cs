using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainBlock;
  

   
    bool animCompleted = false;
    bool clicked = false;


    private void OnEnable()
    {
        FindObjectOfType<AudioManager>().Play("highScoreNew");

        clicked = false;
        animCompleted = false;
        LeanTween.scale(mainBlock, new Vector3( 1f, 1f, 1), 0.7f).setEaseOutElastic().setOnComplete(ChangeScreenActive);
                    Featured.Instance.screenActive = true;


    }
    void ChangeScreenActive()
    {
        animCompleted = true;
    }

    private void changeScreenActive()
    {
       
        if(GameManager.Instance.shopActive == false)
        {

        PresentTimer.Instance.StartPresentTimer();
        Featured.Instance.screenActive = false;
       
        }
      

        gameObject.SetActive(false);



    }



    private void Update()
    {

        if (Input.GetMouseButtonUp(0) && animCompleted == true)
        {


            if (clicked == false)
            {
                clicked = true;
                LeanTween.scale(mainBlock, new Vector3(0f, 0f, 1), 0.3f).setEaseOutElastic().setOnComplete(changeScreenActive);

           
             if( Board.Instance.paused == true && GameManager.Instance.shopActive==false)
                {
                    Board.Instance.pauseBoard();


                }


            }
        }

    }
}