using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.DTO
{
    public class PomodoroTaskForCraeteDTO
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DateDone { get; set; }
        public DateTime DateAdded { get; set; }
        public string ApplicationUserId { get; set; }
        public int PomodoroCategoryId { get; set; }
        public int PomodoroTaskStatusId { get; set; }
    }
}
