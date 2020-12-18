//
//  JPCConst.h

//
//  Created by 洋吴 on 2019/3/14.
//

#ifndef JPCConst_h
#define JPCConst_h

#define DLog(fmt, ...) [JPCLogManager customLogWithFunction:__FUNCTION__ result:[NSString stringWithFormat:fmt, ##__VA_ARGS__]]

//字符串是否为空
#define kISNullString(str) ([str isKindOfClass:[NSNull class]] || str == nil || [str length] < 1 ? YES : NO )
//数组是否为空
#define kISNullArray(array) (array == nil || [array isKindOfClass:[NSNull class]] || array.count == 0 ||[array isEqual:[NSNull null]])
//字典是否为空
#define kISNullDict(dic) (dic == nil || [dic isKindOfClass:[NSNull class]] || dic.allKeys == 0 || [dic isEqual:[NSNull null]])
//是否是空对象
#define kISNullObject(_object) (_object == nil \
|| [_object isKindOfClass:[NSNull class]] \
|| ([_object respondsToSelector:@selector(length)] && [(NSData *)_object length] == 0) \
|| ([_object respondsToSelector:@selector(count)] && [(NSArray *)_object count] == 0))
//判断对象是否为空,为空则返回默认值
#define D_StringFix(_value,_default) ([_value isKindOfClass:[NSNull class]] || !_value || _value == nil || [_value isEqualToString:@"(null)"] || [_value isEqualToString:@"<null>"] || [_value isEqualToString:@""] || [_value length] == 0)?_default:_value

typedef enum {
    BannerAlignLeft               = 1 << 0,
    BannerAlignHorizontalCenter   = 1 << 1,
    BannerAlignRight              = 1 << 2,
    BannerAlignTop                = 1 << 3,
    BannerAlignVerticalCenter     = 1 << 4,
    BannerAlignBottom             = 1 << 5,
}BannerAlign;



#endif /* JPCConst_h */
