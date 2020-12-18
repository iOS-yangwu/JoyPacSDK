using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyPacDemoScript : MonoBehaviour
{
    public Texture ButtonTexture;
    public Texture TextTexture;
    private const string JoyPacSDkDemo = "JoyPacSDkDemo Log:        ";

    private const string JoyPacAppID = "b403ab2ef3";
    private const string AdjustToken = "pp2zrnqzf8xs";
    private const string GAKey = "83363fe6455d0c5ec00cb9920621a9b0";
    private const string GASecret = "26a4395188ecfbfe57c573e6de05ba8171c17395";
    private const string BannerUnitId = "DemoBN1";
    private const string NativeBannerUnitId = "DemoBN";
    private const string InterstitialUnitId = "DemoIV";
    private const string RewardUnitId = "DemoRV";



    private bool BannerCanShow = false;
    private bool NativeBannerCanShow = false;
    private bool InterstitialCanShow = false;
    private bool RewardCanShow = false;

    private bool isReadyBanner = false;
    private bool isReadyNativeBanner = false;

    private string ABTestString= "未获取到在线参数";
    Image image;
    public void Start()
    {
        //打印日志
        JoyPac.Instance().SetLogEnable(true);


        //only init JoyPacSDK  
        //JoyPac.Instance().InitSDK(JoyPacAppID);

        //init  init Adjust和GA 不使用广告和abtest功能
        //JoyPac.Instance().InitSDK(AdjustToken, GAKey, GASecret);

        //SDK init JoyPacSDK Adjust和GA 
        JoyPac.Instance().InitSDK(JoyPacAppID, AdjustToken, GAKey, GASecret);


    }
   

    void onGetOnlineParameter(string abTestString )
    {
        Debug.Log(JoyPacSDkDemo + "ABTest获取到在线参数" + abTestString);
        ABTestString = "ABTest获取到在线参数为    : " +  abTestString;
    }
    private void OnEnable()
    {
        //Add Banner Listener
        JoyPacUniversalFunc.onSetBannerListener_onAdLoaded += BannerListener_onAdLoaded;
        JoyPacUniversalFunc.onSetBannerListener_onAdFailedToLoad += BannerListener_onAdFailedToLoad;
        JoyPacUniversalFunc.onSetBannerListener_onShowSuccess += BannerListener_onShowSuccess;
        JoyPacUniversalFunc.onSetBannerListener_onClick += BannerListener_onClick;
        JoyPacUniversalFunc.onSetBannerListener_onAdClosed += BannerListener_onAdClosed;

        //Add Native Banner Listener
        JoyPacUniversalFunc.onSetNativeBannerListener_onAdLoaded += NativeBannerListener_onAdLoaded;
        JoyPacUniversalFunc.onSetNativeBannerListener_onAdFailedToLoad= NativeBannerListener_onAdFailedToLoad;
        JoyPacUniversalFunc.onSetNativeBannerListener_onShowSuccess += NativeBannerListener_onShowSuccess;
        JoyPacUniversalFunc.onSetNativeBannerListener_onClick += NativeBannerListener_onClick;


        //Add Interstitial Listener
        JoyPacUniversalFunc.onSetInterstitialListener_onAdLoaded += InterstitialListener_onAdLoaded;
        JoyPacUniversalFunc.onSetInterstitialListener_onAdFailedToLoad += InterstitialListener_onAdFailedToLoad;
        JoyPacUniversalFunc.onSetInterstitialListener_onShowSuccess += InterstitialListener_onShowSuccess;
        JoyPacUniversalFunc.onSetInterstitialListener_onShowFailed += InterstitialListener_onShowFailed;
        JoyPacUniversalFunc.onSetInterstitialListener_onAdClosed += InterstitialListener_onAdClosed;
        JoyPacUniversalFunc.onSetInterstitialListener_onClick += InterstitialListener_onClick;
        JoyPacUniversalFunc.onSetInterstitialListener_onFailedToPlay += InterstitialListener_onFailedToPlay;
        JoyPacUniversalFunc.onSetInterstitialListener_onStartPlayVideo += InterstitialListener_onStartPlayVideo;
        JoyPacUniversalFunc.onSetInterstitialListener_onEndPlaying += InterstitialListener_onEndPlaying;


        //Add Reward Listener
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdLoaded += RewardListener_onRewardedVideoAdLoaded;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdFailedToLoad += RewardListener_onRewardedVideoAdFailedToLoad;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoStarted += RewardListener_onRewardedVideoStarted;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdClosed += RewardListener_onRewardedVideoAdClosed;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoClickAd += RewardListener_onRewardedVideoClickAd;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdEnd += RewardListener_onRewardedVideoAdEnd;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdPlayFail += RewardListener_onRewardedVideoAdPlayFail;
        JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoDidRewardedSuccess += RewardListener_onRewardedVideoDidRewardedSuccess;


        //ABTest 
        JoyPacUniversalFunc.onGetOnlineParameter += onGetOnlineParameter;


    }



    public void OnGUI()
    {

        GUI.skin.button.fontSize = (int)(0.030f * Screen.width);

        GUIStyle CanShowStyle = new GUIStyle();
        CanShowStyle.alignment = TextAnchor.MiddleCenter;
        CanShowStyle.fontSize = (int)(0.030f * Screen.width);
        CanShowStyle.normal.textColor = Color.white;
        CanShowStyle.normal.background = (Texture2D)ButtonTexture;

        GUIStyle TextStyle = new GUIStyle();
        TextStyle.alignment = TextAnchor.MiddleCenter;
        TextStyle.fontSize = (int)(0.030f * Screen.width);
        TextStyle.normal.textColor = Color.blue;
        TextStyle.normal.background = (Texture2D)TextTexture;

        //Banner
        #region Banner
        Rect LoadBannerButton = new Rect(0.10f * Screen.width, 0.10f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(LoadBannerButton, "Load Banner"))
        {
            
            Debug.Log(JoyPacSDkDemo + "Load Banner");
            JoyPac.Instance().LoadBanner(BannerUnitId);
        }
        Rect ShowBannerButton = new Rect(0.55f * Screen.width, 0.10f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (BannerCanShow)
        {
            if (GUI.Button(ShowBannerButton, "show Banner", CanShowStyle))
            {
                if (JoyPac.Instance().IsReadyBanner(BannerUnitId))
                {
                    BannerCanShow = false;
                    //底部居中
                    JoyPac.Instance().ShowBanner(BannerUnitId, JoyPacAdManager.JoyPacBannerAlign.BannerAlignBottom | JoyPacAdManager.JoyPacBannerAlign.BannerAlignHorizontalCenter);
                }
                   
            }


        }else
        {
            GUI.Button(ShowBannerButton, "show Banner");
        }
        

        Rect RemoveBannerButton = new Rect(0.10f * Screen.width, 0.18f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(RemoveBannerButton, "Remove Banner"))
        {
            if (isReadyBanner)
                BannerCanShow = true;
            Debug.Log(JoyPacSDkDemo + "Remove Banner");
            JoyPac.Instance().RemoveBanner();
        }

        Rect HideBannerButton = new Rect(0.55f * Screen.width, 0.18f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(HideBannerButton, "Hide Banner"))
        {
            if (isReadyBanner)
                BannerCanShow = true;
            Debug.Log(JoyPacSDkDemo + "Hide Banner");
            JoyPac.Instance().HideBanner();
        }
        #endregion

        //NativeBanner
        #region NativeBanner
        Rect LoadNativeBannerButton = new Rect(0.10f * Screen.width, 0.28f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(LoadNativeBannerButton, "Load NativeBanner"))
        {
            Debug.Log(JoyPacSDkDemo + "Load NativeBanner");
            JoyPac.Instance().LoadNativeBanner(NativeBannerUnitId);
        }

        Rect ShowNativeBannerButton = new Rect(0.55f * Screen.width, 0.28f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (NativeBannerCanShow)
        {
            if (GUI.Button(ShowNativeBannerButton, "show NativeBanner",CanShowStyle))
            {
               
                Debug.Log(JoyPacSDkDemo + "show NativeBanner");
                if (JoyPac.Instance().IsReadyNativeBanner(NativeBannerUnitId))
                {
                    NativeBannerCanShow = false;
                    //底部居中
                    JoyPac.Instance().ShowNativeBanner(NativeBannerUnitId, JoyPacAdManager.JoyPacBannerAlign.BannerAlignBottom | JoyPacAdManager.JoyPacBannerAlign.BannerAlignHorizontalCenter);
                }
                  
            }
        }else
        {
            GUI.Button(ShowNativeBannerButton, "show NativeBanner");
        }
       

        Rect RemoveNativeBannerButton = new Rect(0.10f * Screen.width, 0.36f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(RemoveNativeBannerButton, "Remove NativeBanner"))
        {
            if (isReadyNativeBanner)
                NativeBannerCanShow = true;
            Debug.Log(JoyPacSDkDemo + "Remove NativeBanner");
            JoyPac.Instance().RemoveNativeBanner();
        }

        Rect HideNativeBannerButton = new Rect(0.55f * Screen.width, 0.36f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(HideNativeBannerButton, "Hide NativeBanner"))
        {
            if (isReadyNativeBanner)
                NativeBannerCanShow = true;
            Debug.Log(JoyPacSDkDemo + "Hide NativeBanner");
            JoyPac.Instance().HideNativeBanner();
        }
        #endregion


        //Interstitial
        #region Interstitial
        Rect loadInterstitialButton = new Rect(0.10f * Screen.width, 0.46f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(loadInterstitialButton, "Load Interstitial"))
        {
            Debug.Log(JoyPacSDkDemo + "Load Interstitial");
            JoyPac.Instance().LoadInterstitial(InterstitialUnitId);
        }
        Rect showInterstitialButton = new Rect(0.55f * Screen.width, 0.46f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (InterstitialCanShow)
        {
            if (GUI.Button(showInterstitialButton, "Show Interstitial",CanShowStyle))
            {
                Debug.Log(JoyPacSDkDemo + "Show Interstitial");
                if (JoyPac.Instance().IsReadyInterstitial(InterstitialUnitId))
                    JoyPac.Instance().ShowInterstitial(InterstitialUnitId);
            }
        }
        else
        {
            GUI.Button(showInterstitialButton, "Show Interstitial");
        }


        #endregion



        //RewardVideo
        #region RewardVideo
        Rect LoadRewardVideoButton = new Rect(0.10f * Screen.width, 0.56f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(LoadRewardVideoButton, "Load RewardVideo"))
        {
            Debug.Log(JoyPacSDkDemo + "Load RewardVideo");
            JoyPac.Instance().LoadRewardVideo(RewardUnitId);
        }
        Rect ShowRewardVideoButton = new Rect(0.55f * Screen.width, 0.56f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (RewardCanShow)
        {
            if (GUI.Button(ShowRewardVideoButton, "Show RewardVideo", CanShowStyle))
            {
                Debug.Log(JoyPacSDkDemo + "Show RewardVideo");
                if (JoyPac.Instance().IsReadyRewardVideo(RewardUnitId))
                    JoyPac.Instance().ShowRewardVideo(RewardUnitId);
            }
        }
        else
        {
            GUI.Button(ShowRewardVideoButton, "Show RewardVideo");
        }

        #endregion


       

        ///ABTest
        Rect GUITest = new Rect(0.10f * Screen.width, 0.66f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);
       
        GUI.Label(GUITest,ABTestString, TextStyle);
       

       

        ///TrackEvent
        Rect GA_TrackEventButton = new Rect(0.10f * Screen.width, 0.74f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);

        if (GUI.Button(GA_TrackEventButton, "Only TrackEvent GA"))
        {
            Debug.Log(JoyPacSDkDemo + "Only TrackEvent GA");
            JoyPac.Instance().GA_TrackEvent("GA_TrackEventTest",1);

        }

        Rect Adjust_TrackEventButton = new Rect(0.10f * Screen.width, 0.82f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);

        if (GUI.Button(Adjust_TrackEventButton, "Only TrackEvent  Adjust"))
        {
            Debug.Log(JoyPacSDkDemo + "Only TrackEvent  Adjust");
            JoyPac.Instance().Adjust_TrackEvent("Adjust_TrackEventTest");

        }
        Rect TrackEventButton = new Rect(0.10f * Screen.width, 0.90f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);

        if (GUI.Button(TrackEventButton, "TrackEvent GA and Adjust"))
        {
            Debug.Log(JoyPacSDkDemo + "TrackEvent GA and Adjust");
            JoyPac.Instance().TrackEvent("Adjust_TrackEventTest", "GA_TrackEventTest",1);

        }

    }
   
    #region RewardListener
    private void RewardListener_onRewardedVideoDidRewardedSuccess()
    {
        Debug.Log(JoyPacSDkDemo + "RewardListener_onRewardedVideoDidRewardedSuccess");
    }

    private void RewardListener_onRewardedVideoAdPlayFail()
    {
        Debug.Log(JoyPacSDkDemo + "RewardListener_onRewardedVideoAdPlayFail");
    }

    private void RewardListener_onRewardedVideoAdEnd()
    {
        Debug.Log(JoyPacSDkDemo + "RewardListener_onRewardedVideoAdEnd");
    }

    private void RewardListener_onRewardedVideoClickAd()
    {
        Debug.Log(JoyPacSDkDemo + "RewardListener_onRewardedVideoClickAd");
    }

    private void RewardListener_onRewardedVideoAdClosed()
    {
        Debug.Log(JoyPacSDkDemo + "RewardListener_onRewardedVideoAdClosed");
    }

    private void RewardListener_onRewardedVideoStarted()
    {
        RewardCanShow = false;
        Debug.Log(JoyPacSDkDemo + "RewardListener_onRewardedVideoStarted");
    }

    private void RewardListener_onRewardedVideoAdFailedToLoad()
    {
        Debug.Log(JoyPacSDkDemo + "RewardListener_onRewardedVideoAdFailedToLoad");
    }

    private void RewardListener_onRewardedVideoAdLoaded()
    {
        RewardCanShow = true;
      
        Debug.Log(JoyPacSDkDemo + "RewardListener_onRewardedVideoAdLoaded");
    }
    #endregion


    #region InterstitialListener
    private void InterstitialListener_onEndPlaying()
    {
        Debug.Log(JoyPacSDkDemo + "InterstitialListener_onEndPlaying");
    }

    private void InterstitialListener_onStartPlayVideo()
    {
        
        Debug.Log(JoyPacSDkDemo + "InterstitialListener_onStartPlayVideo");
    }

    private void InterstitialListener_onFailedToPlay()
    {
        Debug.Log(JoyPacSDkDemo + "InterstitialListener_onFailedToPlay");
    }

    private void InterstitialListener_onClick()
    {
        Debug.Log(JoyPacSDkDemo + "InterstitialListener_onClick");
    }

    private void InterstitialListener_onAdClosed()
    {
        Debug.Log(JoyPacSDkDemo + "InterstitialListener_onAdClosed");
    }

    private void InterstitialListener_onShowFailed()
    {
        Debug.Log(JoyPacSDkDemo + "InterstitialListener_onShowFailed");
    }

    private void InterstitialListener_onShowSuccess()
    {
        InterstitialCanShow = false;
        Debug.Log(JoyPacSDkDemo + "InterstitialListener_onShowSuccess");
    }

    private void InterstitialListener_onAdFailedToLoad()
    {
        Debug.Log(JoyPacSDkDemo + "InterstitialListener_onAdFailedToLoad");
    }

    private void InterstitialListener_onAdLoaded()
    {
        InterstitialCanShow = true;
        Debug.Log(JoyPacSDkDemo + "InterstitialListener_onAdLoaded");
    }

    #endregion


    #region NativeBanner
    private void NativeBannerListener_onClick()
    {
        Debug.Log(JoyPacSDkDemo + "NativeBannerListener_onClick");
    }

    private void NativeBannerListener_onShowSuccess()
    {
        NativeBannerCanShow = false;
        Debug.Log(JoyPacSDkDemo + "NativeBannerListener_onShowSuccess");
    }

    private void NativeBannerListener_onAdFailedToLoad()
    {
        Debug.Log(JoyPacSDkDemo + "NativeBannerListener_onAdFailedToLoad");
    }

    private void NativeBannerListener_onAdLoaded()
    {
        NativeBannerCanShow = true;
        isReadyNativeBanner = true;
        Debug.Log(JoyPacSDkDemo + "NativeBannerListener_onAdLoaded");
    }
    #endregion



    #region BannerListener
    private void BannerListener_onAdClosed()
    {
      
        Debug.Log(JoyPacSDkDemo + "BannerListener_onAdClosed");


    }

    private void BannerListener_onClick()
    {
        Debug.Log(JoyPacSDkDemo + "BannerListener_onClick");
    }

    private void BannerListener_onShowSuccess()
    {
        BannerCanShow = false;
        Debug.Log(JoyPacSDkDemo + "BannerListener_onShowSuccess");
    }

    private void BannerListener_onAdFailedToLoad()
    {
        Debug.Log(JoyPacSDkDemo + "BannerListener_onAdFailedToLoad");
    }

    private void BannerListener_onAdLoaded()
    {
        BannerCanShow = true;
        isReadyBanner = true;
        Debug.Log(JoyPacSDkDemo + "BannerListener_onAdLoaded");
    }
    #endregion
}
