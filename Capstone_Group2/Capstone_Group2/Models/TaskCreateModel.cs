using System.ComponentModel.DataAnnotations;

namespace Capstone_Group2.Models
{
    public class TaskCreateModel
    {
        [Required(ErrorMessage = "Please enter the Task Name.")]
        [StringLength(255)]
        public string? TaskName { get; set; }

        [Required(ErrorMessage = "Please enter the Task Type.")]
        
        public int TaskType { get; set; }
        public int PriorityType { get; set; }
        public int StatusType { get; set; }
        public int TimetableId { get; set; }

        [Required(ErrorMessage = "Please enter the Task Description.")]
        [StringLength(255)]
        public string? TaskDescription { get; set; }

        [Required(ErrorMessage = "Please enter the Start Date.")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the Due Date.")]
        [DataType(DataType.DateTime)]
        public DateTime DueDate { get; set; }

    }
}
