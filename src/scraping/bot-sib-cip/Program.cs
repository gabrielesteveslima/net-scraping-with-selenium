using System;

namespace CipScrapingBot
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Autofac;
    using Configuration;
    using Configuration.Resilience;
    using Flurl;
    using Flurl.Http;
    using Flurl.Http.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Polly;
    using Polly.Retry;
    using Selenium.Utils;
    using SendData;
    using SibSample.SeedWorks.Logs;

    internal class Program
    {
        private static IContainer Container { get; set; }
        private static IConfiguration Configuration { get; set; }

        private static async Task Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var builder = new ContainerBuilder();
            RegisterDependencies(builder);
            Container = builder.Build();

            var sendDataToSampleApi = Container.Resolve<ISendDataToSampleApi>();

            var pageObject = Container.Resolve<IPageObject>();
            var banks = await pageObject.RunWebScraping();
            await sendDataToSampleApi.Share(banks);
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            FlurlHttp.Configure(settings => settings.HttpClientFactory = new PollyHttpClientFactory());

            //using log module, best way create nuget for this
            builder.RegisterModule(new LogModule());
            builder.RegisterType<PageObject>().As<IPageObject>();
            builder.RegisterType<SendDataToSampleApi>().As<ISendDataToSampleApi>();

            builder.Register(x => Configuration.GetSection("selenium").Get<SeleniumConfig>()).As<SeleniumConfig>();
            builder.Register(x => Configuration.GetSection("sibApi").Get<SibApiConfig>()).As<SibApiConfig>();

            builder.Register(x =>
            {
                var seleniumConfig = x.Resolve<SeleniumConfig>();
                return WebDriveFactory.CreateWebDrive(seleniumConfig.Browser, seleniumConfig.DrivePath,
                    seleniumConfig.Headless);
            }).As<IWebDriver>();
        }
    }
}