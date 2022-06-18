using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
namespace RageClient.Authorization
{
    public class Authorization : Events.Script
    {
        public Authorization()
        {
            RAGE.Events.Add("ShowAuthorizationCommon", OnShowAuthorizationCommon);
            RAGE.Events.Add("ShowAuthorizationLogin", OnShowAuthorizationLogin);
            RAGE.Events.Add("ShowAuthorizationRegister", OnShowAuthorizationRegister);
            RAGE.Events.Add("AuthorizationFormLogin", OnAuthorizationFormLogin);
            RAGE.Events.Add("AuthorizationFormRegister", OnAuthorizationFormRegister);
            RAGE.Events.Add("AuthorizationFormError", OnAuthorizationFormError);
            RAGE.Events.Add("AuthorizationSuccess", OnAuthorizationSuccess);
        }
      
        private void OnShowAuthorizationCommon(object[] args)
        {
            BrowserSystem.WindowBrowser.SetWindow("package://cef/login/index.html");
            BrowserSystem.WindowBrowser.SetActivated(true);
            BrowserSystem.WindowBrowser.SetCursorShowed(true);
        }
        private void OnShowAuthorizationLogin(object[] args)
        {
            BrowserSystem.WindowBrowser.ExcecuteJS("showLoginForm()");
        }

        private void OnShowAuthorizationRegister(object[] args)
        {
            BrowserSystem.WindowBrowser.ExcecuteJS("showRegisterForm()");
        }

        private void OnAuthorizationFormLogin(object[] args)
        {
            string login = (string)args[0];
            string pass = (string)args[1];
            RAGE.Events.CallRemote("AuthorizationLogin",login,pass);
        }

        private void OnAuthorizationFormRegister(object[] args)
        {
            string login = (string)args[0];
            string pass = (string)args[1];
            RAGE.Events.CallRemote("AuthorizationRegister", login, pass);
        }

        private void OnAuthorizationFormError(object[] args)
        {
            string[] errors = (string[])args[0];
            BrowserSystem.WindowBrowser.ExcecuteJS($"showErrors({errors})");
        }

        private void OnAuthorizationSuccess(object[] args)
        {
            BrowserSystem.WindowBrowser.SetCursorShowed(false);
            BrowserSystem.WindowBrowser.SetActivated(false);
        }

    }
}
