using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnim : MonoBehaviour
{
    public GameObject cloudsBig;
    public GameObject cloudsSmaller;
    public GameObject cloudsEvenSmaller;


    private void OnEnable()
    {
        LeanTween.rotate(cloudsBig, new Vector3(0f, 0f, 6f), 5.5f).setLoopPingPong();
        LeanTween.rotate(cloudsSmaller, new Vector3(0, 0, -6), 5.5f).setLoopPingPong();
        LeanTween.moveLocal(cloudsEvenSmaller, new Vector3(40,0,0), 6.5f).setLoopPingPong();
    }

}
