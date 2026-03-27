namespace TaskModel
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } = "Not Done";

        public override string ToString()
        {
            return Name + " [" + Status + "]";
        }
    }
}