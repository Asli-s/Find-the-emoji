using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string gold200 = "com.findtheemoji.gold200";
    private string gold500 = "com.findtheemoji.gold500";
    private string gold1000 = "com.findtheemoji.gold1000";

    public int addedGold;


    public GameObject purchaseSuccesfulAlert;
    public GameObject purchasefailedAlert;


    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id== gold200)
                {
            Debug.Log("bought 200");
            GameManager.Instance.goldBag += 200;
            addedGold = 200;
            purchaseSuccesfulAlert.SetActive(true);
            DataPersistenceManager.Instance.SaveGame();

            FindObjectOfType<PlayExtraSound>().Play("success");


        }
        else if(product.definition.id == gold500)
                {
            GameManager.Instance.goldBag += 500;
            addedGold = 500;

            purchaseSuccesfulAlert.SetActive(true);


            DataPersistenceManager.Instance.SaveGame();
            FindObjectOfType<PlayExtraSound>().Play("success");

            Debug.Log("bought 500");

        }
        else if(product.definition.id == gold1000)
                {
            addedGold = 1000;

            GameManager.Instance.goldBag += 1000;

            purchaseSuccesfulAlert.SetActive(true);
            DataPersistenceManager.Instance.SaveGame();
            FindObjectOfType<PlayExtraSound>().Play("success");



            Debug.Log("bought 1000");

        }
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        FindObjectOfType<AudioManager>().Play("close");

        Debug.Log("Not successfull because" + failureReason);
        purchasefailedAlert.SetActive(true);

    }
    
}
