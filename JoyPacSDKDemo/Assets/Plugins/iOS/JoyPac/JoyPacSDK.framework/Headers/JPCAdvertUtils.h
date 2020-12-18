//
//  JPCAdvertUtils.h
//  JoyPacSDK
//
//  Created by 洋吴 on 2020/5/22.
//  Copyright © 2020 洋吴. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "JPCSettingModel.h"


NS_ASSUME_NONNULL_BEGIN

@interface JPCAdvertUtils : NSObject

+ (JPCUnitModel *)getModelWithUnitId:(NSString *)unitId adType:(NSString *)type;

+ (NSString *)getAdOrderWithIndex:(int)index adOrder:(NSString *)adOrder;


@end

NS_ASSUME_NONNULL_END
