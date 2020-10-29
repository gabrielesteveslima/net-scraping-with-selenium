namespace SibSample.Infrastructure.Database
{
    using Microsoft.EntityFrameworkCore;
    using SibSample.Domain;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().HasKey(x => x.Id).HasName("Id");
            modelBuilder.Entity<Bank>()
                .OwnsOne(x => x.Document).HasIndex(x => x.Value);

            modelBuilder.Entity<Bank>()
                .OwnsOne(x => x.Document).Property(x => x.Value).HasColumnName("Document");
        }

        public DbSet<Bank> Banks { get; set; }
    }
}