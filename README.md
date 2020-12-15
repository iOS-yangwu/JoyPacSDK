# JoyPacSDK Unity3D Integration
## 1 Introduction

The main purpose of JoyPacSDK is to help developers simplify the SDK process required to access games. JoyPacSDK aggregates AdjustSDK, GameAnalyticsSDK, and TopOnSDK. Once JoyPacSDK is deployed in the application, you can view relevant data in the corresponding third-party management background.

This document describes how to integrate the JoyPac unity3d SDK.

JoyPac supports ad forms as follows in Unity 3D platform:

 |Ads Form | Introduction |
 | ------ | ------ |
 |Video | Video Ads, with UI |
 |Interstitial | Interstitial Ads，with UI |
 |Banner | Banner Ads，with UI |


## 2 Support Function

Statistical analysis: user analysis, retention analysis, terminal attributes

Attribution: Matching app users with the sources that drive their installations. These attribution data can be used to monitor promotion effects, carry out efficient remarketing promotion, and optimize creatives.

Event tracking: Trigger custom events related to IAP, advertising revenue, virtual currency, level progress, errors, or specific situations of the game in the game code.

Online parameters: After configuring custom parameters through the management platform, the server API will be sent to the SDK, and the SDK will pass the parameters through the interface.

Advertising: Based on TopOnSDK.


## 3 Configuration
### 3.1 Basic configuration


Open the project in the Unity editor, go to Assets → Import Package → Custom Package and select the downloaded Unity Package package

JoyPac.Package contains: GA_SDK_UNITY.unitypackage, Adjust_v4.23.2.unitypackage, JoyPac.unitypackage

Among them, GA_SDK_UNITY.unitypackage and Adjust_v4.23.2.unitypackage are Tracking statistical packages, and the rest are Ads packages

### 3.2 Advertising related
#### 3.2.1 Introduce the basic core framework in Xcode
        
        AVFoundation.framework
        Accelerate.framework
        AdSupport.framework
        AudioToolbox.framework
        CoreLocation.framework
        CoreMedia.framework
        CoreMotion.framework
        CoreTelephony.framework
        MessageUI.framework
        MobileCoreServices.framework
        SafariServices.framework
        StoreKit.framework
        SystemConfiguration.framework
        VideoToolbox.framework
        WebKit.framework
        libbz2.tbd
        libc++.tbd
        libresolv.9.tbd
        libsqlite3.tbd
        libxml2.tbd
        libz.tbd
        
#### 3.2.2 Xcode configuration Build Settings and Info.plist

1) In Xcode, click to Build Settings, search for Other Linker Flags and add -ObjC (here the letter O and letter C need to be capitalized), note that Linker Flags  are case sensitive.

2) Add NSAllowsArbitraryLoads to your app’s Info.plist to disable ATS restrictions.

3) If the Admob advertising platform SDK is imported, you also need to add GADApplicationIdentifier to the app’s Info.plist to configure Admob’s AppID.


       <key>GADApplicationIdentifier</key>
       <string>ca-app-pub-9488501426181082/7319780494</string>
       <key>GADIsAdManagerApp</key> <true/>
    
    
    
    
## 4 API 

|API | Parameter | Description |
| ------ | ------ |------ |
|InitSDK | string JoyPacAppID | It needs to be obtained after creating an application in the JoyPac background |
|InitSDK | string adjustToken, string GAKey, string GASecret | AdjustToken, GAKey and GASecret |
|InitSDK | string JoyPacAppID,string adjustToken,string GAKey,string GASecret | JoyPacAppID, AdjustToken, GAKey and GASecret |
|SetLogEnable | bool enable | Set whether there is Debug log output |


## 4.1 Sample code

    JoyPac.Instance().SetLogEnable(true);
    JoyPac.Instance().InitSDK("004ac97c41", "qetw4jo08iss", "5b7b3eb6d9092d71619615d44b497ab1", "7d20ef439c720d168afc0d8f5df95d486ccacbf6");

## 5 Integrate RewardVideo Ad
### 5.1 API

|API | Parameter | Description |
| ------ | ------ |------ |
|LoadRewardVideo | string unitId | Load ad |
|IsReadyRewardVideo | string unitId | Determine whether there is an ad cache |
|ShowRewardVideo | string unitId | Show ad |

### 5.2 Load RewardVideo Ad

    public void loadRV()
    {
      JoyPac.Instance().LoadRewardVideo("Your UnitID");
    }

### 5.3 Show RewardVideo Ad
    public void showRV()
    {
       if (JoyPac.Instance().IsReadyRewardVideo("Your UnitID"))
        {
            JoyPac.Instance().ShowRewardVideo("Your UnitID");
        }
    }
### 5.4 Impletemente RewardVideo Ad Listener

    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdLoaded += onSetRewardListener_onRewardedVideoAdLoaded;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdFailedToLoad += onSetRewardListener_onRewardedVideoAdFailedToLoad;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdClosed += onSetRewardListener_onRewardedVideoAdClosed;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoStarted += onSetRewardListener_onRewardedVideoStarted;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdEnd += onSetRewardListener_onRewardedVideoAdEnd;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoDidRewardedSuccess += onSetRewardListener_onRewardedVideoDidRewardedSuccess;


## 6 Integrate Interstitial Ad
### 6.1 API

|API | Parameter | Description |
| ------ | ------ |------ |
|LoadInterstitial | string unitId | Load ad |
|IsReadyInterstitial | string unitId | Determine whether there is an ad cache |
|ShowInterstitial | string unitId | Show ad |

