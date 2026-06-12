using System.Collections.Generic;
using TaskDataAccess;
using TaskModel;

namespace TaskAppService
{
    public class TaskAppService
    {
        private TaskDBData _db = new TaskDBData();

        public List<TaskItem> GetTasks() => _db.GetAll();

        public string addTask(string task)
        {
            if (string.IsNullOrWhiteSpace(task)) return "Error: Task cannot be empty.";
            _db.Add(task);
            return "Task added successfully!";
        }

        public string addEdit(int id, string newName)
        {
            if (id <= 0) return "Error: Invalid ID.";
            if (string.IsNullOrWhiteSpace(newName)) return "Error: Name cannot be empty.";
            return _db.Edit(id, newName) ? "Task updated!" : "Error: Task not found.";
        }

        public string addDelete(int id)
        {
            if (id <= 0) return "Error: Invalid ID.";
            return _db.Delete(id) ? "Task deleted successfully!" : "Error: Task not found.";
        }

        public string addMarkTask(int id, string status)
        {
            if (id <= 0) return "Error: Invalid ID.";
            return _db.Mark(id, status) ? $"Task marked as {status}!" : "Error: Task not found.";
        }
    }
}