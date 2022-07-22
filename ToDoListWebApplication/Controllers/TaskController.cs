 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListWebApplication.Models;
using ToDoListWebApplication.Repository.Interface;

namespace ToDoListWebApplication.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepo _taskRepo;
        public TaskController(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

    

        public IActionResult Index()
        {
            try
            {
                var model = _taskRepo.GetAllTasks();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                Tasks model = new Tasks();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<IActionResult> Create(Tasks model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }

                await _taskRepo.AddTask(model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public IActionResult Details(int Id)
        {
            try
            {
                var model = _taskRepo.GetTaskById(Id);
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            try
            {
                var model = await _taskRepo.GetTaskById(Id);
                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
                
            }
            catch (Exception)
            {

                throw;
            }
            

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tasks model)
        {

            try
            {
                
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await _taskRepo.EditTask(model);
                return RedirectToAction("Details", new { Id = model.Id });

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var model = await _taskRepo.GetTaskById(Id);
                if (model == null)
                    return NotFound();

                await _taskRepo.DeleteTask(Id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

