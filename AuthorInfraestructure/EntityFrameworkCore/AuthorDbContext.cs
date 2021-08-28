using AuthorDomain.Core.AuthorAggregateRoot;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorInfraestructure.EntityFrameworkCore
{
    public class AuthorDbContext : DbContext
    {
        public DbSet<Author> Authors { get => Set<Author>(); }


        public AuthorDbContext(DbContextOptions options) : 
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
