using System.Threading.Tasks;

namespace TaskAppService
{
    public class TaskAppService
    {

        public void addTask(List<string> tasks)
        {
            Console.Write("Enter Here: ");
            string task = Console.ReadLine();

            tasks.Add(task);

            Console.WriteLine("Task Added:)) ");

            Console.WriteLine("----------------------");
        }
        public void addView(List<string> tasks)
        {
            Console.WriteLine("---- Here's the task/s ----");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + tasks[i]);
            }

            Console.WriteLine("----------------------");
        }
        public void addEdit(List<string> tasks)
        {
            Console.WriteLine();
            addView(tasks);
            Console.WriteLine();

            Console.Write("Enter the number of the task you want to edit: ");
            int editNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the new task: ");
            string newTask = Console.ReadLine();

            tasks[editNum - 1] = newTask;

            Console.WriteLine("Task Edited:)) ");
        }
        public void addDelete(List<string> tasks)
        {
            Console.WriteLine();
            addView(tasks);
            Console.WriteLine();

            Console.Write("Enter the number of the task you want to edit: ");
            int deleteNum = Convert.ToInt32(Console.ReadLine());

            //tasks[deleteNum - 1];

            tasks.RemoveAt(deleteNum - 1);

            Console.WriteLine("Task Deleted:)) ");
        }
        public void addMarkTask(List<string> tasks)
        {
            Console.WriteLine();
            addView(tasks);
            Console.WriteLine();

            Console.Write("Enter the number of the task you want to mark: ");
            int markNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter status (Done/Not Done): ");
            string status = Console.ReadLine();

            tasks[markNum - 1] = tasks[markNum - 1] + " [" + status + "]";

            Console.WriteLine("Task Marked:)) ");
        }


    }
}
