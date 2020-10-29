namespace SibSample.Infrastructure
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Autofac.Extras.CommonServiceLocator;
    using CommonServiceLocator;
    using Domain;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Processing;
    using System;
    using Database;
    using SeedWorks.Logs;

    public static class ApplicationStartup
    {
        public static IServiceProvider Initialize(
            IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = CreateAutofacServiceProvider(services, configuration);
            return serviceProvider;
        }

        private static IServiceProvider CreateAutofacServiceProvider(
            IServiceCollection services, IConfiguration configuration)
        {
            var container = new ContainerBuilder();

            container.Populate(services);
            container.RegisterModule(new DatabaseModule(
                configuration.GetConnectionString("DefaultConnection")));
            container.RegisterModule(new LogModule());
            container.RegisterModule(new DomainModule());
            container.RegisterModule(new MediatorModule());

            var buildContainer = container.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(buildContainer));
            var serviceProvider = new AutofacServiceProvider(buildContainer);
            return serviceProvider;
        }
    }
}