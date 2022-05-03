using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeanAnnimations : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] stars;
    public GameObject mainBlock;

  /*  void Start()
    {
        // transform.localScale = Vector2.zero;
        print(gameObject.name);



        //TODO fadeout panel

        LeanTween.scale(mainBlock, new Vector3(0.8f, 0.8f, 0.8f), 2.3f).setDelay(0.7f).setEase(LeanTweenType.easeOutElastic)*//*.setOnComplete(afterFirstAnimation)*//*;
   

    }
*/
    void afterFirstAnimation()
    {
        //animate the stars

            //foreach
    }





    /* public void Open()
     {
         transform.LeanScale(Vector2.one, 0.8f);
     }*/


    private void OnEnable()
    {
        LeanTween.scale(mainBlock, new Vector3(0.8f, 0.8f, 0.8f), 2.3f)/*.setDelay(0.7f)*/.setEase(LeanTweenType.easeOutElastic)/*.setOnComplete(afterFirstAnimation)*/;

    }

    public void Close()
    {
        print("close!!");
        LeanTween.scale(gameObject, Vector3.zero, 0.6f).setOnComplete(OnDisable);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);


        //  transform.LeanScale(Vector2.zero, 1.8f).;

    }
    /*    void DestroySelf()
        {
            print("destroy");
         //   Destroy(gameObject);
        }*/
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }



}
