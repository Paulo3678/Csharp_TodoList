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

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoVM vm)
    {
        try
        {
            var todo = await _repository.CreateAsync(vm);
            return Ok(new ResponseVM<Todo>(todo));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResponseVM<string>("Erro ao tentar criar todo"));
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int page = 0,
        [FromQuery] int perPage = 10
    )
    {
        try
        {
            var todos = await _repository.GetAsync(page, perPage);
            return Ok(new ResponseVM<List<Todo>>(todos));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResponseVM<string>("Erro ao tentar buscar todos"));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateDoneStatus(int id)
    {
        return Ok();
    }

}
