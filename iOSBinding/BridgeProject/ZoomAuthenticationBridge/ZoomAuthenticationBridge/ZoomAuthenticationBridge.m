//
//  ZoomAuthenticationBridge.m
//  ZoomAuthenticationBridge
//
//  Copyright © 2017 FaceTec, Inc. All rights reserved.
//

#import "ZoomAuthenticationBridge.h"
@import ZoomAuthentication;

@interface ZoomDelegate : NSObject<ZoomEnrollmentDelegate, ZoomAuthenticationDelegate, ZoomVerificationDelegate>
@property(nonatomic) EnrollmentCallback enrollmentCallback;
@property(nonatomic) AuthenticationCallback authenticationCallback;
@property(nonatomic) VerificationCallback verificationCallback;

- (id) initWithEnrollmentCallback:(EnrollmentCallback)callback;
- (id) initWithAuthenticationCallback:(AuthenticationCallback)callback;
- (id) initWithVerificationCallback:(VerificationCallback)callback;
- (void) onZoomEnrollmentResultWithResult:(ZoomEnrollmentResult * _Nonnull)result;
- (void) onZoomAuthenticationResultWithResult:(ZoomAuthenticationResult * _Nonnull)result;
- (void) onZoomVerificationResultWithResult:(ZoomVerificationResult * _Nonnull)result;

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

+(UIViewController* _Nonnull)createEnrollmentVCWithCallback:(EnrollmentCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret secret:(NSString * _Nullable)secret {
    
    return [self createEnrollmentVCWithCallback:callback userID:userID applicationPerUserEncryptionSecret:applicationPerUserEncryptionSecret secret:secret verificationImages:nil retrieveZoomBiometric:false];
}

+(UIViewController * _Nonnull)createEnrollmentVCWithCallback:(EnrollmentCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret secret:(NSString * _Nullable)secret verificationImages:(NSArray<UIImage *> * _Nullable)verificationImages retrieveZoomBiometric:(BOOL)retrieveZoomBiometric {
    
    cachedDelegate = [[ZoomDelegate alloc] initWithEnrollmentCallback: callback];
    
    UIViewController* vc = [[Zoom sdk] createEnrollmentVCWithDelegate:cachedDelegate userID:userID applicationPerUserEncryptionSecret:applicationPerUserEncryptionSecret secret:nil verificationImages:verificationImages retrieveZoomBiometric:retrieveZoomBiometric];
    return vc;
}

+(UIViewController* _Nonnull)createAuthenticationVCWithCallback:(AuthenticationCallback _Nonnull)callback userID:(id)userID applicationPerUserEncryptionSecret:(id)applicationPerUserEncryptionSecret {
    return [self createAuthenticationVCWithCallback:callback userID:userID applicationPerUserEncryptionSecret:applicationPerUserEncryptionSecret verificationImages:nil retrieveZoomBiometric:false];
}

+(UIViewController * _Nonnull)createAuthenticationVCWithCallback:(AuthenticationCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret verificationImages:(NSArray<UIImage *> * _Nullable)verificationImages retrieveZoomBiometric:(BOOL)retrieveZoomBiometric {
    
    cachedDelegate = [[ZoomDelegate alloc] initWithAuthenticationCallback: callback];
    
    UIViewController* vc = [[Zoom sdk] createAuthenticationVCWithDelegate:cachedDelegate userID:userID applicationPerUserEncryptionSecret:applicationPerUserEncryptionSecret verificationImages:verificationImages retrieveZoomBiometric:retrieveZoomBiometric];
    return vc;
}

+(UIViewController * _Nonnull)createVerificationVCWithDelegate:(VerificationCallback _Nonnull)callback verificationImages:(NSArray<UIImage *> * _Nullable)verificationImages {
    cachedDelegate = [[ZoomDelegate alloc] initWithVerificationCallback: callback];
    UIViewController *vc = [[Zoom sdk] createVerificationVCWithDelegate:cachedDelegate verificationImages:verificationImages retrieveZoomBiometric:false];
    
    return vc;
}

+(void)setCustomizationWithInterfaceCustomization:(ZoomCustomization * _Nonnull)interfaceCustomization {
    [[Zoom sdk] setCustomizationWithInterfaceCustomization:interfaceCustomization];
}

+(void)setHybridEncryptionKeyWithPublicKey:(NSString * _Nonnull)publicKey {
    return [[Zoom sdk] setHybridEncryptionKeyWithPublicKey: publicKey];
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

- (id)initWithVerificationCallback:(VerificationCallback)callback {
    self.verificationCallback = callback;
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
- (void) onZoomVerificationResultWithResult:(ZoomVerificationResult * _Nonnull)result {
    self.verificationCallback(result);
    cachedDelegate = nil;
    return;
}
@end

