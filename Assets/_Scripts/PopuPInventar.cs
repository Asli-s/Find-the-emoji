using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopuPInventar : MonoBehaviour
{
   
    // Start is called before the first frame update
    public static PopuPInventar Instance;
    public GameObject mainBlock;
    public Board _board;


    private void Awake()

    {
        if (Instance == null)
        {
            Instance = this;
        }
        //   this.GetComponent<RectTransform>().localPosition = new Vector3(0, 1846, 89501.99f);
    }
    private void OnEnable()


    {


        Time.timeScale = 1;
     
       
        FindObjectOfType<AudioManager>().Play("appear");
        

        if (GameManager.Instance.tablet == true)
        {
            LeanTween.scale(mainBlock, new Vector3(0.7f, 0.7f, 1), 0.8f).setEaseOutExpo().setOnComplete(ChangeScreenActive);

        }
        else
        {

            LeanTween.scale(mainBlock, new Vector3(1, 1, 1), 0.8f).setEaseOutExpo().setOnComplete(ChangeScreenActive);
        }


        if(_board.paused == false)
        {
            print("pausing board");
            _board.pauseBoard();
        }
        /*  if (LeanTween.isTweening() ==false)
          {

          LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1f), 1.2f).setDelay(0.3f).setEaseOutElastic();
          }*/
    }




    private void ChangeScreenActive()
    {
        Featured.Instance.screenActive = true;

    }


    private void SetFalse()

    {
        Featured.Instance.screenActive = false;


        gameObject.SetActive(false);

        //  LeanTween.moveLocal(gameObject/*.GetComponent<RectTransform>()*/,new Vector3(0,1846, 89501.99f), 1f).setEaseInExpo();
    }
    public void CloseMenuAnimation()
    {
        if (_board.paused == true)
        {
            print("was paused , starrt again ");

            _board.pauseBoard();
        }
        LeanTween.scale(mainBlock, new Vector3(0f, 0f, 0f), .8f).setEaseInExpo().setOnComplete(SetFalse);

        print("close");
        
    }

    public void ActivatePOP()
    {
        gameObject.SetActive(true);
     
    }

  
}
