using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Exceptions;
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
    public async Task<Models.Todo> GetByIdAsync(int id)
    {
        try
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null) throw new NotFoundException("Todo não encontrado", null);

            return todo;
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar buscar todo");
        }
    }
    public async Task UpdateDoneStatusAsync(Models.Todo todo)
    {
        try
        {
            todo.Done = !todo.Done;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar atualizar todo");
        }
    }
    public async Task DeleteAsync(Models.Todo todo)
    {
        try
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar remover todo");
        }
    }
}
