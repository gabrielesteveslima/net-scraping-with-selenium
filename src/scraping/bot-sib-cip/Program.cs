using System;

namespace CipScrapingBot
{
    using System;
    using System.IO;
    using Autofac;
    using Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Selenium.Utils;
    using SibSample.SeedWorks.Logs;

    internal class Program
    {
        private static IContainer Container { get; set; }
        private static IConfiguration Configuration { get; set; }

        private static void Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var builder = new ContainerBuilder();
            RegisterDependencies(builder);
            Container = builder.Build();

            var pageObject = Container.Resolve<IPageObject>();
            pageObject.RunWebScraping();
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            //using log module, best way create nuget for this
            builder.RegisterModule(new LogModule());
            builder.RegisterType<PageObject>().As<IPageObject>();

            builder.Register(x => Configuration.GetSection("selenium").Get<SeleniumConfig>()).As<SeleniumConfig>();

            builder.Register(x =>
            {
                var seleniumConfig = x.Resolve<SeleniumConfig>();
                return WebDriveFactory.CreateWebDrive(seleniumConfig.Browser, seleniumConfig.DrivePath,
                    seleniumConfig.Headless);
            }).As<IWebDriver>();
        }
    }
}