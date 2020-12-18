//
//  JPCDataReportManager.h

//
//  Created by 洋吴 on 2019/5/5.
//

#import <Foundation/Foundation.h>
#import "JPCHTTPParameter.h"

extern NSString *const kDataReportURLKey;

@interface JPCDataReportManager : NSObject

+ (JPCDataReportManager *) manager;

- (void) setReportEnvironment:(NSString *)environment;

- (void)reportWithType:(DataReportType)type placementId:(NSString *)placementId reson:(NSString *)reson result:(NSString *)result adType:(NSString *)adType extra1:(NSString *)extra1 extra2:(NSString *)extra2 extra3:(NSString *)extra3;


- (void)reportEventWithEventType:(NSString *)eventType eventSort:(NSString *)eventSort position:(NSString *)position eventExtra:(NSString *)eventExt;

//IAP 代码注入
- (void)reportIAPByEventType:(NSString *)eventType pId:(NSString *)pId failReason:(NSString *)failReason;


@end


