//Task Model

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class Task
    {
        [Key]
        [Required(ErrorMessage ="Please enter a task name.")]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }
        public string DueDate { get; set; }
        [Required(ErrorMessage = "Please select a quadrant.")]
        public int Quadrant { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool Completed { get; set; }
    }
}
