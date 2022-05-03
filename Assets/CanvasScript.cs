using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
   
   
     Vector2 touchPos;
public GraphicRaycaster GR;

void Update()
{
    if (Input.touchCount > 0)
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PointerEventData ped = new PointerEventData(null);
            ped.position = Input.GetTouch(0).position;
            List<RaycastResult> results = new List<RaycastResult>();
            GR.Raycast(ped, results);
            if (results.Count == 0)
            {
                // YOUR CODE HERE
            }
        }
    }
}
}
