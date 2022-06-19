using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI goldAmount;


    public void ShowActualGold()
    {
        goldAmount.text = GameManager.Instance.goldBag.ToString();
    }


   /*  public void AddGold()
    {

    }*/

}
