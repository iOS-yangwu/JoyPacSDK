//
//  JPCUnitModelFactory.h
//  JoyPacSDK
//
//  Created by 洋吴 on 2020/5/22.
//  Copyright © 2020 洋吴. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "JPCSettingModel.h"

NS_ASSUME_NONNULL_BEGIN

@interface JPCUnitModelFactory : NSObject

+ (JPCUnitModelFactory *)factory;

- (JPCUnitModel *_Nullable)unitModelWithUnitId:(NSString *)unitId key:(NSString *)key;


@end

NS_ASSUME_NONNULL_END
