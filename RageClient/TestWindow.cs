using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RageClient.BrowserSystem;

namespace RageClient
{
    class TestWindow : Events.Script
    {
        public TestWindow()
        {
            WindowBrowser.SetWindow("package://cef/test.html");
            RAGE.Events.Add("TestWindowShow", OnTestWindowShow);
            RAGE.Events.Add("TestWindowHide", OnTestWindowHide);
        }

        private void OnTestWindowShow(object[] args)
        {
            WindowBrowser.SetActivated(true);
        }

        private void OnTestWindowHide(object[] args)
        {
            WindowBrowser.SetActivated(false);

        }
    }
}
