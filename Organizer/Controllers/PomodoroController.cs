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
            var model = new PomodoroViewModel();
            model.pomodoroTasks = await _pomodoroTaskRepository.GetPomodoroTasks();
      
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
            return View();
        }

    }
}
