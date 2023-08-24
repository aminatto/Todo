using Kobold.TodoApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Kobold.TodoApp.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<TodoCollection> TodoCollections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .HasOne(t => t.TodoCollection)
                .WithMany(c => c.Todos)
                .HasForeignKey(t => t.TodoCollectionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
