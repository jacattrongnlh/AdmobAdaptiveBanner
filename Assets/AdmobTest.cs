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
        });
    }

    BannerView _bannerView;

    /// <summary>
    /// Creates a 320x50 banner view at top of the screen.
    /// </summary>
    public void CreateBannerView(AdSize adSize, AdPosition adPosition)
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null) { DestroyBannerView(); }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(_adUnitId, adSize, adPosition);
    }

    /// <summary>
    /// Creates the banner view and loads a banner ad.
    /// </summary>
    public void LoadDefaultBannerAd()
    {
        // create an instance of a banner view first.
        if (_bannerView == null) { CreateBannerView(AdSize.Banner, AdPosition.Top); }

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
        if (_bannerView == null) { CreateBannerView(adSize, AdPosition.Top); }

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
            Debug.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }
}