using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessAlert : MonoBehaviour
{
    public GameObject mainBlock;





    bool animCompleted = false;
    bool clicked = false;

    // Update is called once per frame

    private void OnEnable()
    {
        clicked = false;
        animCompleted = false;
        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 0.3f).setEaseOutElastic().setOnComplete(ChangeScreenActive);
        Featured.Instance.screenActive = true;

    }

    void ChangeScreenActive()
    {
        animCompleted = true;
    }

    private void changeScreenActive()
    {


        gameObject.SetActive(false);
        animCompleted = false;
        clicked = false;



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