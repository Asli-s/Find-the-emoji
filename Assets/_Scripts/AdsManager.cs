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

    /*
    #if UNITY_IOS
        string GameId = "4829946";
         string   AdId = "Rewarded_iOS";
    #else
        string GameId = "4829947";
        string AdId = "Rewarded_Android";
    #endif*/

    bool testmode = true;
    public Action onRewardedAdSuccess;

    // Start is called before the first frame update
    void Awake()
    {


        print("awake");

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
       // Advertisement.AddListener(this);
        
    }

    void Start()
    {
    //    Advertisement.Load(AdId, this);
    }







    ////////////////////////////////////////
    
 /*   public void RewardedAdButton()
    {
       // PlayRewardedAd(ActivateReward);

        //call show function



    }*/

    void ActivateReward()
    {
        GoldReward.SetActive(true);
    }



    public void OnUnityAdsAdLoaded(string placementId)
    {
        //  throw new NotImplementedException();
        print(placementId + AdId);
        print("loaded");
        /*  if (placementId.Equals(AdId))
          {
              // showAdButton.onClick.AddListener(ShowAd);
              ShowAd();
          }

  */
        loadedSuccessfully = true;

        
    }


    public void ShowAd()
    {
        print("loadedsuccess" + loadedSuccessfully);
     /*   if(loadedSuccessfully)
        {
*/
        Advertisement.Show(AdId, this);
       // }
    }


    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        //throw new NotImplementedException();
        loadedSuccessfully = false;
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
     //   throw new NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        //  throw new NotImplementedException();


    
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //  throw new NotImplementedException();
        print("show clicked");
     
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {


        //reward
        //  onRewardedAdSuccess.Invoke();
        //   ActivateReward();

        print(placementId + AdId + showCompletionState+ UnityAdsShowCompletionState.COMPLETED);
        print("complete");
        if (placementId == (AdId) && showCompletionState.Equals( UnityAdsShowCompletionState.COMPLETED ))
        {
            print("really completed");

            ActivateReward();
        Advertisement.Load(AdId, this);
        }


        //  throw new NotImplementedException();
    }

    public void OnInitializationComplete()
    {
        //   throw new NotImplementedException();
        Advertisement.Load(AdId, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
       // throw new NotImplementedException();
    }
}
