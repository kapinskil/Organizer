using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Organizer.Data;
using Organizer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Organizer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Organizer.Controllers
{
    [Authorize]
    public class PomodoroController : Controller
    {
        private readonly IPomodoroTaskRepository _pomodoroTaskRepository;
        private readonly IPomodoroCategoryRepository _pomodoroCategoryRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public PomodoroController(IPomodoroTaskRepository pomodoroTaskRepository,
                                   IPomodoroCategoryRepository pomodoroCategoryRepository,
                                    UserManager<ApplicationUser> userManager)
                                   
        {
            _pomodoroTaskRepository = pomodoroTaskRepository;
            _pomodoroCategoryRepository = pomodoroCategoryRepository;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUser();

            var model = new PomodoroViewModel();
            model.pomodoroTasks = await _pomodoroTaskRepository.GetPomodoroTasks(user.Id);
      
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var modelFromRepo = await _pomodoroTaskRepository.GetPomodoroTask(id);

            var model = new PomodoroTaskViewModel
            {
                ApplicationUser = modelFromRepo.ApplicationUser,
                DataStart = modelFromRepo.DataStart,
                DateAdded = modelFromRepo.DateAdded,
                DateDone = modelFromRepo.DateDone,
                Description = modelFromRepo.Description,
                Id = modelFromRepo.Id,
                PomodoroCategory = modelFromRepo.PomodoroCategory,
                PomodoroTaskStatus = modelFromRepo.PomodoroTaskStatus
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userCategoriesFromRepo = await _pomodoroCategoryRepository.GetCategoriesByUser(user.Id);

            var model = new PomodoroTaskViewModel();
            model.PomodoroCategories = userCategoriesFromRepo.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            model.DataStart = DateTime.Now;
            model.DateDone = DateTime.Now;

            model.ApplicationUser = user;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PomodoroTaskViewModel pomodoroTaskViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = await GetCurrentUser();

                PomodoroTask modelToAdded = new PomodoroTask
                {
                    ApplicationUser = user,
                    ApplicationUserId = user.Id,
                    DateAdded = DateTime.Now,
                    DataStart = pomodoroTaskViewModel.DataStart,
                    DateDone = pomodoroTaskViewModel.DateDone,
                    Description = pomodoroTaskViewModel.Description,
                    PomodoroCategoryId = pomodoroTaskViewModel.PomodoroCategoryId,
                    PomodoroTaskStatusId = 1
                 };

                _pomodoroTaskRepository.Add(modelToAdded);

                if (await _pomodoroTaskRepository.SaveAll())
                {
                    //some maessahe when item added
                }

                return RedirectToAction(nameof(Index));
            }

            return View(pomodoroTaskViewModel);
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return user;
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelate = await _pomodoroTaskRepository.GetPomodoroTask(id);

             _pomodoroTaskRepository.Delete(taskToDelate);
            await _pomodoroTaskRepository.SaveAll();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var viewModel = await _pomodoroTaskRepository.GetPomodoroTask(id);

            return View(viewModel);
        }
    }
}
