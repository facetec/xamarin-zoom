using System;

using UIKit;
using ZoomAuthentication;
using CoreGraphics;

namespace Sample.iOS
{
    public partial class ViewController : UIViewController, IZoomEnrollmentDelegate, IZoomAuthenticationDelegate, IZoomVerificationDelegate
	{
		String appToken = "YOUR APP TOKEN HERE";
		String userId = "myUserId";
		String encryptionSecret = "myUserEncryptionSecret";

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			setStyles();

			EnrollButton.Enabled = false;
			EnrollButton.TouchUpInside += delegate { startEnrollment(); };

			AuthButton.Enabled = false;
			AuthButton.TouchUpInside += delegate { startAuthentication(); };

			VersionLabel.Text = "Zoom SDK v" + Zoom.Sdk.Version;

            // Set any customizations to ZoOm's default UI and behavior
            var customization = new ZoomCustomization();
            Zoom.Sdk.SetCustomization(customization);

            // Initialize the SDK before trying to use it
            Zoom.Sdk.Initialize(appToken, onInitializeResult);
		}

        // Enroll a new user
		private void startEnrollment()
		{
            var controller = Zoom.Sdk.CreateEnrollmentVC(this, userId, encryptionSecret, null);
            PresentViewController(controller, false, null);
		}

        // Authenticate an enrolled user
		private void startAuthentication()
		{
			if (Zoom.Sdk.IsUserEnrolled(userId)) {
                var controller = Zoom.Sdk.CreateAuthenticationVC(this, userId, encryptionSecret);
				PresentViewController(controller, false, null);
			}
			else
			{
				showAlert("", "User doesn't exist.");
			}
		}

        // Verify a user's liveness
        private void startVerification() 
        {
            var controller = Zoom.Sdk.CreateVerificationVC(this, null, false);
            PresentViewController(controller, false, null);
        }

		public void OnZoomEnrollmentResult(ZoomEnrollmentResult result)
		{
            if (result.FaceMetrics != null) {
                
            }

            showAlert("Enroll Result", result.Description);
		}

        public void OnZoomAuthenticationResult(ZoomAuthenticationResult result)
		{
			showAlert("Auth Result", result.Description);
		}

        public void OnZoomVerificationResult(ZoomVerificationResult result)
        {
            showAlert("Verification Result", result.Description);
        }

		private void onInitializeResult(bool success)
		{
			EnrollButton.Enabled = success;
			AuthButton.Enabled = success;

			if (!success)
			{
				showAlert("Initialize Failed", Zoom.Sdk.Status.ToString());
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		private void showAlert(String title, String message)
		{
			var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
			alertController.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
			PresentViewController(alertController, true, null);
		}

		private void setStyles()
		{
			var gradient = new CoreAnimation.CAGradientLayer();
			gradient.Frame = UIScreen.MainScreen.Bounds;
			gradient.Colors = new CGColor[] { new UIColor(red:0.04f, green:0.71f, blue:0.64f, alpha:1).CGColor,
				                              new UIColor(red:0.07f, green:0.57f, blue:0.76f, alpha:1).CGColor }; 
			gradient.StartPoint = new CoreGraphics.CGPoint(0, 0);
			gradient.EndPoint = new CoreGraphics.CGPoint(1, 0);
			BackgroundView.Layer.Frame = UIScreen.MainScreen.Bounds;
			BackgroundView.Layer.AddSublayer(gradient);

			UIColor buttonBackgroundColor = new UIColor(white: 0, alpha: 0.6f);
			EnrollButton.BackgroundColor = buttonBackgroundColor;
			AuthButton.BackgroundColor = buttonBackgroundColor;
		}
	}
}
