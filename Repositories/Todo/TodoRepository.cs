using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.ViewModels.Todo;

namespace TodoList.Repositories.Todo;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;
    public TodoRepository(AppDbContext context) => _context = context;

    public async Task<Models.Todo> CreateAsync(CreateTodoVM vm)
    {
        var todo = new Models.Todo();
        todo.Description = vm.Description;
        todo.Title = vm.Title;
        todo.Done = false;

        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
    public async Task<List<Models.Todo>> GetAsync(int page = 0, int perPage = 10)
    {
        try
        {
            var todos = await _context.Todos
            .AsNoTracking()
            .Take(perPage)
            .Skip(page * perPage)
            .ToListAsync();

            return todos;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar buscar todos");
        }
    }
}
