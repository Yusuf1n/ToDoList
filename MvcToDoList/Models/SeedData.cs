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
                        Task = "Learn ASP.NET Core",
                        Description = "Learning to build the new Licensing systems.",
                        Status = "In progress",
                        Priority = "Medium",
                        Assgignee = "Yusuf Naheem",
                        Comments = "Looking into MVC and Razor syntax.",
                        Created = DateTime.Parse("2022-01-05"),
                        CompleteBy = DateTime.Parse("2022-01-07")
                    },

                    new ToDoList
                    {
                        Task = "Go to the Gym",
                        Description = "Go to the Gym at 5pm and train legs.",
                        Status = "To-do",
                        Priority = "High",
                        Assgignee = "Yusuf Naheem",
                        Comments = "Take a bottle of watter with you.",
                        Created = DateTime.Parse("2022-01-07"),
                        CompleteBy = DateTime.Parse("2022-01-07")
                    },

                    new ToDoList
                    {
                        Task = "Buy a new laptop",
                        Description = "Buy a new laptop for home with good specs, budget of £400",
                        Status = "Open",
                        Priority = "Medium",
                        Assgignee = "Yusuf Naheem",
                        Comments = "Min i5 processor.",
                        Created = DateTime.Parse("2022-01-06"),
                        CompleteBy = DateTime.Parse("2022-01-10")
                    },

                    new ToDoList
                    {
                        Task = "Grocery shopping",
                        Description = "Weekly grocery shopping",
                        Status = "To-do",
                        Priority = "Low",
                        Assgignee = "Dad",
                        Comments = "Dont forget milk!",
                        Created = DateTime.Parse("2022-01-11"),
                        CompleteBy = DateTime.Parse("2022-01-11")
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
