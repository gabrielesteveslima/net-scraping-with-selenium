namespace CipScrapingBot.Configuration
{
    using Selenium.Utils;

    public class SeleniumConfig
    {
        public string DrivePath { get; set; }
        public string ScrapingPath { get; set; }
        public int Timeout { get; set; }
        public bool Headless { get; set; }
        public Browser Browser { get; set; }
    }
}