//
//  JPCASDKAdatper.m

//
//  Created by 洋吴 on 2019/3/21.
//

#import "AnyThinkAdatper.h"
#import <AnyThinkSDK/AnyThinkSDK.h>
#import <AnyThinkBanner/AnyThinkBanner.h>
#import <AnyThinkNative/AnyThinkNative.h>
#import <AnyThinkInterstitial/AnyThinkInterstitial.h>
#import <AnyThinkRewardedVideo/AnyThinkRewardedVideo.h>
#import <JoypacSDK/JPCAdvertManager.h>
#import <JoypacSDK/AdmobBannerManager.h>
#import <JoypacSDK/JPCCheckList.h>
#import <JoypacSDK/JPCUtils.h>
#import <JoypacSDK/JPCSearchManager.h>
#import <JoypacSDK/JPCDataReportManager.h>

@interface AnyThinkAdatper ()<
ATNativeADDelegate,
ATInterstitialDelegate,
ATRewardedVideoDelegate,
ATNativeBannerDelegate,
ATBannerDelegate>

@property(nonatomic, copy)void(^callBack)(void);

@property(nonatomic, strong)NSString *NBUnitId;

@property(nonatomic, strong)NSString *BUnitId;

@property(nonatomic, strong)NSString *RVUnitId;

@property(nonatomic, strong)NSString *NUnitId;

@property(nonatomic, strong)NSString *IVUnitId;

@property(nonatomic, strong)UIView *nativeBanner;

@property(nonatomic, strong)UIView *banner;

//@property(nonatomic, strong)JPCNativeADView *nativeView;

@property(nonatomic, strong)UIViewController *rootViewController;

@property(nonatomic, strong)UIView *backgroundView;

@end

@implementation AnyThinkAdatper

#pragma - mark init SDK
- (void)initSDKWithAppId:(NSString *)appId appKey:(NSString *)appKey{
    
//    NSMutableDictionary *dic = [[NSMutableDictionary alloc]init];
//
//    [dic setValue:[[JPCHTTPParameter parameter] JPID] forKey:@"JPID"];
//
//    NSDictionary *segment = [[NSUserDefaults standardUserDefaults] objectForKey:kSegmentKey];
//
//    if ([segment isKindOfClass:[NSDictionary class]]) {
//        if (segment.count) {
//
//            [dic addEntriesFromDictionary:segment];
//        }
//
//    }else{
//
//        [dic addEntriesFromDictionary:@{@"cohort_id":@"setting_timeout_default"}];
//    }
//
//    NSDictionary *selfCheckList = [JPCCheckList checkInstallList];
//
//    if (selfCheckList.count && [selfCheckList isKindOfClass:[NSDictionary class]]) {
//
//        [dic addEntriesFromDictionary:selfCheckList];
//
//    }
//
//    [ATAPI sharedInstance].customData = dic;
    
    [[ATAPI sharedInstance] startWithAppID:appId appKey:appKey error:nil];
}

- (void)refreshSegmentWithDictionary:(NSDictionary *)customData{
    
    NSString *topOnVersion = [ATAPI sharedInstance].version;
    topOnVersion = [topOnVersion substringWithRange:NSMakeRange(3,5)];
    if ([JPCUtils compareVersion:topOnVersion toVersion:@"5.5.1"] == -1) {
        return;
    }else{
        NSMutableDictionary *dic = [NSMutableDictionary dictionary];
        NSDictionary *selfCheckList = [JPCCheckList checkInstallList];
        
        if (selfCheckList.count && [selfCheckList isKindOfClass:[NSDictionary class]]) {
            
            [dic addEntriesFromDictionary:selfCheckList];
            
        }
        [dic addEntriesFromDictionary:customData];
        [ATAPI sharedInstance].customData = dic;
    }
}

