using System;

using UIKit;
using ZoomAuthenticationHybrid;
using CoreGraphics;

namespace Sample.iOS
{
    public partial class ViewController : UIViewController, IZoomVerificationDelegate
	{
		readonly String appToken = "SET_YOUR_TOKEN_HERE";

        // Set your encryption key to retrieve facemaps
        readonly String hybridEncryptionKey = @""; 

		public ViewController(IntPtr handle) : base(handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetStyles();

            EnrollButton.Enabled = false;
            EnrollButton.TouchUpInside += delegate { StartVerification(); };

            AuthButton.Enabled = false;
            AuthButton.TouchUpInside += delegate {  };

			VersionLabel.Text = "Zoom SDK v" + Zoom.Sdk.Version;

            // Set any customizations to ZoOm's default UI and behavior
            var customization = new ZoomCustomization();
            Zoom.Sdk.SetCustomization(customization);

            // Initialize the SDK before trying to use it
            Zoom.Sdk.Initialize(appToken, OnInitializeResult);

            // Set your biometric encryption key if provided
            if (hybridEncryptionKey.Length > 0) {
                Zoom.Sdk.SetHybridEncryptionKey(hybridEncryptionKey);
            }
		}


        // Verify a user's liveness
        void StartVerification() 
        {
            bool retrieveBiometric = hybridEncryptionKey.Length > 0;

            var controller = Zoom.Sdk.CreateVerificationVC(this, retrieveBiometric);
            PresentViewController(controller, false, null);
        }


        public void OnZoomVerificationResult(ZoomVerificationResult result)
        {
            ShowZoomAlert("Verification Result", result.Description);

            if (result.FaceMetrics != null) {
                String facemap = result.FaceMetrics.ZoomFacemap;

            }
        }

        void OnInitializeResult(bool success)
		{
			EnrollButton.Enabled = success;
			AuthButton.Enabled = success;

			if (!success)
			{
				ShowZoomAlert("Initialize Failed", Zoom.Sdk.Status.ToString());
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

        void ShowZoomAlert(String title, String message)
		{
			var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
			alertController.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
			PresentViewController(alertController, true, null);
		}

        void SetStyles()
		{
			var gradient = new CoreAnimation.CAGradientLayer();
			gradient.Frame = UIScreen.MainScreen.Bounds;
			gradient.Colors = new CGColor[] { new UIColor(red:0.04f, green:0.71f, blue:0.64f, alpha:1).CGColor,
				                              new UIColor(red:0.07f, green:0.57f, blue:0.76f, alpha:1).CGColor }; 
			gradient.StartPoint = new CGPoint(0, 0);
			gradient.EndPoint = new CGPoint(1, 0);
			BackgroundView.Layer.Frame = UIScreen.MainScreen.Bounds;
			BackgroundView.Layer.AddSublayer(gradient);

			UIColor buttonBackgroundColor = new UIColor(white: 0, alpha: 0.6f);
			EnrollButton.BackgroundColor = buttonBackgroundColor;
			AuthButton.BackgroundColor = buttonBackgroundColor;
		}
	}
}
