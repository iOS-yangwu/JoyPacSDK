using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class JoyPacAdManager : MonoBehaviour {

    private static JoyPacAdManager s_instance;
    public static JoyPacAdManager Instance
    {
        get {
            if (s_instance == null) {
                GameObject JoyPac = new GameObject();
                JoyPac.name = "AdObject";
                s_instance = JoyPac.AddComponent<JoyPacAdManager>();
                DontDestroyOnLoad(JoyPac);
            }
            return s_instance;
        }
    }

    [Flags]
    public enum JoyPacBannerAlign : int
    {
        BannerAlignLeft = 1 << 0,
        BannerAlignHorizontalCenter = 1 << 1,
        BannerAlignRight = 1 << 2,
        BannerAlignTop = 1 << 3,
        BannerAlignVerticalCenter = 1 << 4,
        BannerAlignBottom = 1 << 5,
    }

#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void initSDK(string appID);
    [DllImport("__Internal")]
    private static extern void loadNativeBannerWithUnitId(string unitId);
    [DllImport("__Internal")]
    private static extern bool isReadyNativeBannerWithUnitId(string unitId);
    [DllImport("__Internal")]
    private static extern void showNativeBannerWithUnitId(string unitId);
    [DllImport("__Internal")]
    private static extern void setNativeBannerAlign(int align);
    [DllImport("__Internal")]
    private static extern void hideNativeBanner();
    [DllImport("__Internal")]
    private static extern void removeNativeBanner();
    [DllImport("__Internal")]
    private static extern void loadBannerWithUnitId(string unitId);
    [DllImport("__Internal")]
    private static extern bool isReadyBannerWithUnitId(string unitId);
    [DllImport("__Internal")]
    private static extern void showBannerWithUnitId(string unitId);
    [DllImport("__Internal")]
    private static extern void setBannerAlign(int align);
    [DllImport("__Internal")]
    private static extern void hideBanner();
    [DllImport("__Internal")]
    private static extern void removeBanner();
    [DllImport("__Internal")]
    private static extern void loadInterstitialWithUnitId(string UnitId);
    [DllImport("__Internal")]
    private static extern bool isReadyInterstitialWithUnitId(string UnitId);
    [DllImport("__Internal")]
    private static extern void showInterstitialWithUnitId(string UnitId);
    [DllImport("__Internal")]
    private static extern void loadNativeWithUnitId(string UnitId,float width, float height);
    [DllImport("__Internal")]
    private static extern bool isReadyNativeWithUnitId(string UnitId);
    [DllImport("__Internal")]
    private static extern void layoutNativeWithFrame(float x, float y, float width, float height);
    [DllImport("__Internal")]
    private static extern void showNativeWithUnitId(string UnitId);
    [DllImport("__Internal")]
    private static extern void removeNative();
    [DllImport("__Internal")]
    private static extern void loadRewardVideoWithUnitId(string UnitId);
    [DllImport("__Internal")]
    private static extern bool isReadyRewardVideoWithUnitId(string UnitId);
    [DllImport("__Internal")]
    private static extern void showRewardVideoWithUnitId(string UnitId);
    [DllImport("__Internal")]
    private static extern void eventLog(string eventSort, string eventType, string eventPosition, string eventExtra);
    [DllImport("__Internal")]
    private static extern void setLogEnable(bool enable);

    
    public void InitSDK(string appID)
    {
        initSDK (appID);
    }

    #region nativeBanner
    public void LoadNativeBanner(string unitId)
    {    
        loadNativeBannerWithUnitId (unitId);
    }

    public bool IsReadyNativeBanner(string unitId)
    {    
        return isReadyNativeBannerWithUnitId (unitId);
    }

    public void ShowNativeBanner(string unitId)
    {
        showNativeBannerWithUnitId(unitId);
    }

    public void SetNativeBannerAlign (JoyPacBannerAlign align)
    {
        setNativeBannerAlign ((int)align);
    }

    public void HideNativeBanner()
    {
        hideNativeBanner ();
    }

    public void RemoveNativeBanner()
    {
        removeNativeBanner ();
    }
    #endregion

    #region banner
    public void LoadBanner(string unitId)
    {
        loadBannerWithUnitId(unitId);
    }

    public bool IsReadyBanner(string unitId)
    {
        return isReadyBannerWithUnitId(unitId);
    }

    public void ShowBanner(string unitId)
    {
        showBannerWithUnitId(unitId);
    }

    public void SetBannerAlign(JoyPacBannerAlign align)
    {
        setBannerAlign((int)align);
    }

    public void HideBanner()
    {
        hideBanner();
    }

    public void RemoveBanner()
    {
        removeBanner();
    }

    #endregion

    #region Interstitial
    public void LoadInterstitial(string unitId)
    {
        loadInterstitialWithUnitId (unitId);
    }

    public bool IsReadyInterstitial(string unitId)
    {
        return isReadyInterstitialWithUnitId (unitId);
    }

    public void ShowInterstitial(string unitId)
    {    
        showInterstitialWithUnitId (unitId);
    }
    #endregion


    #region native
    public void LoadNative(string unitId, float width, float height)
    {
        loadNativeWithUnitId (unitId,width,height);
    }

    public bool IsReadNative(string unitId)
    {
        return isReadyNativeWithUnitId (unitId);
    }

    public void LayoutNativeWithFrame(float x,float y,float width,float height)
    {
        layoutNativeWithFrame (x, y, width, height);
    }

    public void ShowNative(string unitId)
    {
        showNativeWithUnitId (unitId);
    }
    
    public void RemoveNative()
    {
        removeNative();
    }
    #endregion

    #region rewardVideo
    public void LoadVideo(string unitId)
    {
        loadRewardVideoWithUnitId(unitId);
    }

    public bool IsReadyVideo(string unitId)
    {    
        return isReadyRewardVideoWithUnitId (unitId);
    }

    public void ShowVideo(string unitId)
    {
        showRewardVideoWithUnitId (unitId);
    }
    #endregion


    #region eventLog
    public void EventLog(string event_sort,string event_type,string event_position,string event_extra)
    {    
        eventLog(event_sort,event_type,event_position,event_extra);
    }

    public void SetLogEnable(bool enable) 
    {
        setLogEnable(enable);
    }
    #endregion


    #region onlinePara
    void onGetOnlineParameter(string json)
    {
        if (JoyPacUniversalFunc.onGetOnlineParameter != null)
            JoyPacUniversalFunc.onGetOnlineParameter(json);
    }
    #endregion


    #region InterstitialCallback
    public void JoyPacInterstitialAdLoad()
    {
        if (JoyPacUniversalFunc.onSetInterstitialListener_onAdLoaded != null)
        {
            JoyPacUniversalFunc.onSetInterstitialListener_onAdLoaded();
        }
    }

    public void JoyPacInterstitialAdLoadFail()
    {
        if (JoyPacUniversalFunc.onSetInterstitialListener_onAdFailedToLoad != null)
        {
            JoyPacUniversalFunc.onSetInterstitialListener_onAdFailedToLoad();
        }
    }

    public void JoyPacInterstitialAdShow()
    {
        if (JoyPacUniversalFunc.onSetInterstitialListener_onShowSuccess != null)
        {
            JoyPacUniversalFunc.onSetInterstitialListener_onShowSuccess();
        }
    }

    public void JoyPacInterstitialAdsShowFail()
    {
        if (JoyPacUniversalFunc.onSetInterstitialListener_onShowFailed != null)
        {
            JoyPacUniversalFunc.onSetInterstitialListener_onShowFailed();
        }
    }

    public void JoyPacInterstitialAdClose()
    {
        if (JoyPacUniversalFunc.onSetInterstitialListener_onAdClosed != null)
        {
            JoyPacUniversalFunc.onSetInterstitialListener_onAdClosed();
        }
    }

    public void JoyPacInterstitialAdClick()
    {
        if (JoyPacUniversalFunc.onSetInterstitialListener_onClick != null)
        {
            JoyPacUniversalFunc.onSetInterstitialListener_onClick();
        }
    }

    public void JoyPacInterstitialAdsEndPlaying()
    {
        if (JoyPacUniversalFunc.onSetInterstitialListener_onEndPlaying != null)
        {
            JoyPacUniversalFunc.onSetInterstitialListener_onEndPlaying();
        }
    }

    public void JoyPacInterstitialAdFailedToPlay()
    {
        if (JoyPacUniversalFunc.onSetInterstitialListener_onFailedToPlay != null)
        {
            JoyPacUniversalFunc.onSetInterstitialListener_onFailedToPlay();
        }
    }
       
    public void JoyPacInterstitialAdsStartPlayVideo()
    {
        if (JoyPacUniversalFunc.onSetInterstitialListener_onStartPlayVideo != null)
        {
            JoyPacUniversalFunc.onSetInterstitialListener_onStartPlayVideo();
        }
    }
    #endregion


    #region videoCallback
    public void JoyPacVideoAdLoaded()
    {
        if (JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdLoaded != null)
        {
            JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdLoaded();
        }
    }

    public void JoyPacVideoAdLoadFail()
    {
        if (JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdFailedToLoad != null)
        {
            JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdFailedToLoad();
        }
    }

    public void JoyPacVideoAdPlayStart()
    {
        if (JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoStarted != null)
        {
            JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoStarted();
        }
    }

    public void JoyPacVideoAdPlayEnd()
    {
        if (JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdEnd != null)
        {
            JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdEnd();
        }
    }

    public void JoyPacVideoAdPlayFail()
    {
        if (JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdPlayFail != null)
        {
            JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdPlayFail();
        }
    }

    public void JoyPacVideoAdPlayClosed()
    {
        if (JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdClosed != null)
        {
            JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdClosed();
        }
    }

    public void JoyPacVideoAdPlayClicked()
    {
        if (JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoClickAd != null)
        {
            JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoClickAd();
        }
    }

    public void JoyPacVideoAdDidRewardedSuccess(){
        if (JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoDidRewardedSuccess != null)
        {
            JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoDidRewardedSuccess();
        }
    }
    #endregion


    #region bannerCallback
    public void JoyPacBannerAdLoad()
    {
        if (JoyPacUniversalFunc.onSetBannerListener_onAdLoaded != null) {
            JoyPacUniversalFunc.onSetBannerListener_onAdLoaded();
        }
    }

    public void JoyPacBannerAdLoadFail()
    {
        if (JoyPacUniversalFunc.onSetBannerListener_onAdFailedToLoad != null)
        {
            JoyPacUniversalFunc.onSetBannerListener_onAdFailedToLoad();
        }
    }

    public void JoyPacBannerAdDidShow()
    {
        if (JoyPacUniversalFunc.onSetBannerListener_onShowSuccess != null)
        {
            JoyPacUniversalFunc.onSetBannerListener_onShowSuccess();
        }
    }

    public void JoyPacBannerAdDidClick()
    {
        if (JoyPacUniversalFunc.onSetBannerListener_onClick != null)
        {
            JoyPacUniversalFunc.onSetBannerListener_onClick();
        }
    }

    public void JoyPacBannerAdDidClickCloseButton()
    {
        if (JoyPacUniversalFunc.onSetBannerListener_onAdClosed != null)
        {
            JoyPacUniversalFunc.onSetBannerListener_onAdClosed();
        }
    }
    #endregion

    #region nativeBannerCallback
    public void JoyPacNativeBannerAdLoad()
    {
        if (JoyPacUniversalFunc.onSetNativeBannerListener_onAdLoaded != null)
        {
            JoyPacUniversalFunc.onSetNativeBannerListener_onAdLoaded();
        }
    }

    public void JoyPacNativeBannerAdLoadFail()
    {
        if (JoyPacUniversalFunc.onSetNativeBannerListener_onAdFailedToLoad != null)
        {
            JoyPacUniversalFunc.onSetNativeBannerListener_onAdFailedToLoad();
        }
    }

    public void JoyPacNativeBannerAdDidShow()
    {
        if (JoyPacUniversalFunc.onSetNativeBannerListener_onShowSuccess != null)
        {
            JoyPacUniversalFunc.onSetNativeBannerListener_onShowSuccess();
        }
    }

    public void JoyPacNativeBannerAdDidClick()
    {
        if (JoyPacUniversalFunc.onSetNativeBannerListener_onClick != null)
        {
            JoyPacUniversalFunc.onSetNativeBannerListener_onClick();
        }
    }
    #endregion

    #region nativeCallback
    public void JoyPacNativeAdLoadFail()
    {
        if (JoyPacUniversalFunc.onSetNativeListener_onAdFailedToLoad != null)
        {
            JoyPacUniversalFunc.onSetNativeListener_onAdFailedToLoad();
        }
    }

    public void JoyPacNativeAdLoaded()
    {
        if (JoyPacUniversalFunc.onSetNativeListener_onAdLoaded != null)
        {
            JoyPacUniversalFunc.onSetNativeListener_onAdLoaded();
        }
    }

    public void JoyPacNativeAdDidShow()
    {
        if (JoyPacUniversalFunc.onSetNativeListener_onShowSuccess != null)
        {
            JoyPacUniversalFunc.onSetNativeListener_onShowSuccess();
        }
    }

    public void JoyPacNativeAdDidClick()
    {
        if (JoyPacUniversalFunc.onSetNativeListener_onClick != null)
        {
            JoyPacUniversalFunc.onSetNativeListener_onClick();
        }
    }
    #endregion
  

#endif
}
