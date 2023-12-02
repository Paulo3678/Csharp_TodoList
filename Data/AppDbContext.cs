using Microsoft.EntityFrameworkCore;
using TodoList.Data.Configurations;

namespace TodoList.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Perguntas;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoConf());
        base.OnModelCreating(modelBuilder);
    }

}