### 6.2 Load Interstitial Ad

    public void loadInterstitial()
    {
      JoyPac.Instance().LoadInterstitial("Your UnitID");
    }

### 6.3 Show Interstitial Ad
    public void showInterstitial()
    {
       if (JoyPac.Instance().IsReadyInterstitial("Your UnitID"))
        {
            JoyPac.Instance().ShowInterstitial("Your UnitID");
        }
    }
### 6.4 Impletemente Interstitial Ad Listener

    JoyPacUniversalFunc.onSetInterstitialListener_onAdLoaded += onSetInterstitialListener_onAdLoaded;
    JoyPacUniversalFunc.onSetInterstitialListener_onAdFailedToLoad += onSetInterstitialListener_onAdFailedToLoad;
    JoyPacUniversalFunc.onSetInterstitialListener_onAdClosed += onSetInterstitialListener_onAdClosed;
    JoyPacUniversalFunc.onSetInterstitialListener_onShowSuccess += onSetInterstitialListener_onShowSuccess;
    JoyPacUniversalFunc.onSetInterstitialListener_onStartPlayVideo += onSetInterstitialListener_onStartPlayVideo;
    JoyPacUniversalFunc.onSetInterstitialListener_onEndPlaying += onSetInterstitialListener_onEndPlaying;
    
    
## 7 Integrate Banner Ad
### 7.1 API

|API | Parameter | Description |
| ------ | ------ |------ |
|LoadBanner | string unitId | Load ad |
|IsReadyBanner | string unitId | Determine whether there is an ad cache |
|ShowBanner | string untId, JoyPacAdManager.JoyPacBannerAlign align | Show ad with direction |
|HideBanner |  | hide banner |
|RemoveBanner |  | remove banner |

### 7.2 Load Banner Ad

    public void loadBanner()
    {
      JoyPac.Instance().LoadBanner("Your UnitID");
    }

### 7.3 Show Banner Ad
    public void showBanner()
    {
       if (JoyPac.Instance().IsReadyBanner("Your UnitID"))
        {
            JoyPac.Instance().ShowBanner("Your UnitID", JoyPacAdManager.JoyPacBannerAlign.BannerAlignBottom | JoyPacAdManager.JoyPacBannerAlign.BannerAlignHorizontalCenter);
        }
    }
### 7.4 Impletemente Banner Ad Listener

    JoyPacUniversalFunc.onSetBannerListener_onAdLoaded += onSetBannerListener_onAdLoaded;
    JoyPacUniversalFunc.onSetBannerListener_onShowSuccess += onSetBannerListener_onShowSuccess;
    JoyPacUniversalFunc.onSetBannerListener_onClick += onSetBannerListener_onClick;
    
      
## 8 Integrate Native Banner Ad
### 8.1 API

|API | Parameter | Description |
| ------ | ------ |------ |
|LoadNativeBanner | string unitId | Load ad |
|IsReadyNativeBanner | string unitId | Determine whether there is an ad cache |
|ShowNativeBanner | string untId, JoyPacAdManager.JoyPacBannerAlign align | Show ad with direction |
|HideNativeBanner |  | hide native banner |
|RemoveNativeBanner |  | remove native banner |

### 8.2 Load Native Banner Ad

    public void loadNativeBanner()
    {
      JoyPac.Instance().LoadNativeBanner("Your UnitID");
    }

### 8.3 Show Native Banner Ad
    public void showNativeBanner()
    {
       if (JoyPac.Instance().IsReadyNativeBanner("Your UnitID"))
        {
            JoyPac.Instance().ShowNativeBanner("Your UnitID", JoyPacAdManager.JoyPacBannerAlign.BannerAlignBottom | JoyPacAdManager.JoyPacBannerAlign.BannerAlignHorizontalCenter);
        }
    }
### 8.4 Impletemente Native Banner Ad Listener

    JoyPacUniversalFunc.onSetNativeBannerListener_onAdLoaded += onSetNativeBannerListener_onAdLoaded;
    JoyPacUniversalFunc.onSetNativeBannerListener_onShowSuccess += onSetBNativeannerListener_onShowSuccess;
    JoyPacUniversalFunc.onSetNativeBannerListener_onClick += onSetNativeBannerListener_onClick;
    
    
## 9 Tracking Event
### 9.1 API

|API | Parameter | Description |
| ------ | ------ |------ |
|Adjust_TrackEvent | string AdjustEventName | Adjust eventName |
|GA_TrackEvent | string GAEventName, float eventValue | GA eventName and eventValue |
|TrackEvent | string AdjustEventName, string GAEventName, float GAEventValue | AdjustEventName, GAEventName,  GAEventValue |
|JoyPacEvent | string event_sort, string event_type, string event_position, string event_extra | Event classification |


### 9.2 Sample Code

    public void trackingEvent(string adjustEventName,string GAEventName,float GAEventValue)
    {
       JoyPac.Instance().TrackEvent(adjustEventName,GAEventName,GAEventValue);
    }
  
## 10 OnlineParameter & ABTest

According to the configuration in the background of JoyPac, the server performs the streaming, and you can get different parameters for abtest experiment.

### 10.1 Impletemente OnlineParameter Listener

    JoyPacUniversalFunc.onGetOnlineParameter += onGetOnlineParameter;
    
### 10.2 Sample code

    public void onGetOnlineParameter(string jsonString)
    {
      Debug.Log("onGetOnlineParameter" + jsonString );
    }

