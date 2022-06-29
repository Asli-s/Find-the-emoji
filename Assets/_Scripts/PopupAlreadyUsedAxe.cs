using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupAlreadyUsedAxe : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public static PopupAlreadyUsedAxe Instance;
    public GameObject mainBlock;
    public Board _board;
    // public GameObject closingX;
    bool clicked = false;



    private void Awake()

    {
        if (Instance == null)
        {
            Instance = this;
        }
       
    }
    private void OnEnable()


    {
        FindObjectOfType<AudioManager>().Play("close");



        //Time.timeScale = 1;


        //FindObjectOfType<AudioManager>().Play("appear");


        if (GameManager.Instance.tablet == true)
        {
            LeanTween.scale(mainBlock, new Vector3(0.7f, 0.7f, 1), 0.8f).setEaseOutExpo().setOnComplete(ChangeScreenActive);
          //  Invoke("AnimateX", 0.2f);


        }
        else
        {

            LeanTween.scale(mainBlock, new Vector3(1, 1, 1), 0.8f).setEaseOutExpo().setOnComplete(ChangeScreenActive);
        //    Invoke("AnimateX", 0.2f);


        }
        Featured.Instance.screenActive = false;

        if (_board.paused == false)
        {
            print("pausing board");
            _board.pauseBoard();
        }
        Featured.Instance.screenActive = true;

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

        Sweets.Instance.lolliClicked = false;

        gameObject.SetActive(false);

        //  LeanTween.moveLocal(gameObject/*.GetComponent<RectTransform>()*/,new Vector3(0,1846, 89501.99f), 1f).setEaseInExpo();
    }
/*    void AnimateX()
    {


        LeanTween.scale(closingX, new Vector3(1.7f, 1.7f, 1), 0.3f).setEaseInOutExpo();

    }
*/
    public void CloseMenuAnimation()
    {
        if (_board.paused == true)
        {
            print("was paused , starrt again ");

            _board.pauseBoard();
        }
        clicked = false;
        LeanTween.scale(mainBlock, new Vector3(0f, 0f, 0f), .8f).setEaseInExpo().setOnComplete(SetFalse);
    //    LeanTween.scale(closingX, new Vector3(0, 0, 0), 0.8f).setEaseOutExpo();
        print("close");

    }

    public void ActivatePOP()
    {
        gameObject.SetActive(true);

    }

    void Update()
    {


        if (Input.GetMouseButtonUp(0))
        {


            if (clicked == false)
            {
                clicked = true;
                CloseMenuAnimation();
            }
        }
    }
}
