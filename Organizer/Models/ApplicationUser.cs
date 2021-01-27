using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class ApplicationUser: IdentityUser
    {
        public virtual IEnumerable<PomodoroProperty> PomodoroProperties { get; set; }
        public virtual IEnumerable<PomodoroTask> PomodoroTasks { get; set; }
        public virtual IEnumerable<PomodoroCategory> PomodoroCategories { get; set; }
    }
}