#pragma mark - load ads
- (void)loadADWithPlacementId:(NSString *)placementId adType:(ADType)type nativeFrame:(CGRect)frame splashWaitTime:(NSString *)time{
    
    if (type == kADTypeNative) {
        
//        self.NUnitId = placementId;
//        CGRect frameF = [JPCUtils transformationToOCCoordinates:frame nativeStyle:kNativeStyleOrigin];
//        [[ATAdManager sharedManager] loadADWithPlacementID:placementId extra:@{kExtraInfoNativeAdTypeKey:@(ATGDTNativeAdTypeSelfRendering), kATExtraNativeImageSizeKey:kATExtraNativeImageSize690_388,kExtraInfoNativeAdSizeKey:[NSValue valueWithCGSize:CGSizeMake(frameF.size.width, frameF.size.height)]} delegate:self];
        
    }else if(type == kADTypeIterstital){
        
        self.IVUnitId = placementId;
        [[ATAdManager sharedManager]loadADWithPlacementID:placementId extra:nil delegate:self];
        
    }else if (type == kADTypeVideo){
        
        self.RVUnitId = placementId;
        NSString *idfv = [UIDevice currentDevice].identifierForVendor.UUIDString;
        [[ATAdManager sharedManager]loadADWithPlacementID:placementId
                                                    extra:@{kATAdLoadingExtraUserIDKey:idfv}
                                                 delegate:self];
        
    }else if(type == kADTypeBanner){
        
        self.BUnitId = placementId;
        [[ATAdManager sharedManager] loadADWithPlacementID:placementId extra:@{kATAdLoadingExtraBannerAdSizeKey:[NSValue valueWithCGSize:CGSizeMake([self adSize].size.width, [self adSize].size.height)]} delegate:self];
        
    }else if (type == kADTypeNativeBanner){
        
        self.NBUnitId = placementId;
        [ATNativeBannerWrapper loadNativeBannerAdWithPlacementID:placementId extra:@{kExtraInfoNativeAdTypeKey:@(ATGDTNativeAdTypeSelfRendering), kATExtraNativeImageSizeKey:kATExtraNativeImageSize690_388} customData:nil delegate:self];
    }
}

#pragma mark - isReady ads
- (BOOL)isReadyADWithADType:(ADType)type {
    
    if (type == kADTypeBanner) {
        
        return self.BUnitId?[[ATAdManager sharedManager] bannerAdReadyForPlacementID:self.BUnitId]:NO;
        
    }else if (type == kADTypeNativeBanner){
        return self.NBUnitId ? [ATNativeBannerWrapper nativeBannerAdReadyForPlacementID:self.NBUnitId] : NO;
        
    }else if (type == kADTypeIterstital){
        
        return self.IVUnitId ? [[ATAdManager sharedManager] interstitialReadyForPlacementID:self.IVUnitId] : NO;
        
    }else if (type == kADTypeVideo){
        
        return self.RVUnitId ? [[ATAdManager sharedManager] rewardedVideoReadyForPlacementID:self.RVUnitId] : NO;
        
    }else if(type == kADTypeNative){
        
//        return self.NUnitId ? [[ATAdManager sharedManager] nativeAdReadyForPlacementID:self.NUnitId] : NO;
        return NO;
        
    }else{
        return  NO;
    }
    
}

#pragma mark - show ads
- (void)showADWithADType:(ADType)type {
    
    [self rootViewController];
    
    if (type == kADTypeNativeBanner) {
        
        [self showNativeBanner];
        
    }else if (type == kADTypeIterstital){
        
        [[ATAdManager sharedManager] showInterstitialWithPlacementID:self.IVUnitId
                                                    inViewController:self.rootViewController
                                                            delegate:self];
        
    }else if (type == kADTypeVideo){
        
        [[ATAdManager sharedManager]showRewardedVideoWithPlacementID:self.RVUnitId
                                                    inViewController:self.rootViewController
                                                            delegate:self];
        
    }else if (type == kADTypeNative){
        
//        [self showNative];
    }else if (type == kADTypeBanner){
        
        [self showBanner];
    }
}

