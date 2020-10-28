namespace SibSample.Infrastructure.Processing
{
    using System.Reflection;
    using Application;

    public static class Assemblies
    {
        public static readonly Assembly Application = typeof(CommandBase).Assembly;
    }
}