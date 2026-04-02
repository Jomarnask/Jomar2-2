using TaskDataAccess;
using TaskModel;

namespace TaskAppService
{
    public class TaskAppService
    {
        private TaskDBData _db = new TaskDBData();

        public List<TaskItem> GetTasks()
        {
            return _db.GetAll();
        }

        public string addTask(string task)
        {
            if (string.IsNullOrWhiteSpace(task))
            {
                return "Task cannot be empty!";
            }
            _db.Add(task);
            return "Task added successfully!";
        }

        public string addEdit(int id, string newName)
        {
            if (id <= 0)
            {
                return "Invalid id!";
            }
            if (string.IsNullOrWhiteSpace(newName))
            {
                return "Task cannot be empty!";
            }
            _db.Edit(id, newName);
            return "Task edited successfully!";
        }

        public string addDelete(int id)
        {
            if (id <= 0)
            {
                return "Invalid id!";
            }
            _db.Delete(id);
            return "Task deleted successfully!";
        }

        public bool addMarkTask(int id, string status)
        {
            return _db.Mark(id, status);
        }
    }
}
