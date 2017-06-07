using System;
using ObjCRuntime;

namespace Zoom
{

	[Native]
	public enum ZoomAuthenticationStatus : ulong
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
		FailedBecauseTouchIDSettingsChanged = 13
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
	public enum ZoomEffectiveStrategy : ulong
	{
		NotEnrolled = 0,
		Zoom = 1,
		ZoomAndPin = 2,
		ZoomAndFinger = 3,
		ZoomAndFingerAndPin = 4
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
		FailedBecauseFingerprintDisabled = 6,
		FailedBecauseUserCouldNotValidateFingerprint = 7,
		FailedBecauseOfOSContextSwitch = 8,
		FailedBecauseOfTimeout = 9,
		FailedBecauseOfLowMemory = 10,
		FailedBecauseOfDiskWriteError = 11,
		FailedBecauseWifiNotOnInDevMode = 12,
		FailedBecauseNoConnectionInDevMode = 13,
		UserFailedToProvideGoodEnrollment = 14
	}

	[Native]
	public enum ZoomFingerprintHardwareCapability : ulong
	{
		NeverAvailable = 0,
		NotCurrentlyAvailable = 1,
		CurrentlyLockedOut = 2,
		Available = 3
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
		VersionDeprecated = 5
	}

	[Native]
	public enum ZoomStrategy : ulong
	{
		ZoomOnly = 1,
		TwoFactor = 2,
		ThreeFactor = 3
	}

	[Native]
	public enum ZoomUserEnrollmentStatus : ulong
	{
		Enrolled = 0,
		NotEnrolled = 1,
		Invalidated = 2
	}
}
