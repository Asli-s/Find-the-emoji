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

    private RewardedAd rewardedAd;
    private string rewardedAdID;
    bool rewardedCompleted = false;
    bool callOnce = false;

    string adUnitId;
    public GameObject RewardAlert;





    #endregion



    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        // rewardedAdID = "ca-app-pub-3940256099942544/5224354917";
        //ios : "ca-app-pub-3940256099942544/1712485313";
       // string adUnitId;

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            rewardedAdID = "ca-app-pub-3940256099942544/1712485313";
#else
            rewardedAdID = "unexpected_platform";
#endif




        if(GameManager.Instance.gameActive == false)
        {

            MobileAds.Initialize(HandleInitCompleteAction);
            print("initialize");
        }

        this.rewardedAd = new RewardedAd(adUnitId);
        
     
        // Create an empty ad request.

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


        //  RequestRewardedVideo();


    }

    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        Debug.Log("Initialization complete.");

    }



    public void UserChoseToWatchAd()
    {
            print(""+this.rewardedAd.IsLoaded());
        if (this.rewardedAd.IsLoaded())
        {
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

        //    Featured.Instance?.AddCoin();
       


        }
    }

    /* private void RequestRewardedVideo()
     {
         rewardedAd = new RewardedAd(rewardedAdID);
         rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
         rewardedAd.OnAdClosed += HandleRewardedAdClosed;
         rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
         AdRequest request = new AdRequest.Builder().Build();
         rewardedAd.LoadAd(request);

     }
     public void ShowRewardedVideo()
     {
         if (rewardedAd.IsLoaded())        {
             rewardedAd.Show();
         }
     }

     public void HandleRewardedAdLoaded(object sender, EventArgs args)
     {
         MonoBehaviour.print("HandleRewardedAdLoaded event received");
         RequestRewardedVideo();

     }

     public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
     {
         MonoBehaviour.print(
             "HandleRewardedAdFailedToLoad event received with message: "
                              );
         RequestRewardedVideo();

     }

     public void HandleRewardedAdOpening(object sender, EventArgs args)
     {
         MonoBehaviour.print("HandleRewardedAdOpening event received");


     }

     public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
     {
         MonoBehaviour.print(
             "HandleRewardedAdFailedToShow event received with message: "
                              + args);
         RequestRewardedVideo();

     }

     public void HandleRewardedAdClosed(object sender, EventArgs args)
     {
         MonoBehaviour.print("HandleRewardedAdClosed event received");


     }

     public void HandleUserEarnedReward(object sender, Reward args)
     {
         string type = args.Type;
         double amount = args.Amount;
         MonoBehaviour.print(
             "HandleRewardedAdRewarded event received for "
                         + amount.ToString() + " " + type);

         rewardedCompleted = true;

     }
 */
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
    }





    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
 
        this.CreateAndLoadRewardedAd(adUnitId);
    }





    public RewardedAd CreateAndLoadRewardedAd(string adUnitId)
    {
        /* RewardedAd rewardedAd = new RewardedAd(adUnitId);



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


         // Create an empty ad request.
         AdRequest request = new AdRequest.Builder().Build();
         // Load the rewarded ad with the request.
         rewardedAd.LoadAd(request);
         print("next ad loaded +" + this.rewardedAd.IsLoaded());*/

        this.rewardedAd = new RewardedAd(adUnitId);


        // Create an empty ad request.

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