#pragma mark - native
#pragma mark -
- (void)layoutNativeWithX:(CGFloat)x Y:(CGFloat)y W:(CGFloat)w H:(CGFloat)h{
    
//    ATNativeADConfiguration *config = [[ATNativeADConfiguration alloc] init];
//    config.delegate = self;
//    CGRect configFrame = CGRectZero;
//    config.renderingViewClass = [JPCOriginNavtiveAdView class];
//    configFrame = [JPCUtils transformationToOCCoordinates:CGRectMake(x, y, w, h) nativeStyle:kNativeStyleOrigin];
//    config.ADFrame = configFrame;
//    //防止重复添加AdView
//    if (self.nativeView) {
//        return;
//    }
//    self.nativeView = [[ATAdManager sharedManager] retriveAdViewWithPlacementID:self.NUnitId configuration:config];
//    self.nativeView.mediaView.frame = self.nativeView.bounds;
//    self.nativeView.hidden = YES;
    
}

- (void)showNative{
    
//    self.nativeView.hidden = NO;
//    [self.nativeView bringSubviewToFront:self.nativeView.sponsorIV];
//    [self.rootViewController.view addSubview:self.nativeView];
}

- (void)hideNative {
    
    [self removeNative];
}

- (void)removeNative {
    
//    if (self.nativeView) {
//        self.nativeView.hidden = YES;
//        [self.nativeView removeFromSuperview];
//        self.nativeView = nil;
//    }
}

#pragma mark - nativeBanner & banner
#pragma mark -
- (void)showBanner {
    
    if (self.BUnitId) {
        
        if (self.banner.superview && self.banner.superview.alpha == 0) {
            
            self.banner.superview.alpha = 1;
        }else{
            
            ATBannerView *bannerView = [[ATAdManager sharedManager] retrieveBannerViewForPlacementID:self.BUnitId];
            self.banner = bannerView;
            [self.banner setFrame:[self adSize]];
            if (self.banner) {
                [[AdmobBannerManager sharedInstance]removeAdView:self.banner];
                [[AdmobBannerManager sharedInstance]setAdView:self.banner];
            }else{
            }
            [[AdmobBannerManager sharedInstance]showBanner:self.rootViewController.view];
            
        }
    }
    
}

- (void)showNativeBanner{
    
    if (self.NBUnitId) {
        
        if (self.nativeBanner.superview && self.nativeBanner.superview.alpha == 0) {
            
            self.nativeBanner.superview.alpha = 1;
        }else{
            
            self.nativeBanner = [ATNativeBannerWrapper retrieveNativeBannerAdViewWithPlacementID:self.NBUnitId extra:@{kATNativeBannerAdShowingExtraBackgroundColorKey:[UIColor whiteColor],kATNativeBannerAdShowingExtraHideCloseButtonFlagKey:@YES,kATNativeBannerAdShowingExtraAdSizeKey:[NSValue valueWithCGSize:CGSizeMake([self adSize].size.width, [self adSize].size.height)]} delegate:self];
            
            
            [self.nativeBanner setFrame:[self adSize]];
            if (self.nativeBanner) {
                [[AdmobBannerManager sharedInstance]removeAdView:self.nativeBanner];
                [[AdmobBannerManager sharedInstance]setAdView:self.nativeBanner];
            }else{
            }
            [[AdmobBannerManager sharedInstance]showBanner:self.rootViewController.view];
            
        }
    }
    
}

- (void)hideBanner {
    
    NSLog(@"yangwu %s-%@-%@",__func__,self.banner,self.nativeBanner);
    if (self.banner) {
        
        [[AdmobBannerManager sharedInstance]hideBanner];
    }
}

- (void)removeBanner {
    
    NSLog(@"yangwu %s-%@-%@",__func__,self.banner,self.nativeBanner);
    if (self.banner) {
        
        [[AdmobBannerManager sharedInstance]removeAdView:self.banner];
    }
}

- (void)hideNativeBanner{
    
    NSLog(@"yangwu %s-%@-%@",__func__,self.banner,self.nativeBanner);
    if (self.nativeBanner) {
        
        [[AdmobBannerManager sharedInstance] hideBanner];
    }
    
}

