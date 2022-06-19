using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEqualsAnim : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject goldObject;
    public GameObject presentObject;

    bool animated = false;
    bool  clicked = false;

    [SerializeField] TMPro.TextMeshProUGUI presentText;
    [SerializeField] TMPro.TextMeshProUGUI goldText;

    //    public GameObject // nextscreen



    private void OnEnable()
    {
        LeanTween.moveLocal(goldObject, new Vector3(234, 103, 1),.4f).setEaseOutElastic();
        LeanTween.moveLocal(presentObject, new Vector3(-22, 103, 1),.4f).setEaseOutElastic().setOnComplete(ChangeAnimationCompleted);
        presentText.text = Board.Instance.bonusCounter.ToString();
        // could be 2x or 3x if present not orange
        goldText.text = presentText.text;
    }


    void ChangeAnimationCompleted()
    {
        animated = true;
    }

    /*  private void Update()
      {
          if (Input.GetKeyDown(0))
          {
              if (animated == true && clicked == false)
              {
                  clicked = true;
              //   Nextscreen   .SetActive(true);
              }
          }
      }
  */
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (animated == true && clicked == false)
            {
                clicked = true;
                gameObject.SetActive(false);
              //  BonusEqualsScreen.SetActive(true);
            }
        }
    }


}
