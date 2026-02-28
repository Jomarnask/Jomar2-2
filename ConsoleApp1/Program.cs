using System;

namespace TaskStatusProgram
{
    class Program
    {
        static string[] tasks = new string[100];
        static int taskCount = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--- Task Status Program ---");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Exit");

                Console.WriteLine();

                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    addTask();
                }

                else if (option == "2")
                {
                    addView();
                }

                else if (option == "3")
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
        static void addTask()
        {
            Console.Write("Enter Here: ");
            string task = Console.ReadLine();

            tasks[taskCount] = task;
            taskCount++;

            Console.WriteLine("Task Added:)) ");

            Console.WriteLine("----------------------");
        }
        static void addView()
        {
            Console.WriteLine("---- Here's the task/s ----");
            for (int i = 0; i < taskCount; i++)
            {
                Console.WriteLine("* " + tasks[i]);
            }

            Console.WriteLine("----------------------");
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