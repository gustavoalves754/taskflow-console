using TaskFlow.Console.Services;

namespace TaskFlow.Tests;

public sealed class TaskManagerTests
{
    [Fact]
    public void AddTask_WithValidTitle_AddsTaskToList()
    {
        var manager = new TaskManager();

        var createdTask = manager.AddTask("Estudar testes unitários");

        var storedTask = Assert.Single(manager.ListTasks());
        Assert.Same(createdTask, storedTask);
        Assert.Equal("Estudar testes unitários", storedTask.Title);
        Assert.False(storedTask.IsCompleted);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void AddTask_WithMissingTitle_ThrowsArgumentException(string? title)
    {
        var manager = new TaskManager();

        Assert.Throws<ArgumentException>(() => manager.AddTask(title));
        Assert.Empty(manager.ListTasks());
    }
}
