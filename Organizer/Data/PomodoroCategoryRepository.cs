using Microsoft.EntityFrameworkCore;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Data
{
    public class PomodoroCategoryRepository : GenericRepository, IPomodoroCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public PomodoroCategoryRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<List<PomodoroCategory>> GetCategoriesByUser(string id)
        {
            var categories = await _context.PomodoroCategories.Where(c => c.ApplicationUserId == id).ToListAsync();

            return categories;
        }
    }
}
