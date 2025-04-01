namespace TodoAppExercise.Models
{
    public class Todo
    {
        private static int _idCounter = 1;

        public int Id { get; private set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public bool IsActive { get; set; }

        public Todo(string name = "", string description = "")
        {
            Id = _idCounter++;
            Name = name;
            Description = description;
            Created = DateTime.UtcNow;
            IsActive = true;
        }
    }
}
