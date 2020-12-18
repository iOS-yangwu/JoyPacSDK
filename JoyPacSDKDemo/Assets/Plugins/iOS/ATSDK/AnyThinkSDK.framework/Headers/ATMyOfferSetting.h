//
//  ATMyOfferSetting.h
//  AnyThinkSDK
//
//  Created by Martin Lau on 2019/9/23.
//  Copyright © 2019 Martin Lau. All rights reserved.
//

#import "ATOfferSetting.h"

@interface ATMyOfferSetting : ATOfferSetting
-(instancetype) initWithDictionary:(NSDictionary *)dictionary placementID:(NSString*)placementID;

@property(nonatomic, readwrite) NSTimeInterval resourceCacheTime;
//setting for banner
@property(nonatomic, readwrite) NSString *bannerSize;
@property(nonatomic, readwrite) BOOL showBannerCloseBtn;
@property(nonatomic, readwrite) NSInteger splashCountDownTime;
@property(nonatomic, readwrite) BOOL skipable;
@property(nonatomic, readwrite) NSInteger splashOrientation;

+(instancetype) mockSetting;
@end
