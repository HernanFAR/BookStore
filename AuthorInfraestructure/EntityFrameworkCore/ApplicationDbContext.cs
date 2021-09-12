using AuthorDomain.Core.AuthorAggregateRoot;
using AuthorInfraestructure.EntityFrameworkCore.Relations;
using Microsoft.EntityFrameworkCore;

namespace AuthorInfraestructure.EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get => Set<Author>(); }


        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AuthorEntityTypeConfiguration().Configure(modelBuilder.Entity<Author>());
        }
    }
}
