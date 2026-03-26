namespace TaskAppService
{
    public class TaskAppService
    {
        public void addTask(List<string> tasks, string task)
        {
            tasks.Add(task + " [Not Done]");  
        }

        public void addView(List<string> tasks)
        {

        }

        public void addEdit(List<string> tasks, int index, string newTask)
        {
            if (index >= 0 && index < tasks.Count)
                tasks[index] = newTask;
        }

        public void addDelete(List<string> tasks, int index)
        {
            if (index >= 0 && index < tasks.Count)
                tasks.RemoveAt(index);
        }

        public void addMarkTask(List<string> tasks, int index, string status)
        {
            if (index >= 0 && index < tasks.Count)
            {
                int bracketIndex = tasks[index].IndexOf(" [");
                if (bracketIndex >= 0)
                    tasks[index] = tasks[index].Substring(0, bracketIndex);

                tasks[index] = tasks[index] + " [" + status + "]";
            }
        }
    }
}