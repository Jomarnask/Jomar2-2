using System;
using System.Collections.Generic;
using TaskAppService;

namespace TaskStatusProgram
{
    class Program
    {
        static void Main(string[] args)
        {
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
                    Console.Write("Enter Here: ");
                    string name = Console.ReadLine();
                    taskApp.addTask(name);
                    Console.WriteLine("Task Added:)) ");
                    Console.WriteLine("------------------------");
                }
                else if (option == "2")
                {
                    var tasks = taskApp.GetTasks();
                    Console.WriteLine("----- Here's the task/s -----");
                    for (int i = 0; i < tasks.Count; i++)
                        Console.WriteLine((i + 1) + ". " + tasks[i]);
                    Console.WriteLine("------------------------");
                }
                else if (option == "3")
                {
                    var tasks = taskApp.GetTasks();
                    Console.WriteLine("----- Here's the task/s -----");
                    for (int i = 0; i < tasks.Count; i++)
                        Console.WriteLine((i + 1) + ". " + tasks[i]);
                    Console.WriteLine("------------------------");

                    Console.Write("Enter the number of the task you want to edit: ");
                    int editNum = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the new task: ");
                    string newTask = Console.ReadLine();
                    taskApp.addEdit(editNum - 1, newTask);
                    Console.WriteLine("Task Edited:)) ");
                    Console.WriteLine("------------------------");
                }
                else if (option == "4")
                {
                    var tasks = taskApp.GetTasks();
                    Console.WriteLine("----- Here's the task/s -----");
                    for (int i = 0; i < tasks.Count; i++)
                        Console.WriteLine((i + 1) + ". " + tasks[i]);
                    Console.WriteLine("------------------------");

                    Console.Write("Enter the number of the task you want to delete: ");
                    int deleteNum = Convert.ToInt32(Console.ReadLine());
                    taskApp.addDelete(deleteNum - 1);
                    Console.WriteLine("Task Deleted:)) ");
                    Console.WriteLine("------------------------");
                }
                else if (option == "5")
                {
                    var tasks = taskApp.GetTasks();
                    Console.WriteLine("----- Here's the task/s -----");
                    for (int i = 0; i < tasks.Count; i++)
                        Console.WriteLine((i + 1) + ". " + tasks[i]);
                    Console.WriteLine("------------------------");

                    Console.Write("Enter the number of the task you want to mark: ");
                    int markNum = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter status (Done/Not Done): ");
                    string status = Console.ReadLine();

                    if (status != "Done" && status != "Not Done")
                    {
                        Console.WriteLine("Invalid status! Please enter Done or Not Done.");
                    }
                    else
                    {
                        bool success = taskApp.addMarkTask(markNum - 1, status);
                        if (success)
                            Console.WriteLine("Task Marked:)) ");
                        else
                            Console.WriteLine("Task is already marked as " + status + "!");
                    }
                    Console.WriteLine("------------------------");
                }
                else if (option == "6")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                    Console.WriteLine("------------------------");
                }
            }
        }
    }
}