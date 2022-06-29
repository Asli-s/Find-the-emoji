using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusBackToGame : MonoBehaviour
{

    public GameObject mainBlock;


    private void OnEnable()
    {
        FindObjectOfType<AudioManager>().Play("appear");

        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 0.8f).setEaseOutExpo();

    }
    public void RestartFromBonus()
    {
       
        DataPersistenceManager.Instance.SaveGame();
        LeanTween.scale(mainBlock, new Vector3(0f, 0f, 1), 0.3f).setEaseOutExpo().setOnComplete(ActualRestart);


        //animate out
    

    }
    private void ActualRestart()
    {
        // Featured.Instance.restartScene();
        GameManager.Instance.yellowPresentBonus = false;
        GameManager.Instance.greenPresentBonus = false;
        GameManager.Instance.bluePresentBonus = false;
        GameManager.Instance.darkBluePresentBonus = false;
        GameManager.Instance.redPresentBonus = false;
        GameManager.Instance.lilaPresentBonus = false;
        GameManager.Instance.rainbowPresentBonus = false;
        GameManager.Instance.rainbowPresentBonus2 = false;
        GameManager.Instance.rainbowPresentBonus3 = false;
        GameManager.Instance.rainbowPresentBonus4 = false;
        GameManager.Instance.rainbowPresentBonus5 = false;
        GameManager.Instance.rainbowPresentBonus6 = false;



    PresentTimer.Instance.StartThisCoroutine();

        GameManager.Instance.bonusOn = false;
        Featured.Instance.screenActive = false;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);


    }
}
