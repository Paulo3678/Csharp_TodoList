using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Repositories.Todo;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
         .SetBasePath(System.IO.Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json")
         .Build();

var connString = configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connString);
});

builder.Services.AddControllers();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();

var app = builder.Build();
app.MapControllers();

app.Run();
