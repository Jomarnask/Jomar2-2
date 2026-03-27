using TaskModel;
using TaskDataAccess;

namespace TaskAppService
{
    public class TaskAppService
    {
        private TaskRepository _repo = new TaskRepository();

        public List<TaskItem> GetTasks()
        {
            return _repo.Load();
        }

        public void addTask(string name)
        {
            var tasks = _repo.Load();
            tasks.Add(new TaskItem
            {
                Id = tasks.Count + 1,
                Name = name,
                Status = "Not Done"
            });
            _repo.Save(tasks);
        }

        public void addEdit(int index, string newName)
        {
            var tasks = _repo.Load();
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].Name = newName;
                _repo.Save(tasks);
            }
        }

        public void addDelete(int index)
        {
            var tasks = _repo.Load();
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                _repo.Save(tasks);
            }
        }

        public bool addMarkTask(int index, string status)
        {
            var tasks = _repo.Load();
            if (index >= 0 && index < tasks.Count)
            {
                if (tasks[index].Status == status)
                    return false;

                tasks[index].Status = status;
                _repo.Save(tasks);
                return true;
            }
            return false;
        }
    }
}