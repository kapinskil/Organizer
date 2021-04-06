using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class PomodoroTaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<PomodoroTask> PomodoroTasks { get; set; }

    }
}
