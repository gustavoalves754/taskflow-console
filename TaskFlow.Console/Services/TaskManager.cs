using TaskFlow.Console.Domain;

namespace TaskFlow.Console.Services;

public sealed class TaskManager
{
    private readonly List<TaskItem> _tasks = [];

    public TaskItem AddTask(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("O título da tarefa é obrigatório.", nameof(title));
        }

        var task = new TaskItem(title.Trim());
        _tasks.Add(task);
        return task;
    }

    public IReadOnlyList<TaskItem> ListTasks()
    {
        return _tasks.AsReadOnly();
    }

    public TaskItem FindTaskById(Guid id)
    {
        return _tasks.FirstOrDefault(task => task.Id == id)
            ?? throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");
    }

    public bool CompleteTask(Guid id)
    {
        var task = FindTaskById(id);

        if (!task.IsCompleted)
        {
            task.ToggleCompletion();
        }

        return true;
    }
}
