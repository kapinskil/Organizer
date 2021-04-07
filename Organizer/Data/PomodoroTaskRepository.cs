using Microsoft.EntityFrameworkCore;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Data
{
    public class PomodoroTaskRepository : GenericRepository, IPomodoroTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public PomodoroTaskRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        /// <summary>
        /// method return list of all pomodoro tasks
        /// </summary>
        /// <returns></returns>
        public async Task<List<PomodoroTask>> GetPomodoroTasks()
        {
            var pomodorTasks = await _context.PomodoroTasks
                                        .Include(u => u.ApplicationUser)
                                        .ToListAsync();

            return pomodorTasks;
        }

        public async Task<PomodoroTask> GetPomodoroTask(int? id)
        {
            var pomodoroTask = await _context.PomodoroTasks
                                        .Include(u => u.ApplicationUser)
                                        .FirstOrDefaultAsync(t => t.Id == id);

            return pomodoroTask;
        }
    }
}
