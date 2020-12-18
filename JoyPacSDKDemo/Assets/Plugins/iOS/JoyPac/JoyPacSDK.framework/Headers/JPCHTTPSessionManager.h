//
//  JPCNetWorkTools.h

//
//  Created by 洋吴 on 2019/3/14.
//

#import <Foundation/Foundation.h>
#import "AFNetworking.h"


@interface JPCHTTPSessionManager : NSObject

@property (nonatomic,strong)AFHTTPSessionManager * _Nullable manager;

+ (JPCHTTPSessionManager *_Nullable)manager;

- (void)POST:(NSString *_Nonnull)url
      params:(NSDictionary *_Nullable)params
timeoutInterval:(NSString *_Nullable)timeoutInterval
     success:(void (^_Nullable)(NSURLSessionDataTask * _Nonnull task, id _Nullable responseObj))success
     failure:(void (^_Nullable)(NSError * _Nullable error))failure;

- (void)GET:(NSString *_Nullable)url
     params:(NSDictionary *_Nullable)params
timeoutInterval:(NSString *_Nullable)timeoutInterval
    success:(void (^_Nullable)(NSURLSessionDataTask * _Nonnull task,id _Nullable responseObj))success
    failure:(void (^_Nullable)(NSError * _Nullable error))failure;

@end

