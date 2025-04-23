using System;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace lld_console_app.TaskManagement // Task Management System
// This is a simple task management system that allows users to create, update, and delete tasks.
{
    public class Task
    {
        public string Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public TaskStatus Status { get; set; }
        public User AssignedUser { get; }

        public Task(string id, string title, string description, DateTime dueDate, int priority, User assignedUser)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = TaskStatus.PENDING;
            AssignedUser = assignedUser;
        }

        public override bool Equals(object obj)
        {
            if (obj is Task task)
            {
                return Id == task.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class TaskManagementSystemDemo
    {
        public static void Run()
        {
            TaskManager taskManager = TaskManager.GetInstance();
            
            // Create users
            User user1 = new User("1", "John Doe", "john@example.com");
            User user2 = new User("2", "Jane Smith", "jane@example.com");

            // Create tasks
            Task task1 = new Task("1", "Task 1", "Description 1", DateTime.Now, 1, user1);
            Task task2 = new Task("2", "Task 2", "Description 2", DateTime.Now, 2, user2);
            Task task3 = new Task("3", "Task 3", "Description 3", DateTime.Now, 1, user1);

            // Add tasks to the task manager
            taskManager.CreateTask(task1);
            taskManager.CreateTask(task2);
            taskManager.CreateTask(task3);

            // Update a task
            task2.Description = "Updated description";
            taskManager.UpdateTask(task2);

            // Search tasks
            List<Task> searchResults = taskManager.SearchTasks("Task");
            Console.WriteLine("Search Results:");
            foreach (Task task in searchResults)
            {
                Console.WriteLine(task.Title);
            }

            // Filter tasks
            List<Task> filteredTasks = taskManager.FilterTasks(TaskStatus.PENDING, DateTime.MinValue, DateTime.Now, 1);
            Console.WriteLine("Filtered Tasks:");
            foreach (Task task in filteredTasks)
            {
                Console.WriteLine(task.Title);
            }

            // Mark a task as completed
            taskManager.MarkTaskAsCompleted("1");

            // Get task history for a user
            List<Task> taskHistory = taskManager.GetTaskHistory(user1);
            Console.WriteLine("Task History for " + user1.Name + ":");
            foreach (Task task in taskHistory)
            {
                Console.WriteLine(task.Title);
            }

            // Delete a task
            taskManager.DeleteTask("3");
        }
    }

    public class TaskManager
    {
        private static TaskManager _instance;
        private readonly ConcurrentDictionary<string, Task> _tasks;
        private readonly ConcurrentDictionary<string, List<Task>> _userTasks;

        private TaskManager()
        {
            _tasks = new ConcurrentDictionary<string, Task>();
            _userTasks = new ConcurrentDictionary<string, List<Task>>();
        }

        public static TaskManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TaskManager();
            }
            return _instance;
        }

        public void CreateTask(Task task)
        {
            _tasks[task.Id] = task;
            AssignTaskToUser(task.AssignedUser, task);
        }

        public void UpdateTask(Task updatedTask)
        {
            if (_tasks.TryGetValue(updatedTask.Id, out Task existingTask))
            {
                lock (existingTask)
                {
                    existingTask.Title = updatedTask.Title;
                    existingTask.Description = updatedTask.Description;
                    existingTask.DueDate = updatedTask.DueDate;
                    existingTask.Priority = updatedTask.Priority;
                    existingTask.Status = updatedTask.Status;

                    if (!existingTask.AssignedUser.Equals(updatedTask.AssignedUser))
                    {
                        UnassignTaskFromUser(existingTask.AssignedUser, existingTask);
                        AssignTaskToUser(updatedTask.AssignedUser, existingTask);
                    }
                }
            }
        }

        public void DeleteTask(string taskId)
        {
            if (_tasks.TryRemove(taskId, out Task task))
            {
                UnassignTaskFromUser(task.AssignedUser, task);
            }
        }

        public List<Task> SearchTasks(string keyword)
        {
            return _tasks.Values
                         .Where(task => task.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                                        task.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                         .ToList();
        }

        public List<Task> FilterTasks(TaskStatus status, DateTime startDate, DateTime endDate, int priority)
        {
            return _tasks.Values
                         .Where(task => task.Status == status && task.DueDate >= startDate && task.DueDate <= endDate && task.Priority == priority)
                         .ToList();
        }

        public void MarkTaskAsCompleted(string taskId)
        {
            if (_tasks.TryGetValue(taskId, out Task task))
            {
                lock (task)
                {
                    task.Status = TaskStatus.COMPLETED;
                }
            }
        }

        public List<Task> GetTaskHistory(User user)
        {
            return _userTasks.GetOrAdd(user.Id, new List<Task>());
        }

        private void AssignTaskToUser(User user, Task task)
        {
            _userTasks.GetOrAdd(user.Id, new List<Task>()).Add(task);
        }

        private void UnassignTaskFromUser(User user, Task task)
        {
            if (_userTasks.TryGetValue(user.Id, out List<Task> tasks))
            {
                tasks.Remove(task);
            }
        }
    }

    public enum TaskStatus
    {
        PENDING,
        IN_PROGRESS,
        COMPLETED
    }

    public class User
    {
        public string Id { get; }
        public string Name { get; }
        public string Email { get; }

        public User(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            if (obj is User user)
            {
                return Id == user.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
    

}