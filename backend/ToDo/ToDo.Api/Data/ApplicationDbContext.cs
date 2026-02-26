using Microsoft.EntityFrameworkCore;
using ToDo.Api.Models;

namespace ToDo.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();   // no duplicate emails
                entity.HasIndex(u => u.UserName).IsUnique(); // no duplicate usernames
                entity.Property(u => u.Email).HasMaxLength(256);
                entity.Property(u => u.UserName).HasMaxLength(100);
            });

            // Configure TodoItem and its FK relationship
            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.Property(t => t.Title).HasMaxLength(200).IsRequired();
                entity.HasOne(t => t.User)
                      .WithMany(u => u.TodoItems)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // deleting a user deletes their todos
            });
        }
    }
}
