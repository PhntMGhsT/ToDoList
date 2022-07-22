using Microsoft.EntityFrameworkCore;
using ToDoListWebApplication.Models;

namespace ToDoListWebApplication.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks => Set<Tasks>();
        public DbSet<Status> Status => Set<Status>();




    }
}
