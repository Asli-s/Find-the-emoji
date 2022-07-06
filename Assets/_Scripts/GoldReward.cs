using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldReward : MonoBehaviour
{
    public GameObject mainBlock;
    [SerializeField] TMPro.TextMeshProUGUI goldText;




    bool animCompleted = false;
    bool clicked = false;

    // Update is called once per frame

    private void OnEnable()
    {
        FindObjectOfType<AudioManager>().Play("highScoreNew");
        clicked = false;
        animCompleted = false;

        GameManager.Instance.goldBag += 50;
        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 0.5f).setEaseOutExpo().setOnComplete(ChangeScreenActive);



    }




    void ChangeScreenActive()
    {
        animCompleted = true;
    }

    private void changeScreenActive()
    {

        animCompleted = false;
        clicked = false;
        gameObject.SetActive(false);
     // 



    }


    private void Update()
    {

        if (Input.GetMouseButtonUp(0) && animCompleted == true)
        {


            if (clicked == false)
            {
                clicked = true;
                LeanTween.scale(mainBlock, new Vector3(0f, 0f, 1), 0.5f).setEaseOutExpo().setOnComplete(changeScreenActive);
                GameManager.Instance.watchedAd = false;

                if (GameManager.Instance.shopActive == true)
                {
                    goldText.text = GameManager.Instance.goldBag.ToString();

                }

            }
        }

    }
}