- (void)removeNativeBanner{
    NSLog(@"yangwu %s-%@-%@",__func__,self.banner,self.nativeBanner);
    if (self.nativeBanner) {
        
        [[AdmobBannerManager sharedInstance]removeAdView:self.nativeBanner];
    }
}

- (void)setBannerAlign:(BannerAlign)align offset:(CGPoint)offset {
    
    [[AdmobBannerManager sharedInstance]setLastOffsetX:offset.x];
    [[AdmobBannerManager sharedInstance]setLastOffsetY:offset.y];
    [[AdmobBannerManager sharedInstance]setBannerAlign:align];
}

- (CGRect)adSize {
    CGRect gadSize = CGRectMake(0, 0, 320, 50);
    if ([[UIDevice currentDevice] userInterfaceIdiom] == UIUserInterfaceIdiomPad) {
        gadSize = CGRectMake(0, 0, 728, 90);;
    }
    return gadSize;
}

#pragma mark - ads delegete
#pragma mark Loading Delegate
- (void)didFailToLoadADWithPlacementID:(NSString *)placementID error:(NSError *)error {
    
    NSString *type;
    if ([self.BUnitId isEqualToString:placementID]) {
        type = @"banner";
        UnitySendMessage("AdObject", "JoyPacBannerAdLoadFail", "");
    }else if ([self.IVUnitId isEqualToString:placementID]){
        type = @"interstitial";
        UnitySendMessage("AdObject", "JoyPacInterstitialAdLoadFail", "");
    }else if ([self.RVUnitId isEqualToString:placementID]){
        type = @"rewardVideo";
        UnitySendMessage("AdObject", "JoyPacVideoAdLoadFail", "");
    }else if ([self.NUnitId isEqualToString:placementID]){
        type = @"native";
        UnitySendMessage("AdObject", "JoyPacNativeAdLoadFail", "");
    }else{
        type = @"NULL";
    }
    
    [[JPCDataReportManager manager] reportWithType:kLoadAdCallBack
                                       placementId:placementID
                                             reson:[NSString stringWithFormat:@"%@",error]
                                            result:@"Fail"
                                            adType:type
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
    
}

- (void)didFinishLoadingADWithPlacementID:(NSString *)placementID {
    
    NSString *type;
    if ([self.BUnitId isEqualToString:placementID]) {
        type = @"banner";
        UnitySendMessage("AdObject", "JoyPacBannerAdLoad", "");
    }else if ([self.IVUnitId isEqualToString:placementID]){
        type = @"interstitial";
        UnitySendMessage("AdObject", "JoyPacInterstitialAdLoad", "");
        
    }else if ([self.RVUnitId isEqualToString:placementID]){
        type = @"rewardVideo";
        UnitySendMessage("AdObject", "JoyPacVideoAdLoaded", "");
        
    }else if ([self.NUnitId isEqualToString:placementID]){
        type = @"native";
        UnitySendMessage("AdObject", "JoyPacNativeAdLoaded", "");
    }else{
        type = @"NULL";
    }
    
    [[JPCDataReportManager manager]reportWithType:kLoadAdCallBack
                                      placementId:placementID
                                            reson:@"SuccessCallBack"
                                           result:@"Success"
                                           adType:type
                                           extra1:@""
                                           extra2:@""
                                           extra3:@""];
}

#pragma mark - rv
-(void) rewardedVideoDidStartPlayingForPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacVideoAdPlayStart", "");
    
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:@"didStartPlayingRewardVideo"
                                            result:@"Success"
                                            adType:@"rewardVideo"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
    
}

-(void) rewardedVideoDidEndPlayingForPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    
    UnitySendMessage("AdObject", "JoyPacVideoAdPlayEnd", "");
    
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:@"didEndPlayingRewardVideo"
                                            result:@"Success"
                                            adType:@"rewardVideo"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
    
}

-(void) rewardedVideoDidFailToPlayForPlacementID:(NSString*)placementID error:(NSError*)error extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacVideoAdPlayFail", "");
    
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:[NSString stringWithFormat:@"%@",error]
                                            result:@"Fail"
                                            adType:@"rewardVideo"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
    
}

