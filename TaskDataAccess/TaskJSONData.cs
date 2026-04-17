using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using TaskModel;

namespace TaskDataAccess
{
    public class TaskJSONData
    {
        private string filePath = "tasks.json";
        private List<TaskItem> Load()
        {
            if (!File.Exists(filePath))
                return new List<TaskItem>();
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
        private void Save(List<TaskItem> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, json);
        }
        public List<TaskItem> GetAll()
        {
            return Load();
        }
        public void Add(string task)
        {
            var tasks = Load();
            tasks.Add(new TaskItem
            {
                Id = tasks.Count + 1,
                Name = task,
                Status = "Not Done"
            });
            Save(tasks);
        }
        public bool Edit(int id, string newName)
        {
            var tasks = Load();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Name = newName;  // ← correct
                Save(tasks);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var tasks = Load();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                Save(tasks);
                return true;
            }
            return false;
        }
        public bool Mark(int id, string status)
        {
            var tasks = Load();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                if (task.Status == status)
                    return false;

                task.Status = status;
                Save(tasks);
                return true;
            }
            return false;
        }
    }
}
    

