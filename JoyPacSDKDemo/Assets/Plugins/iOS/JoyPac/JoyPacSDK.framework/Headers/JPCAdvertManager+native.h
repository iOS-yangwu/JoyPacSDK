//
//  JPCAdvertManager+native.h

//
//  Created by 洋吴 on 2019/5/8.
//

#import "JPCAdvertManager.h"

NS_ASSUME_NONNULL_BEGIN

@interface JPCAdvertManager (native)

//Native
- (void)loadNativeAdWithUnitId:(NSString *)unitId nativeFrame:(CGRect)frame;

- (BOOL)isReadyNativeAdWithUnitId:(NSString *)unitId;

- (void)layoutNativeWithX:(CGFloat)x Y:(CGFloat)y W:(CGFloat)w H:(CGFloat)h;

- (void)showNativeWithUnitId:(NSString *)unitId;

- (void)hideNative;

- (void)removeNative;

@end

NS_ASSUME_NONNULL_END
