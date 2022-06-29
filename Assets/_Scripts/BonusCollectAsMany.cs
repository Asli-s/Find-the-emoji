using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCollectAsMany : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainBlock;
    bool clicked = false;

   public GameObject featureTileBonus;

    public GameObject ThemeAudio;
    private AudioSource ThemeAudioSource;

  /*  public CanvasGroup backPanelFade;
    public GameObject backPanelObject;*/

  //  public GameObject pauseButton;
//public GameObject restartButtom;




    private void OnEnable()
    {
        ThemeAudio = GameObject.Find("Audio Source themesong");
       // ThemeAudio.SetActive(true);
        ThemeAudioSource = ThemeAudio.GetComponent<AudioSource>();

        GameManager.Instance.bonusCollectAsManyAlertActive = true;


                Featured.Instance.screenActive = true;


        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 0.4f).setEaseOutElastic();

        Board.Instance.GenerateBonusGrid();




    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {


            if (clicked == false)
            {
                ThemeAudioSource.pitch = 1.26f;
                ThemeAudioSource.volume = 0.17f;

                clicked = true;
                gameObject.SetActive(false);
                Board.Instance.PopBonus();
                //  FindObjectOfType<CurrentStreakMenu>().ChangeCurrStreak();
                //
                Featured.Instance.screenActive = false;
                print("gridpop firstalert" + Board.Instance.gridPopulation);
                GameManager.Instance.popBonus = true;

                // print("gridpop firstalert" + Board.Instance.gridPopulation);
            }
        }

    }
}
