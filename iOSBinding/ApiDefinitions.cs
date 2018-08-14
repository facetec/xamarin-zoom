using System;
using CoreAnimation;
using Foundation;
using ObjCRuntime;
using UIKit;
using ZoomAuthentication;

namespace ZoomAuthentication
{
	// @interface Zoom : NSObject
	[BaseType (typeof(NSObject))]
	interface Zoom
	{
		// @property (readonly, nonatomic, strong, class) id<ZoomSDKProtocol> _Nonnull sdk;
		[Static]
		[Export ("sdk", ArgumentSemantic.Strong)]
		IZoomSDKProtocol Sdk { get; }
	}

	// @protocol ZoomAuthenticationDelegate
    [BaseType(typeof(NSObject))]
	[Protocol, Model]
	interface ZoomAuthenticationDelegate
	{
		// @required -(void)onZoomAuthenticationResultWithResult:(ZoomAuthenticationResult * _Nonnull)result;
		[Abstract]
		[Export ("onZoomAuthenticationResultWithResult:")]
		void OnZoomAuthenticationResult (ZoomAuthenticationResult result);
	}

    interface IZoomAuthenticationDelegate { }

	// @interface ZoomAuthenticationResult : NSObject
	[BaseType (typeof(NSObject))]
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

		// @property (readonly, nonatomic) NSInteger consecutiveAuthenticationFailures;
		[Export ("consecutiveAuthenticationFailures")]
		nint ConsecutiveAuthenticationFailures { get; }

		// @property (readonly, nonatomic) NSInteger consecutiveLockouts;
		[Export ("consecutiveLockouts")]
		nint ConsecutiveLockouts { get; }

		// @property (readonly, nonatomic, strong) NSDate * _Nonnull lockoutEndTime;
		[Export ("lockoutEndTime", ArgumentSemantic.Strong)]
		NSDate LockoutEndTime { get; }

