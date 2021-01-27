using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class PomodoroCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<PomodoroTask> PomodoroTasks{ get; set; } 
    }
}
