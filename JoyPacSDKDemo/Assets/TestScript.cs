using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;


public class TestScript : MonoBehaviour {

    // Use this for initialization
    public float originX;
    public float originY;
    public float originWidth;
    public float originHeight;
    //public RectTransform squre;


    void Start () {

        
    }

    // Update is called once per frame
    void Update () {
		
	}

        public void InitBtnClick(){
        
        JoyPac.Instance().SetLogEnable(true);
        //JoyPac.Instance().InitSDK("004ac97c41", "qetw4jo08ikg", "5b7b3eb6d9092d71619615d24b497ab1", "7d20ef439c7209168afc0d8f5df95d486ccacbf6");
        JoyPac.Instance().InitSDK("4599d861fe");
        //banner
        JoyPacUniversalFunc.onSetBannerListener_onAdLoaded += onSetBannerListener_onAdLoaded;
        JoyPacUniversalFunc.onSetBannerListener_onAdFailedToLoad += onSetBannerListener_onAdFailedToLoad;
        JoyPacUniversalFunc.onSetBannerListener_onAdClosed += onSetBannerListener_onAdClosed;
        JoyPacUniversalFunc.onSetBannerListener_onClick += onSetBannerListener_onClick;
        JoyPacUniversalFunc.onSetBannerListener_onShowSuccess += onSetBannerListener_onShowSuccess;

        //interstitial
        JoyPacUniversalFunc.onSetInterstitialListener_onAdLoaded += onSetInterstitialListener_onAdLoaded;
        JoyPacUniversalFunc.onSetInterstitialListener_onAdFailedToLoad += onSetInterstitialListener_onAdFailedToLoad;
        JoyPacUniversalFunc.onSetInterstitialListener_onAdClosed += onSetInterstitialListener_onAdClosed;
        JoyPacUniversalFunc.onSetInterstitialListener_onClick += onSetInterstitialListener_onClick;
        JoyPacUniversalFunc.onSetInterstitialListener_onShowFailed += onSetInterstitialListener_onShowFailed;
        JoyPacUniversalFunc.onSetInterstitialListener_onShowSuccess += onSetInterstitialListener_onShowSuccess;
        JoyPacUniversalFunc.onSetInterstitialListener_onStartPlayVideo += onSetInterstitialListener_onStartPlayVideo;
        JoyPacUniversalFunc.onSetInterstitialListener_onEndPlaying += onSetInterstitialListener_onEndPlaying;

        //native
        JoyPacUniversalFunc.onSetNativeListener_onAdLoaded += onSetNativeListener_onAdLoaded;
        JoyPacUniversalFunc.onSetNativeListener_onAdFailedToLoad += onSetNativeListener_onAdFailedToLoad;
        JoyPacUniversalFunc.onSetNativeListener_onClick += onSetNativeListener_onClick;
        JoyPacUniversalFunc.onSetNativeListener_onShowSuccess += onSetNativeListener_onShowSuccess;

        //rewardVideo
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdLoaded += onSetRewardListener_onRewardedVideoAdLoaded;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdFailedToLoad += onSetRewardListener_onRewardedVideoAdFailedToLoad;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdClosed += onSetRewardListener_onRewardedVideoAdClosed;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoStarted += onSetRewardListener_onRewardedVideoStarted;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdEnd += onSetRewardListener_onRewardedVideoAdEnd;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoDidRewardedSuccess += onSetRewardListener_onRewardedVideoDidRewardedSuccess;

        //online para
        JoyPacUniversalFunc.onGetOnlineParameter += onGetOnlineParameter;

        //native banner
        JoyPacUniversalFunc.onSetNativeBannerListener_onAdLoaded += onSetNativeBannerListener_onAdLoaded;
        JoyPacUniversalFunc.onSetNativeBannerListener_onShowSuccess += onSetBNativeannerListener_onShowSuccess;
        JoyPacUniversalFunc.onSetNativeBannerListener_onClick += onSetNativeBannerListener_onClick;


    }

    public void onSetNativeBannerListener_onAdLoaded()
    {

        Debug.Log("onSetNativeBannerListener_onAdLoaded");
    }

    public void onSetBNativeannerListener_onShowSuccess()
    {

        Debug.Log("onSetBNativeannerListener_onShowSuccess");
    }

    public void onSetNativeBannerListener_onClick()
    {

        Debug.Log("onSetNativeBannerListener_onClick");
    }

    public void onSetInterstitialListener_onStartPlayVideo()
    {

        Debug.Log("onSetInterstitialListener_onStartPlayVideo");
    }

    public void onSetInterstitialListener_onEndPlaying()
    {

        Debug.Log("onSetInterstitialListener_onEndPlaying");
    }

    public void onGetOnlineParameter(string obj) {

        Debug.Log("onGetOnlineParameter" + obj);
    }

