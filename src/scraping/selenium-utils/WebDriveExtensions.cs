using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;

namespace Selenium.Utils
{
    public static class WebDriveExtensions
    {
        public static void LoadPage(this IWebDriver webDriver,
            TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            var webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            var webElement = webDriver.FindElement(by);
            if (!(webDriver is InternetExplorerDriver)) // workaround submit for IE
            {
                webElement.Submit();
            }
            else
            {
                webElement.SendKeys(Keys.Enter);
            }
        }
    }
}