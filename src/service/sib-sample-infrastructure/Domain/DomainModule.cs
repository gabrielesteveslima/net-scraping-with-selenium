namespace SibSample.Infrastructure.Domain
{
    using Autofac;
    using Repositories;
    using SibSample.Domain.Core.Data;
    using SibSample.Domain.Users;

    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}