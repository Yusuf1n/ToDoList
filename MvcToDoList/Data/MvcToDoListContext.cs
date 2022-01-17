#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcToDoList.Models;

namespace MvcToDoList.Data
{
    public class MvcToDoListContext : DbContext
    {
        public MvcToDoListContext (DbContextOptions<MvcToDoListContext> options)
            : base(options)
        {
        }

        public DbSet<MvcToDoList.Models.ToDoList> ToDoList { get; set; }
    }
}
