using System.ComponentModel.DataAnnotations;

namespace Capstone_Group2.Models
{
    public class TaskCreateModel
    {
        [Required(ErrorMessage = "Please enter the Task Name.")]
        [StringLength(255)]
        public string? TaskName { get; set; }

        [Required(ErrorMessage = "Please enter the Task Type.")]
        [StringLength(255)]
        public string? TaskType { get; set; }

        [Required(ErrorMessage = "Please enter the Task Description.")]
        [StringLength(255)]
        public string? TaskDescription { get; set; }

        [Required(ErrorMessage = "Please enter the Start Date.")]
        [DataType(DataType.DateTime)]
        public string? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the Due Date.")]
        [DataType(DataType.DateTime)]
        public string? DueDate { get; set; }

    }
}
