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

            // Set any customizations to ZoOm's default UI and behavior
            var customization = new ZoomCustomization();
            ZoomSDK.SetCustomization(customization);

            // Initialize the SDK before trying to use it
			ZoomSDK.Initialize(this, appToken, ZoomStrategy.ZoomOnly, new ZoomInitializeCallback(this));
		}

        // Enroll a new user
		private void startEnrollment()
		{
			Intent enrollmentIntent = new Intent(this, typeof(ZoomEnrollmentActivity));
			enrollmentIntent.PutExtra(ZoomSDK.ExtraEnrollmentUserId, userId);
			enrollmentIntent.PutExtra(ZoomSDK.ExtraUserEncryptionSecret, encryptionSecret);

			StartActivityForResult(enrollmentIntent, ZoomSDK.RequestCodeEnrollment);
		}

        // Authenticate an enrolled user
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

        // Verify a user's liveness
        private void startVerification() 
        {
            Intent verificationIntent = new Intent(this, typeof(ZoomVerificationActivity));

            // You can optionally provide an image for the user to be compared to. 
            ZoomSDK.SetVerificationImages(new System.Collections.Generic.List<Android.Graphics.Bitmap>());

            StartActivityForResult(verificationIntent, ZoomSDK.RequestCodeVerification);
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
                else if (requestCode == ZoomSDK.RequestCodeAuthentication)
				{
					ZoomAuthenticationResult result = (ZoomAuthenticationResult)data.GetParcelableExtra(ZoomSDK.ExtraAuthResults);

                    if (result.FaceMetrics != null)
                    {

                    }

					showAlert(result.Status.ToString());
				}
                else if (requestCode == ZoomSDK.RequestCodeVerification) 
                {
                    ZoomVerificationResult result = (ZoomVerificationResult)data.GetParcelableExtra(ZoomSDK.ExtraVerifyResults);

                    if (result.FaceMetrics != null)
                    {
                        
                    }
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