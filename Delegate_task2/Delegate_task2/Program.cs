class Programm
{
    static void Main(String[] args)
    {
        List <Task> tasks = new List <Task> ();
        tasks.Add(new Task("Task№1", "Check this out"));
        tasks.Add(new Task("Task№2", "Check that out"));
        TaskManager taskManager = new TaskManager ();
        TaskNotifications taskNotifications = new TaskNotifications ();
        taskManager.TaskCompleted += taskNotifications.TaskCompleteNotification;
        taskManager.CompleteTask(tasks[1]);
    }
}

class Task
{
    private string name = "No name";
    private string description = "No description";
    private bool status = false;

    public string Name { get { return name; } set { name = value; } }
    public string Description { get { return description; } set { description = value; } }
    public bool Status { get { return status; } set { status = value; } }
    public Task(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

}

class TaskManager
{
    public delegate void TaskCompletion(Task task);
    public event TaskCompletion TaskCompleted;
    public TaskManager() { }
    public void CompleteTask (Task task)
    {
        task.Status = true;
        TaskCompleted (task);
    }
}

class TaskNotifications
{
    public void TaskCompleteNotification(Task task)
    {
        Console.WriteLine("Task {0} completed", task.Name);
    }
}