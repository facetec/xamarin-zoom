using System;
using CoreAnimation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Zoom
{
	// @interface ZoomAuthenticationResult : NSObject
	[BaseType(typeof(NSObject))]
	[Protocol]
	[DisableDefaultCtor]
	interface ZoomAuthenticationResult
	{
		// @property (readonly, nonatomic) enum ZoomAuthenticationStatus status;
		[Export ("status")]
		ZoomAuthenticationStatus Status { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable secret;
		[NullAllowed, Export ("secret")]
		string Secret { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState faceAuthenticatorState;
		[Export ("faceAuthenticatorState")]
		ZoomAuthenticatorState FaceAuthenticatorState { get; }

		// @property (readonly, nonatomic, strong) ZoomFaceBiometricMetrics * _Nullable faceMetrics;
		[NullAllowed, Export ("faceMetrics", ArgumentSemantic.Strong)]
		ZoomFaceBiometricMetrics FaceMetrics { get; }

		// @property (readonly, nonatomic) NSInteger countOfFaceFailuresSinceLastSuccess;
		[Export ("countOfFaceFailuresSinceLastSuccess")]
		nint CountOfFaceFailuresSinceLastSuccess { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState fingerprintAuthenticatorState;
		[Export ("fingerprintAuthenticatorState")]
		ZoomAuthenticatorState FingerprintAuthenticatorState { get; }

		// @property (readonly, nonatomic, strong) ZoomFingerprintMetrics * _Nullable fingerprintMetrics;
		[NullAllowed, Export ("fingerprintMetrics", ArgumentSemantic.Strong)]
		ZoomFingerprintMetrics FingerprintMetrics { get; }

		// @property (readonly, nonatomic) NSInteger countOfFingerprintFailuresSinceLastSuccess;
		[Export ("countOfFingerprintFailuresSinceLastSuccess")]
		nint CountOfFingerprintFailuresSinceLastSuccess { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState pinAuthenticatorState;
		[Export ("pinAuthenticatorState")]
		ZoomAuthenticatorState PinAuthenticatorState { get; }

		// @property (readonly, nonatomic, strong) ZoomPinMetrics * _Nullable pinMetrics;
		[NullAllowed, Export ("pinMetrics", ArgumentSemantic.Strong)]
		ZoomPinMetrics PinMetrics { get; }

		// @property (readonly, nonatomic) NSInteger countOfPinFailuresSinceLastSuccess;
		[Export ("countOfPinFailuresSinceLastSuccess")]
		nint CountOfPinFailuresSinceLastSuccess { get; }

		// @property (readonly, nonatomic) NSInteger consecutiveAuthenticationFailures;
		[Export ("consecutiveAuthenticationFailures")]
		nint ConsecutiveAuthenticationFailures { get; }

		// @property (readonly, nonatomic) NSInteger consecutiveLockouts;
		[Export ("consecutiveLockouts")]
		nint ConsecutiveLockouts { get; }

		// @property (readonly, nonatomic, strong) NSDate * _Nonnull lockoutEndTime;
		[Export ("lockoutEndTime", ArgumentSemantic.Strong)]
		NSDate LockoutEndTime { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }
	}

	// @interface ZoomEnrollmentResult : NSObject
	[BaseType(typeof(NSObject))]
	[Protocol]
	[DisableDefaultCtor]
	interface ZoomEnrollmentResult
	{
		// @property (readonly, nonatomic) enum ZoomEnrollmentStatus status;
		[Export ("status")]
		ZoomEnrollmentStatus Status { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState faceEnrollmentState;
		[Export ("faceEnrollmentState")]
		ZoomAuthenticatorState FaceEnrollmentState { get; }

		// @property (readonly, nonatomic, strong) ZoomFaceBiometricMetrics * _Nullable faceMetrics;
		[NullAllowed, Export ("faceMetrics", ArgumentSemantic.Strong)]
		ZoomFaceBiometricMetrics FaceMetrics { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState fingerprintEnrollmentState;
		[Export ("fingerprintEnrollmentState")]
		ZoomAuthenticatorState FingerprintEnrollmentState { get; }

		// @property (readonly, nonatomic) enum ZoomAuthenticatorState pinEnrollmentState;
		[Export ("pinEnrollmentState")]
		ZoomAuthenticatorState PinEnrollmentState { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }
	}

	// @interface ZoomVerificationResult : NSObject
	[BaseType (typeof(NSObject))]
	[Protocol]
	[DisableDefaultCtor]
	interface ZoomVerificationResult
	{
		// @property (readonly, nonatomic) enum ZoomVerificationStatus status;
		[Export ("status")]
		ZoomVerificationStatus Status { get; }

		// @property (readonly, nonatomic, strong) ZoomFaceBiometricMetrics * _Nullable faceMetrics;
		[NullAllowed, Export ("faceMetrics", ArgumentSemantic.Strong)]
		ZoomFaceBiometricMetrics FaceMetrics { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }
	}

	// @interface ZoomFaceBiometricMetrics : NSObject
	[BaseType (typeof(NSObject))]
    [Protocol]
	[DisableDefaultCtor]
	interface ZoomFaceBiometricMetrics
	{
		// @property (readonly, copy, nonatomic) NSArray<UIImage *> * _Nullable auditTrail;
		[NullAllowed, Export ("auditTrail", ArgumentSemantic.Copy)]
		UIImage[] AuditTrail { get; }

		// @property (readonly, nonatomic) enum ZoomLivenessResult livenessResult;
		[Export ("livenessResult")]
		ZoomLivenessResult LivenessResult { get; }

		// @property (readonly, nonatomic) float livenessScore;
		[Export ("livenessScore")]
		float LivenessScore { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable zoomFacemap;
		[NullAllowed, Export ("zoomFacemap")]
		string ZoomFacemap { get; }
	}

	// @interface ZoomFingerprintMetrics : NSObject
	[BaseType (typeof(NSObject))]
    [Protocol]
	[DisableDefaultCtor]
	interface ZoomFingerprintMetrics
	{
		// @property (readonly, nonatomic) BOOL success;
		[Export ("success")]
		bool Success { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable errorString;
		[NullAllowed, Export ("errorString")]
		string ErrorString { get; }
	}

	// @interface ZoomPinMetrics : NSObject
	[BaseType (typeof(NSObject))]
    [Protocol]
	[DisableDefaultCtor]
	interface ZoomPinMetrics
	{
		// @property (readonly, nonatomic) BOOL success;
		[Export ("success")]
		bool Success { get; }

		// @property (readonly, nonatomic) NSInteger retryCount;
		[Export ("retryCount")]
		nint RetryCount { get; }
	}

	// typedef void (^EnrollmentCallback)(ZoomEnrollmentResult * _Nonnull);
	delegate void EnrollmentCallback(ZoomEnrollmentResult result);

	// typedef void (^AuthenticationCallback)(ZoomAuthenticationResult * _Nonnull);
	delegate void AuthenticationCallback(ZoomAuthenticationResult result);

	// typedef void (^VerificationCallback)(ZoomVerificationResult * _Nonnull);
	delegate void VerificationCallback (ZoomVerificationResult result);

	// typedef void (^InitializeCallback)(BOOL);
	delegate void InitializeCallback(bool success);

	// @interface ZoomAuthenticationBridge : NSObject
	[BaseType(typeof(NSObject), Name="ZoomAuthenticationBridge")]
	interface Sdk
	{
		// +(NSString * _Nonnull)getVersion;
		[Static]
		[Export ("getVersion")]
		string Version { get; }

		// +(ZoomSDKStatus)getStatus;
		[Static]
		[Export ("getStatus")]
		ZoomSDKStatus Status { get; }

		// +(void)setAuditTrailEnabled:(BOOL)enabled;
		[Static]
		[Export ("setAuditTrailEnabled:")]
		void SetAuditTrailEnabled (bool enabled);

		// +(BOOL)isUserEnrolledWithUserID:(NSString * _Nonnull)userID;
		[Static]
		[Export ("isUserEnrolledWithUserID:")]
		bool IsUserEnrolled (string userID);

		// +(void)preload;
		[Static]
		[Export ("preload")]
		void Preload ();

		// +(void)initializeWithAppToken:(NSString * _Nonnull)appToken enrollmentStrategy:(ZoomStrategy)enrollmentStrategy completion:(InitializeCallback _Nonnull)completion;
		[Static]
		[Export ("initializeWithAppToken:enrollmentStrategy:completion:")]
		void Initialize (string appToken, ZoomStrategy enrollmentStrategy, InitializeCallback completion);

		// +(UIViewController * _Nonnull)createEnrollmentVCWithCallback:(EnrollmentCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;
		[Static]
		[Export ("createEnrollmentVCWithCallback:userID:applicationPerUserEncryptionSecret:")]
		UIViewController CreateEnrollmentVC(EnrollmentCallback callback, string userID, string applicationPerUserEncryptionSecret);

		// +(UIViewController * _Nonnull)createAuthenticationVCWithCallback:(AuthenticationCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;
		[Static]
		[Export ("createAuthenticationVCWithCallback:userID:applicationPerUserEncryptionSecret:")]
		UIViewController CreateAuthenticationVC (AuthenticationCallback callback, string userID, string applicationPerUserEncryptionSecret);

		// +(UIViewController * _Nonnull)createVerificationVCWithDelegate:(VerificationCallback _Nonnull)callback verificationImages:(NSArray<UIImage *> * _Nullable)verificationImages;
		[Static]
		[Export ("createVerificationVCWithDelegate:verificationImages:")]
		UIViewController CreateVerificationVC (VerificationCallback callback, [NullAllowed] UIImage[] verificationImages);

		// +(void)setCustomizationWithInterfaceCustomization:(ZoomCustomization * _Nonnull)interfaceCustomization;
		[Static]
		[Export ("setCustomizationWithInterfaceCustomization:")]
		void SetCustomization (ZoomCustomization interfaceCustomization);
	}

	// @interface ZoomCustomization : NSObject
	[BaseType (typeof(NSObject), Name="_TtC18ZoomAuthentication17ZoomCustomization")]
    [Protocol]
	interface ZoomCustomization
	{
		// @property (nonatomic) BOOL showAuthenticationFactorsTabBar;
		[Export ("showAuthenticationFactorsTabBar")]
		bool ShowAuthenticationFactorsTabBar { get; set; }

		// @property (nonatomic) BOOL showZoomIntro;
		[Export ("showZoomIntro")]
		bool ShowZoomIntro { get; set; }

		// @property (nonatomic) BOOL showPreEnrollmentScreen;
		[Export ("showPreEnrollmentScreen")]
		bool ShowPreEnrollmentScreen { get; set; }

		// @property (nonatomic) BOOL showUserLockedScreen;
		[Export ("showUserLockedScreen")]
		bool ShowUserLockedScreen { get; set; }

		// @property (nonatomic) BOOL showSuccessScreen;
		[Export ("showSuccessScreen")]
		bool ShowSuccessScreen { get; set; }

		// @property (nonatomic) BOOL showFailureScreen;
		[Export ("showFailureScreen")]
		bool ShowFailureScreen { get; set; }

		// @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull mainBackgroundColors;
		[Export ("mainBackgroundColors", ArgumentSemantic.Copy)]
		UIColor[] MainBackgroundColors { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull mainForegroundColor;
		[Export ("mainForegroundColor", ArgumentSemantic.Strong)]
		UIColor MainForegroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull buttonTextNormalColor;
		[Export ("buttonTextNormalColor", ArgumentSemantic.Strong)]
		UIColor ButtonTextNormalColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull buttonBackgroundNormalColor;
		[Export ("buttonBackgroundNormalColor", ArgumentSemantic.Strong)]
		UIColor ButtonBackgroundNormalColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull buttonTextHighlightColor;
		[Export ("buttonTextHighlightColor", ArgumentSemantic.Strong)]
		UIColor ButtonTextHighlightColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull buttonBackgroundHighlightColor;
		[Export ("buttonBackgroundHighlightColor", ArgumentSemantic.Strong)]
		UIColor ButtonBackgroundHighlightColor { get; set; }

		// @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull resultsScreenBackgroundColor;
		[Export ("resultsScreenBackgroundColor", ArgumentSemantic.Copy)]
		UIColor[] ResultsScreenBackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull resultsScreenForegroundColor;
		[Export ("resultsScreenForegroundColor", ArgumentSemantic.Strong)]
		UIColor ResultsScreenForegroundColor { get; set; }

		// @property (nonatomic, strong) CAGradientLayer * _Nonnull progressBarColor;
		[Export ("progressBarColor", ArgumentSemantic.Strong)]
		CAGradientLayer ProgressBarColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull progressTextColor;
		[Export ("progressTextColor", ArgumentSemantic.Strong)]
		UIColor ProgressTextColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull progressSpinnerColor1;
		[Export ("progressSpinnerColor1", ArgumentSemantic.Strong)]
		UIColor ProgressSpinnerColor1 { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull progressSpinnerColor2;
		[Export ("progressSpinnerColor2", ArgumentSemantic.Strong)]
		UIColor ProgressSpinnerColor2 { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull tabBackgroundColor;
		[Export ("tabBackgroundColor", ArgumentSemantic.Strong)]
		UIColor TabBackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull tabBackgroundSelectedColor;
		[Export ("tabBackgroundSelectedColor", ArgumentSemantic.Strong)]
		UIColor TabBackgroundSelectedColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull tabTextColor;
		[Export ("tabTextColor", ArgumentSemantic.Strong)]
		UIColor TabTextColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull tabTextSelectedColor;
		[Export ("tabTextSelectedColor", ArgumentSemantic.Strong)]
		UIColor TabTextSelectedColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull tabTextSuccessColor;
		[Export ("tabTextSuccessColor", ArgumentSemantic.Strong)]
		UIColor TabTextSuccessColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull tabBackgroundSuccessColor;
		[Export ("tabBackgroundSuccessColor", ArgumentSemantic.Strong)]
		UIColor TabBackgroundSuccessColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull fingerprintSuccessColor;
		[Export ("fingerprintSuccessColor", ArgumentSemantic.Strong)]
		UIColor FingerprintSuccessColor { get; set; }

		// @property (nonatomic, strong) UIImage * _Nullable brandingLogo;
		[NullAllowed, Export ("brandingLogo", ArgumentSemantic.Strong)]
		UIImage BrandingLogo { get; set; }
	}

}
