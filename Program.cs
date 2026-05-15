using System;
using System.Collections.Generic;

namespace TaskManagerApp
{
    class Program
    {
        // List to store tasks
        static List<TaskItem> tasks = new List<TaskItem>();

        static void Main(string[] args)
        {
            bool running = true;

            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("      PERSONAL TASK MANAGER");
            Console.WriteLine("=====================================\n");

            while (running)
            {
                DisplayMenu();
                Console.Write("Select an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTasks();
                        break;
                    case "3":
                        MarkTaskComplete();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting program... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
        }

        // Displays the main menu
        static void DisplayMenu()
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Add a Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete a Task");
            Console.WriteLine("5. Exit\n");
        }

        // Adds a new task to the list
        static void AddTask()
        {
            Console.Write("Enter task name: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Task name cannot be empty.");
                return;
            }

            Console.Write("Enter task description: ");
            string? description = Console.ReadLine();

            // Replace nulls with default text
            TaskItem newTask = new TaskItem(name ?? "Unnamed Task", description ?? "No description provided");
            tasks.Add(newTask);

            Console.WriteLine("Task added successfully!\n");
        }

        // Displays all tasks
        static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.\n");
                return;
            }

            Console.WriteLine("\nYour Tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
            Console.WriteLine();
        }

        // Marks a task as completed
        static void MarkTaskComplete()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to complete.\n");
                return;
            }

            ViewTasks();
            Console.Write("Enter the number of the task to mark complete: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int index))
            {
                if (index < 1 || index > tasks.Count)
                {
                    Console.WriteLine("Invalid task number.\n");
                    return;
                }

                tasks[index - 1].IsCompleted = true;
                Console.WriteLine("Task marked as completed!\n");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
            }
        }

        // Deletes a task
        static void DeleteTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to delete.\n");
                return;
            }

            ViewTasks();
            Console.Write("Enter the number of the task to delete: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int index))
            {
                if (index < 1 || index > tasks.Count)
                {
                    Console.WriteLine("Invalid task number.\n");
                    return;
                }

                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task deleted successfully!\n");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
            }
        }
    }

    // Represents a task item
    class TaskItem
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public TaskItem(string name, string description)
        {
            Name = name;
            Description = description;
            IsCompleted = false;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "✔ Completed" : "✘ Not Completed";
            return $"{Name} - {Description} [{status}]";
        }
    }
}
