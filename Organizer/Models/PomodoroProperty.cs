using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class PomodoroProperty
    {
        public int Id { get; set; }
        
        [Range(1, 30)]
        public int ShortBreak { get; set; }
        [Range(1,60)]
        public int LongBreak { get; set; }
        [Range(2,10)]
        public int TimeToLongBreak { get; set; }


        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
