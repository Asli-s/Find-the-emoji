using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public static MenuAnim Instance;
    public CanvasGroup Fade;


    private void Awake()

    {
        if(Instance == null)
        {
           Instance= this;
        }
        this.GetComponent<RectTransform>().localPosition =new Vector3(0, 1846, 89501.99f);
    }
    private void OnEnable()
    {
        Featured.Instance.screenActive = true;

        LeanTween.moveLocal(gameObject,new Vector3(0,0, 89501.99f), 0.8f).setEaseOutExpo();
        Fade.LeanAlpha(0, 0);
        Fade.LeanAlpha(1, .6f).setDelay(0.18f);

    }
    private void SetFalse()
   
    {
        gameObject.SetActive(false);
        Featured.Instance.screenActive = false;


        //  LeanTween.moveLocal(gameObject/*.GetComponent<RectTransform>()*/,new Vector3(0,1846, 89501.99f), 1f).setEaseInExpo();
    }
    public void CloseMenuAnim()
    {
     //   print("change screenactive to false");
          LeanTween.moveLocal(gameObject/*.GetComponent<RectTransform>()*/, new Vector3(0, 1846, 89501.99f), 0.6f).setEaseInExpo().setOnComplete(SetFalse);
        Fade.LeanAlpha(0, 0);

    }


}
