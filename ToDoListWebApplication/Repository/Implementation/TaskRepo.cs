﻿using ToDoListWebApplication.Data;
using ToDoListWebApplication.Models;
using ToDoListWebApplication.Repository.Interface;

namespace ToDoListWebApplication.Repository.Implementation
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskContext _context;
        public TaskRepo(TaskContext context)
        {
            _context = context;
        }

        public async Task AddTask(Tasks model)
        {
            Tasks _task = model;
            _task.StatusId = 1;
            _task.CreatedBy = "Olumide/Joshua";
            _task.ModifiedBy = "Olumide/Joshua";
            _task.CreatedDate = DateTime.Now;
            _task.ModifiedDate = DateTime.Now;
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int? id)
        {
            var model = await _context.Tasks.FindAsync(id);
            if (model != null)
            {
                _context.Tasks.Remove(model);
            }

            await _context.SaveChangesAsync();
        }

        public async Task EditTask(Tasks model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync(); ;
        }

        public List<Tasks> GetAllTasks()
        {
            return _context.Tasks.Where(o => o.StatusId != 3 || o.StatusId != 4).OrderBy(o => o.DueDate).ToList();
        }

        public async Task<Tasks> GetTaskById(int id)
        {
              var model = await _context.Tasks.FindAsync(id);
            if (model == null)
            {
                throw new Exception("Task Not Found");
            }
            return model;
        }
    }
}
