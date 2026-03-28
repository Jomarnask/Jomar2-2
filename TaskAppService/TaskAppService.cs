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

        public void addTask(string name)
        {
            _db.Add(name);
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