using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Plus;
using Android.OS;
using Xamarin.Facebook;
using Xamarin.Forms;

namespace Cito.Droid
{
    internal static class GoogleLogin 
    {
        internal static ICallbackManager CallbackManager;
        internal static GoogleApiClient MyGoogleApiClient;
        internal static GoogleApiClient.Builder Builder;
        internal static bool IsGoogleLogin;
        internal static bool IsIntentStarted;
        internal static bool IntentHandled;

        public static void Handle()
        {
            CallbackManager = CallbackManagerFactory.Create();
            CreateBuilder();           
            RegisterGoogleCallbacks();
        }

        public static void RegisterGoogleCallbacks()
        {
            CallbackManager = CallbackManagerFactory.Create();
        }

        public static void CreateBuilder()
        {
            var googleCallbacks = new GoogleCallback();

            Builder = new GoogleApiClient.Builder(Forms.Context);
            Builder.AddConnectionCallbacks(googleCallbacks);
            Builder.AddOnConnectionFailedListener(googleCallbacks);
            Builder.AddApi(PlusClass.API);
            Builder.AddScope(PlusClass.ScopePlusLogin);
            Builder.AddScope(PlusClass.ScopePlusProfile);

            MyGoogleApiClient = Builder.Build();
        }      
    }

    internal class GoogleCallback : Fragment, GoogleApiClient.IConnectionCallbacks,
        GoogleApiClient.IOnConnectionFailedListener
    {
        internal static ConnectionResult MyConnectionResult;
        public new void Dispose()
        {
            
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            MyConnectionResult = result;
            ResolveSignInError();
        }

        public void OnConnected(Bundle connectionHint)
        {
            GoogleLogin.IntentHandled = false;
            GoogleLogin.IsIntentStarted = false;
            GoogleLogin.IsGoogleLogin = false;
            App.Locator.Prelogin.ExternalLoginCommand.Execute(null);
        }

        public void OnConnectionSuspended(int cause)
        {
            
        }


        private void ResolveSignInError()
        {
            if (GoogleLogin.MyGoogleApiClient.IsConnected)
            {
                return;
            }

            if(MyConnectionResult != null)
            {
                if (MyConnectionResult.HasResolution)
                {
                    try
                    {
                        if (!GoogleLogin.MyGoogleApiClient.IsConnecting && (!GoogleLogin.IsIntentStarted || GoogleLogin.IntentHandled))
                        {
                            GoogleLogin.IsIntentStarted = true;
                            var activity = (MainActivity)Forms.Context;
                            activity.StartIntentSenderForResult(MyConnectionResult.Resolution.IntentSender, 0, null, 0, 0, 0);
                            GoogleLogin.IntentHandled = false;
                        }
                    }
                    catch (IntentSender.SendIntentException e)
                    {
                        GoogleLogin.MyGoogleApiClient.Connect();
                    }
                }          
            }
        }
    }
}