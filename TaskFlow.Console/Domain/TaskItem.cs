namespace TaskFlow.Console.Domain;

public sealed class TaskItem
{
    public TaskItem(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
    }

    public Guid Id { get; }

    public string Title { get; }

    public bool IsCompleted { get; private set; }

    public void ToggleCompletion()
    {
        IsCompleted = !IsCompleted;
    }
}
