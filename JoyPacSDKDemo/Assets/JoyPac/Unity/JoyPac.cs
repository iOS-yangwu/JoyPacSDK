using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using com.adjust.sdk;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;
using GameAnalyticsSDK.Wrapper;

public class JoyPac : MonoBehaviour
{



    public void InitSDK(string JoyPacAppID)
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        
        if (!string.IsNullOrEmpty(JoyPacAppID))
        {
            _iosClient.InitSDK(JoyPacAppID);
        }
#endif
    }


    public void InitSDK(string adjustToken, string GAKey, string GASecret)
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        
        if (!string.IsNullOrEmpty(GAKey) && !string.IsNullOrEmpty(GASecret))
        {
            InitGA(GAKey, GASecret);
        }
        if (!string.IsNullOrEmpty(adjustToken))
        {

            InitAdjust(adjustToken);
        }
#endif
    }

    public void InitSDK(string JoyPacAppID,string adjustToken,string GAKey,string GASecret)
    {

#if (UNITY_IOS && !UNITY_EDITOR)
        if (!string.IsNullOrEmpty(GAKey) && !string.IsNullOrEmpty(GASecret))
        {
            InitGA(GAKey, GASecret);
        }
        if (!string.IsNullOrEmpty(adjustToken))
        {

            InitAdjust(adjustToken);
        }
        if (!string.IsNullOrEmpty(JoyPacAppID))
        {
            _iosClient.InitSDK(JoyPacAppID);
        }
#endif
    }


    // ================================= ads ==========================
    #region nativeBanner
    public void LoadNativeBanner(string unitId) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.LoadNativeBanner(unitId);
#endif
    }

    public bool IsReadyNativeBanner(string unitId) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        return _iosClient.IsReadyNativeBanner(unitId);
#endif
        return false;
    }

    public void ShowNativeBanner(string unitId, JoyPacAdManager.JoyPacBannerAlign align) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.SetNativeBannerAlign(align);
        _iosClient.ShowNativeBanner(unitId);
#endif
    }

    public void HideNativeBanner() 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.HideNativeBanner();
#endif
    }

    public void RemoveNativeBanner() 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.RemoveNativeBanner();
#endif
    }
    #endregion


    #region banner
    public void LoadBanner(string unitId)
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.LoadBanner(unitId);
#endif
    }

    public bool IsReadyBanner(string unitId)
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        return _iosClient.IsReadyBanner(unitId);
#endif
        return false;
    }

    public void ShowBanner(string unitId, JoyPacAdManager.JoyPacBannerAlign align)
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.SetBannerAlign(align);
        _iosClient.ShowBanner(unitId);
#endif
    }

    public void HideBanner()
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.HideBanner();
#endif
    }

    public void RemoveBanner()
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.RemoveBanner();
#endif
    }
    #endregion


    #region interstitial
    public void LoadInterstitial(string unitId) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
       _iosClient.LoadInterstitial(unitId);
#endif
    }

    public bool IsReadyInterstitial(string unitId) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        return _iosClient.IsReadyInterstitial(unitId);
#endif
        return false;
    }

    public void ShowInterstitial(string unitId) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.ShowInterstitial(unitId);
#endif
    }
    #endregion


    #region native
    public void LoadNative(string unitId, float width, float height)
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.LoadNative(unitId,width,height);
#endif
    }

    public bool IsReadyNative(string unitId) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        return _iosClient.IsReadNative(unitId);
#endif
        return false;
    }

    public void ShowNative(string unitId,float x,float y,float width,float height) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.LayoutNativeWithFrame(x, y, width, height);
        _iosClient.ShowNative(unitId);
#endif
    }

    public void RemoveNative() 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.RemoveNative();
#endif
    }
    #endregion


    #region rewardVideo
    public void LoadRewardVideo(string unitId) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.LoadVideo(unitId);
#endif
    }

    public bool IsReadyRewardVideo(string unitId) 
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        return _iosClient.IsReadyVideo(unitId);
#endif
        return false;
    }

    public void ShowRewardVideo(string unitId)
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.ShowVideo(unitId);
#endif
    }
    #endregion
    // ================================= ads ==========================



    // ======================== track event ==========================

    public void JoyPacEvent(string event_sort, string event_type, string event_position, string event_extra)
    {
#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.EventLog(event_sort, event_type, event_position, event_extra);
#endif
    }

    public void Adjust_TrackEvent(string AdjustEventName)
    {
        if (!string.IsNullOrEmpty(AdjustEventName))
        {
            AdjustEvent adjustEvent = new AdjustEvent(AdjustEventName);
            Adjust.trackEvent(adjustEvent);
        }
    }

    public void GA_TrackEvent(string GAEventName, float eventValue)
    {
        if (!string.IsNullOrEmpty(GAEventName))
        {
            GameAnalytics.NewDesignEvent(GAEventName, eventValue);
        }

    }

    public void TrackEvent(string AdjustEventName, string GAEventName, float GAEventValue)
    {
        if (!string.IsNullOrEmpty(AdjustEventName))
        {
            AdjustEvent adjustEvent = new AdjustEvent(AdjustEventName);
            Adjust.trackEvent(adjustEvent);
        }

        if (!string.IsNullOrEmpty(GAEventName))
        {
            GameAnalytics.NewDesignEvent(GAEventName, GAEventValue);
        }

    }

    // ======================== track event ==========================


    public void SetLogEnable(bool enable) 
    {

#if (UNITY_IOS && !UNITY_EDITOR)
        _iosClient.SetLogEnable(enable);
        GA_Wrapper.SetVerboseLog(true);
        GA_Wrapper.SetInfoLog(true);
        
#endif
    }


    #region adjust
    private void InitAdjust(string token)
    {
        if (UnityEngine.Object.FindObjectOfType(typeof(Adjust)) == null)
        {
            GameObject ga = new GameObject();
            ga.name = "Adjust";
            //ga.transform.parent = transform;
            ga.AddComponent<Adjust>();
        }
        else
        {
            Debug.LogWarning("A GameAnalytics object already exists in this scene - you should never have more than one per scene!");
        }

        AdjustConfig config = new AdjustConfig(token, AdjustEnvironment.Production, true);
        config.setLogLevel(AdjustLogLevel.Suppress);
        config.setLogDelegate(msg => Debug.Log(msg));
        Adjust.start(config);


    }
    #endregion


    #region GA
    private void InitGA(string key, string secret)
    {
      if (UnityEngine.Object.FindObjectOfType (typeof (GameAnalytics)) == null) {
       GameObject ga = new GameObject ();
       ga.name = "GameAnalytics";
       ga.AddComponent<GA_SpecialEvents> ();
       ga.AddComponent<GameAnalytics> ();
      } else {
       Debug.LogWarning ("A GameAnalytics object already exists in this scene - you should never have more than one per scene!");
      }

      GameAnalytics.Initialize ();
      GA_Wrapper.SetBuild(Application.version);
      GA_Wrapper.Initialize(key, secret);
    }
    #endregion

    private static JoyPac s_instance = new JoyPac();
    private JoyPacAdManager _iosClient;

    private JoyPac()
    {

        _iosClient = JoyPacAdManager.Instance;
    }

    public static JoyPac Instance()
    {
        return s_instance;
    }
}
