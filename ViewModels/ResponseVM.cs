namespace TodoList.ViewModels;

public class ResponseVM<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; } = new();
    public ResponseVM() { }
    public ResponseVM(T data) => Data = data;
    public ResponseVM(string error) => Errors.Add(error);
    public ResponseVM(List<string> errors) => Errors = errors;
}


