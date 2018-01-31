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
	[Protocol]
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

        // +(void)initializeWithAppToken:(NSString * _Nonnull)appToken enrollmentStrategy:(ZoomStrategy)enrollmentStrategy completion:(InitializeCallback _Nonnull)completion;
        [Static]
        [Export("initializeWithAppToken:enrollmentStrategy:interfaceCustomization:completion:")]
        void Initialize(string appToken, ZoomStrategy enrollmentStrategy, ZoomCustomization customization, InitializeCallback completion);

		// +(ZoomEnrollmentViewController * _Nonnull)prepareEnrollmentVCWithCallback:(EnrollmentCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;
		[Static]
		[Export("prepareEnrollmentVCWithCallback:userID:applicationPerUserEncryptionSecret:")]
		UIViewController PrepareEnrollmentVC(EnrollmentCallback callback, string userID, string applicationPerUserEncryptionSecret);

		// +(ZoomAuthenticationViewController * _Nonnull)prepareAuthenticationVCWithCallback:(AuthenticationCallback _Nonnull)callback userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret;
		[Static]
		[Export("prepareAuthenticationVCWithCallback:userID:applicationPerUserEncryptionSecret:")]
		UIViewController PrepareAuthenticationVC(AuthenticationCallback callback, string userID, string applicationPerUserEncryptionSecret);

	}

	// @interface ZoomCustomization : NSObject
	[BaseType (typeof(NSObject), Name="_TtC18ZoomAuthentication17ZoomCustomization")]
    [Protocol]
	interface ZoomCustomization
	{
		// @property (nonatomic) BOOL showAuthenticationFactorsTabBar;
		[Export ("showAuthenticationFactorsTabBar")]
		bool ShowAuthenticationFactorsTabBar { get; set; }

		// @property (nonatomic) BOOL showAuthenticationIntroLogo;
		[Export ("showAuthenticationIntroLogo")]
		bool ShowAuthenticationIntroLogo { get; set; }

		// @property (nonatomic) BOOL showEnrollmentIntro;
		[Export ("showEnrollmentIntro")]
		bool ShowEnrollmentIntro { get; set; }

		// @property (nonatomic) BOOL showUserLockedScreen;
		[Export ("showUserLockedScreen")]
		bool ShowUserLockedScreen { get; set; }

		// @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull mainBackgroundColors;
		[Export ("mainBackgroundColors", ArgumentSemantic.Copy)]
		UIColor[] MainBackgroundColors { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull mainForegroundColor;
		[Export ("mainForegroundColor", ArgumentSemantic.Strong)]
		UIColor MainForegroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull buttonTextNormalColor;
		[Export ("buttonTextNormalColor", ArgumentSemantic.Strong)]
		UIColor ButtonTextNormalColor { get; set; }

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
