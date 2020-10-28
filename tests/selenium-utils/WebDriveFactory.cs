namespace Selenium.Utils
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;

    public static class WebDriveFactory
    {
        public static IWebDriver CreateWebDrive(Browser browser, string pathDriver, bool headless)
        {
            IWebDriver webDriver;

            switch (browser)
            {
                case Browser.Firefox:
                    var optionsFf = new FirefoxOptions();
                    if (headless)
                    {
                        optionsFf.AddArgument("--headless");
                    }

                    webDriver = new FirefoxDriver(pathDriver, optionsFf);

                    break;
                case Browser.Chrome:
                    var options = new ChromeOptions();
                    if (headless)
                    {
                        options.AddArgument("--headless");
                    }

                    webDriver = new ChromeDriver(pathDriver, options);

                    break;
                default:
                    throw new WebDriveNotUndefinedException("Web driver undefined");
            }

            return webDriver;
        }
    }
}