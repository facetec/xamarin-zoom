using System;
using ObjCRuntime;

namespace Zoom
{
	
	public enum ZoomAuthenticationStatus
	{
		UserWasAuthenticated = 0,
		FailedBecauseAppTokenNotValid = 1,
		FailedBecauseUserCancelled = 2,
		FailedBecauseCameraPermissionDenied = 3,
		FailedBecauseTouchIDUnavailable = 4,
		FailedBecauseUserFailedAuthentication = 5,
		FailedBecauseUserMustEnroll = 6,
		FailedToAuthenticateTooManyTimesAndUserWasDeleted = 7,
		FailedBecauseOfTimeout = 8,
		FailedBecauseOfLowMemory = 9,
		FailedBecauseOfOSContextSwitch = 10,
		FailedBecauseWifiNotOnInDevMode = 11,
		FailedBecauseNoConnectionInDevMode = 12,
		FailedBecauseTouchIDSettingsChanged = 13,
		FailedBecauseOfflineSessionsExceeded = 14
	}

	
	public enum ZoomAuthenticatorState
	{
		Unused = 0,
		Cancelled = 1,
		Failed = 2,
		Completed = 3
	}

	
	public enum ZoomCameraPermissionStatus
	{
		NotDetermined = 0,
		Denied = 1,
		Restricted = 2,
		Authorized = 3
	}

	
	public enum ZoomEffectiveStrategy
	{
		NotEnrolled = 0,
		Zoom = 1,
		ZoomAndPin = 2,
		ZoomAndFinger = 3,
		ZoomAndFingerAndPin = 4
	}

	
	public enum ZoomEnrollmentStatus
	{
		UserWasEnrolled = 0,
		UserNotEnrolled = 1,
		FailedBecauseUserCancelled = 2,
		FailedBecauseAppTokenNotValid = 3,
		FailedBecauseCameraPermissionDeniedByUser = 4,
		FailedBecauseCameraPermissionDeniedByAdministrator = 5,
		FailedBecauseFingerprintDisabled = 6,
		FailedBecauseUserCouldNotValidateFingerprint = 7,
		FailedBecauseOfOSContextSwitch = 8,
		FailedBecauseOfTimeout = 9,
		FailedBecauseOfLowMemory = 10,
		FailedBecauseOfDiskWriteError = 11,
		FailedBecauseWifiNotOnInDevMode = 12,
		FailedBecauseNoConnectionInDevMode = 13,
		UserFailedToProvideGoodEnrollment = 14,
		FailedBecauseOfflineSessionsExceeded = 15
	}

	
	public enum ZoomExternalImageSetVerificationResult
	{
		CouldNotDetermineMatch = 0,
		LowConfidenceMatch = 1,
		Match = 2
	}

	
	public enum ZoomFingerprintHardwareCapability
	{
		NeverAvailable = 0,
		NotCurrentlyAvailable = 1,
		CurrentlyLockedOut = 2,
		Available = 3
	}

	
	public enum ZoomLivenessResult
	{
		LivenessUndetermined = 0,
		Alive = 1
	}

	
	public enum ZoomSDKStatus
	{
		NeverInitialized = 0,
		Initialized = 1,
		NetworkIssues = 2,
		InvalidToken = 3,
		DeviceInsecure = 4,
		VersionDeprecated = 5,
		OfflineSessionsExceeded = 6
	}

	
	public enum ZoomStrategy
	{
		ZoomOnly = 1,
		TwoFactor = 2,
		ThreeFactor = 3
	}

	
	public enum ZoomUserEnrollmentStatus
	{
		Enrolled = 0,
		NotEnrolled = 1,
		Invalidated = 2
	}
}
