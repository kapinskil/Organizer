using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Data
{
    public interface IPomodoroTaskRepository
    {
        Task<IEnumerable<PomodoroTask>> GetPomodoroTasks();
    }
}
