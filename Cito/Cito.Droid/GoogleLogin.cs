using System;
using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Plus;
using Android.Gms.Plus.Model.People;
using Android.OS;
using Cito.ViewModels;
using Xamarin.Facebook;
using Xamarin.Forms;

namespace Cito.Droid
{
    internal static class GoogleLogin 
    {
        internal static ICallbackManager CallbackManager;
        internal static GoogleApiClient MyGoogleApiClient;
        internal static GoogleApiClient.Builder Builder;
        internal static IPerson UserProfile;
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
            GoogleLogin.UserProfile = PlusClass.PeopleApi.GetCurrentPerson(GoogleLogin.MyGoogleApiClient); // wtf!
            LoadProfile();

            App.Locator.CreateAccount.FullName = GoogleLogin.UserProfile.DisplayName;
            var pic = GoogleLogin.UserProfile.Image.Url;
            var profilePicture = ImageSource.FromUri(new Uri(pic));
            ProfileData.ProfilePicture = profilePicture;
            //App.Locator.OwnerProfile.ProfilePicture = profilePicture;
            GoogleLogin.IntentHandled = false;
            GoogleLogin.IsIntentStarted = false;
            GoogleLogin.IsGoogleLogin = false;
            App.Locator.Prelogin.ExternalLoginCommand.Execute(null);

        }

        public async void LoadProfile()
        {
            var tmp = await PlusClass.PeopleApi.LoadConnected(GoogleLogin.MyGoogleApiClient);
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