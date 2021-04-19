using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.ViewModels
{
    public class TraningViewModel
    {
        public List<TraningValues> TraningValues { get; set; }
        public List<PomodoroTask> PomodoroTasks { get; set; }
    }
}
