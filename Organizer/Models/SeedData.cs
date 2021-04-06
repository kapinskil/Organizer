using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Organizer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
               
                if(context.TraningValues.Any())
                {
                    return;
                }

                context.TraningValues.AddRange(
                    new TraningValues { Name ="test1",Value=1},
                    new TraningValues { Name = "test2", Value =2}
                    );
                context.SaveChanges();

                context.PomodoroTasks.AddRange
                    (
                    
                    );
            }
        }
    }
}
