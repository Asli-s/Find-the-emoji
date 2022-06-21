using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFirstAlert : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainBlock;
    bool clicked = false;

    public GameObject featureTileBonus;
    public CanvasGroup backPanelFade;
    public GameObject backPanelObject;

    public GameObject pauseButton;
    public GameObject restartButtom;




    private void OnEnable()
    {
        pauseButton.SetActive(false);
        restartButtom.SetActive(false);
        PresentTimer.Instance.StopThisCoroutine();

        LeanTween.scale(mainBlock, new Vector3(0.7f, 0.7f, 1), 0.8f).setEaseOutExpo();
        backPanelObject.SetActive(true);
                    backPanelFade.LeanAlpha(0.9f, 0.2f);




    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {


            if (clicked == false)
            {

                clicked = true;
                gameObject.SetActive(false);
                Board.Instance.GenerateBonusGrid();

              //  FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                GameManager.Instance.bonusOn = true;
                print("gridpop firstalert" + Board.Instance.gridPopulation);
                featureTileBonus.SetActive(true);
                GameManager.Instance.popBonus = true;

               // print("gridpop firstalert" + Board.Instance.gridPopulation);
            }
        }

    }
}
