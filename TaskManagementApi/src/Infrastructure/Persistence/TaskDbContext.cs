using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

    public DbSet<TaskEntity> Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<TaskEntity>()
        .Property(t => t.IsCompleted)
        .HasDefaultValue(false); // Ensure it reflects changes
}


    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<TaskEntity>().ToTable("Tasks");
    // }
}
