using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Organizer.Models;

namespace Organizer.Data
{
    public interface IPomodoroCategoryRepository: IGenericRepository
    {
        Task<PomodoroCategory> GetPomodoroCategory(int id);
        Task<List<PomodoroCategory>> GetCategoriesByUser(string id);
    }
}
