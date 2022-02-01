using Microsoft.EntityFrameworkCore;
using MvcToDoList.Data;

namespace MvcToDoList.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcToDoListContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<MvcToDoListContext>>()))
            {
                // Look for an To-Do tasks
                if (context.ToDoList.Any())
                {
                    return; // DB has been seeded
                }

                context.ToDoList.AddRange(
                    new ToDoList
                    {
                        Task = "Learn Arabic",
                        Description = "Attend online Arabic course",
                        Status = "To do",
                        Priority = "Medium",
                        Assgignee = "Yusuf Naheem",
                        Comments = "Revise lesson 3 notes before attending class.",
                        Created = DateTime.Parse("2022-01-05"),
                        CompleteBy = DateTime.Parse("2022-01-07")
                    },

                    new ToDoList
                    {
                        Task = "Go to the Gym",
                        Description = "Go to the Gym at 5pm and train legs.",
                        Status = "Planning",
                        Priority = "High",
                        Assgignee = "Yusuf Naheem",
                        Comments = "Take a bottle of watter with you.",
                        Created = DateTime.Parse("2022-01-07"),
                        CompleteBy = DateTime.Parse("2022-01-07")
                    },

                    new ToDoList
                    {
                        Task = "Buy a new laptop",
                        Description = "Buy a new laptop for brother with good specs. (Budget of £500)",
                        Status = "Open",
                        Priority = "Low",
                        Assgignee = "Yusuf Naheem",
                        Comments = "Minimum i5 processor.",
                        Created = DateTime.Parse("2022-01-06"),
                        CompleteBy = DateTime.Parse("2022-01-10")
                    },

                    new ToDoList
                    {
                        Task = "Grocery shopping",
                        Description = "Weekly grocery shopping",
                        Status = "To do",
                        Priority = "High",
                        Assgignee = "Mum",
                        Comments = "Dont forget milk!",
                        Created = DateTime.Parse("2022-01-11"),
                        CompleteBy = DateTime.Parse("2022-01-11")
                    },

                    new ToDoList
                    {
                        Task = "Schedule a meeting for designing the E-commerce website",
                        Description = "Download required Software and tools.",
                        Status = "Planning",
                        Priority = "High",
                        Assgignee = "Mark Zuckerberg",
                        Comments = "",
                        Created = DateTime.Now,
                        CompleteBy = DateTime.Now.AddDays(2)
                    },

                    new ToDoList
                    {
                        Task = "Read 2 Pages of Atomic Habits",
                        Description = "Review what you had read once complete",
                        Status = "In progress",
                        Priority = "Low",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Now,
                        CompleteBy = DateTime.Now
                    },

                    new ToDoList
                    {
                        Task = "Renew Gym memberhsip",
                        Description = "",
                        Status = "To do",
                        Priority = "High",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Parse("2022-02-08"),
                        CompleteBy = DateTime.Parse("2022-02-11")
                    },

                    new ToDoList
                    {
                        Task = "Go for a walk",
                        Description = "At 5:45pm",
                        Status = "To-do",
                        Priority = "Medium",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Now,
                        CompleteBy = DateTime.Now
                    },

                    new ToDoList
                    {
                        Task = "Go for a walk",
                        Description = "At 5:45pm",
                        Status = "To-do",
                        Priority = "Medium",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Now,
                        CompleteBy = DateTime.Now
                    },

                    new ToDoList
                    {
                        Task = "Learn about Unit Tests",
                        Description = "Go over Microsoft Docs for C# xUnit",
                        Status = "Planning",
                        Priority = "High",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Now,
                        CompleteBy = DateTime.Now
                    },

                    new ToDoList
                    {
                        Task = "Book holiday",
                        Description = "Look at holidays deals for March",
                        Status = "To-do",
                        Priority = "Medium",
                        Assgignee = "Dad",
                        Comments = "",
                        Created = DateTime.Now,
                        CompleteBy = DateTime.Now.AddDays(1)
                    },

                    new ToDoList
                    {
                        Task = "Book holiday",
                        Description = "Look at holidays deals for March",
                        Status = "To-do",
                        Priority = "Medium",
                        Assgignee = "Dad",
                        Comments = "",
                        Created = DateTime.Now,
                        CompleteBy = DateTime.Now.AddDays(10)
                    },

                    new ToDoList
                    {
                        Task = "Get car serviced",
                        Description = "",
                        Status = "To-do",
                        Priority = "Medium",
                        Assgignee = "Dad",
                        Comments = "",
                        Created = DateTime.Now,
                        CompleteBy = DateTime.Now.AddDays(6)
                    },

                    new ToDoList
                    {
                        Task = "Look at new Corsair desk chairs",
                        Description = "Budget £120",
                        Status = "Planned",
                        Priority = "Lowest",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Now.AddDays(3),
                        CompleteBy = DateTime.Now.AddDays(5)
                    },

                    new ToDoList
                    {
                        Task = "Look into the new updates in C# 10",
                        Description = "",
                        Status = "To-do",
                        Priority = "Medium",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Now,
                        CompleteBy = DateTime.Now.AddDays(6)
                    },

                    new ToDoList
                    {
                        Task = "Do some more DSA challenges",
                        Description = "Use resources like HackerRank or Leetcode",
                        Status = "Planned",
                        Priority = "High",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Now.AddDays(3),
                        CompleteBy = DateTime.Now.AddDays(5)
                    },

                    new ToDoList
                    {
                        Task = "Look at Linux/Ubuntu",
                        Description = "",
                        Status = "Planned",
                        Priority = "High",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Now.AddDays(3),
                        CompleteBy = DateTime.Now.AddDays(5)
                    },

                    new ToDoList
                    {
                        Task = "Look at Linux/Ubuntu",
                        Description = "",
                        Status = "Planned",
                        Priority = "High",
                        Assgignee = "Yusuf Naheem",
                        Comments = "",
                        Created = DateTime.Now.AddDays(3),
                        CompleteBy = DateTime.Now.AddDays(5)
                    }
                    ); ;
                context.SaveChanges();
            }
        }
    }
}
