using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Repositories.Todo;
using TodoList.ViewModels;
using TodoList.ViewModels.Todo;

namespace TodoList.Controllers;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository _repository;
    public TodoController(ITodoRepository repository) => _repository = repository;

    public async Task<IActionResult> Create(CreateTodoVM vm)
    {
        try
        {
            var todo = await _repository.CreateAsync(vm);
            return Ok(new ResponseVM<Todo>(todo));
        }
        catch (Exception)
        {
            throw;
            return StatusCode(500, new ResponseVM<string>("Erro ao tentar criar todo"));
        }
    }

}
