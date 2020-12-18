//
//  JPCUtils.h
//  JoyPacSDK
//
//  Created by 洋吴 on 2020/6/11.
//  Copyright © 2020 洋吴. All rights reserved.
//

#import <UIKit/UIKit.h>


NS_ASSUME_NONNULL_BEGIN

typedef NSString *kNativeStyle NS_STRING_ENUM;

FOUNDATION_EXPORT kNativeStyle const kNativeStyleOrigin;

typedef NSString *kBannerStyle NS_STRING_ENUM;
FOUNDATION_EXPORT kBannerStyle const kBannerStyleBanner;
FOUNDATION_EXPORT kBannerStyle const kBannerStyleNativeBanner;

#define UI_IS_IPAD (UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad)
#define UI_IS_IPHONE (UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPhone)
#define UI_IS_RETINA ([[UIScreen mainScreen] scale] >= 2.0)

#define SCREENSIZE_IS_35  (UI_IS_IPHONE && [[UIScreen mainScreen] bounds].size.height < 568.0)
#define SCREENSIZE_IS_40  (UI_IS_IPHONE && [[UIScreen mainScreen] bounds].size.height == 568.0)
#define SCREENSIZE_IS_47  (UI_IS_IPHONE && [[UIScreen mainScreen] bounds].size.height == 667.0)
#define SCREENSIZE_IS_55  (UI_IS_IPHONE && [[UIScreen mainScreen] bounds].size.height == 736.0 || [[UIScreen mainScreen] bounds].size.width == 736.0)

//iPHoneXr
#define SCREENSIZE_IS_XR ([UIScreen instancesRespondToSelector:@selector(currentMode)] ? CGSizeEqualToSize(CGSizeMake(750, 1624), [[UIScreen mainScreen] currentMode].size) && !UI_IS_IPAD : NO)

//iPHoneX、iPHoneXs
#define SCREENSIZE_IS_X ([UIScreen instancesRespondToSelector:@selector(currentMode)] ? CGSizeEqualToSize(CGSizeMake(1125, 2436), [[UIScreen mainScreen] currentMode].size) && !UI_IS_IPAD : NO)
#define SCREENSIZE_IS_XS ([UIScreen instancesRespondToSelector:@selector(currentMode)] ? CGSizeEqualToSize(CGSizeMake(1125, 2436), [[UIScreen mainScreen] currentMode].size) && !UI_IS_IPAD : NO)

//iPhoneXs Max
#define SCREENSIZE_IS_XS_MAX ([UIScreen instancesRespondToSelector:@selector(currentMode)] ? CGSizeEqualToSize(CGSizeMake(1242, 2688), [[UIScreen mainScreen] currentMode].size) && !UI_IS_IPAD : NO)

#define IS_IPhoneX_All ([UIScreen mainScreen].bounds.size.height == 812 || [UIScreen mainScreen].bounds.size.height == 896)

//iphone 7p 8p
#define SCREENSIZE_IS_8P ([UIScreen instancesRespondToSelector:@selector(currentMode)] ? CGSizeEqualToSize(CGSizeMake(1242,2208), [[UIScreen mainScreen] currentMode].size) && !UI_IS_IPAD : NO)

//iphone 7 8 6sp
#define SCREENSIZE_IS_6SP ([UIScreen instancesRespondToSelector:@selector(currentMode)] ? CGSizeEqualToSize(CGSizeMake(1125,2001), [[UIScreen mainScreen] currentMode].size) && !UI_IS_IPAD : NO)

@interface JPCUtils : NSObject

+ (CGRect) transformationToOCCoordinates:(CGRect)frame nativeStyle:(kNativeStyle)style;

+ (NSInteger)compareVersion:(NSString *)version1 toVersion:(NSString *)version2;

@end

NS_ASSUME_NONNULL_END
