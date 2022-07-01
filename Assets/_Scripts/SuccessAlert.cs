using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessAlert : MonoBehaviour
{
    public GameObject mainBlock;

    [SerializeField] public TMPro.TextMeshProUGUI alertText;
    public GameObject EssentialPopUp;



    bool animCompleted = false;
    bool clicked = false;

    // Update is called once per frame

    private void OnEnable()
    {
        // FindObjectOfType<AudioManager>().Play("success");


        clicked = false;
        animCompleted = false;
        LeanTween.scale(alertText.gameObject, new Vector3(1f, 1f, 1), 0.8f).setDelay(0.16f).setEaseOutElastic().setOnComplete(ChangeScreenActive);
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
        if(GameManager.Instance.shopActive==true&& GameManager.Instance.buyEssential == true)
        {
            EssentialPopUp.SetActive(true);
            GameManager.Instance.buyEssential = false;

        }



    }


    private void Update()
    {

        if (Input.GetMouseButtonUp(0) && animCompleted == true)
        {


            if (clicked == false)
            {
                clicked = true;
                LeanTween.scale(alertText.gameObject, new Vector3(0f, 0f, 1), 0.1f).setEaseOutElastic().setOnComplete(changeScreenActive);



            }
        }

    }
}