# JoyPacSDK
简介

JoyPac聚合SDK主要目的是帮助开发者简化接入游戏所需SDK流程。JoyPacSDK聚合了AdjustSDK、GameAnalyticsSDK，一旦在应用中部署了JoyPacSDK，就可以在相应的第三方管理后台查看相关数据。
### 1 支持功能

统计分析：用户分析、留存分析、终端属性

归因：将应用用户与推动其安装的来源进行匹配，这些归因数据可以用来监测推广效果、开展高效再营销推广以及优化广告素材

事件追踪：在游戏代码中触发与IAP、广告收入、虚拟货币、等级进展、错误相关、或针对游戏的特定情况，使用自定义事件

在线参数：通过管理平台配置自定义参数后，服务端API下发至SDK，SDK将通过接口传递参数

广告：

### 1.1 SDK架构

### 1.2 设计模块
设计需求：

1、调用简便

2、针对不同平台（iOS/Android）的接口实现

具体细节

1、游戏客户端的所有接口调用是通过 JoyPac 类

2、JoyPac 类会根据当前运行平台的不同，调用不同平台上的实现逻辑

3、这些不同平台上的实现逻辑会跨平台调用原生环境的接口

4、原生环境所有的信息数据发送给JoyPacNotify类

5、JoyPacNotify类将相关数据转发给JoyPac 类

6、JoyPac 类再将数据处理后反馈给游戏客户端


### 2 配置
#### 2.1 基础配置

在Unity编辑器中打开项目，转到Assets → Import Package → Custom Package并选择下载的Unity Package包

JoyPac提供三个Package：GA_SDK_UNITY.unitypackage、Adjust_v4.23.2.unitypackage、JoyPac.unitypackage

其中 GA_SDK_UNITY.unitypackage、Adjust_v4.23.2.unitypackage为Tracking/统计包,JoyPac.unitypackage为广告包,按需导入即可

#### 2.2 广告相关
1  导入基础核心框架（iOS）
        
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
        
2 iOS 配置Build Settings 和 Info.plist

1) 在 Xcode中, 点击到 Build Settings, 搜索 Other Linker Flags 然后添加 -ObjC(这里的字母O和字母C需要大写), 注意 Linker Flags 是区分大小写的

2) 在您app的Info.plist中添加 NSAllowsArbitraryLoads 禁用ATS限制。

3）如果导入了Admob广告平台SDK，那么还需要在app的Info.plist中添加 GADApplicationIdentifier 配置Admob的AppID。

    <key>GADApplicationIdentifier</key>
    <string>ca-app-pub-9488501426181082/7319780494</string>
    <key>GADIsAdManagerApp</key> <true/>
    
    
3 广告流程建议

我们建议以下图所示流程来集成广告:

应用启动时初始化 JoyPac SDK

调用JoyPac SDK加载广告loadADWithUnitID

应用需要展示广告时，判断isReady

True, 展示广告。收到广告关闭回调后，重新加载广告。

False, 调用JoyPac SDK 重新加载广告并且提示用户“广告正在加载中”

### 3 API 说明
给到游戏调用的 JoyPac 类中我们定义了以下接口

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
    
    

