using ToDoListWebApplication.Models;

namespace ToDoListWebApplication.Repository.Interface
{
    public interface ITaskRepo
    {
        public Task AddTask(Tasks model);
        public Task EditTask(Tasks model ); 
        public Task DeleteTask(int? id);
        public List<Tasks> GetAllTasks();
        public Task<Tasks> GetTaskById(int id);




    }
}
