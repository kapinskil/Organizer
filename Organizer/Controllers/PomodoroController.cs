using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Organizer.Data;

namespace Organizer.Controllers
{
    [Authorize]
    public class PomodoroController : Controller
    {
        private readonly IPomodoroTaskRepository _pomodoroTaskRepository;

        public PomodoroController(IPomodoroTaskRepository pomodoroTaskRepository)
        {
            _pomodoroTaskRepository = pomodoroTaskRepository;
        }

        public IActionResult Index(string name)
        {
            ViewData["Message"] = "hello " + name;
            return View();
        }

    }
}
