//
//  JPCSearchManager.h

//
//  Created by 洋吴 on 2019/5/7.
//

#import <Foundation/Foundation.h>
#import "JPCSettingModel.h"

NS_ASSUME_NONNULL_BEGIN

@interface JPCSearchManager : NSObject

+ (JPCSearchManager *)shareManager;

//获取当前APP配置文件
- (JPCSettingModel *_Nullable)getAppConfigByName:(NSString *)name;

//获取unit配置文件
- (JPCUnitModel *_Nullable)getUnitConfigByUnitId:(NSString *)unitID;

//获取本地配置APP文件
- (JPCSettingModel *_Nullable)getDefaultAppConfig;

//获取本地unitConfig
- (JPCUnitModel *_Nullable)getDefaultUnitConfigWithKey:(NSString *)key unitId:(NSString *_Nullable)unitid;

//获取当前聚合SDK name 空时取值""
- (NSString *)getMediationSDKName;

//获取当前聚合SDK name 空时取本地值
- (NSString *)getAppID;

//存储joypac placementID
- (void)putJPUnitID:(NSString *)unitID Key:(NSString *)key;

- (NSString *)getJPUnitIdByKey:(NSString *)key;

#pragma IV&RV
//获取上次展示时间以及游标
- (NSDictionary *)getLastShowTimeAndIndexByUnitId:(NSString *)unitId;

//存储上次展示时间及游标
- (void)putLastShowTime:(NSString *)time index:(NSString *)index unitId:(NSString *)unitId;


@end

NS_ASSUME_NONNULL_END
