using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusBackToGame : MonoBehaviour
{

    public GameObject mainBlock;


    private void OnEnable()
    {
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

        GameManager.Instance.bonusOn = false;
        Featured.Instance.screenActive = false;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);


    }
}
