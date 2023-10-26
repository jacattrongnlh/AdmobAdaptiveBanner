using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdmobTest : MonoBehaviour
{
    public const string _adUnitId = "ca-app-pub-3940256099942544/6300978111";

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            // LoadAd();
            DebugConsole.Log(initStatus.ToString());
        });
    }

    BannerView _bannerView;

    /// <summary>
    /// Creates a 320x50 banner view at top of the screen.
    /// </summary>
    public void CreateBannerView(AdSize adSize, AdPosition adPosition)
    {
        DebugConsole.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null) { DestroyBannerView(); }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(_adUnitId, adSize, adPosition);
        ListenToAdEvents();
    }

    /// <summary>
    /// Creates the banner view and loads a banner ad.
    /// </summary>
    public void LoadDefaultBannerAd()
    {
        // create an instance of a banner view first.
        // if (_bannerView == null) 
        {
            CreateBannerView(AdSize.Banner, AdPosition.Top);
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void LoadAdaptiveBannerAd()
    {
        // create an instance of a banner view first.
        var adSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        // if (_bannerView == null) 
        {
            CreateBannerView(adSize, AdPosition.Top);
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    /// <summary>
    /// Destroys the banner view.
    /// </summary>
    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
            DebugConsole.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    /// <summary>
    /// listen to events the banner view may raise.
    /// </summary>
    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        _bannerView.OnBannerAdLoaded += () =>
        {
            DebugConsole.Log("Banner view loaded an ad with response : "
                             + _bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            DebugConsole.Log("Banner view failed to load an ad with error : "
                             + error);
        };
        // Raised when the ad is estimated to have earned money.
        _bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        _bannerView.OnAdImpressionRecorded += () => { Debug.Log("Banner view recorded an impression."); };
        // Raised when a click is recorded for an ad.
        _bannerView.OnAdClicked += () => { Debug.Log("Banner view was clicked."); };
        // Raised when an ad opened full screen content.
        _bannerView.OnAdFullScreenContentOpened += () => { Debug.Log("Banner view full screen content opened."); };
        // Raised when the ad closed full screen content.
        _bannerView.OnAdFullScreenContentClosed += () => { Debug.Log("Banner view full screen content closed."); };
    }
}