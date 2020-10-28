namespace SibSample.Infrastructure.Database
{
    using Microsoft.EntityFrameworkCore;
    using SibSample.Domain;
    using SibSample.Domain.Users;
    using SibSample.Domain.Users.Documents;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .OwnsOne(x => x.Email).HasIndex(x => x.Value);

            modelBuilder.Entity<User>()
                .OwnsOne(x => x.Email).Property(x => x.Value).HasColumnName("Email");

            modelBuilder.Entity<Document>()
                .HasOne(s => s.User)
                .WithMany(g => g.Documents)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}