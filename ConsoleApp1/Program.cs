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
                    taskApp.addTask(tasks);
                }

                else if (option == "2")
                {
                    taskApp.addView(tasks);
                }
                else if (option == "3")
                {
                    taskApp.addEdit(tasks);
                }
                else if (option == "4")
                {
                    taskApp.addDelete(tasks);
                }
                else if (option == "5")
                {
                    taskApp.addMarkTask(tasks);
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