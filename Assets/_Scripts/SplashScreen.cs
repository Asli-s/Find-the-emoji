using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour, IDataPersistence
{
    public int secondsToFade = 3;
    public int lastPosition;
    public string loadPosition ;

    public bool timerEnd = false;
    private bool alreadyCalled= false;
    // Update is called once per frame
    private void Start()
    {
        secondsToFade = 3;
    }
    void Update()
    {
        /* if(secondsToFade > 0)
         {
             StartCoroutine(FadeAway());
         }
         else if(secondsToFade ==0)
         {
             timerEnd = true;
             print("stopped" + lastPosition);
             StopCoroutine(FadeAway());
             //SceneManager.LoadScene(lastPosition);


         }*/
         if (secondsToFade > 0)
        {
            StartCoroutine(FadeAway());
        }
        if (secondsToFade == 0)
        {
            StopCoroutine(FadeAway());
            timerEnd = true;
        }
        if (timerEnd == true)
        {
            changeScene();
        }
    }
    public void changeScene()
    {
        if(alreadyCalled ==false &&timerEnd == true)
        {
            print(loadPosition);
          SceneManager.LoadScene(loadPosition);
            alreadyCalled = true;
        }
    }

    public void LoadData(GameData gameData)
    {
        print(loadPosition);
        loadPosition = gameData.lastPos;
    }
   
   public void SaveData(GameData gameData)
    {
      
     /*   gameData.lastPos = "slow";*/
    }

    IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(1);
        print(secondsToFade);

        secondsToFade--;
    }
}
