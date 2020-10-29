namespace SibSample.Infrastructure.Domain
{
    using Autofac;
    using Repositories;
    using SibSample.Domain;
    using SibSample.Domain.Core.Data;

    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BankRepository>().As<IBankRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}