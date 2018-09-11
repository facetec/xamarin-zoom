using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using CoreGraphics;
using Foundation;
using UIKit;

using ZoomAuthenticationHybrid;
using System.Text;

namespace Sample.iOS {
    public partial class ViewController : UIViewController, IZoomVerificationDelegate {
		readonly String appToken = "SET_YOUR_TOKEN_HERE";

        // Set your encryption key to retrieve facemaps
        readonly String hybridEncryptionKey = "-----BEGIN PUBLIC KEY-----\n" +
            "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA5PxZ3DLj+zP6T6HFgzzk\n" +
            "M77LdzP3fojBoLasw7EfzvLMnJNUlyRb5m8e5QyyJxI+wRjsALHvFgLzGwxM8ehz\n" +
            "DqqBZed+f4w33GgQXFZOS4AOvyPbALgCYoLehigLAbbCNTkeY5RDcmmSI/sbp+s6\n" +
            "mAiAKKvCdIqe17bltZ/rfEoL3gPKEfLXeN549LTj3XBp0hvG4loQ6eC1E1tRzSkf\n" +
            "GJD4GIVvR+j12gXAaftj3ahfYxioBH7F7HQxzmWkwDyn3bqU54eaiB7f0ftsPpWM\n" +
            "ceUaqkL2DZUvgN0efEJjnWy5y1/Gkq5GGWCROI9XG/SwXJ30BbVUehTbVcD70+ZF\n" +
            "8QIDAQAB\n" +
            "-----END PUBLIC KEY-----";

        private String baseURL = "https://api.zoomauth.com/api/v1/biometrics";
        enum ZoomHybridRequestType { Enroll, Authenticate };
        ZoomHybridRequestType latestZoomHybridRequestType;

        public ViewController(IntPtr handle) : base(handle) {
		}

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            SetStyles();

            // dismiss keyboard when done
            IdentityTextField.ShouldReturn = delegate {
                IdentityTextField.ResignFirstResponder();
                return true;
            };

            EnrollButton.Enabled = false;
            EnrollButton.TouchUpInside += delegate {
                if(IdentityTextField.Text.Length == 0) {
                    ShowZoomAlert("Empty Username", "Please enter a username.");
                    return;
                }

                latestZoomHybridRequestType = ZoomHybridRequestType.Enroll;
                StartVerification(); 
            };

            AuthButton.Enabled = false;
            AuthButton.TouchUpInside += delegate {
                if (IdentityTextField.Text.Length == 0) {
                    ShowZoomAlert("Empty Username", "Please enter a username.");
                    return;
                }

                latestZoomHybridRequestType = ZoomHybridRequestType.Authenticate;
                StartVerification(); 
            };

            CheckEnrollmentButton.Enabled = false;
            CheckEnrollmentButton.TouchUpInside += delegate {
                if (IdentityTextField.Text.Length == 0) {
                    ShowZoomAlert("Empty Username", "Please enter a username.");
                    return;
                }

                IsUserEnrolled(IdentityTextField.Text.Replace(" ", "")); 
            };

            DeleteEnrollmentButton.Enabled = false;
            DeleteEnrollmentButton.TouchUpInside += delegate {
                if (IdentityTextField.Text.Length == 0) {
                    ShowZoomAlert("Empty Username", "Please enter a username.");
                    return;
                }

                DeleteUser(IdentityTextField.Text.Replace(" ", "")); 
            };

            VersionLabel.Text = "Zoom SDK v" + Zoom.Sdk.Version;

            // Set any customizations to ZoOm's default UI and behavior
            var customization = new ZoomCustomization();
            customization.ShowSuccessScreen = false;
            customization.ShowFailureScreen = false;
            Zoom.Sdk.SetCustomization(customization);

            // Initialize the SDK before trying to use it
            Zoom.Sdk.Initialize(appToken, OnInitializeResult);

            // Set your biometric encryption key if provided
            if (hybridEncryptionKey.Length > 0) {
                Zoom.Sdk.SetHybridEncryptionKey(hybridEncryptionKey);
            }
		}

        // Verify a user's liveness
        void StartVerification() {
            bool retrieveBiometric = hybridEncryptionKey.Length > 0;

            var controller = Zoom.Sdk.CreateVerificationVC(this, retrieveBiometric);
            PresentViewController(controller, false, null);
        }


