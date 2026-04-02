using TaskDataAccess;
using TaskModel;

namespace TaskAppService
{
    public class TaskAppService
    {
        private TaskDBData _db = new TaskDBData();

       public string addTask(string task)
        {
          if (string.IsNullOrWhiteSpace(task))
          {
          return "Task cannot be empty!";
          }

          _db.Add(task);
          return "Task added successfully!";
        }
        public List<TaskItem> GetTasks()
        {
          if (string.IsNullOrWhiteSpaces(GetTask)
          {
           return "No existing task/s";
          }    
            return _db.GetAll();
        }    
        public void addEdit(int id, string newName)
        {
            _db.Edit(id, newName);
        }

        public void addDelete(int id)
        {
            _db.Delete(id);
        }

        public bool addMarkTask(int id, string status)
        {
            return _db.Mark(id, status);
        }
    }
}
