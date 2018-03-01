using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Com.Facetec.Zoom.Sdk;
using System;

namespace Sample.Droid
{
	[Activity(Label = "Sample", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar", Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private readonly String appToken = "SET YOUR TOKEN HERE";

		protected static readonly String userId = "myUserId";
		protected static readonly String encryptionSecret = "myUserEncryptionSecret";

		protected Button enrollButton;
		protected Button authButton;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			enrollButton = FindViewById<Button>(Resource.Id.enrollButton);
			enrollButton.Click += delegate { startEnrollment(); };

			authButton = FindViewById<Button>(Resource.Id.authButton);
			authButton.Click += delegate { startAuth(); };

			String versionStr = "Zoom SDK v" + ZoomSDK.Version();
			FindViewById<TextView>(Resource.Id.versionText).Text = versionStr;
		}

		protected override void OnStart()
		{
			base.OnStart();

			ZoomSDK.Initialize(this, appToken, ZoomStrategy.ZoomOnly, new ZoomInitializeCallback(this));
		}

		private void startEnrollment()
		{
			Intent enrollmentIntent = new Intent(this, typeof(ZoomEnrollmentActivity));
			enrollmentIntent.PutExtra(ZoomSDK.ExtraEnrollmentUserId, userId);
			enrollmentIntent.PutExtra(ZoomSDK.ExtraUserEncryptionSecret, encryptionSecret);

			StartActivityForResult(enrollmentIntent, ZoomSDK.RequestCodeEnrollment);
		}

		private void startAuth()
		{
			if (ZoomSDK.IsUserEnrolled(this, userId))
			{
				Intent authenticationIntent = new Intent(this, typeof(ZoomAuthenticationActivity));
				authenticationIntent.PutExtra(ZoomSDK.ExtraAuthenticationUserId, userId);
				authenticationIntent.PutExtra(ZoomSDK.ExtraUserEncryptionSecret, encryptionSecret);

				StartActivityForResult(authenticationIntent, ZoomSDK.RequestCodeAuthentication);
			}
			else
			{
				Toast.MakeText(this, "User not enrolled", ToastLength.Short).Show();
			}
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if (resultCode == Result.Ok)
			{
				if (requestCode == ZoomSDK.RequestCodeEnrollment)
				{
					ZoomEnrollmentResult result = (ZoomEnrollmentResult)data.GetParcelableExtra(ZoomSDK.ExtraEnrollResults);
              
                    if (result.FaceMetrics != null) {
                        
                    }

					showAlert(result.Status.ToString());
				}
				else
				{
					ZoomAuthenticationResult result = (ZoomAuthenticationResult)data.GetParcelableExtra(ZoomSDK.ExtraAuthResults);
					showAlert(result.Status.ToString());
				}
			}
		}

		protected void showAlert(string message)
		{
			AlertDialog.Builder alert = new AlertDialog.Builder(this);
			alert.SetMessage(message);
			alert.SetCancelable(true);
			alert.SetNeutralButton("Ok", (senderAlert, arg) => { });
			alert.Create().Show();
		}

		private class ZoomInitializeCallback : ZoomSDK.InitializeCallback
		{
			private MainActivity activity;

			public ZoomInitializeCallback(MainActivity activity)
			{
				this.activity = activity;
			}

			public override void OnCompletion(bool success)
			{
				activity.RunOnUiThread(delegate
				{
					activity.enrollButton.Enabled = success;
					activity.authButton.Enabled = success;

					if (!success)
					{
						String statusStr = ZoomSDK.GetStatus(activity).ToString();
						String alertMessage = "Initialization failed. " + statusStr;
						activity.showAlert(alertMessage);
					}
				});
			}
		}
	}
}