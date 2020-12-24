using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


enum ADType
{
    Banner,
    NativeBanner,
    Interstitial,
    Reward
}
public class Advertising : MonoBehaviour
{

    private Texture ButtonTexture;
    private Sprite bg;
    private GameObject BackGround;

    private const string JoyPacAppID = "b403ab2ef3";


    public const string BannerUnitId = "DemoBN1";
    public const string NativeBannerUnitId = "DemoBN";
    public const string InterstitialUnitId = "DemoIV";
    public const string RewardUnitId = "DemoRV";



    public const string JoyPacSDkDemo = "JoyPacSDkDemo Log:        ";

    public bool BannerCanShow = false;
    public bool NativeBannerCanShow = false;
    public bool InterstitialCanShow = false;
    public bool RewardCanShow = false;

    public bool isReadyBanner = false;
    public bool isReadyNativeBanner = false;


   
    GUIStyle fontstyle = null;
    public int FontSize = 10;

    public Image image, image1, image2, image3;
    private void Awake()
    {
        
        bg = Resources.Load("Textrues/background", typeof(Sprite)) as Sprite;
        BackGround = GameObject.Find("BackGround");
        BackGround.AddComponent<Image>().sprite = bg;

        ButtonTexture = Resources.Load("Textrues/button", typeof(Texture)) as Texture;

        image.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0.34f * Screen.height, 0);
        image1.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0.16f * Screen.height, 0);
        image2.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0.026f * Screen.height, 0);
        image3.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, -(0.076f * Screen.height), 0);


        image.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, 0.18f * Screen.height);
        image1.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, 0.18f * Screen.height);
        image2.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, 0.070f * Screen.height);
        image3.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, 0.070f * Screen.height);


    }

    private string LoadFail(ADType type)
    {
        var str = string.Format("{0} Load failed / {0} 加载失败", type.ToString());
        return str;
    }
        
    private string Loading(ADType type)
    {
        var str = string.Format("{0} is loading / {0} 正在加载.........", type.ToString());
        return str;
    }
    private string Completed(ADType type)
    {
        var str = string.Format("{0} is loading completed / {0} 加载完成", type.ToString());
        return str;
    }
    public void Start()
    {
        //打印日志
        JoyPac.Instance().SetLogEnable(true);


        //only init JoyPacSDK  
        JoyPac.Instance().InitSDK(JoyPacAppID);

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
        JoyPacUniversalFunc.onSetNativeBannerListener_onAdFailedToLoad = NativeBannerListener_onAdFailedToLoad;
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



    }
    public void OnGUI()
    {

       
        GUI.skin.button.fontSize = (int)(0.030f * Screen.width);

        GUIStyle CanShowStyle = new GUIStyle();
        CanShowStyle.alignment = TextAnchor.MiddleCenter;
        CanShowStyle.fontSize = (int)(0.030f * Screen.width);
        CanShowStyle.normal.textColor = Color.white;
        CanShowStyle.normal.background = (Texture2D)ButtonTexture;


        fontstyle = new GUIStyle();

        fontstyle.fontSize = (int)(0.050f * Screen.width);

        fontstyle.normal.textColor = Color.red;
        Rect lable = new Rect(0.40f * Screen.width, 0.07f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        GUI.Label(lable,"banner", fontstyle);
        //Banner
        #region Banner
        Rect LoadBannerButton = new Rect(0.10f * Screen.width, 0.10f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(LoadBannerButton, "Load Banner"))
        {

            Debug.Log(JoyPacSDkDemo + "Load Banner");
            JoyPac.Instance().LoadBanner(BannerUnitId);
            OnGUIDebug.Instance.AddMsg(Loading(ADType.Banner));
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


        }
        else
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
        Rect NativeBanner = new Rect(0.40f * Screen.width, 0.25f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        GUI.Label(NativeBanner, "NativeBanner", fontstyle);
        //NativeBanner
        #region NativeBanner
        Rect LoadNativeBannerButton = new Rect(0.10f * Screen.width, 0.28f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(LoadNativeBannerButton, "Load NativeBanner"))
        {
            Debug.Log(JoyPacSDkDemo + "Load NativeBanner");
            JoyPac.Instance().LoadNativeBanner(NativeBannerUnitId);

            OnGUIDebug.Instance.AddMsg(Loading(ADType.NativeBanner));
        }

        Rect ShowNativeBannerButton = new Rect(0.55f * Screen.width, 0.28f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (NativeBannerCanShow)
        {
            if (GUI.Button(ShowNativeBannerButton, "show NativeBanner", CanShowStyle))
            {

                Debug.Log(JoyPacSDkDemo + "show NativeBanner");
                if (JoyPac.Instance().IsReadyNativeBanner(NativeBannerUnitId))
                {
                    NativeBannerCanShow = false;
                    //底部居中
                    JoyPac.Instance().ShowNativeBanner(NativeBannerUnitId, JoyPacAdManager.JoyPacBannerAlign.BannerAlignBottom | JoyPacAdManager.JoyPacBannerAlign.BannerAlignHorizontalCenter);
                }

            }
        }
        else
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

        Rect Interstitial = new Rect(0.40f * Screen.width, 0.43f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        GUI.Label(Interstitial, "Interstitial", fontstyle);
        //Interstitial
        #region Interstitial
        Rect loadInterstitialButton = new Rect(0.10f * Screen.width, 0.46f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(loadInterstitialButton, "Load Interstitial"))
        {
            Debug.Log(JoyPacSDkDemo + "Load Interstitial");
            JoyPac.Instance().LoadInterstitial(InterstitialUnitId);

            OnGUIDebug.Instance.AddMsg(Loading(ADType.Interstitial));
        }
        Rect showInterstitialButton = new Rect(0.55f * Screen.width, 0.46f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (InterstitialCanShow)
        {
            if (GUI.Button(showInterstitialButton, "Show Interstitial", CanShowStyle))
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

        Rect RewardVideo = new Rect(0.40f * Screen.width, 0.53f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        GUI.Label(RewardVideo, "RewardVideo", fontstyle);

        //RewardVideo
        #region RewardVideo
        Rect LoadRewardVideoButton = new Rect(0.10f * Screen.width, 0.56f * Screen.height, 0.35f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(LoadRewardVideoButton, "Load RewardVideo"))
        {
            Debug.Log(JoyPacSDkDemo + "Load RewardVideo");
            JoyPac.Instance().LoadRewardVideo(RewardUnitId);

            OnGUIDebug.Instance.AddMsg(Loading(ADType.Reward));
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


        Rect ReturnButton = new Rect(0.10f * Screen.width, 0.65f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(ReturnButton, "Return"))
        {
            SceneManager.LoadScene("MainScene");

            JoyPac.Instance().RemoveBanner();
            JoyPac.Instance().RemoveNativeBanner();
            OnGUIDebug.Instance.RemoveAll();
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
        OnGUIDebug.Instance.AddMsg(LoadFail(ADType.Reward));
    }

    private void RewardListener_onRewardedVideoAdLoaded()
    {
        RewardCanShow = true;
        OnGUIDebug.Instance.AddMsg(Completed(ADType.Reward));
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
        OnGUIDebug.Instance.AddMsg(LoadFail(ADType.Interstitial));
    }

    private void InterstitialListener_onAdLoaded()
    {
        InterstitialCanShow = true;
        OnGUIDebug.Instance.AddMsg(Completed(ADType.Interstitial));
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
        OnGUIDebug.Instance.AddMsg(LoadFail(ADType.NativeBanner));
    }

    private void NativeBannerListener_onAdLoaded()
    {
        NativeBannerCanShow = true;
        isReadyNativeBanner = true;
        OnGUIDebug.Instance.AddMsg(Completed(ADType.NativeBanner));
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
        OnGUIDebug.Instance.AddMsg(LoadFail(ADType.Banner));

    }

    private void BannerListener_onAdLoaded()
    {
        BannerCanShow = true;
        isReadyBanner = true;
        OnGUIDebug.Instance.AddMsg(Completed(ADType.Banner));
        Debug.Log(JoyPacSDkDemo + "BannerListener_onAdLoaded");

    }
    #endregion
}
