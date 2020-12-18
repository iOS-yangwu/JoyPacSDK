//
//  JPCAdvertManager+interstitial.h

//
//  Created by 洋吴 on 2019/5/5.
//

#import "JPCAdvertManager.h"

NS_ASSUME_NONNULL_BEGIN

@interface JPCAdvertManager (interstitial)

//Interstitial
- (void)loadInterstitialWithUnitId:(NSString*)unitId;

- (BOOL)isReadyInterstitialWithUnitId:(NSString *)unitId;

- (void)showInterstitialWithUnitId:(NSString *)unitId;

@end

NS_ASSUME_NONNULL_END
