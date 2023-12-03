using Microsoft.AspNetCore.Mvc;
using TodoList.Exceptions;
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
    public async Task<IActionResult> CreateAsync(CreateTodoVM vm)
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
    public async Task<IActionResult> GetAllAsync(
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

    [HttpPatch("{id}/done")]
    public async Task<IActionResult> UpdateDoneStatusAsync([FromRoute] int id)
    {
        try
        {
            var todo = await _repository.GetByIdAsync(id);
            await _repository.UpdateDoneStatusAsync(todo);

            return Ok(new ResponseVM<dynamic>(new { message = "Todo atualizado com sucesso" }));
        }
        catch (NotFoundException)
        {
            return NotFound(new ResponseVM<string>("Todo não encontrado no sistema"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResponseVM<string>("Erro ao tentar atualizar todo"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var todo = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(todo);
            return Ok(new ResponseVM<dynamic>(new { message = "Todo removido com sucesso" }));
        }
        catch (NotFoundException)
        {
            return NotFound(new ResponseVM<string>("Todo não encontrado no sistema"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResponseVM<string>("Erro ao tentar remover todo"));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateTodoVM vm, [FromRoute] int id)
    {
        try
        {
            var todo = await _repository.GetByIdAsync(id);
            await _repository.UpdateAsync(todo, vm);
            return Ok(new ResponseVM<dynamic>(new { message = "Todo atualizado com sucesso" }));
        }
        catch (NotFoundException)
        {
            return NotFound(new ResponseVM<string>("Todo não encontrado no sistema"));
        }
        catch (Exception)
        {
            throw;
        }
    }
}
