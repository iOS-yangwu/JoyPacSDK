# JoyPacSDK Unity3D Integration
## Introduction

The main purpose of JoyPacSDK is to help developers simplify the SDK process required to access games. JoyPacSDK aggregates AdjustSDK, GameAnalyticsSDK, and TopOnSDK. Once JoyPacSDK is deployed in the application, you can view relevant data in the corresponding third-party management background.

This document describes how to integrate the JoyPac unity3d SDK.

JoyPac supports ad forms as follows in Unity 3D platform:

 |Ads Form | Introduction |
 | ------ | ------ |
 |Video | Video Ads, with UI |
 |Interstitial | Interstitial Ads，with UI |
 |Banner | Banner Ads，with UI |


## Support Function

Statistical analysis: user analysis, retention analysis, terminal attributes

Attribution: Matching app users with the sources that drive their installations. These attribution data can be used to monitor promotion effects, carry out efficient remarketing promotion, and optimize creatives

Event tracking: Trigger custom events related to IAP, advertising revenue, virtual currency, level progress, errors, or specific situations of the game in the game code

Online parameters: After configuring custom parameters through the management platform, the server API will be sent to the SDK, and the SDK will pass the parameters through the interface

Advertising: Based on TopOnSDK


## Configuration
### Basic configuration


Open the project in the Unity editor, go to Assets → Import Package → Custom Package and select the downloaded Unity Package package

JoyPac.Package contains: GA_SDK_UNITY.unitypackage, Adjust_v4.23.2.unitypackage, JoyPac.unitypackage

Among them, GA_SDK_UNITY.unitypackage and Adjust_v4.23.2.unitypackage are Tracking statistical packages, and the rest are Ads packages

### Advertising related
1 Introduce the basic core framework in Xcode
        
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
        
2 Xcode configuration Build Settings and Info.plist

1) In Xcode, click to Build Settings, search for Other Linker Flags and add -ObjC (here the letter O and letter C need to be capitalized), note that Linker Flags  are case sensitive

2) Add NSAllowsArbitraryLoads to your app’s Info.plist to disable ATS restrictions

3）If the Admob advertising platform SDK is imported, you also need to add GADApplicationIdentifier to the app’s Info.plist to configure Admob’s AppID.

    <key>GADApplicationIdentifier</key>
    <string>ca-app-pub-9488501426181082/7319780494</string>
    <key>GADIsAdManagerApp</key> <true/>
    
    
### API 

Init sdk

    /**
    JoyPacAppId: JoyPac AppID
    adjustKey: Adjust 初始化所需 Key
    GAKey: GA 初始化所需 key
    GASecret: GA 初始化所需 secret
    */
    public void InitSDK(string JoyPacAppID);
    public void InitSDK(string adjustToken, string GAKey, string GASecret);
    public void InitSDK(string JoyPacAppId, string adjustKey, string GAKey, string GASecret);

Tracking

    /**
    
    AdjustEventName: Adjust 事件名称
    GAEventName: GA 事件名称
    eventValue: 事件数值
    */

    public void TrackEvent(string AdjustEventName);
    public void TrackEvent(string GAEventName, float eventValue);
    public void TrackEvent(string AdjustEventName, string GAEventName, float eventValue);

    若想使用GA提供的事件追踪接口，请参照文档：
    https://gameanalytics.com/docs/item/unity-sdk/#event-tracking
    
Ads
    
    

