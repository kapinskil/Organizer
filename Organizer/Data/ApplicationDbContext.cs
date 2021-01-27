using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<PomodoroProperty> PomodoroProperties { get; set; }
        public DbSet<PomodoroTask> PomodoroTasks { get; set; }
        public DbSet<PomodoroCategory> PomodoroCategories { get; set; }
        public DbSet<PomodoroTaskStatus> PomodoroTaskStatuses { get; set; }
        public DbSet<TraningValues> TraningValues { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        



    }
}
