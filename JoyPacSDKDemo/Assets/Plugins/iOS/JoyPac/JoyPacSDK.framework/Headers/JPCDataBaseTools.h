//
//  JoypacDataBaseTools.h

//
//  Created by 洋吴 on 2019/3/18.
//

#import <Foundation/Foundation.h>

extern NSString *const kDBNameKey;
extern NSString *const kTableNameKey;

@interface JPCDataBaseTools : NSObject

+ (instancetype)dbTools;

- (void)putObject:(id)object withId:(NSString *)objectId;

- (id)getObjectById:(NSString *)objectId;

- (void)putString:(NSString *)string withId:(NSString *)stringId;

- (NSString *)getStringById:(NSString *)stringId;

- (void)putNumber:(NSNumber *)number withId:(NSString *)numberId;

- (NSNumber *)getNumberById:(NSString *)numberId;

- (void)deleteObjectById:(NSString *)objectId;


@end

