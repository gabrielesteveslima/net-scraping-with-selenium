namespace SibSample.Infrastructure
{
    using Database;
    using Microsoft.EntityFrameworkCore;
    using SibSample.Domain;

    public class EntityContextChild : ApplicationContext
    {
        public EntityContextChild(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }
    }
}