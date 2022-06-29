using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWin : MonoBehaviour
{
    public static BonusWin Instance;

    public GameObject mainBlock;
    [SerializeField] TMPro.TextMeshProUGUI bonusText;
    bool animated = false;
    bool clicked = false;
    public GameObject BonusEqualsScreen;

    public GameObject ThemeAudio;
    private AudioSource ThemeAudioSource;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    
    private void OnEnable()
    {
        FindObjectOfType<AudioManager>().Play("success");
        ThemeAudio = GameObject.Find("Audio Source themesong");

        ThemeAudioSource = ThemeAudio.GetComponent<AudioSource>();
        ThemeAudioSource.pitch = 1.1f;
        ThemeAudioSource.volume = .1f;


    }

    public void ActivateBonusScreen()
    {
        GameManager.Instance.popBonus = false;

        print("  GameManager.Instance.bonusOn " + GameManager.Instance.bonusOn);
    
        //addgold
        //if orange else 2x or 3x
       // GameManager.Instance.goldBag += Board.Instance.bonusCounter;
        //DataPersistenceManager.Instance.SaveGame();
        
        bonusText.text = Board.Instance.bonusCounter.ToString();
        showScreen();

        //screen active?
    }
    private void showScreen()
    {


        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 0.8f), .6f).setEase(LeanTweenType.easeOutElastic);/*.setOnComplete(ChangeAnimationComplete);*/
        Invoke("ChangeAnimationComplete", 1f);
    }


    private void ChangeAnimationComplete()
    {
        animated = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            print("panel clicked");
            if(animated == true && clicked == false)
            {

                gameObject.SetActive(false);
                clicked = true;
                BonusEqualsScreen.SetActive(true);
            }
        }
    }



/*
    public void RestartFromBonus()
    {
        GameManager.Instance.gameCount = 1;
        DataPersistenceManager.Instance.SaveGame();
      //animate out
            Featured.Instance.restartScene();

        GameManager.Instance.bonusOn = false;
            Featured.Instance.screenActive = false;

        
    }
*/
}
