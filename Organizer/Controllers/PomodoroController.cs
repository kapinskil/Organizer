using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Organizer.Controllers
{
    [Authorize]
    public class PomodoroController : Controller
    {
        public IActionResult Index(string name)
        {
            ViewData["Message"] = "hello " + name;
            return View();
        }
    }
}