		// @property (readonly, nonatomic) NSInteger countOfZoomSessionsPerformed;
		[Export ("countOfZoomSessionsPerformed")]
		nint CountOfZoomSessionsPerformed { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export ("new")]
		ZoomAuthenticationResult New ();
	}

	// @interface ZoomCustomization : NSObject
	[BaseType (typeof(NSObject))]
	interface ZoomCustomization
	{
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

		// @property (nonatomic, strong) UIImage * _Nullable brandingLogo;
		[NullAllowed, Export ("brandingLogo", ArgumentSemantic.Strong)]
		UIImage BrandingLogo { get; set; }

		// @property (nonatomic, strong) UIImage * _Nullable cancelButtonImage;
		[NullAllowed, Export ("cancelButtonImage", ArgumentSemantic.Strong)]
		UIImage CancelButtonImage { get; set; }

		// @property (nonatomic) enum CancelButtonLocation cancelButtonLocation;
		[Export ("cancelButtonLocation", ArgumentSemantic.Assign)]
		CancelButtonLocation CancelButtonLocation { get; set; }

		// @property (nonatomic, strong) ZoomInstructions * _Nonnull zoomInstructionsImages;
		[Export ("zoomInstructionsImages", ArgumentSemantic.Strong)]
		ZoomInstructions ZoomInstructionsImages { get; set; }
	}

	// @protocol ZoomEnrollmentDelegate
    [BaseType(typeof(NSObject))]
	[Protocol, Model]
	interface ZoomEnrollmentDelegate
	{
		// @required -(void)onZoomEnrollmentResultWithResult:(ZoomEnrollmentResult * _Nonnull)result;
		[Abstract]
		[Export ("onZoomEnrollmentResultWithResult:")]
		void OnZoomEnrollmentResult (ZoomEnrollmentResult result);
	}

    interface IZoomEnrollmentDelegate {}

	// @interface ZoomEnrollmentResult : NSObject
	[BaseType (typeof(NSObject))]
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

		// @property (readonly, nonatomic) NSInteger countOfZoomSessionsPerformed;
		[Export ("countOfZoomSessionsPerformed")]
		nint CountOfZoomSessionsPerformed { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export ("new")]
		ZoomEnrollmentResult New ();
	}

	// @interface ZoomFaceBiometricMetrics : NSObject
	[BaseType (typeof(NSObject))]
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

		// @property (readonly, nonatomic) enum ZoomExternalImageSetVerificationResult externalImageSetVerificationResult;
		[Export ("externalImageSetVerificationResult")]
		ZoomExternalImageSetVerificationResult ExternalImageSetVerificationResult { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable zoomFacemap;
		[NullAllowed, Export ("zoomFacemap")]
		string ZoomFacemap { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export ("new")]
		ZoomFaceBiometricMetrics New ();
	}

	// @interface ZoomInstructions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ZoomInstructions
	{
		// -(instancetype _Nonnull)initWithGenericImage:(UIImage * _Nullable)genericImage badLightingImage:(UIImage * _Nullable)badLightingImage badAngleImage:(UIImage * _Nullable)badAngleImage __attribute__((objc_designated_initializer));
		[Export ("initWithGenericImage:badLightingImage:badAngleImage:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] UIImage genericImage, [NullAllowed] UIImage badLightingImage, [NullAllowed] UIImage badAngleImage);

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export ("new")]
		ZoomInstructions New ();
	}

	// @protocol ZoomSDKProtocol
	[Protocol, Model]
	interface ZoomSDKProtocol
	{
		// @required -(void)initializeWithAppToken:(NSString * _Nonnull)appToken completion:(void (^ _Nullable)(BOOL))completion;
		[Abstract]
		[Export ("initializeWithAppToken:completion:")]
		void Initialize (string appToken, [NullAllowed] Action<bool> completion);

		// @required -(void)setCustomizationWithInterfaceCustomization:(ZoomCustomization * _Nonnull)interfaceCustomization;
		[Abstract]
		[Export ("setCustomizationWithInterfaceCustomization:")]
		void SetCustomization (ZoomCustomization interfaceCustomization);

		// @required -(BOOL)isAppTokenValid __attribute__((warn_unused_result));
		[Abstract]
		[Export ("isAppTokenValid")]
		bool IsAppTokenValid { get; }

		// @required -(enum ZoomSDKStatus)getStatus __attribute__((warn_unused_result));
		[Abstract]
		[Export ("getStatus")]
		ZoomSDKStatus Status { get; }

		// @required -(void)preload;
		[Abstract]
		[Export ("preload")]
		void Preload ();

		// @required -(BOOL)isUserEnrolledWithUserID:(NSString * _Nonnull)userID __attribute__((warn_unused_result));
		[Abstract]
		[Export ("isUserEnrolledWithUserID:")]
		bool IsUserEnrolled (string userID);

		// @required -(enum ZoomUserEnrollmentStatus)getUserEnrollmentStatusWithUserID:(NSString * _Nonnull)userID __attribute__((warn_unused_result));
		[Abstract]
		[Export ("getUserEnrollmentStatusWithUserID:")]
		ZoomUserEnrollmentStatus GetUserEnrollmentStatus (string userID);

		// @required @property (readonly, nonatomic) enum ZoomCameraPermissionStatus cameraPermissionStatus;
		[Abstract]
		[Export ("cameraPermissionStatus")]
		ZoomCameraPermissionStatus CameraPermissionStatus { get; }

		// @required -(BOOL)deleteUserWithUserID:(NSString * _Nonnull)userID error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("deleteUserWithUserID:error:")]
		bool DeleteUser (string userID, [NullAllowed] out NSError error);

		// @required -(BOOL)deleteAllEnrollmentsAndReturnError:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("deleteAllEnrollmentsAndReturnError:")]
		bool DeleteAllEnrollmentsAndReturnError ([NullAllowed] out NSError error);

		// @required -(void)setLanguage:(NSString * _Nonnull)language;
		[Abstract]
		[Export ("setLanguage:")]
		void SetLanguage (string language);

		// @required @property (nonatomic) BOOL auditTrailEnabled;
		[Abstract]
		[Export ("auditTrailEnabled")]
		bool AuditTrailEnabled { get; set; }

		// @required @property (nonatomic) enum AuditTrailType auditTrailType;
		[Abstract]
		[Export ("auditTrailType", ArgumentSemantic.Assign)]
		AuditTrailType AuditTrailType { get; set; }

		// @required @property (nonatomic) NSInteger activeTimeoutInSeconds;
		[Abstract]
		[Export ("activeTimeoutInSeconds")]
		nint ActiveTimeoutInSeconds { get; set; }

		// @required @property (nonatomic) enum ZoomHybridBiometricStorageMode zoomHybridBiometricStorageMode;
		[Abstract]
		[Export ("zoomHybridBiometricStorageMode", ArgumentSemantic.Assign)]
		ZoomHybridBiometricStorageMode ZoomHybridBiometricStorageMode { get; set; }

		// @required @property (nonatomic) NSInteger failuresBeforeAuthLockout;
		[Abstract]
		[Export ("failuresBeforeAuthLockout")]
		nint FailuresBeforeAuthLockout { get; set; }

		// @required @property (nonatomic) NSInteger authLockoutTimeInSeconds;
		[Abstract]
		[Export ("authLockoutTimeInSeconds")]
		nint AuthLockoutTimeInSeconds { get; set; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Abstract]
		[Export ("version")]
		string Version { get; }

		// @required -(void)setHybridEncryptionKeyWithPublicKey:(NSString * _Nonnull)publicKey;
		[Abstract]
		[Export ("setHybridEncryptionKeyWithPublicKey:")]
		void SetHybridEncryptionKey (string publicKey);

		// @required -(UIViewController * _Nonnull)createEnrollmentVCWithDelegate:(id<ZoomEnrollmentDelegate> _Nonnull)delegate userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret secret:(NSString * _Nullable)secret verificationImages:(NSArray<UIImage *> * _Nullable)verificationImages retrieveZoomBiometric:(BOOL)retrieveZoomBiometric __attribute__((warn_unused_result));
		[Abstract]
		[Export ("createEnrollmentVCWithDelegate:userID:applicationPerUserEncryptionSecret:secret:verificationImages:retrieveZoomBiometric:")]
		UIViewController CreateEnrollmentVC (IZoomEnrollmentDelegate @delegate, string userID, string applicationPerUserEncryptionSecret, [NullAllowed] string secret, [NullAllowed] UIImage[] verificationImages, bool retrieveZoomBiometric);

		// @required -(UIViewController * _Nonnull)createEnrollmentVCWithDelegate:(id<ZoomEnrollmentDelegate> _Nonnull)delegate userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret secret:(NSString * _Nullable)secret __attribute__((warn_unused_result));
		[Abstract]
		[Export ("createEnrollmentVCWithDelegate:userID:applicationPerUserEncryptionSecret:secret:")]
		UIViewController CreateEnrollmentVC (IZoomEnrollmentDelegate @delegate, string userID, string applicationPerUserEncryptionSecret, [NullAllowed] string secret);

		// @required -(UIViewController * _Nonnull)createAuthenticationVCWithDelegate:(id<ZoomAuthenticationDelegate> _Nonnull)delegate userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret verificationImages:(NSArray<UIImage *> * _Nullable)verificationImages retrieveZoomBiometric:(BOOL)retrieveZoomBiometric __attribute__((warn_unused_result));
		[Abstract]
		[Export ("createAuthenticationVCWithDelegate:userID:applicationPerUserEncryptionSecret:verificationImages:retrieveZoomBiometric:")]
        UIViewController CreateAuthenticationVC (IZoomAuthenticationDelegate @delegate, string userID, string applicationPerUserEncryptionSecret, [NullAllowed] UIImage[] verificationImages, bool retrieveZoomBiometric);

		// @required -(UIViewController * _Nonnull)createAuthenticationVCWithDelegate:(id<ZoomAuthenticationDelegate> _Nonnull)delegate userID:(NSString * _Nonnull)userID applicationPerUserEncryptionSecret:(NSString * _Nonnull)applicationPerUserEncryptionSecret __attribute__((warn_unused_result));
		[Abstract]
		[Export ("createAuthenticationVCWithDelegate:userID:applicationPerUserEncryptionSecret:")]
        UIViewController CreateAuthenticationVC (IZoomAuthenticationDelegate @delegate, string userID, string applicationPerUserEncryptionSecret);

		// @required -(UIViewController * _Nonnull)createVerificationVCWithDelegate:(id<ZoomVerificationDelegate> _Nonnull)delegate verificationImages:(NSArray<UIImage *> * _Nullable)verificationImages retrieveZoomBiometric:(BOOL)retrieveZoomBiometric __attribute__((warn_unused_result));
		[Abstract]
		[Export ("createVerificationVCWithDelegate:verificationImages:retrieveZoomBiometric:")]
		UIViewController CreateVerificationVC (IZoomVerificationDelegate @delegate, [NullAllowed] UIImage[] verificationImages, bool retrieveZoomBiometric);
	}

    interface IZoomSDKProtocol {} // Important: Do not remove

	// @protocol ZoomVerificationDelegate
    [BaseType(typeof(NSObject))]
	[Protocol, Model]
	interface ZoomVerificationDelegate
	{
		// @required -(void)onZoomVerificationResultWithResult:(ZoomVerificationResult * _Nonnull)result;
		[Abstract]
		[Export ("onZoomVerificationResultWithResult:")]
		void OnZoomVerificationResult (ZoomVerificationResult result);
	}

    interface IZoomVerificationDelegate {}

	// @interface ZoomVerificationResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ZoomVerificationResult
	{
		// @property (readonly, nonatomic) enum ZoomVerificationStatus status;
		[Export ("status")]
		ZoomVerificationStatus Status { get; }

		// @property (readonly, nonatomic, strong) ZoomFaceBiometricMetrics * _Nullable faceMetrics;
		[NullAllowed, Export ("faceMetrics", ArgumentSemantic.Strong)]
		ZoomFaceBiometricMetrics FaceMetrics { get; }

		// @property (readonly, nonatomic) NSInteger countOfZoomSessionsPerformed;
		[Export ("countOfZoomSessionsPerformed")]
		nint CountOfZoomSessionsPerformed { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export ("new")]
		ZoomVerificationResult New ();
	}
}
