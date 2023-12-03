using TodoList.Data;
using TodoList.Repositories.Todo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();

builder.Services.AddTransient<ITodoRepository, TodoRepository>();

var app = builder.Build();
app.MapControllers();

app.Run();
