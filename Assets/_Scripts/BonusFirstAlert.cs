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

    [SerializeField] private GameObject BonusCollectAsMany;




    private void OnEnable()
    {
        FindObjectOfType<AudioManager>().Play("bonus");
        pauseButton.SetActive(false);
                featureTileBonus.SetActive(true);
        restartButtom.SetActive(false);
        PresentTimer.Instance.StopThisCoroutine();

        LeanTween.scale(mainBlock, new Vector3(0.7f, 0.7f, 1), 0.8f).setEaseOutElastic();
        backPanelObject.SetActive(true);
                    backPanelFade.LeanAlpha(.7f, 0.2f);




    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {


            if (clicked == false)
            {

                clicked = true;
                gameObject.SetActive(false);
                BonusCollectAsMany.SetActive(true);
                GameManager.Instance.bonusOn = true;
                featureTileBonus.SetActive(true);

                /*   Board.Instance.GenerateBonusGrid();

                 //  FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                   GameManager.Instance.bonusOn = true;
                   print("gridpop firstalert" + Board.Instance.gridPopulation);
                   featureTileBonus.SetActive(true);
                   GameManager.Instance.popBonus = true;

                  // print("gridpop firstalert" + Board.Instance.gridPopulation);*/
            }
        }

    }
}
