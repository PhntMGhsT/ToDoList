using Microsoft.EntityFrameworkCore;

namespace ToDoListWebApplication.Models
{
    public class TaskContext : DbContext
    {
        /*public TaskContext() : base ("TaskContext")
        { 
        }*/

        public DbSet<Tasks> Tasks => Set<Tasks>();

        
    }
}