-(void) rewardedVideoDidCloseForPlacementID:(NSString*)placementID rewarded:(BOOL)rewarded extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacVideoAdPlayClosed", "");
    [[JPCDataReportManager manager]reportWithType:kRewardedInfo
                                      placementId:placementID
                                            reson:@"didClose"
                                           result:@""
                                           adType:@"rewardVideo"
                                           extra1:@""
                                           extra2:@""
                                           extra3:@""];
    
}

-(void) rewardedVideoDidRewardSuccessForPlacemenID:(NSString*)placementID extra:(NSDictionary*)extra{
    
    UnitySendMessage("AdObject", "JoyPacVideoAdDidRewardedSuccess", "");
    
}

-(void) rewardedVideoDidClickForPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacVideoAdPlayClicked", "");
    
    NSString *jpUnitID = [[JPCSearchManager shareManager] getJPUnitIdByKey:kRewardVideoUnitIDKey];
    
    [[JPCDataReportManager manager]reportWithType:kDidClickAd
                                      placementId:placementID
                                            reson:jpUnitID
                                           result:@""
                                           adType:@"rewardVideo"
                                           extra1:@""
                                           extra2:@""
                                           extra3:@""];
}

#pragma mark - iv
-(void) interstitialDidShowForPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacInterstitialAdShow", "");
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:@"didShow"
                                            result:@"Success"
                                            adType:@"interstitial"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
    
}

-(void) interstitialFailedToShowForPlacementID:(NSString*)placementID error:(NSError*)error extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacInterstitialAdsShowFail", "");
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:[NSString stringWithFormat:@"%@",error]
                                            result:@"Fail"
                                            adType:@"interstitial"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
}

-(void) interstitialDidStartPlayingVideoForPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacInterstitialAdsStartPlayVideo", "");
}

-(void) interstitialDidEndPlayingVideoForPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacInterstitialAdsEndPlaying", "");
    
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:@"didEndPlayingVideo"
                                            result:@"Success"
                                            adType:@"interstitial"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
}

-(void) interstitialDidFailToPlayVideoForPlacementID:(NSString*)placementID error:(NSError*)error extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacInterstitialAdFailedToPlay", "");
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:[NSString stringWithFormat:@"%@",error]
                                            result:@"Fail"
                                            adType:@"interstitial"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
}

-(void) interstitialDidCloseForPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacInterstitialAdClose", "");
    
}

-(void) interstitialDidClickForPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacInterstitialAdClick", "");
    
    NSString *jpUnitID = [[JPCSearchManager shareManager] getJPUnitIdByKey:kInterstitialUnitIDKey];
    
    [[JPCDataReportManager manager]reportWithType:kDidClickAd
                                      placementId:placementID
                                            reson:jpUnitID
                                           result:@""
                                           adType:@"interstitial"
                                           extra1:@""
                                           extra2:@""
                                           extra3:@""];
    
}

#pragma mark - banner
-(void) bannerView:(ATBannerView*)bannerView failedToAutoRefreshWithPlacementID:(NSString*)placementID error:(NSError*)error{
    
}
-(void) bannerView:(ATBannerView*)bannerView didShowAdWithPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacBannerAdDidShow", "");
    
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:@"didShowNativeBanner"
                                            result:@"Success"
                                            adType:@"banner"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
}
-(void) bannerView:(ATBannerView*)bannerView didClickWithPlacementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacBannerAdDidClick", "");
    
    NSString *jpUnitID = [[JPCSearchManager shareManager] getJPUnitIdByKey:kBannerUnitIDKey];
    
    [[JPCDataReportManager manager]reportWithType:kDidClickAd
                                      placementId:placementID
                                            reson:jpUnitID
                                           result:@""
                                           adType:@"banner"
                                           extra1:@""
                                           extra2:@""
                                           extra3:@""];
}


