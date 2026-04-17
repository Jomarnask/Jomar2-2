using TaskDataAccess;
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
            bool success=_db.Delete(id); 
            return success ? "Task deleted successful" : "Task ID not found.";
        }

        public string addMarkTask(int id, string status)
        {
             if (id <= 0) return "Invalid id!"; // Step 1: Validate
             bool success = _db.Mark(id, status); // Step 2: Execute
             return success ? $"Task marked as {status}!" : "Task ID not found."; // Step 3: Respond
        }
    }
}
