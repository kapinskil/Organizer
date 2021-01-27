using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Organizer.Models.ViewModels;

namespace Organizer.Controllers
{   
    [Authorize]
    public class TrainingController : Controller
    {
        private ApplicationDbContext _applicationDbContext;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           TraningViewModel model = new TraningViewModel();

            model.TraningValues = await _applicationDbContext.TraningValues.ToListAsync();

           return View(model);
        }




        public TrainingController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<String> Users()
        {
            var users = await _applicationDbContext.ApplicationUsers.Include(p => p.PomodoroProperties).ToListAsync();
            string answer = "";


            foreach(var user in users)
            {
                answer = answer +user.Email + user.PomodoroProperties.FirstOrDefault().LongBreak + "\n";
            }

            return answer;
        }
    }
}
