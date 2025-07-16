using Microsoft.EntityFrameworkCore;
using Tamagotchi_API.Domain.Entities;

namespace Tamagotchi_API.Data
{
    public class ChecklistContext(DbContextOptions<ChecklistContext> options): DbContext(options)
    {
        public DbSet<ChecklistItem> ChecklistItem => Set<ChecklistItem>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("I've removed this");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChecklistItem>(item =>
            {
                item.HasKey(x => x.Id);
                item.Property(x => x.Title).HasColumnName("Title");
                item.Property(x => x.Description).HasColumnName("Description");
                item.Property(x => x.IsComplete).HasColumnName("IsComplete");
            });
        }
    }
}