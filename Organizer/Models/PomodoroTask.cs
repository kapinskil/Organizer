using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class PomodoroTask
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DateDone { get; set; }
        public DateTime DateAdded { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int PomodoroCategoryId { get; set; }
        public PomodoroCategory PomodoroCategory { get; set; }

        public int PomodoroTaskStatusId { get; set; }
        public PomodoroTaskStatus PomodoroTaskStatus {get;set;}

    }

    public enum PomodoroTaskEnum
    {
        Done,
        Todo
    }
}
