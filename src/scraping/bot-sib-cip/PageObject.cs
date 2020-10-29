namespace CipScrapingBot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Configuration;
    using Flurl;
    using Flurl.Http;
    using Flurl.Http.Configuration;
    using Newtonsoft.Json;
    using OpenQA.Selenium;
    using Polly;
    using Polly.Retry;
    using Selenium.Utils;
    using SibSample.SeedWorks.Logs;

    public class PageObject : IPageObject
    {
        private readonly SeleniumConfig _seleniumConfig;
        private readonly SibApiConfig _sibApiConfig;
        private readonly IWebDriver _driver;
        private readonly ILogging _logging;

        public PageObject(SeleniumConfig seleniumConfig, IWebDriver driver, ILogging logging, SibApiConfig sibApiConfig)
        {
            _seleniumConfig = seleniumConfig;
            _driver = driver;
            _logging = logging;
            _sibApiConfig = sibApiConfig;
        }

        public async Task<List<Bank>> RunWebScraping()
        {
            try
            {
                _driver.LoadPage(TimeSpan.FromSeconds(_seleniumConfig.Timeout), _seleniumConfig.ScrapingPath);

                var rowsPage = _driver
                    .FindElement(By.ClassName("demo"))
                    .FindElement(By.TagName("tbody"))
                    .FindElements(By.TagName("tr"));

                return rowsPage.Select(row => row.FindElements(By.TagName("td")))
                    .Select(bankData => new Bank
                    {
                        Name = bankData[1].Text,
                        Code = bankData[2].Text,
                        Document = bankData[3].Text,
                        ISPB = bankData[4].Text
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                _logging.Error(new
                {
                    details = "Error happened in the web scraping process",
                    exception = new {e.Message, e.InnerException}
                });

                throw;
            }
            finally
            {
                _driver.Close();
            }
        }
    }
}