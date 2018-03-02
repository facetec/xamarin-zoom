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

+(void)setAuditTrailEnabled:(BOOL)enabled;

+(BOOL)isUserEnrolledWithUserID:(NSString * _Nonnull)userID;

+(void)preload;

+(void)initializeWithAppToken:(NSString * _Nonnull)appToken enrollmentStrategy:(ZoomStrategy)enrollmentStrategy completion:(InitializeCallback _Nonnull)completion;

+(UIViewController* _Nonnull)createEnrollmentVCWithCallback:(EnrollmentCallback _Nonnull )callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;

+(UIViewController* _Nonnull)createAuthenticationVCWithCallback:(AuthenticationCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;

+(void)setCustomizationWithInterfaceCustomization:(ZoomCustomization * _Nonnull)interfaceCustomization;

@end
