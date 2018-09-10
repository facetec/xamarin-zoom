using System;
using ObjCRuntime;

namespace ZoomAuthenticationHybrid
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
		TopLeft = 0,
		TopRight = 1,
		Disabled = 2
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
	public enum ZoomExternalImageSetVerificationResult : ulong
	{
		CouldNotDetermineMatch = 0,
		LowConfidenceMatch = 1,
		Match = 2
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
		VersionDeprecated = 4,
		OfflineSessionsExceeded = 5,
		UnknownError = 6
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
