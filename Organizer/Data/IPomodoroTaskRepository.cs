﻿using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Data
{
    public interface IPomodoroTaskRepository :IGenericRepository
    {
        Task<List<PomodoroTask>> GetPomodoroTasks();
        Task<PomodoroTask> GetPomodoroTask(int? id);
    }
}
