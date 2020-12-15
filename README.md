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

Attribution: Matching app users with the sources that drive their installations. These attribution data can be used to monitor promotion effects, carry out efficient remarketing promotion, and optimize creatives

Event tracking: Trigger custom events related to IAP, advertising revenue, virtual currency, level progress, errors, or specific situations of the game in the game code

Online parameters: After configuring custom parameters through the management platform, the server API will be sent to the SDK, and the SDK will pass the parameters through the interface

Advertising: Based on TopOnSDK


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

1) In Xcode, click to Build Settings, search for Other Linker Flags and add -ObjC (here the letter O and letter C need to be capitalized), note that Linker Flags  are case sensitive

2) Add NSAllowsArbitraryLoads to your app’s Info.plist to disable ATS restrictions

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
### 5.4 Impletemente RewardVideo Listener

    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdLoaded += onSetRewardListener_onRewardedVideoAdLoaded;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdFailedToLoad += onSetRewardListener_onRewardedVideoAdFailedToLoad;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdClosed += onSetRewardListener_onRewardedVideoAdClosed;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoStarted += onSetRewardListener_onRewardedVideoStarted;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoAdEnd += onSetRewardListener_onRewardedVideoAdEnd;
    JoyPacUniversalFunc.onSetRewardListener_onRewardedVideoDidRewardedSuccess += onSetRewardListener_onRewardedVideoDidRewardedSuccess;
