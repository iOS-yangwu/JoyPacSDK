//
//  JPCAdvertManager+rewardVideo.h

//
//  Created by 洋吴 on 2019/5/6.
//

#import "JPCAdvertManager.h"

NS_ASSUME_NONNULL_BEGIN

@interface JPCAdvertManager (rewardVideo)

//Video
- (void)loadRewardVideoWithUnitId:(NSString*)unitId;

- (BOOL)isReadVideoWithUnitId:(NSString *)unitId;

- (void)showVideoWithUnitId:(NSString *)unitId;

@end

NS_ASSUME_NONNULL_END
