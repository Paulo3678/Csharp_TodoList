using System.ComponentModel.DataAnnotations;

namespace TodoList.ViewModels.Todo;

public class UpdateTodoVM
{
    [Required(ErrorMessage = "É preciso informar o titulo para continuar")]
    [MinLength(3, ErrorMessage = "O titulo deve ter ao menos 3 caracteres")]
    public string Title { get; set; }
    [Required(ErrorMessage = "É preciso informar a descrição para continuar")]
    [MinLength(3, ErrorMessage = "O titulo deve ter ao menos 3 caracteres")]
    public string Description { get; set; }

}
