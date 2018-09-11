using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Com.Facetec.Zoom.Sdk;
using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Sample.Droid {
	[Activity(Label = "Sample", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar", Icon = "@mipmap/icon")]
	public class MainActivity : Activity {
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

        protected EditText identityText;
        protected Button enrollButton;
		protected Button authButton;
        protected Button checkEnrollmentButton;
        protected Button deleteEnrollmentButton;

        protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

            identityText = FindViewById<EditText>(Resource.Id.identityText);

            enrollButton = FindViewById<Button>(Resource.Id.enrollButton);
            enrollButton.Click += delegate {
                if (identityText.Text.Length == 0) {
                    ShowZoomAlert("Empty Username", "Please enter a username.");
                    return;
                }
                latestZoomHybridRequestType = ZoomHybridRequestType.Enroll;
                StartVerification(); 
            };

			authButton = FindViewById<Button>(Resource.Id.authButton);
            authButton.Click += delegate {
                if (identityText.Text.Length == 0) {
                    ShowZoomAlert("Empty Username", "Please enter a username.");
                    return;
                }
                latestZoomHybridRequestType = ZoomHybridRequestType.Authenticate;
                StartVerification(); 
            };

            checkEnrollmentButton = FindViewById<Button>(Resource.Id.checkEnrollmentButton);
            checkEnrollmentButton.Click += delegate {
                if (identityText.Text.Length == 0) {
                    ShowZoomAlert("Empty Username", "Please enter a username.");
                    return;
                }
                IsUserEnrolled(identityText.Text.Replace(" ", "")); 
            };

            deleteEnrollmentButton = FindViewById<Button>(Resource.Id.deleteEnrollmentButton);
            deleteEnrollmentButton.Click += delegate {
                if (identityText.Text.Length == 0) {
                    ShowZoomAlert("Empty Username", "Please enter a username.");
                    return;
                }
                DeleteUser(identityText.Text.Replace(" ", "")); 
            };

            String versionStr = "Zoom SDK v" + ZoomSDK.Version();
			FindViewById<TextView>(Resource.Id.versionText).Text = versionStr;
		}

        protected override void OnStart() {
            base.OnStart();

            // Set any customizations to ZoOm's default UI and behavior
            var customization = new ZoomCustomization();
            customization.ShowFailureScreen = false;
            customization.ShowSuccessScreen = false;
            ZoomSDK.SetCustomization(customization);

            // Initialize the SDK before trying to use it
            ZoomSDK.Initialize(this, appToken, new ZoomInitializeCallback(this));

            // Set your biometric encryption key if provided
            if (hybridEncryptionKey.Length > 0) {
                ZoomSDK.SetHybridEncryptionKey(hybridEncryptionKey);
            }
        }

        // Verify a user's liveness
        void StartVerification() {
            Intent verificationIntent = new Intent(this, typeof(ZoomVerificationActivity));

            if (hybridEncryptionKey.Length > 0) {
                verificationIntent.PutExtra(ZoomSDK.ExtraRetrieveZoomBiometric, true);
            }

            StartActivityForResult(verificationIntent, ZoomSDK.RequestCodeVerification);
        }

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
			if (resultCode == Result.Ok) {
				if (requestCode == ZoomSDK.RequestCodeVerification) {
                    ZoomVerificationResult result = (ZoomVerificationResult)data.GetParcelableExtra(ZoomSDK.ExtraVerifyResults);

                    if (result.FaceMetrics != null) {
                        byte[] zoomFacemap = result.FaceMetrics.GetZoomFacemap();

                        if (latestZoomHybridRequestType == ZoomHybridRequestType.Enroll) {
                            EnrollUser(identityText.Text.Replace(" ", ""), zoomFacemap, result.SessionId);
                        }
                        else if (latestZoomHybridRequestType == ZoomHybridRequestType.Authenticate) {
                            AuthenticateUser(identityText.Text.Replace(" ", ""), zoomFacemap, result.SessionId);
                        }
                    }
                }
			}
		}

		protected void ShowZoomAlert(string title, string message) {
			AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle(title);
			alert.SetMessage(message);
			alert.SetCancelable(true);
			alert.SetNeutralButton("Ok", (senderAlert, arg) => { });
			alert.Create().Show();
		}

		private class ZoomInitializeCallback : ZoomSDK.InitializeCallback {
			private MainActivity activity;

			public ZoomInitializeCallback(MainActivity activity) {
				this.activity = activity;
			}

			public override void OnCompletion(bool success) {
				activity.RunOnUiThread(delegate {
					activity.enrollButton.Enabled = success;
					activity.authButton.Enabled = success;
                    activity.checkEnrollmentButton.Enabled = success;
                    activity.deleteEnrollmentButton.Enabled = success;

                    if (!success) {
						String statusStr = ZoomSDK.GetStatus(activity).ToString();
						String alertMessage = "Initialization failed. " + statusStr;
                        activity.ShowZoomAlert("Warning", alertMessage);
					}
				});
			}
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

        private async void EnrollUser(String user, byte[] zoomFacemap, String sessionId) {
            String zoomFacemapStr = Convert.ToBase64String(zoomFacemap);
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
            if (enrolled) {
                ShowZoomAlert("Enrollment Status", "User Enrolled!");
            }
            else {
                ShowZoomAlert("Enrollment Status", "Enrollment Failed\nHybrid Response:\n" + result);
            }
        }

        private async void AuthenticateUser(String user, byte[] zoomFacemap, String sessionId) {
            JObject paramterField = new JObject();
            paramterField.Add("enrollmentIdentifier", user);
            String zoomFacemapStr = Convert.ToBase64String(zoomFacemap);
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
            if (ok) {
                int authenticated = parsedResponse.data.results[0].authenticated;
                if (authenticated == 1) {
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