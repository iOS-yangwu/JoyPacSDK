
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;


public class JoyPacUniversalFunc : MonoBehaviour {

    //banner
    public static Action onSetBannerListener_onAdLoaded;

    public static Action onSetBannerListener_onAdFailedToLoad;

    public static Action onSetBannerListener_onShowSuccess;

    public static Action onSetBannerListener_onClick;

    public static Action onSetBannerListener_onAdClosed;

    //nativeBanner
    public static Action onSetNativeBannerListener_onAdLoaded;

    public static Action onSetNativeBannerListener_onAdFailedToLoad;

    public static Action onSetNativeBannerListener_onShowSuccess;

    public static Action onSetNativeBannerListener_onClick;

    //interstitial
    public static Action onSetInterstitialListener_onAdLoaded;

    public static Action onSetInterstitialListener_onAdFailedToLoad;

    public static Action onSetInterstitialListener_onShowSuccess;

    public static Action onSetInterstitialListener_onShowFailed;

    public static Action onSetInterstitialListener_onAdClosed;

    public static Action onSetInterstitialListener_onClick;

    public static Action onSetInterstitialListener_onFailedToPlay;

    public static Action onSetInterstitialListener_onStartPlayVideo;

    public static Action onSetInterstitialListener_onEndPlaying;

    //Native
    public static Action onSetNativeListener_onAdLoaded;

    public static Action onSetNativeListener_onAdFailedToLoad;

    public static Action onSetNativeListener_onClick;

    public static Action onSetNativeListener_onShowSuccess;

    //reward
    public static Action onSetRewardListener_onRewardedVideoAdLoaded;

    public static Action onSetRewardListener_onRewardedVideoAdFailedToLoad;

    public static Action onSetRewardListener_onRewardedVideoStarted;

    public static Action onSetRewardListener_onRewardedVideoAdClosed;

    public static Action onSetRewardListener_onRewardedVideoClickAd;
    
    public static Action onSetRewardListener_onRewardedVideoAdEnd;

    public static Action onSetRewardListener_onRewardedVideoAdPlayFail;

    public static Action onSetRewardListener_onRewardedVideoDidRewardedSuccess;

    //onlineParameter
    public static Action<string> onGetOnlineParameter;
}
