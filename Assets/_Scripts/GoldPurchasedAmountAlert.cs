using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPurchasedAmountAlert : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainBlock;

    [SerializeField] public TMPro.TextMeshProUGUI alertText;
    [SerializeField] public TMPro.TextMeshProUGUI shopText;

    //  public GameObject EssentialPopUp;

    // public GameObject goldAmountAlert;
    public IAPManager PurchaseScript;

    bool animCompleted = false;
    bool clicked = false;

    // Update is called once per frame

    private void OnEnable()
    {
        // FindObjectOfType<AudioManager>().Play("success");
        shopText.text = GameManager.Instance.goldBag.ToString();

        clicked = false;
        animCompleted = false;
        if (PurchaseScript.addedGold ==200)
        {


            alertText.text = "+ 200";
        }
        else if (PurchaseScript.addedGold == 500)
        {
            alertText.text = "+ 500";

        }
        else if (PurchaseScript.addedGold == 1000)
        {
            alertText.text = "+ 1000";

        }
        LeanTween.scale(mainBlock.gameObject, new Vector3(1f, 1f, 1), 0.8f).setDelay(0.16f).setEaseOutElastic().setOnComplete(ChangeScreenActive);
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
        //
   //     goldAmountAlert.SetActive(true);


    }


    private void Update()
    {

        if (Input.GetMouseButtonUp(0) && animCompleted == true)
        {


            if (clicked == false)
            {
                clicked = true;
                LeanTween.scale(mainBlock.gameObject, new Vector3(0f, 0f, 1), 0.1f).setEaseOutElastic().setOnComplete(changeScreenActive);



            }
        }

    }
}
