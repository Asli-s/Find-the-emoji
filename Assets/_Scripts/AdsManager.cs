using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public GameObject GoldReward;

    string Android_Game_ID = "4829947";
    string Iphone_Game_ID = "4829946";

    string AdIdIOS = "Rewarded_iOS";
    string AdIdAndroid = "Rewarded_Android";

    string GameId;
    string AdId;

    public Button showAdButton;

    bool loadedSuccessfully = false;

    bool buttonCLick = false;
   
    bool testmode = false;
    public Action onRewardedAdSuccess;

    // Start is called before the first frame update
    void Awake()
    {

     
    }

    void Start()
    {
        print("awake ad");

        if (Application.platform == RuntimePlatform.Android)
        {
            GameId = Android_Game_ID;
            AdId = AdIdAndroid;
        }

        else
        {
            GameId = Iphone_Game_ID;
            AdId = AdIdIOS;
        }

        Advertisement.Initialize(GameId, testmode, this);
      
    }





    void ActivateReward()
    {
        GoldReward.SetActive(true);
    }

        ///////
        ///
        ///
        bool adStarted =false;

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        Advertisement.Load(AdId, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
   
        print("failed");
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
        if (!adStarted  )
        {
            loadedSuccessfully = true;
            if(notready= false)
            {
                notready = true;
                Advertisement.Show(AdId, this);


            }
        }
    }
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
       
        print("failed");

    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
      
        print("failed");

    }

    public bool adCompleted;
    public void OnUnityAdsShowStart(string adUnitId)
    {
        adStarted = true;
        Debug.Log("Ad Started: " + adUnitId);
    }


    public void ckilcKButton()
    {
        print("adStarted" + adStarted);
        print("loaded" + loadedSuccessfully);
        if (loadedSuccessfully)
        {
            Advertisement.Show(AdId, this);
       
        }
        else
        {

            Advertisement.Load(AdId, this);
            notready = false;

        }
    }


    bool notready = true;

    public void OnUnityAdsShowClick(string adUnitId)
    {
        Debug.Log("Ad Clicked: " + adUnitId);
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        adCompleted = showCompletionState == UnityAdsShowCompletionState.COMPLETED;
        Debug.Log("Ad Completed: " + adUnitId);
        adStarted = false;
        Advertisement.Load(AdId, this);

        ActivateReward();
    }







}
