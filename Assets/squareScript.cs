using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //set active after , oneanable after 6s delete 
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
