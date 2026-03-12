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


    }
}
