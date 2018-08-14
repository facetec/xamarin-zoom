using System;
using ObjCRuntime;

namespace ZoomAuthentication
{
	[Native]
	public enum AuditTrailType : ulong
	{
		Disabled = 0,
		FullResolution = 1,
		Height640 = 2
	}

	[Native]
	public enum CancelButtonLocation : ulong
	{
		Left = 0,
		Right = 1
	}

	[Native]
	public enum ZoomAuthenticationStatus : ulong
	{
		UserWasAuthenticated = 0,
		FailedBecauseAppTokenNotValid = 1,
		FailedBecauseUserCancelled = 2,
		FailedBecauseCouldNotRetrieveBiometricDataForUser = 3,
		FailedBecauseCameraPermissionDenied = 4,
		FailedBecauseTouchIDUnavailable = 5,
		FailedBecauseUserFailedAuthentication = 6,
		FailedBecauseUserMustEnroll = 7,
		FailedToAuthenticateTooManyTimesAndUserWasDeleted = 8,
		FailedBecauseOfTimeout = 9,
		FailedBecauseOfLowMemory = 10,
		FailedBecauseOfOSContextSwitch = 11,
		FailedBecauseNoConnectionInDevMode = 12,
		FailedBecauseTouchIDSettingsChanged = 13,
		FailedBecauseOfflineSessionsExceeded = 14,
		FailedBecauseEncryptionSecretInvalid = 15,
		FailedBecauseEncryptionKeyInvalid = 16
	}

	[Native]
	public enum ZoomAuthenticatorState : ulong
	{
		Unused = 0,
		Cancelled = 1,
		Failed = 2,
		Completed = 3
	}

	[Native]
	public enum ZoomCameraPermissionStatus : ulong
	{
		NotDetermined = 0,
		Denied = 1,
		Restricted = 2,
		Authorized = 3
	}

	[Native]
	public enum ZoomEnrollmentStatus : ulong
	{
		UserWasEnrolled = 0,
		UserNotEnrolled = 1,
		FailedBecauseUserCancelled = 2,
		FailedBecauseAppTokenNotValid = 3,
		FailedBecauseCameraPermissionDeniedByUser = 4,
		FailedBecauseCameraPermissionDeniedByAdministrator = 5,
		FailedBecauseOfOSContextSwitch = 6,
		FailedBecauseOfTimeout = 7,
		FailedBecauseOfLowMemory = 8,
		FailedBecauseOfDiskWriteError = 9,
		FailedBecauseNoConnectionInDevMode = 10,
		UserFailedToProvideGoodEnrollment = 11,
		FailedBecauseOfflineSessionsExceeded = 12,
		FailedBecauseEncryptionKeyInvalid = 13
	}

	[Native]
	public enum ZoomExternalImageSetVerificationResult : ulong
	{
		CouldNotDetermineMatch = 0,
		LowConfidenceMatch = 1,
		Match = 2
	}

	[Native]
	public enum ZoomHybridBiometricStorageMode : ulong
	{
		Standard = 0,
		Enhanced = 1
	}

	[Native]
	public enum ZoomLivenessResult : ulong
	{
		LivenessUndetermined = 0,
		Alive = 1
	}

	[Native]
	public enum ZoomSDKStatus : ulong
	{
		NeverInitialized = 0,
		Initialized = 1,
		NetworkIssues = 2,
		InvalidToken = 3,
		DeviceInsecure = 4,
		VersionDeprecated = 5,
		OfflineSessionsExceeded = 6
	}

	[Native]
	public enum ZoomUserEnrollmentStatus : ulong
	{
		Enrolled = 0,
		NotEnrolled = 1,
		Invalidated = 2
	}

	[Native]
	public enum ZoomVerificationStatus : ulong
	{
		UserProcessedSuccessfully = 0,
		UserNotProcessed = 1,
		FailedBecauseUserCancelled = 2,
		FailedBecauseAppTokenNotValid = 3,
		FailedBecauseCameraPermissionDeniedByUser = 4,
		FailedBecauseCameraPermissionDeniedByAdministrator = 5,
		FailedBecauseOfOSContextSwitch = 6,
		FailedBecauseOfTimeout = 7,
		FailedBecauseOfLowMemory = 8,
		FailedBecauseOfDiskWriteError = 9,
		FailedBecauseNoConnectionInDevMode = 10,
		FailedBecauseOfflineSessionsExceeded = 11,
		FailedBecauseEncryptionKeyInvalid = 12
	}
}
