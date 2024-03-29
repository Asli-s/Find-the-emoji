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
    public GameObject BackToGame;
   public GameObject ExtraSweetHammer;
    public GameObject ExtraSweetGlass;
        




    private void OnEnable()
    {
        FindObjectOfType<AudioManager>().Play("highScoreNew");

        LeanTween.moveLocal(goldObject, new Vector3(234, 103, 1),.4f).setEaseOutElastic();
        LeanTween.moveLocal(presentObject, new Vector3(-22, 103, 1),.4f).setEaseOutElastic().setOnComplete(ChangeAnimationCompleted);
        presentText.text = Board.Instance.bonusCounter.ToString();
        // could be 2x or 3x if present not orange
         if (GameManager.Instance.yellowPresentBonus)
        {
            GameManager.Instance.goldBag += Board.Instance.bonusCounter;

            goldText.text = presentText.text;

        }
      else  if (GameManager.Instance.greenPresentBonus|| GameManager.Instance.bluePresentBonus)
        {
            GameManager.Instance.goldBag += 2 * Board.Instance.bonusCounter;
            goldText.text =( 2* Board.Instance.bonusCounter).ToString();


        }
        else if(GameManager.Instance.darkBluePresentBonus || GameManager.Instance.redPresentBonus || GameManager.Instance.lilaPresentBonus)
        {
            GameManager.Instance.goldBag += 3 * Board.Instance.bonusCounter;

            goldText.text = (3 * Board.Instance.bonusCounter).ToString();


            //    goldText.text = presentText.text;
        }
        else if (GameManager.Instance.rainbowPresentBonus || GameManager.Instance.rainbowPresentBonus2 || GameManager.Instance.rainbowPresentBonus3 || GameManager.Instance.rainbowPresentBonus4 || GameManager.Instance.rainbowPresentBonus5 || GameManager.Instance.rainbowPresentBonus6)
        {
            GameManager.Instance.goldBag += 4 * Board.Instance.bonusCounter;

            goldText.text = (4 * Board.Instance.bonusCounter).ToString();


            //    goldText.text = presentText.text;
        }
       
        DataPersistenceManager.Instance.SaveGame();
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

                if (/*GameManager.Instance.yellowPresentBonus && */GameManager.Instance.currentStreak == 100)
                {
                    ExtraSweetHammer.SetActive(true);
                }
                else if (GameManager.Instance.currentStreak > 100 && GameManager.Instance.currentStreak %100 ==0)
                {
                    ExtraSweetGlass.SetActive(true);
                }
                  else
                {

                    BackToGame.SetActive(true);
                }
            }
        }
    }


}
