using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryNotEnoughCoinsALert : MonoBehaviour
{
    public GameObject mainBlock;
   

    bool animCompleted = false;
    bool clicked = false;

    private void OnEnable()
    {
        clicked = false;
        animCompleted = false;
        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 0.1f).setEaseOutElastic().setOnComplete(ChangeScreenActive);
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
                LeanTween.scale(mainBlock, new Vector3(0f, 0f, 1), 0.1f).setEaseOutElastic().setOnComplete(changeScreenActive);

              


            }
        }

    }
}
