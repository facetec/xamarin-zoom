//
//  ZoomAuthenticationBridge.m
//  ZoomAuthenticationBridge
//
//  Copyright © 2017 FaceTec, Inc. All rights reserved.
//

#import "ZoomAuthenticationBridge.h"
@import ZoomAuthentication;

@interface ZoomDelegate : NSObject<ZoomEnrollmentDelegate, ZoomAuthenticationDelegate>
@property(nonatomic) EnrollmentCallback enrollmentCallback;
@property(nonatomic) AuthenticationCallback authenticationCallback;

- (id) initWithEnrollmentCallback:(EnrollmentCallback)callback;
- (id) initWithAuthenticationCallback:(AuthenticationCallback)callback;
- (void) onZoomEnrollmentResultWithResult:(ZoomEnrollmentResult *)result;
- (void) onZoomAuthenticationResultWithResult:(ZoomAuthenticationResult * _Nonnull)result;

@end

ZoomDelegate* cachedDelegate;

@implementation ZoomAuthenticationBridge : NSObject

+(NSString*)getVersion {
    return [[Zoom sdk] version];
}

+(ZoomSDKStatus)getStatus {
    return [[Zoom sdk] getStatus];
}

+(void)setAuditTrailEnabled:(BOOL)enabled {
    [Zoom sdk].auditTrailEnabled = enabled;
}

+(BOOL)isUserEnrolledWithUserID:(NSString * _Nonnull)userID {
    return [[Zoom sdk] isUserEnrolledWithUserID:userID];
}

+(void)preload {
    [[Zoom sdk] preload];
}

+(void)initializeWithAppToken:(NSString * _Nonnull)appToken enrollmentStrategy:(ZoomStrategy)
    enrollmentStrategy completion:(InitializeCallback _Nonnull)completion {
    return [[Zoom sdk] initializeWithAppToken:appToken enrollmentStrategy:enrollmentStrategy completion:completion];
}

+(UIViewController* _Nonnull)createEnrollmentVCWithCallback:(EnrollmentCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret; {
    
    cachedDelegate = [[ZoomDelegate alloc] initWithEnrollmentCallback: callback];
    UIViewController* vc = [[Zoom sdk] createEnrollmentVCWithDelegate:cachedDelegate userID:userID applicationPerUserEncryptionSecret:applicationPerUserEncryptionSecret secret:nil];
    
    return vc;
}

+(UIViewController* _Nonnull)createAuthenticationVCWithCallback:(AuthenticationCallback _Nonnull)callback userID:(id)userID applicationPerUserEncryptionSecret:(id)applicationPerUserEncryptionSecret {
    
    cachedDelegate = [[ZoomDelegate alloc] initWithAuthenticationCallback: callback];
    UIViewController* vc = [[Zoom sdk] createAuthenticationVCWithDelegate:cachedDelegate userID:userID applicationPerUserEncryptionSecret:applicationPerUserEncryptionSecret];
    return vc;
}

+(void)setCustomizationWithInterfaceCustomization:(ZoomCustomization * _Nonnull)interfaceCustomization {
    [[Zoom sdk] setCustomizationWithInterfaceCustomization:interfaceCustomization];
}

@end

@implementation ZoomDelegate

- (id)initWithEnrollmentCallback:(EnrollmentCallback)callback {
    self.enrollmentCallback = callback;
    return self;
}

- (id)initWithAuthenticationCallback:(AuthenticationCallback)callback {
    self.authenticationCallback = callback;
    return self;
}

- (void)onZoomEnrollmentResultWithResult:(ZoomEnrollmentResult * _Nonnull)result {
    self.enrollmentCallback(result);
    cachedDelegate = nil;
    return;
}
- (void) onZoomAuthenticationResultWithResult:(ZoomAuthenticationResult * _Nonnull)result {
    self.authenticationCallback(result);
    cachedDelegate = nil;
    return;
}
@end