        public void OnZoomVerificationResult(ZoomVerificationResult result) {
            //ShowZoomAlert("Verification Result", result.Description);

            if (result.FaceMetrics != null) {
                NSData facemap = result.FaceMetrics.ZoomFacemap;

                if(latestZoomHybridRequestType == ZoomHybridRequestType.Enroll) {
                    EnrollUser(IdentityTextField.Text.Replace(" ", ""), facemap, result.SessionId);
                }
                else if(latestZoomHybridRequestType == ZoomHybridRequestType.Authenticate) {
                    AuthenticateUser(IdentityTextField.Text.Replace(" ", ""), facemap, result.SessionId);
                }
            }
        }

        void OnInitializeResult(bool success) {
			EnrollButton.Enabled = success;
			AuthButton.Enabled = success;
            CheckEnrollmentButton.Enabled = success;
            DeleteEnrollmentButton.Enabled = success;

            if (!success) {
				ShowZoomAlert("Initialize Failed", Zoom.Sdk.Status.ToString());
			}
		}

		public override void DidReceiveMemoryWarning() {
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

        void ShowZoomAlert(String title, String message) {
			var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
			alertController.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
			PresentViewController(alertController, true, null);
		}

        void SetStyles() {
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
            CheckEnrollmentButton.BackgroundColor = buttonBackgroundColor;
            DeleteEnrollmentButton.BackgroundColor = buttonBackgroundColor;
        }

        private async void IsUserEnrolled(String user) {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-App-Token", appToken);

            HttpResponseMessage response = await client.GetAsync(baseURL + "/enrollment/" + user);
            var result = await response.Content.ReadAsStringAsync();
            dynamic parsedResponse = JObject.Parse(result);


            bool enrolled = parsedResponse.meta.ok;
            ShowZoomAlert("Enrollment Status", user + " enrolled: " + enrolled);
        }

        private async void DeleteUser(String user) {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-App-Token", appToken);

            HttpResponseMessage response = await client.DeleteAsync(baseURL + "/enrollment/" + user);
            var result = await response.Content.ReadAsStringAsync();
            dynamic parsedResponse = JObject.Parse(result);

            bool deleted = parsedResponse.meta.ok;
            ShowZoomAlert("Deletion Status", user + " deleted: " + deleted);
        }

        private async void EnrollUser(String user, NSData zoomFacemap, String sessionId) {
            String zoomFacemapStr = zoomFacemap.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
            JObject parameters = new JObject(
                                    new JProperty("enrollmentIdentifier", user),
                                    new JProperty("facemap", zoomFacemapStr),
                                    new JProperty("sessionId", sessionId));
            var content = new StringContent(parameters.ToString(), Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-App-Token", appToken);
            String url = baseURL + "/enrollment";
            HttpResponseMessage response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            dynamic parsedResponse = JObject.Parse(result);

            bool enrolled = parsedResponse.meta.ok;
            if(enrolled) {
                ShowZoomAlert("Enrollment Status", "User Enrolled!");
            }
            else {
                ShowZoomAlert("Enrollment Status", "Enrollment Failed\nHybrid Response:\n" + result);
            }
        }

        private async void AuthenticateUser(String user, NSData zoomFacemap, String sessionId) {
            JObject paramterField = new JObject(); 
            paramterField.Add("enrollmentIdentifier", user);
            String zoomFacemapStr = zoomFacemap.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
            JObject destinationMapsField = new JObject();
            destinationMapsField.Add("facemap", zoomFacemapStr);
            JObject[] destinationMapsFieldArr = new JObject[] { destinationMapsField };

            JObject parameters = new JObject(
                                    new JProperty("source", paramterField),
                                    new JProperty("comparisons", destinationMapsFieldArr),
                                    new JProperty("performContinuousLearning", true),
                                    new JProperty("sessionId", sessionId));
            var content = new StringContent(parameters.ToString(), Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-App-Token", appToken);
            String url = baseURL + "/compare";

            HttpResponseMessage response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            dynamic parsedResponse = JObject.Parse(result);

            bool ok = parsedResponse.meta.ok;
            if(ok) {
                int authenticated = parsedResponse.data.results[0].authenticated;
                if(authenticated == 1) {
                    ShowZoomAlert("Authentication Status", "User Authenticated!");
                }
                else {
                    ShowZoomAlert("Authentication Status", "Authentication Failed");
                }
            }
            else {
                ShowZoomAlert("Authentication Status", "Authentication Failed\nHybrid Response:\n" + result);
            }
        }
    }
}
