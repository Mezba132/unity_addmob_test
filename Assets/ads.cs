using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ads : MonoBehaviour {

	private BannerView bannerview;
	private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;



    [SerializeField]
    private string appID = "ca-app-pub-6407342032788722~9801604724"; //"ca-app-pub-3940256099942544~3347511713";
    [SerializeField]
    private string bannerID = "ca-app-pub-3940256099942544/6300978111";
    [SerializeField]
    private string interstitialID = "ca-app-pub-6407342032788722/1787329436";
    [SerializeField]
    private string rewardvideoID = "ca-app-pub-6407342032788722/5750625172";

    

    // Use this for initialization
    void Start () 
	{
		MobileAds.Initialize (appID);	
		OnlickShowBanner ();
		RequestInterstitial ();
        //		showInterstitialAds ();	
		this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        RequestRewardBasedVideo();
    }
	public void OnlickShowBanner()
	{
		Debug.Log ("Swage");
		this.RequestBanner ();
		//this.bannerview.Destroy ();
	}
	public void showInterstitialAds()
	{
		Debug.Log (interstitial.ToString());
		//Show Ad
		if (this.interstitial.IsLoaded ()) {
			Debug.Log ("No Null Ref Excp");
			this.interstitial.Show ();
			//this.interstitial.Destroy ();
		}
	}
	public void ShowRewardVideo()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
			
            this.rewardBasedVideo.Show();
            Debug.Log("RewardVideo SHowing....");
        }
    }

    private void RequestBanner()
	{ 
		// Create a 320x50 banner at the top of the screen.
		bannerview = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerview.LoadAd(request);

	}
	private void RequestInterstitial()
	{

		// Initialize an InterstitialAd.
		this.interstitial = new InterstitialAd(interstitialID);
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		this.interstitial.LoadAd(request);


	}
    private void RequestRewardBasedVideo()
    {
		//this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, rewardvideoID);
    }
}
