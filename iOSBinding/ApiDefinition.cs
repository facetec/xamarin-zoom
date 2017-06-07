using System;
using CoreAnimation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Zoom
{
	// @interface ZoomAuthenticationResult : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ZoomAuthenticationResult
	{
		// @property (readonly, nonatomic) enum ZoomAuthenticationStatus status;
		[Export("status")]
		ZoomAuthenticationStatus Status { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState faceAuthenticatorState;
		[Export("faceAuthenticatorState")]
		ZoomAuthenticatorState FaceAuthenticatorState { get; }

		// @property (readonly, nonatomic) NSInteger countOfFaceFailuresSinceLastSuccess;
		[Export("countOfFaceFailuresSinceLastSuccess")]
		nint CountOfFaceFailuresSinceLastSuccess { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState fingerprintAuthenticatorState;
		[Export("fingerprintAuthenticatorState")]
		ZoomAuthenticatorState FingerprintAuthenticatorState { get; }

		// @property (readonly, nonatomic) NSInteger countOfFingerprintFailuresSinceLastSuccess;
		[Export("countOfFingerprintFailuresSinceLastSuccess")]
		nint CountOfFingerprintFailuresSinceLastSuccess { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState pinAuthenticatorState;
		[Export("pinAuthenticatorState")]
		ZoomAuthenticatorState PinAuthenticatorState { get; }

		// @property (readonly, nonatomic) NSInteger countOfPinFailuresSinceLastSuccess;
		[Export("countOfPinFailuresSinceLastSuccess")]
		nint CountOfPinFailuresSinceLastSuccess { get; }

		// @property (readonly, nonatomic) NSInteger consecutiveAuthenticationFailures;
		[Export("consecutiveAuthenticationFailures")]
		nint ConsecutiveAuthenticationFailures { get; }

		// @property (readonly, nonatomic) NSInteger consecutiveLockouts;
		[Export("consecutiveLockouts")]
		nint ConsecutiveLockouts { get; }
	}

	// @interface ZoomEnrollmentResult : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ZoomEnrollmentResult
	{
		// @property (readonly, nonatomic) enum ZoomEnrollmentStatus status;
		[Export("status")]
		ZoomEnrollmentStatus Status { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState faceEnrollmentState;
		[Export("faceEnrollmentState")]
		ZoomAuthenticatorState FaceEnrollmentState { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState fingerprintEnrollmentState;
		[Export("fingerprintEnrollmentState")]
		ZoomAuthenticatorState FingerprintEnrollmentState { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState pinEnrollmentState;
		[Export("pinEnrollmentState")]
		ZoomAuthenticatorState PinEnrollmentState { get; }
	}

	// typedef void (^EnrollmentCallback)(ZoomEnrollmentResult * _Nonnull);
	delegate void EnrollmentCallback(ZoomEnrollmentResult result);

	// typedef void (^AuthenticationCallback)(ZoomAuthenticationResult * _Nonnull);
	delegate void AuthenticationCallback(ZoomAuthenticationResult result);

	// typedef void (^InitializeCallback)(BOOL);
	delegate void InitializeCallback(bool success);

	// @interface ZoomAuthenticationBridge : NSObject
	[BaseType(typeof(NSObject), Name="ZoomAuthenticationBridge")]
	interface Sdk
	{
		// +(NSString * _Nonnull)getVersion;
		[Static]
		[Export("getVersion")]
		string Version { get; }

		// +(ZoomSDKStatus)getStatus;
		[Static]
		[Export("getStatus")]
		ZoomSDKStatus Status { get; }

		// +(BOOL)isUserEnrolledWithUserID:(NSString * _Nonnull)userID;
		[Static]
		[Export("isUserEnrolledWithUserID:")]
		bool IsUserEnrolled(string userID);

		// +(void)initializeWithAppToken:(NSString * _Nonnull)appToken enrollmentStrategy:(ZoomStrategy)enrollmentStrategy completion:(InitializeCallback _Nonnull)completion;
		[Static]
		[Export("initializeWithAppToken:enrollmentStrategy:completion:")]
		void Initialize(string appToken, ZoomStrategy enrollmentStrategy, InitializeCallback completion);

		// +(ZoomEnrollmentViewController * _Nonnull)prepareEnrollmentVCWithCallback:(EnrollmentCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;
		[Static]
		[Export("prepareEnrollmentVCWithCallback:userID:applicationPerUserEncryptionSecret:")]
		UIViewController PrepareEnrollmentVC(EnrollmentCallback callback, string userID, string applicationPerUserEncryptionSecret);

		// +(ZoomAuthenticationViewController * _Nonnull)prepareAuthenticationVCWithCallback:(AuthenticationCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;
		[Static]
		[Export("prepareAuthenticationVCWithCallback:userID:applicationPerUserEncryptionSecret:")]
		UIViewController PrepareAuthenticationVC(AuthenticationCallback callback, string userID, string applicationPerUserEncryptionSecret);

	}
}
