using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Organizer.ViewModels;

namespace Organizer.Controllers
{   
    [Authorize]
    public class TrainingController : Controller
    {
        private IPomodoroTaskRepository _pomodoroTaskRepository;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           TraningViewModel model = new TraningViewModel();

           // model.TraningValues = await _applicationDbContext.TraningValues.ToListAsync();
            model.PomodoroTasks = await _pomodoroTaskRepository.GetPomodoroTasks();

           return View(model);
        }
        public TrainingController(IPomodoroTaskRepository pomodoroTaskRepository)
        {
            _pomodoroTaskRepository = pomodoroTaskRepository;
        }


        [HttpGet]
        public  IActionResult Create()
        {
            var model = new PomodoroViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PomodoroTaskViewModel pomodoroTaskViewModel)
        {
            var model = new PomodoroViewModel();

            return View(model);
        }



    }
}
