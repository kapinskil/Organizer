using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Controllers
{   
    [Authorize]
    public class TrainingController : Controller
    {
        private ApplicationDbContext _applicationDbContext;

        public TrainingController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public string Task()
        {
            var query = _applicationDbContext.Tasks.ToList();
            string answer ="";

            foreach(var item in query)
            {
                answer = answer + item.Id + " " + item.Title + " " + item.Status + "\n";
            }

            if(answer == string.Empty)
            {
                answer = "bad request";
            }

            return answer;
        }


        [HttpGet]
        public String Users()
        {

            var users = _applicationDbContext.ApplicationUsers.Include(p => p.PomodoroProperties).ToList();
            string answer = "";


            foreach(var user in users)
            {
                answer = answer +user.Email +   user.PomodoroProperties.FirstOrDefault().LongBreak + "\n";
            }

            return answer;
        }
    }
}