    public void onSetRewardListener_onRewardedVideoAdEnd()
    {

        Debug.Log("onSetRewardListener_onRewardedVideoAdEnd");
    }

    public void onSetRewardListener_onRewardedVideoAdPlayFail()
    {

        Debug.Log("onSetRewardListener_onRewardedVideoAdPlayFail");
    }

    public void onSetRewardListener_onRewardedVideoDidRewardedSuccess()
    {

        Debug.Log("onSetRewardListener_onRewardedVideoDidRewardedSuccess");
    }

    public void onSetRewardListener_onRewardedVideoStarted()
    {

        Debug.Log("onSetRewardListener_onRewardedVideoStarted");
    }

    //viewcontroller
    public void onSetViewController_onPresent()
    {

        Debug.Log("onSetViewController_onPresent");
    }

    public void onSetViewController_onDissmiss()
    {

        Debug.Log("onSetViewController_onDissmiss");
    }


    //native
    public void onSetNativeListener_onAdLoaded()
    {

        Debug.Log("onSetNativeListener_onAdLoaded" );
    }
    public void onSetNativeListener_onAdFailedToLoad()
    {

        Debug.Log("onSetNativeListener_onAdFailedToLoad" );
    }
    public void onSetNativeListener_onClick()
    {

        Debug.Log("onSetNativeListener_onClick" );
    }
    public void onSetNativeListener_onShowSuccess()
    {

        Debug.Log("onSetNativeListener_onShowSuccess" );
    }

    //interstitial
    public void onSetInterstitialListener_onAdLoaded()
    {

        Debug.Log("onSetInterstitialListener_onAdLoaded" );
    }
    public void onSetInterstitialListener_onAdFailedToLoad()
    {

        Debug.Log("onSetInterstitialListener_onAdFailedToLoad" );
    }
    public void onSetInterstitialListener_onAdClosed()
    {

        Debug.Log("onSetInterstitialListener_onAdClosed" );
    }
    public void onSetInterstitialListener_onClick()
    {

        Debug.Log("onSetInterstitialListener_onClick" );
    }
    public void onSetInterstitialListener_onShowFailed()
    {

        Debug.Log("onSetInterstitialListener_onShowFailed" );
    }
    public void onSetInterstitialListener_onShowSuccess()
    {

        Debug.Log("onSetInterstitialListener_onShowSuccess" );
    }

    //banner
    public void onSetBannerListener_onAdLoaded()
    {

        Debug.Log("onSetBannerListener_onAdLoaded" );
    }

    public void onSetBannerListener_onAdFailedToLoad()
    {

        Debug.Log("onSetBannerListener_onAdFailedToLoad" );
    }

    public void onSetBannerListener_onAdClosed()
    {

        Debug.Log("onSetBannerListener_onAdClosed" );
    }

    public void onSetBannerListener_onClick()
    {

        Debug.Log("onSetBannerListener_onClick" );
    }

    public void onSetBannerListener_onShowFailed()
    {

        Debug.Log("onSetBannerListener_onShowFailed" );
    }

    public void onSetBannerListener_onShowSuccess()
    {

        Debug.Log("onSetBannerListener_onShowSuccess" );
    }

   

    public void onSetRewardListener_onRewardedVideoClickAd() {

        Debug.Log("onSetRewardListener_onRewardedVideoClickAd");
    }

    public void onSetRewardListener_onRewardedVideoAdLoaded() {

        Debug.Log("onSetRewardListener_onRewardedVideoAdLoaded");
    }

    public void onSetRewardListener_onRewardedVideoAdFailedToLoad() {

        Debug.Log("onSetRewardListener_onRewardedVideoAdFailedToLoad" );
    }

    public void onSetRewardListener_onRewardedVideoAdClosed()
    {

        Debug.Log("onSetRewardListener_onRewardedVideoAdClosed" );
    }

    //banner
    public void trackingEvent(string adjustEventName,string GAEventName,float GAEventValue)
    {
        JoyPac.Instance().TrackEvent(adjustEventName,GAEventName,GAEventValue);
    }



	public void showBanner(){

        JoyPac.Instance().ShowBanner("", JoyPacAdManager.JoyPacBannerAlign.BannerAlignBottom | JoyPacAdManager.JoyPacBannerAlign.BannerAlignHorizontalCenter);
    }

	//iv
	public void loadIV(){


		Debug.Log ("调用load iv");
    }


    public void showIV()
    {

        JoyPac.Instance().TrackEvent("adjust eventName", "GAEventName", 0);

    }


	//rv
	public void loadRV()
    {
		
        JoyPac.Instance().LoadRewardVideo("WakuangRV1");
	}


    public void showRV()
    {
       if (JoyPac.Instance().IsReadyRewardVideo("WakuangRV1"))
        {
            JoyPac.Instance().ShowRewardVideo("WakuangRV1");
        }
    }


    public void removeNative() {

        JoyPac.Instance().RemoveBanner();
    }
}
