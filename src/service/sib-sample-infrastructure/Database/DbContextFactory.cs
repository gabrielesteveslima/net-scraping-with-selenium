namespace SibSample.Infrastructure.Database
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using TypedId;

    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            dbContextOptionsBuilder.UseNpgsql(
                "User ID=postgres;Password=postgres;Host=localhost;Port=5432");

            dbContextOptionsBuilder
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .EnableDetailedErrors();

            return new ApplicationContext(dbContextOptionsBuilder.Options);
        }
    }
}