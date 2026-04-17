Using TaskDataAccess;
using TaskModel;

namespace TaskAppService
{
    public class TaskAppService
    {
        private TaskJSONData _db = new TaskJSONData();

        public List<TaskItem> GetTasks()
        {
            return _db.GetAll();
        }

        public string addTask(string task)
        {
            if (string.IsNullOrWhiteSpace(task)) 
            {
                return "Task cannot be empty";
            }
            _db.Add(task);
            return "Task added successful";
        }

        public string addEdit(int id, string newName)
        {
            if(id <= 0)
            {
                return "Invalid id!";
            }
            if (string.IsNullOrWhiteSpace(newName))
            {
                return "Task cannot be empty";
            }
            bool success = _db.Edit(id, newName);
            return success ? "Task updated!" : "Error: Task ID not found.";
        }

        public string addDelete(int id)
        {
            if (id <= 0) 
            {
                return "Invalid id!";
            }
            bool success_db.Delete(id);
            return success ? "Task deleted successful" : "Task ID not found.";
        }

        public bool addMarkTask(int id, string status)
        {
            return _db.Mark(id, status);
        }
    }
}
