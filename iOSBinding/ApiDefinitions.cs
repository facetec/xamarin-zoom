using System;
using CoreAnimation;
using Foundation;
using ObjCRuntime;
using UIKit;
using ZoomAuthenticationHybrid;

namespace ZoomAuthenticationHybrid
{
    // @interface Zoom : NSObject
    [BaseType(typeof(NSObject))]
    interface Zoom
    {
        // @property (readonly, nonatomic, strong, class) id<ZoomSDKProtocol> _Nonnull sdk;
        [Static]
        [Export("sdk", ArgumentSemantic.Strong)]
        IZoomSDKProtocol Sdk { get; }
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

		// @property (readonly, copy, nonatomic) NSData * _Nullable zoomFacemap;
		[NullAllowed, Export ("zoomFacemap", ArgumentSemantic.Copy)]
		NSData ZoomFacemap { get; }

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

		// @required @property (readonly, nonatomic) enum ZoomCameraPermissionStatus cameraPermissionStatus;
		[Abstract]
		[Export ("cameraPermissionStatus")]
		ZoomCameraPermissionStatus CameraPermissionStatus { get; }

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

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Abstract]
		[Export ("version")]
		string Version { get; }

		// @required -(void)setHybridEncryptionKeyWithPublicKey:(NSString * _Nonnull)publicKey;
		[Abstract]
		[Export ("setHybridEncryptionKeyWithPublicKey:")]
		void SetHybridEncryptionKey (string publicKey);

		// @required -(UIViewController * _Nonnull)createVerificationVCWithDelegate:(id<ZoomVerificationDelegate> _Nonnull)delegate retrieveZoomBiometric:(BOOL)retrieveZoomBiometric __attribute__((warn_unused_result));
		[Abstract]
		[Export ("createVerificationVCWithDelegate:retrieveZoomBiometric:")]
		UIViewController CreateVerificationVC (IZoomVerificationDelegate @delegate, bool retrieveZoomBiometric);
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

        // @optional -(void)onBeforeDismiss;
        [Export("onBeforeDismiss")]
        void OnBeforeDismiss();
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

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sessionId;
		[Export ("sessionId")]
		string SessionId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export ("new")]
		ZoomVerificationResult New ();
	}
}
