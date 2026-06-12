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
                    string task = Console.ReadLine();
                    string message = taskApp.addTask(task);
                    Console.WriteLine(message);
                    Console.WriteLine("------------------------");
                }
                else if (option == "2")
                {
                    var tasks = taskApp.GetTasks();
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No existing task/s to view");
                    }
                    else
                    {
                        Console.WriteLine("----- Here's the task/s -----");
                        for (int i = 0; i < tasks.Count; i++)
                            Console.WriteLine((i + 1) + ". " + tasks[i]);
                    }
                    Console.WriteLine("------------------------");
                }
                else if (option == "3")
                {
                    var tasks = taskApp.GetTasks();
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No existing task/s to edit");
                    }
                    else
                    {
                        Console.WriteLine("----- Here's the task/s -----");
                        for (int i = 0; i < tasks.Count; i++)
                            Console.WriteLine((i + 1) + ". " + tasks[i]);
                     Console.WriteLine("------------------------");

                     Console.Write("Enter the number of the task you want to edit: ");
        
                        if (int.TryParse(Console.ReadLine(), out int editNum) && editNum > 0 && editNum <= tasks.Count)
                        {
                          Console.Write("Enter the new task: ");
                          string newTask = Console.ReadLine();
                          int editId = tasks[editNum - 1].Id;
                          Console.WriteLine(taskApp.addEdit(editId, newTask));
                        }
                    else
                       {
                          Console.WriteLine("Error: Invalid task number selection.");
                       }
                    }
                    Console.WriteLine("------------------------");
                }
                
                else if (option == "4")
                {
                    var tasks = taskApp.GetTasks();
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No existing task/s to delete");
                        Console.WriteLine("------------------------");
                    }
                    else
                    {
                        Console.WriteLine("----- Here's the task/s -----");
                        for (int i = 0; i < tasks.Count; i++)
                            Console.WriteLine((i + 1) + ". " + tasks[i]);
                        Console.WriteLine("------------------------");

                        Console.Write("Enter the number of the task you want to delete: ");
                        
                     if (int.TryParse(Console.ReadLine(), out int deleteNum) && deleteNum > 0 && deleteNum <= tasks.Count)
                      {
                        int deleteId = tasks[deleteNum - 1].Id;
                        Console.WriteLine(taskApp.addDelete(deleteId));
                      }
                     else
                      {
                        Console.WriteLine("Error: Invalid task number selection.");
                      }
                    }
                        Console.WriteLine("------------------------");
                }
                else if (option == "5")
                {
                    var tasks = taskApp.GetTasks();
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No existing task/s to mark");
                        Console.WriteLine("------------------------");
                    }
                    else
                   {
                        Console.WriteLine("----- Here's the task/s -----");
                        for (int i = 0; i < tasks.Count; i++)
                            Console.WriteLine((i + 1) + ". " + tasks[i]);
                        Console.WriteLine("------------------------");

                        Console.Write("Enter the number of the task you want to mark: ");
        
                       if (int.TryParse(Console.ReadLine(), out int markNum) && markNum > 0 && markNum <= tasks.Count)
                    {
                         Console.Write("Enter status (Done/Not Done): ");
                         string status = Console.ReadLine();

                        if (status != "Done" && status != "Not Done")
                        {
                          Console.WriteLine("Invalid status! Please enter Done or Not Done.");
                        }
                        else
                        {
                          int actualId = tasks[markNum - 1].Id;
                          string message = taskApp.addMarkTask(actualId, status);
                          Console.WriteLine(message);
                        }
                     }
                         else
                         {
                           Console.WriteLine("Error: Please choose a valid number from the list above.");
                         }
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
//commit