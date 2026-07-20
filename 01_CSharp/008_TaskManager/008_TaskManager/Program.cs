List<string> tasks = new List<string>();
bool isRunning = true;
Console.WriteLine("Welcome to the Task Manager!");
Console.WriteLine();
while (isRunning)
{
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. Show tasks");
    Console.WriteLine("3. Update task");
    Console.WriteLine("4. Remove task");
    Console.WriteLine("5. Exit");
    Console.WriteLine();
    Console.WriteLine("Select option:");
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            AddTask(tasks);
            break;

        case "2":
            ShowTasks(tasks);
            break;

        case "3":
            UpdateTask(tasks);
            break;

        case "4":
            RemoveTask(tasks);
            break;

        case "5":
            isRunning = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
    if (isRunning)
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadLine();
        Console.Clear();
    }
}
Console.WriteLine("Goodbye!");
void AddTask(List<string> tasks)
{

    Console.WriteLine("Enter the task description:");
    string description = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(description))
    {
        Console.WriteLine("Task description cannot be empty.");
        return;
    }

    Console.WriteLine();
    tasks.Add(description);

    Console.WriteLine();
    Console.WriteLine("Task added successfully!");
}
void ShowTasks(List<string> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Your task list is empty.");
        return;
    }

    Console.WriteLine("Your tasks:");

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i]}");
    }
}
void RemoveTask(List<string> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Your task list is empty.");
        return;
    }

    ShowTasks(tasks);
    Console.WriteLine();

    Console.WriteLine("Enter the number of the task to remove:");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int taskNumber))
    {
        Console.WriteLine("Invalid task number.");
        return;
    }

    int index = taskNumber - 1;

    if (index < 0 || index >= tasks.Count)
    {
        Console.WriteLine("Task number does not exist.");
        return;
    }

    string removedTask = tasks[index];
    tasks.RemoveAt(index);

    Console.WriteLine($"Task \"{removedTask}\" removed successfully.");
}
void UpdateTask(List<string> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Your task list is empty.");
        return;
    }

    ShowTasks(tasks);
    Console.WriteLine();

    Console.WriteLine("Enter the number of the task to update:");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int taskNumber))
    {
        Console.WriteLine("Invalid task number.");
        return;
    }

    int index = taskNumber - 1;

    if (index < 0 || index >= tasks.Count)
    {
        Console.WriteLine("Task number does not exist.");
        return;
    }

    string oldTask = tasks[index];

    Console.WriteLine("Enter the new task description:");
    string newDescription = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(newDescription))
    {
        Console.WriteLine("Task description cannot be empty.");
        return;
    }

    tasks[index] = newDescription;

    Console.WriteLine($"Task \"{oldTask}\" updated to \"{newDescription}\".");
}