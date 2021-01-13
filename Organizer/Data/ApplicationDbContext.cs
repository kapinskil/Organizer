using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<PomodoroProperty> PomodoroProperties { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
