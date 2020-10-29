namespace SibSample.SeedWorks.Logs
{
    using Autofac;
    using Serilog;

    public class LogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Logging>().As<ILogging>();

            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}