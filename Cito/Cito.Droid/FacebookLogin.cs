using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cito;
using Cito.Droid;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Forms;

namespace Cito.Droid
{
    internal static class FacebookLogin
    {
        internal static ICallbackManager CallbackManager;
        internal static Profile FacebookProfile = Profile.CurrentProfile;
        internal static FacebookCallback<LoginResult> LoginCallback;
        internal static Xamarin.Facebook.ProfileTracker FacebookProfileTracker = new ProfileTracker();

        public static void Handle()
        {
            CallbackManager = CallbackManagerFactory.Create();
            RegisterFacebookCallbacks();
            HandleToken();
        }

        public static void RegisterFacebookCallbacks()
        {
            CallbackManager = CallbackManagerFactory.Create();

            LoginCallback = new FacebookCallback<LoginResult>
            {
                HandleSuccess = loginResult =>
                {
                    FacebookSdk.ClientToken = AccessToken.CurrentAccessToken.Token;
                    FacebookProfileTracker.StartTracking();
                    App.Locator.Prelogin.ExternalLoginCommand.Execute(null);
                },

                HandleCancel = () =>
                {
                },

                HandleError = loginError =>
                {

                },

                HandleLogout = () =>
                {
                }
            };

            LoginManager.Instance.RegisterCallback(CallbackManager, LoginCallback);
        }

        public static void HandleToken()
        {
            if (AccessToken.CurrentAccessToken != null)
            {
                var token = AccessToken.CurrentAccessToken;
                FacebookSdk.ClientToken = token.Token;
                var permissions = AccessToken.CurrentAccessToken.Permissions;
                var deniedPermissions = AccessToken.CurrentAccessToken.DeclinedPermissions;
                LoginCallback.HandleSuccess.Invoke(new LoginResult(token, permissions, deniedPermissions));
            }
            else
            {
                FacebookSdk.ClientToken = null;
                LoginCallback.HandleCancel.Invoke();
            }
        }
    }


    internal class FacebookCallback<TResult> : Java.Lang.Object, IFacebookCallback where TResult : Java.Lang.Object
    {
        public Action HandleCancel { get; set; }
        public Action<FacebookException> HandleError { private get; set; }
        public Action<TResult> HandleSuccess { get; set; }
        public Action HandleLogout { get; set; }

        public void OnCancel()
        {
            try
            {
                App.UpdateLoading(true);
                HandleCancel?.Invoke();
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }
        }

        public void OnError(FacebookException error)
        {
            try
            {
                App.UpdateLoading(true);
                HandleError?.Invoke(error);
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            try
            {
                App.UpdateLoading(true);
                HandleSuccess?.Invoke(result.JavaCast<TResult>());
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }
        }

        public void OnLogout()
        {
            try
            {
                App.UpdateLoading(true);
                HandleLogout?.Invoke();
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }
        }
    }

    class ProfileTracker : Xamarin.Facebook.ProfileTracker
    {
        protected override void OnCurrentProfileChanged(Profile oldProfile, Profile currentProfile)
        {
            FacebookLogin.FacebookProfile = currentProfile;
            if (oldProfile == null) { }
            //App.PostSuccessFacebookAction.Invoke(FacebookSdk.ClientToken, FacebookProfile?.Name);
        }
    }
}