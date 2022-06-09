using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAnimRestart : MonoBehaviour
{
    // Start is called before the first frame update
    public static PopUpAnimRestart Instance;
    public GameObject mainBlock;


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
        Featured.Instance.screenActive = true;
        FindObjectOfType<AudioManager>().Play("appear");

        if(GameManager.Instance.tablet == true)
        {
            LeanTween.scale(mainBlock, new Vector3(0.7f, 0.7f, 1), 0.8f).setEaseOutExpo();

        }
        else
        {

        LeanTween.scale(mainBlock, new Vector3(1,1,1), 0.8f).setEaseOutExpo();
        }
      /*  if (LeanTween.isTweening() ==false)
        {

        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1f), 1.2f).setDelay(0.3f).setEaseOutElastic();
        }*/
    }
    private void SetFalse()

    {
        Featured.Instance.screenActive = false;

        gameObject.SetActive(false);
    

        //  LeanTween.moveLocal(gameObject/*.GetComponent<RectTransform>()*/,new Vector3(0,1846, 89501.99f), 1f).setEaseInExpo();
    }
    public void CloseMenuAnimation()
    {
        LeanTween.scale(mainBlock, new Vector3(0f, 0f, 0f), .8f).setEaseInExpo().setOnComplete(SetFalse);
      //
      //
      //LeanTween.scale(Featured.Instance.tile as , new Vector3(1, 1, 1),0);
        print("close");
    }
}
