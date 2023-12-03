using TodoList.ViewModels.Todo;

namespace TodoList.Repositories.Todo;

public interface ITodoRepository
{
    public Task<Models.Todo> CreateAsync(CreateTodoVM vm);
    public Task<List<Models.Todo>> GetAsync(int page = 0, int perPage=10);
    public Task<Models.Todo> GetByIdAsync(int id);
    public Task UpdateDoneStatusAsync(Models.Todo todo);
}
