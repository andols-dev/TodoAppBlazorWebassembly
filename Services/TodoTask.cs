using TodoAppExercise.Models;
using TodoAppExercise.LogMessages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Blazored.Toast.Services;


namespace TodoAppExercise.Services
{
    // The TodoTask class handles the logic for managing Todo tasks, including adding, removing, updating, and marking tasks as completed.
    public class TodoTask : ITodoTask
    {
        // A private list to store the tasks
        private readonly List<Todo> _tasks = new List<Todo>();

        // Toast service for showing notifications
        private readonly IToastService _toastService;

      

        // Logger for logging important actions and events
        private readonly ILogger<TodoTask> _logger;

        // Public property to access the list of tasks
        public List<Todo> Tasks => _tasks;

        // A property to store the input value for creating a new Todo task
        public string TodoFromInput { get; set; }

        // Property that filters out only the active tasks (those that are not completed)
        public List<Todo> AllActiveTasks
        {
            get
            {
                // Filters tasks where IsActive is true
                return _tasks.Where(t => t.IsActive).ToList();
            }
        }

        // Property for storing the task description
        public string Description { get; set; }

        // A flag to track whether a task is being updated or not
        public bool IsUpdating { get; set; } = false;

        // The task that is being updated
        public Todo TaskToUpdate { get; set; } = new Todo();

        // Constructor that initializes the TodoTask service with a logger
        public TodoTask(IToastService toastService, ILogger<TodoTask> logger)
        {
            _toastService = toastService ?? throw new ArgumentNullException(nameof(toastService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Adds a new task to the list after validating the input fields
        public void AddTask()
        {
            // Check if the task name is empty
            if (string.IsNullOrEmpty(TodoFromInput))
            {
                // Log a warning message if the task name is empty
                _logger.LogWarning(LogMessages.LogMessages.TaskNameEmpty);
                return;
            }

            // Check if the task description is empty
            if (string.IsNullOrEmpty(Description))
            {
                // Log a warning message if the task description is empty
                _logger.LogWarning(LogMessages.LogMessages.TaskDescriptionEmpty);
                return;
            }

            // Create a new Todo task using the provided name and description, then add it to the task list
            _tasks.Add(new Todo(TodoFromInput, Description));
            _toastService.ShowSuccess($"{LogMessages.LogMessages.TaskAdded} {TodoFromInput}");
            // Reset the input fields after adding the task
            TodoFromInput = String.Empty;
            Description = String.Empty;

            // Log the task creation event with the task name
            _logger.LogInformation("Task added: {TaskName}", TodoFromInput);
            // Skapa ett formatmeddelande genom att använda string.Format
            


        }

        // Removes a task by its ID
        public void RemoveTask(int taskId)
        {
            // Find the task with the given ID
            var existingTask = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (existingTask != null)
            {
                // If the task exists, remove it from the list
                _tasks.Remove(existingTask);
                // Log the removal of the task
                _logger.LogInformation($"Removing {existingTask.Name}");
                _toastService.ShowWarning($"{LogMessages.LogMessages.TaskRemoved} {existingTask.Name}");
            }
        }

        // Marks a task as completed by setting its IsActive flag to false
        public void CompletedTask(int id)
        {
            // Find the task by its ID
            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask != null)
            {
                // Mark the task as inactive (completed)
                existingTask.IsActive = false;
            }
        }

        // Opens the form for updating a specific task
        string oldName = "";
        string oldDescription = "";
        public void OpenUpdateTaskForm(Todo task)
        {
            // retreive the name and description that is going to be changed
            oldName = task.Name;
            oldDescription = task.Description;
            // Set the flag to indicate that the task is being updated
            IsUpdating = true;
            // Set the task to update
            TaskToUpdate = task;
            // Log that the update form is being opened
            _logger.LogInformation($"open update form");
            // Log the task name being updated
            _logger.LogInformation($"{task.Name} ");
        }

        // Cancels the update and resets the update flag
        public void CancelUpdate()
        {
            // Set the flag to indicate that the update is canceled
            IsUpdating = false;
            // Log the cancelation of the update
            _logger.LogInformation("cancel update");
        }

        // Updates the task with the new name and description
  
        public void UpdateTask(string name, string description)
        {
            Console.WriteLine($"oldName: {oldName}");
            // Check if a task is being updated
            if (TaskToUpdate != null )
            {
                
                // Update the task's name, description, and reset the created date to now
                TaskToUpdate.Name = name;
                TaskToUpdate.Description = description;
               var newName = TaskToUpdate.Name;
                var newDescription = TaskToUpdate.Description;
                Console.WriteLine($"newName: {newName}");
                if (newName != oldName || newDescription != oldDescription)
                {
                    _toastService.ShowWarning($"{LogMessages.LogMessages.TaskUpdated} ");
                }

                // Reset the update flag
                IsUpdating = false;
            }

        }
    }
}
