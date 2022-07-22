using System.ComponentModel.DataAnnotations;

namespace ToDoListWebApplication.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
