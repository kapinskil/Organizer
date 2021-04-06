using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models.ViewModels
{
    public class PomodoroViewModel
    {
        public DateTime PomodoroClockValue { get; set; }

        public List<PomodoroTask> pomodoroTasks { get; set; }
        public List<PomodoroCategory> pomodoroCategories { get; set; }
    }
}
