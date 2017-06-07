//
//  ZoomAuthenticationBridge.h
//  ZoomAuthenticationBridge
//
//  Created by Gregory Perez on 6/5/17.
//  Copyright © 2017 FaceTec, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "../../../ZoomAuthentication.framework/Headers/ZoomAuthentication-Swift.h"

typedef void(^EnrollmentCallback)(ZoomEnrollmentResult* _Nonnull result);
typedef void(^AuthenticationCallback)(ZoomAuthenticationResult* _Nonnull result);
typedef void(^InitializeCallback)(BOOL success);

@interface ZoomAuthenticationBridge : NSObject

+(NSString*_Nonnull)getVersion;

+(ZoomSDKStatus)getStatus;

+(BOOL)isUserEnrolledWithUserID:(NSString * _Nonnull)userID;

+(void)initializeWithAppToken:(NSString * _Nonnull)appToken enrollmentStrategy:(ZoomStrategy)enrollmentStrategy completion:(InitializeCallback _Nonnull)completion;//

+(ZoomEnrollmentViewController* _Nonnull)prepareEnrollmentVCWithCallback:(EnrollmentCallback _Nonnull )callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;

+(ZoomAuthenticationViewController* _Nonnull)prepareAuthenticationVCWithCallback:(AuthenticationCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;

@end
