using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Organizer.Models;

namespace Organizer.Data
{
    public interface IPomodoroCategoryRepository: IGenericRepository
    {
        Task<List<PomodoroCategory>> GetCategoriesByUser(string id);
    }
}