-(void) bannerView:(ATBannerView*)bannerView didAutoRefreshWithPlacement:(NSString*)placementID extra:(NSDictionary *)extra{
    
    NSString *jpUnitID = [[JPCSearchManager shareManager] getJPUnitIdByKey:kBannerUnitIDKey];
    
    [[JPCDataReportManager manager] reportWithType:kTriggerShowAd
                                       placementId:placementID
                                             reson:jpUnitID
                                            result:@""
                                            adType:@"banner"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
}
-(void) bannerView:(ATBannerView*)bannerView didTapCloseButtonWithPlacementID:(NSString*)placementID extra:(NSDictionary*)extra{
    
    UnitySendMessage("AdObject", "JoyPacBannerAdDidClickCloseButton", "");
}

#pragma mark - native banner
-(void) didFinishLoadingNativeBannerAdWithPlacementID:(NSString *)placementID{
    
    UnitySendMessage("AdObject", "JoyPacNativeBannerAdLoad", "");
}

-(void) didFailToLoadNativeBannerAdWithPlacementID:(NSString*)placementID error:(NSError*)error{
    
    UnitySendMessage("AdObject", "JoyPacNativeBannerAdLoadFail", "");
}

-(void) didShowNativeBannerAdInView:(ATNativeBannerView*)bannerView placementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacNativeBannerAdDidShow", "");
    
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:@"didShowNativeBanner"
                                            result:@"Success"
                                            adType:@"nativeBanner"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
}

-(void) didClickNativeBannerAdInView:(ATNativeBannerView*)bannerView placementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacNativeBannerAdDidClick", "");
    
    NSString *jpUnitID = [[JPCSearchManager shareManager] getJPUnitIdByKey:kBannerUnitIDKey];
    
    [[JPCDataReportManager manager]reportWithType:kDidClickAd
                                      placementId:placementID
                                            reson:jpUnitID
                                           result:@""
                                           adType:@"nativeBanner"
                                           extra1:@""
                                           extra2:@""
                                           extra3:@""];
    
    
}

-(void) didClickCloseButtonInNativeBannerAdView:(ATNativeBannerView*)bannerView placementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    
}

-(void) didAutorefreshNativeBannerAdInView:(ATNativeBannerView*)bannerView placementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    NSString *jpUnitID = [[JPCSearchManager shareManager] getJPUnitIdByKey:kBannerUnitIDKey];
    
    [[JPCDataReportManager manager] reportWithType:kTriggerShowAd
                                       placementId:placementID
                                             reson:jpUnitID
                                            result:@""
                                            adType:@"banner"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
    
}
#pragma mark - native
-(void) didShowNativeAdInAdView:(ATNativeADView*)adView placementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacNativeAdDidShow", "");
    adView.mainImageView.hidden = [adView isVideoContents];
    
    [[JPCDataReportManager manager] reportWithType:kShowAdResult
                                       placementId:placementID
                                             reson:@"didShowNative"
                                            result:@"Success"
                                            adType:@"native"
                                            extra1:@""
                                            extra2:@""
                                            extra3:@""];
    
}

-(void) didClickNativeAdInAdView:(ATNativeADView*)adView placementID:(NSString*)placementID extra:(NSDictionary *)extra{
    
    UnitySendMessage("AdObject", "JoyPacNativeAdDidClick", "");
    
    NSString *jpUnitID = [[JPCSearchManager shareManager] getJPUnitIdByKey:kNativeUnitIDKey];
    
    [[JPCDataReportManager manager]reportWithType:kDidClickAd
                                      placementId:placementID
                                            reson:jpUnitID
                                           result:@""
                                           adType:@"native"
                                           extra1:@""
                                           extra2:@""
                                           extra3:@""];
}

#pragma mark - lazyingLoading
- (UIViewController *)rootViewController{
    
    if (!_rootViewController) {
        _rootViewController = [UIApplication sharedApplication].keyWindow.rootViewController;
    }
    return _rootViewController;
}


#pragma mark - instance
+ (AnyThinkAdatper *)adatper{
    static AnyThinkAdatper *adatper = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        adatper = [[AnyThinkAdatper alloc]init];
    });
    return adatper;
}

@end
