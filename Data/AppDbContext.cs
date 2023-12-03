using Microsoft.EntityFrameworkCore;
using TodoList.Data.Configurations;
using TodoList.Models;

namespace TodoList.Data;

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TodoList;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoConf());
        base.OnModelCreating(modelBuilder);
    }
}
