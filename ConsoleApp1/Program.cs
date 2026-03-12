using System;
using System.Collections.Generic;
using TaskAppService;

namespace TaskStatusProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();

            TaskAppService.TaskAppService taskApp = new TaskAppService.TaskAppService();
            taskApp.addTask(tasks);

            while (true)
            {
                Console.WriteLine("--- Task Status Program ---");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Edit Tasks");
                Console.WriteLine("4. Delete Tasks");
                Console.WriteLine("5. Mark Tasks");
                Console.WriteLine("6. Exit");

                Console.WriteLine();

                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    addTask(tasks);
                }

                else if (option == "2")
                {
                    addView(tasks);
                }
                else if (option == "3")
                {
                    addEdit(tasks);
                }
                else if (option == "4")
                {
                    addDelete(tasks);
                }
                else if (option == "5")
                {
                    addMarkTask(tasks);
                }
                else if (option == "6")
                {
                    addExit();
                }

                else
                {
                    addError();
                }

                Console.WriteLine();
            }
        }
        //remove this function since it's redundant with taskAppService class(the one we want to use)
        static void addTask(List<string>tasks)
        {
            Console.Write("Enter Here: ");
            string task = Console.ReadLine();

           tasks.Add(task);  

            Console.WriteLine("Task Added:)) ");

            Console.WriteLine("----------------------");
        }
        static void addView(List<string>tasks)
        {
            Console.WriteLine("---- Here's the task/s ----");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + tasks[i]);
            }

            Console.WriteLine("----------------------");
        }
        static void addEdit(List<string> tasks)
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
        static void addDelete(List<string> tasks)
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
        static void addMarkTask(List<string> tasks)
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
        static void addExit()
        {
            Console.WriteLine("Thank you for using the code:)) ");

            Console.WriteLine("----------------------");
        }

        static void addError()
        {
            Console.WriteLine("Please only input what on the menu, thank you:))");
        }
    }
}