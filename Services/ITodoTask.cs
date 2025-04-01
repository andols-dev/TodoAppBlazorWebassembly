using TodoAppExercise.Models;

namespace TodoAppExercise.Services
{
    public interface ITodoTask
    {
        List<Todo> Tasks { get; }

        void AddTask();
        string TodoFromInput { get; set; }
        string Description { get; set; }
        public bool IsUpdating { get; set; }

        void RemoveTask(int id);
        void CompletedTask(int id);

        void OpenUpdateTaskForm(Todo task);

        void CancelUpdate();

        //void showAllActiveTasks();

        List<Todo> AllActiveTasks { get; }

        public Todo TaskToUpdate { get; set; }

        void UpdateTask(string name, string description);



    }


    


}
