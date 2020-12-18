//
//  JPDefaultConfiguration.h
//  Joypac_Unity_SDK
//
//  Created by 洋吴 on 2020/5/12.
//  Copyright © 2020 洋吴. All rights reserved.
//

#import <Foundation/Foundation.h>

extern NSString *const kDefaultConfigKey;


@interface JPCDefaultConfiguration : NSObject

+ (void) setupDefaultConfiguration;

+ (NSString *_Nullable)getADConfigurationByKey:(NSString *_Nullable)key;


@end


