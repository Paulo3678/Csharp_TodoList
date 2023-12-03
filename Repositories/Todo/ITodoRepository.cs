using TodoList.ViewModels.Todo;

namespace TodoList.Repositories.Todo;

public interface ITodoRepository
{
    public Task<Models.Todo> CreateAsync(CreateTodoVM vm);
}
