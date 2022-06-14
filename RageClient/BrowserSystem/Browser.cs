using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
namespace RageClient.BrowserSystem
{
    public class Browser
    {
        private RAGE.Ui.HtmlWindow window;

        public Browser(string url)
        {
            window = new RAGE.Ui.HtmlWindow(url);
            window.Active = false;
        }
        public void ExcecuteJS(string js)
        {
            window.ExecuteJs(js);
        }
        public void Destroy()
        {
            if (window != null) window.Destroy();
        }
        public void SetActive(bool activated)
        {
            if (window != null) window.Active = activated;
        }

    }
}
