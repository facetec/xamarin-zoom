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
        readonly String appToken = "SET_YOUR_TOKEN_HERE";

        // Set your encryption key to retrieve facemaps
        readonly String hybridEncryptionKey = @"";

        protected Button enrollButton;
		protected Button authButton;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			enrollButton = FindViewById<Button>(Resource.Id.enrollButton);
            enrollButton.Click += delegate { StartVerification(); };

			authButton = FindViewById<Button>(Resource.Id.authButton);
			authButton.Click += delegate { };

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
            ZoomSDK.Initialize(this, appToken, new ZoomInitializeCallback(this));

            // Set your biometric encryption key if provided
            if (hybridEncryptionKey.Length > 0)
            {
                ZoomSDK.SetHybridEncryptionKey(hybridEncryptionKey);
            }
        }

        // Verify a user's liveness
        void StartVerification() 
        {
            Intent verificationIntent = new Intent(this, typeof(ZoomVerificationActivity));

            if (hybridEncryptionKey.Length > 0)
            {
                verificationIntent.PutExtra(ZoomSDK.ExtraRetrieveZoomBiometric, true);
            }

           

            StartActivityForResult(verificationIntent, ZoomSDK.RequestCodeVerification);
        }

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if (resultCode == Result.Ok)
			{
				if (requestCode == ZoomSDK.RequestCodeVerification) 
                {
                    ZoomVerificationResult result = (ZoomVerificationResult)data.GetParcelableExtra(ZoomSDK.ExtraVerifyResults);

                    if (result.FaceMetrics != null)
                    {
                        String zoomFacemap = result.FaceMetrics.ZoomFacemap;
                    }
                }
			}
		}

		protected void ShowZoomAlert(string message)
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
                        activity.ShowZoomAlert(alertMessage);
					}
				});
			}
		}
	}
}