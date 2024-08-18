using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using YogaCommerce.EntityFramework.Data.Models;

namespace YogaCommerce.EntityFramework.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (AuditableEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreationTime = DateTime.UtcNow;
                }
                entity.LastModifiedTime = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
