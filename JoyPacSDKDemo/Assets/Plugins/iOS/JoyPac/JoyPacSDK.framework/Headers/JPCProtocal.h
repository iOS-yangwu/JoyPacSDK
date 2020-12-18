//
//  JPCProtocal.h

//
//  Created by 洋吴 on 2019/3/21.
//


#define JPCProtocal_h
#import <UIKit/UIKit.h>
#import "JPCConst.h"


typedef NS_ENUM(NSUInteger, ADType) {
    kADTypeBanner = 0,
    kADTypeVideo = 1,
    kADTypeIterstital = 2,
    kADTypeNative = 3,
    kADTypeNativeBanner = 4
};

@protocol JPCProtocal <NSObject>

#pragma mark 
- (void)initSDKWithAppId:(NSString *)appId appKey:(NSString *)appKey;

#pragma mark common
- (void)loadADWithPlacementId:(NSString*)placementId adType:(ADType)type nativeFrame:(CGRect)frame splashWaitTime:(NSString *)time;

- (void)showADWithADType:(ADType)type;

- (BOOL)isReadyADWithADType:(ADType)type;

#pragma mark banner
- (void)setBannerAlign:(BannerAlign)align offset:(CGPoint)offset;

- (void)hideBanner;

- (void)removeBanner;

#pragma mark nativeBanner
- (void)hideNativeBanner;

- (void)removeNativeBanner;

#pragma mark native
- (void)layoutNativeWithX:(CGFloat)x Y:(CGFloat)y W:(CGFloat)w H:(CGFloat)h;

- (void)showNative;

- (void)hideNative;

- (void)removeNative;



@end


