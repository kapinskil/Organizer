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
                if(context.Tasks.Any())
                {
                    return;
                }

                context.Tasks.AddRange(
                    new Task
                    {
                        Title = "Coding C#",
                        Date = DateTime.Parse("2021-01-14"),
                        Description = "it is important",
                        Status = TaskStatus.todo,
                    },

                    new Task
                    {
                        Title = "Read the book",
                        Date = DateTime.Parse("2021-01-15"),
                        Description = "",
                        Status = TaskStatus.done,
                    }
               );

                context.SaveChanges();
            }
        }
    }
}
