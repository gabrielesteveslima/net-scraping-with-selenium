namespace CipScrapingBot
{
    using System;
    using System.Collections.Generic;
    using Configuration;
    using OpenQA.Selenium;
    using Selenium.Utils;

    public class PageObject : IPageObject
    {
        private readonly SeleniumConfig _seleniumConfig;
        private IWebDriver _driver;

        public PageObject(SeleniumConfig seleniumConfig, IWebDriver driver)
        {
            _seleniumConfig = seleniumConfig;
            _driver = driver;
        }

        public IEnumerable<Bank> RunWebScraping()
        {
            try
            {
                _driver.LoadPage(TimeSpan.FromSeconds(_seleniumConfig.Timeout), _seleniumConfig.ScrapingPath);

                var banks = new List<Bank>();
                var rowsPage = _driver
                    .FindElement(By.ClassName("demo"))
                    .FindElement(By.TagName("tbody"))
                    .FindElements(By.TagName("tr"));

                foreach (var row in rowsPage)
                {
                    var bankData = row.FindElements(By.TagName("td"));
                    var bank = new Bank
                    {
                        Name = bankData[1].Text,
                        Code = bankData[2].Text,
                        Document = bankData[3].Text,
                        ISPB = bankData[4].Text,
                        Product = bankData[5].Text,
                    };
                    
                    banks.Add(bank);
                }

                return banks;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _driver.Close();
            }
        }
    }

    public interface IPageObject
    {
        IEnumerable<Bank> RunWebScraping();
    }
}