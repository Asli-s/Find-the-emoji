using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


public class GoogleAdsScript : MonoBehaviour
{
    public static GoogleAdsScript Instance;


    #region Variables

    private string rewardedAdID;
    bool rewardedCompleted = false;
    bool callOnce = false;
    public GameObject RewardAlert;
    bool clickedtoWatch = false;
    private RewardedAd rewardedAd;
   
    #endregion



    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {

        string adUnitId;

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
                    rewardedAdID = "ca-app-pub-3940256099942544/1712485313";
        #else
                    rewardedAdID = "unexpected_platform";
        #endif

        if(GameManager.Instance.gameActive == false) // Only initialize in the beginning
        {
            MobileAds.Initialize(HandleInitCompleteAction);
            print("initialize");
        }


        // Create an empty ad request.
        if (this.rewardedAd != null)
        {
            this.rewardedAd.Destroy();
        }
        else
        {
            this.rewardedAd = new RewardedAd(adUnitId);



            // Called when an ad request has successfully loaded.
            this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            // Called when the ad is closed.
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

            AdRequest request = new AdRequest.Builder().Build();
            // Load the rewarded ad with the request.
            this.rewardedAd.LoadAd(request);






        }




    /*   if (this.rewardedAd.IsLoaded() == false)
       {

       }*/

    //  RequestRewardedVideo();


}







    public void SetAdsActive()
    {
        gameObject.SetActive(true);
    }


    public void SetAdsInactive()
    {
        gameObject.SetActive(false);
    }





    void OnDestroy()
    {
        print("destroy");
        this.rewardedAd.Destroy(); //Destroy
      
    }

    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        Debug.Log("Initialization complete.");

    }



    public void UserChoseToWatchAd() // Button-Click to show ad
    {
        
        if (this.rewardedAd.IsLoaded() && clickedtoWatch ==false)
        {
            clickedtoWatch = true;
            print("show ad");
            callOnce = false;
            rewardedCompleted = false;
            this.rewardedAd.Show();
        }
    }

    private void Update()
    {
        if(rewardedCompleted == true && callOnce ==false)
        {
            callOnce = true;

            GameManager.Instance.watchedAd = true;
            RewardAlert.SetActive(true);
            clickedtoWatch = false;


        }
    }

  
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {

        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
     //   this.rewardedAd.Destroy();

    }


    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        this.rewardedAd.Destroy(); // destroy previous ad

        string adUnitId;

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
                    rewardedAdID = "ca-app-pub-3940256099942544/1712485313";
#else
                    rewardedAdID = "unexpected_platform";
#endif


        this.CreateAndLoadRewardedAd(adUnitId);
    }



    public RewardedAd CreateAndLoadRewardedAd(string adUnitId)
    {

        if (this.rewardedAd != null)
        {
           this.rewardedAd.Destroy();
        }
        else
        {
            this.rewardedAd = new RewardedAd(adUnitId);

        }

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
        print("next ad loaded +" + this.rewardedAd.IsLoaded()); 

        //  RequestRewardedVideo();


        return rewardedAd;
    }






    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        rewardedCompleted = true;
        callOnce = false;

        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }
}
