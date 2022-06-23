using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class GoogleAdsScript : MonoBehaviour
{

    #region Variables

    private RewardedAd rewardedAd;
    private string rewardedAdID;
    bool rewardedCompleted = false;
    bool callOnce = false;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        // rewardedAdID = "ca-app-pub-3940256099942544/5224354917";
        //ios : "ca-app-pub-3940256099942544/1712485313";

       
#if UNITY_ANDROID
        rewardedAdID = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            rewardedAdID = "ca-app-pub-3940256099942544/1712485313";
#else
            rewardedAdID = "unexpected_platform";
#endif



        MobileAds.Initialize(initStatus => { });
        RequestRewardedVideo();


    }


    private void Update()
    {
        if(rewardedCompleted == true && callOnce ==false)
        {
            callOnce = true;

            GameManager.Instance.watchedAd = true;

            Featured.Instance?.AddCoin();

        }
    }

    private void RequestRewardedVideo()
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

}
