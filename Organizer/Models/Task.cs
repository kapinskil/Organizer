using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{

    public enum TaskStatus
    {
        todo,
        done
    }

    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
