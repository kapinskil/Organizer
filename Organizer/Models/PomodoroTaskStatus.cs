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

        public int PomodoroTaskId { get; set; }
        public PomodoroTask pomodoroTask { get; set; }

    }
}
