using System;

using UIKit;
using Zoom;
using CoreGraphics;

namespace Sample.iOS
{
	public partial class ViewController : UIViewController
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

			Zoom.Sdk.Initialize(appToken, Zoom.ZoomStrategy.ZoomOnly, onInitializeResult);
		}

		private void startEnrollment()
		{
			var controller = Zoom.Sdk.PrepareEnrollmentVC(onEnrollmentResult, userId, encryptionSecret);
			PresentViewController(controller, false, null);

		}

		private void startAuthentication()
		{
			if (Zoom.Sdk.IsUserEnrolled(userId)) {
				var controller = Zoom.Sdk.PrepareAuthenticationVC(onAuthenticationResult, userId, encryptionSecret);
				PresentViewController(controller, false, null);
			}
			else
			{
				showAlert("", "User doesn't exist.");
			}
		}

		private void onEnrollmentResult(ZoomEnrollmentResult result)
		{
            showAlert("Enroll Result", result.Description);
		}

		private void onAuthenticationResult(ZoomAuthenticationResult result)
		{
			showAlert("Auth Result", result.Description);
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
