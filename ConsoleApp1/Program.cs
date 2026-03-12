using System;
using System.Collections.Generic;   

namespace TaskStatusProgram
{
    class Program
    {
       static List<string> tasks = new List<string>();  

        static void Main(string[] args)
        {
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
                    addTask();
                }

                else if (option == "2")
                {
                    addView();
                }
                else if (option == "3")
                {
                    addEdit();
                }
                else if (option == "4")
                {
                    addDelete();
                }
                else if (option == "5")
                {
                    addMarkTask();
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
        static void addEdit()
        {
            Console.WriteLine();
            addView();
            Console.WriteLine();

            Console.write("Enter the number of the task you want to edit: ");   
            int editNum = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter the new task: ");
            string newTask = Console.ReadLine();

            tasks[editNum - 1] = newTask;   

            Console.WriteLine("Task Edited:)) ");
        }
        static void addDelete()
        {
            Console.WriteLine();
            addView();
            Console.WriteLine();

            Console.write("Enter the number of the task you want to edit: ");
            int deleteNum = Convert.ToInt32(Console.ReadLine());

            //tasks[deleteNum - 1];

            tasks.RemoveAt[deleteNum - 1];  

            Console.WriteLine("Task Deleted:)) ");  
        }
        static void addMarkTask()
        {
            Console.WriteLine();
            addView();
            Console.WriteLine();

            Console.write("Enter the number of the task you want to edit: ");
            int deleteNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter status (Done/Not Done): ");
            string status = Console.ReadLine();

            tasks[deleteNum - 1] = tasks[deleteNum - 1] + " - " + status;

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