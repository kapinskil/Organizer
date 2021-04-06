using Microsoft.EntityFrameworkCore;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Data
{
    public class PomodoroTaskRepository : IPomodoroTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public PomodoroTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PomodoroTask>> GetPomodoroTasks()
        {
            var pomodorTasks = await _context.PomodoroTasks.ToListAsync();

            return pomodorTasks;
        }
    }
}
