using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] public TMPro.TextMeshProUGUI m_Object;
    public int coinCount;
   private string coinCountText;

    void Start()
    {
       //if coincount not 5 take that else 5
       //memory?
       m_Object.text = "5";
       /* if(coinCount read == null){
        * 
            coinCountText == "6";
        }*/
       /* coinCountText = m_Object.text;
        coinCount = int.Parse(coinCountText);
        print(coinCount);*/
    }


 
}
