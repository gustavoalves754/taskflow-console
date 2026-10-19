using TaskFlow.Console.Domain;
using TaskFlow.Console.Services;

var manager = new TaskManager();
var isRunning = true;

while (isRunning)
{
    ShowMenu();
    var option = System.Console.ReadLine()?.Trim();
    System.Console.WriteLine();

    switch (option)
    {
        case "1":
            AddTask(manager);
            break;
        case "2":
            ListTasks(manager);
            break;
        case "3":
            CompleteTask(manager);
            break;
        case "0":
            isRunning = false;
            System.Console.WriteLine("Até logo!");
            break;
        default:
            System.Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    System.Console.WriteLine();
}

static void ShowMenu()
{
    System.Console.WriteLine("========================");
    System.Console.WriteLine("        TASKFLOW");
    System.Console.WriteLine("========================");
    System.Console.WriteLine("1 - Adicionar tarefa");
    System.Console.WriteLine("2 - Listar tarefas");
    System.Console.WriteLine("3 - Concluir tarefa");
    System.Console.WriteLine("0 - Sair");
    System.Console.Write("Escolha uma opção: ");
}

static void AddTask(TaskManager manager)
{
    System.Console.Write("Título da tarefa: ");
    var title = System.Console.ReadLine();

    try
    {
        var task = manager.AddTask(title);
        System.Console.WriteLine($"Tarefa adicionada com o ID {task.Id}.");
    }
    catch (ArgumentException exception)
    {
        System.Console.WriteLine(exception.Message);
    }
}

static void ListTasks(TaskManager manager)
{
    var tasks = manager.ListTasks();

    if (tasks.Count == 0)
    {
        System.Console.WriteLine("Nenhuma tarefa cadastrada.");
        return;
    }

    foreach (var task in tasks)
    {
        WriteTask(task);
    }
}

static void CompleteTask(TaskManager manager)
{
    System.Console.Write("Informe o ID da tarefa: ");

    if (!Guid.TryParse(System.Console.ReadLine(), out var id))
    {
        System.Console.WriteLine("ID inválido.");
        return;
    }

    var completed = manager.CompleteTask(id);
    System.Console.WriteLine(completed
        ? "Tarefa concluída com sucesso."
        : "Tarefa não encontrada.");
}

static void WriteTask(TaskItem task)
{
    var status = task.IsCompleted ? "Concluída" : "Pendente";
    System.Console.WriteLine($"[{status}] {task.Title} (ID: {task.Id})");
}
