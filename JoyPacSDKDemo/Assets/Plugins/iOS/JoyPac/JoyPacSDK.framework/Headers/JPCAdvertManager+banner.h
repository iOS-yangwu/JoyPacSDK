//
//  JPCAdvertManager+banner.h

//
//  Created by 洋吴 on 2019/5/9.
//

#import "JPCAdvertManager.h"

NS_ASSUME_NONNULL_BEGIN

@interface JPCAdvertManager (banner)

//Banner
- (void)loadBannerWithUnitId:(NSString *)unitId;

- (BOOL)isReadyBannerWithUnitId:(NSString *)unitId;

- (void)showBannerWithUnitId:(NSString *)unitId;

- (void)setBannerAlign:(BannerAlign)align offset:(CGPoint)offset;

- (void)hideBanner;

- (void)removeBanner;


@end

NS_ASSUME_NONNULL_END
