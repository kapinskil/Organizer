using Microsoft.AspNetCore.Mvc.Rendering;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.ViewModels
{
    public class PomodoroTaskViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =  "{0:dd/MM/yyyy}")]
        public DateTime DataStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateDone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAdded { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int PomodoroCategoryId { get; set; }
        public PomodoroCategory PomodoroCategory { get; set; }

        public int PomodoroTaskStatusId { get; set; }
        public PomodoroTaskStatus PomodoroTaskStatus { get; set; }

        public List<SelectListItem> PomodoroCategories { get; set; }
    }
}
