using System;
using System.Collections.Generic;
using System.Text;

namespace RageClient.BrowserSystem
{
    public static class WindowBrowser
    {
        private static Browser currentBrowser;
        public static void SetWindow(string url)
        {
            if (currentBrowser != null) currentBrowser.Destroy();
            currentBrowser = new Browser(url);
        }
        public static void ExcecuteJS(string js)
        {
            if (currentBrowser == null) return;
            currentBrowser.ExcecuteJS(js);
        }
        public static void SetActivated(bool activated)
        {
            if (currentBrowser == null) return;
            currentBrowser.SetActive(activated);
            RAGE.Chat.Activate(!activated);
        }
        public static void SetCursorShowed(bool status)
        {
            RAGE.Ui.Cursor.Visible = status;
        }
    }
}
