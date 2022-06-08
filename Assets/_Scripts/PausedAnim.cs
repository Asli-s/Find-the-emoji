using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedAnim : MonoBehaviour
{
    public static PausedAnim Instance;
    bool alreadyClicked = false;
    // Start is called before the first frame update
    public CanvasGroup Fade;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
      //  Fade = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        alreadyClicked = false;
        Fade.LeanAlpha(0, 0);

        Fade.LeanAlpha(1, 0.2f);
        Featured.Instance.screenActive = true;


    }
    public void ClosePauseScreen()
    {
        //LeanTween.alpha(gameObject, 0, 2f).setOnComplete(DeactivateScreen);
        if(alreadyClicked == false)
        {
            alreadyClicked = true;

        Fade.LeanAlpha(0, 0.2f).setOnComplete(DeactivateScreen);

        Featured.Instance.screenActive = false;

        }

    }
    void DeactivateScreen()
    {
        Board.Instance.PauseButton();
        gameObject.SetActive(false);

    }
}
