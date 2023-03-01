using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //set active after , oneanable after 6s delete 
        if(GameManager.Instance.bonusOn == false)
        {

        Destroy(gameObject, 6f);
        }
        else
        {
        //    Invoke("DelayedDeactivation", 0.01f);
        }
    }

    // Update is called once per frame

  //

}
