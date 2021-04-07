using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organizer.Data;
using Organizer.Models;

namespace Organizer.Controllers
{
    public class PomodoroTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PomodoroTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PomodoroTasks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PomodoroTasks.Include(p => p.ApplicationUser).Include(p => p.PomodoroCategory).Include(p => p.PomodoroTaskStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PomodoroTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pomodoroTask = await _context.PomodoroTasks
                .Include(p => p.ApplicationUser)
                .Include(p => p.PomodoroCategory)
                .Include(p => p.PomodoroTaskStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pomodoroTask == null)
            {
                return NotFound();
            }

            return View(pomodoroTask);
        }

        // GET: PomodoroTasks/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["PomodoroCategoryId"] = new SelectList(_context.PomodoroCategories, "Id", "Id");
            ViewData["PomodoroTaskStatusId"] = new SelectList(_context.PomodoroTaskStatuses, "Id", "Id");
            return View();
        }

        // POST: PomodoroTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,DataStart,DateDone,DateAdded,ApplicationUserId,PomodoroCategoryId,PomodoroTaskStatusId")] PomodoroTask pomodoroTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pomodoroTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", pomodoroTask.ApplicationUserId);
            ViewData["PomodoroCategoryId"] = new SelectList(_context.PomodoroCategories, "Id", "Id", pomodoroTask.PomodoroCategoryId);
            ViewData["PomodoroTaskStatusId"] = new SelectList(_context.PomodoroTaskStatuses, "Id", "Id", pomodoroTask.PomodoroTaskStatusId);
            return View(pomodoroTask);
        }

        // GET: PomodoroTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pomodoroTask = await _context.PomodoroTasks.FindAsync(id);
            if (pomodoroTask == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", pomodoroTask.ApplicationUserId);
            ViewData["PomodoroCategoryId"] = new SelectList(_context.PomodoroCategories, "Id", "Id", pomodoroTask.PomodoroCategoryId);
            ViewData["PomodoroTaskStatusId"] = new SelectList(_context.PomodoroTaskStatuses, "Id", "Id", pomodoroTask.PomodoroTaskStatusId);
            return View(pomodoroTask);
        }

        // POST: PomodoroTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,DataStart,DateDone,DateAdded,ApplicationUserId,PomodoroCategoryId,PomodoroTaskStatusId")] PomodoroTask pomodoroTask)
        {
            if (id != pomodoroTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pomodoroTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PomodoroTaskExists(pomodoroTask.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", pomodoroTask.ApplicationUserId);
            ViewData["PomodoroCategoryId"] = new SelectList(_context.PomodoroCategories, "Id", "Id", pomodoroTask.PomodoroCategoryId);
            ViewData["PomodoroTaskStatusId"] = new SelectList(_context.PomodoroTaskStatuses, "Id", "Id", pomodoroTask.PomodoroTaskStatusId);
            return View(pomodoroTask);
        }

        // GET: PomodoroTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pomodoroTask = await _context.PomodoroTasks
                .Include(p => p.ApplicationUser)
                .Include(p => p.PomodoroCategory)
                .Include(p => p.PomodoroTaskStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pomodoroTask == null)
            {
                return NotFound();
            }

            return View(pomodoroTask);
        }

        // POST: PomodoroTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pomodoroTask = await _context.PomodoroTasks.FindAsync(id);
            _context.PomodoroTasks.Remove(pomodoroTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PomodoroTaskExists(int id)
        {
            return _context.PomodoroTasks.Any(e => e.Id == id);
        }
    }
}
