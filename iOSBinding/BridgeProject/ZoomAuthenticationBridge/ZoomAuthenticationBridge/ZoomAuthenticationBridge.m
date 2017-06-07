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

+ (NSString*)getVersion {
    return [[Zoom sdk] version];
}

+(ZoomSDKStatus)getStatus {
    return [[Zoom sdk] getStatus];
}

+ (BOOL)isUserEnrolledWithUserID:(NSString * _Nonnull)userID {
    return [[Zoom sdk] isUserEnrolledWithUserID:userID];
}

+(void)initializeWithAppToken:(NSString * _Nonnull)appToken enrollmentStrategy:(ZoomStrategy)
    enrollmentStrategy completion:(InitializeCallback _Nonnull)completion {
    
    return [[Zoom sdk] initializeWithAppToken:appToken enrollmentStrategy:enrollmentStrategy completion:completion];
}

+(ZoomEnrollmentViewController* _Nonnull)prepareEnrollmentVCWithCallback:(EnrollmentCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret; {
    
    ZoomEnrollmentViewController* vc = [[Zoom sdk] createEnrollmentVC];
    cachedDelegate = [[ZoomDelegate alloc] initWithEnrollmentCallback: callback];
    [vc prepareForEnrollmentWithDelegate:cachedDelegate userID:userID applicationPerUserEncryptionSecret:applicationPerUserEncryptionSecret secret:nil];
    
    return vc;
}

+(ZoomAuthenticationViewController* _Nonnull)prepareAuthenticationVCWithCallback:(AuthenticationCallback _Nonnull)callback userID:(id)userID applicationPerUserEncryptionSecret:(id)applicationPerUserEncryptionSecret {
    
    ZoomAuthenticationViewController* vc = [[Zoom sdk] createAuthenticationVC];
    cachedDelegate = [[ZoomDelegate alloc] initWithAuthenticationCallback: callback];
    [vc prepareForAuthenticationWithDelegate:cachedDelegate userID:userID applicationPerUserEncryptionSecret:applicationPerUserEncryptionSecret];
    
    return vc;
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

