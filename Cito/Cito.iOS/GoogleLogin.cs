using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using Google.SignIn;
using UIKit;

namespace Cito.iOS
{
    public class GoogleLogin : UIViewController, ISignInDelegate, ISignInUIDelegate
    {
        internal static bool IsGoogleLogin;

        public GoogleLogin()
        {
            SignIn.SharedInstance.UIDelegate = this;
            SignIn.SharedInstance.Delegate = this;
        }
        public void HandleGoogleLoginClicked()
        {
			if (SignIn.SharedInstance.HasAuthInKeychain) {
				SignIn.SharedInstance.SignInUserSilently();
			} else {
				SignIn.SharedInstance.SignInUser();
			}
        }


        public void DidSignIn(SignIn signIn, GoogleUser user, NSError error)
        {                 
            if (user != null && error == null)
            {
                App.Locator.CreateAccount.FullName = user.Profile.Name;
                App.Locator.Prelogin.ExternalLoginCommand.Execute(null);
            }
        }

        [Export("signIn:didDisconnectWithUser:withError:")]
		public virtual void DidDisconnect(SignIn signIn, GoogleUser user, NSError error)
        {
		}


        [Export("signInWillDispatch:error:")]
        public void WillDispatch(SignIn signIn, NSError error)
        {
        }

        [Export("signIn:presentViewController:")]
        public void PresentViewController(SignIn signIn, UIViewController viewController)
        {
            PresentViewController(viewController, true, null);
        }

        [Export("signIn:dismissViewController:")]
        public void DismissViewController(SignIn signIn, UIViewController viewController)
        {
            DismissViewController(true, null);
        }
    }
}
