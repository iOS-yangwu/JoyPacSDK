//
//  JPCAdvertManager.h
//  //
//  Created by 洋吴 on 2019/3/14.
//

#import "JPCProtocal.h"
#import "JPHeader.h"

#ifdef __cplusplus
extern "C"{
#endif
    
    void    UnitySendMessage(const char* obj, const char* method, const char* msg);
    
#ifdef __cplusplus
}
#endif

extern NSString *const kGroupIDKey;
extern NSString *const kLogIDKey;
extern NSString *const kSegmentKey;
extern NSString *const kSDKVersionKey;
extern NSString *const kSettingURLKey;
extern NSString *const kAPPConfigKey;
extern NSString *const kUnitConfigKey;
extern NSString *const kInstallSchemeKey;
extern NSString *const kEnterBackgroundTimeKey;
extern NSString *const kInterstitialKey;
extern NSString *const kRewardVideoKey;
extern NSString *const kNativeKey;
extern NSString *const kBannerKey;
extern NSString *const kNativeBannerKey;
extern NSString *const kSplashKey;
extern NSString *const kInstallTimeKey;
extern NSString *const kGetSettingTimeKey;
extern NSString *const kBannerUnitIDKey;
extern NSString *const kRewardVideoUnitIDKey;
extern NSString *const kInterstitialUnitIDKey;
extern NSString *const kNativeUnitIDKey;
extern NSString *const kSplashUnitIDKey;

@interface JPCAdvertManager : NSObject

@property (nonatomic,weak)id<JPCProtocal> delegate;

@property (nonatomic,strong)NSString *JPAppID;

@property (nonatomic,assign)BOOL initializeSDK;

@property (nonatomic,strong)NSMutableArray *queueArr;

+ (JPCAdvertManager *)manager;
//请求广告初始化
- (instancetype)initSDK;
//初始化SDK
- (void)startSDKWithAppID:(NSString *)appID;

- (void)refreshSegment;

@end


