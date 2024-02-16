using System.ComponentModel.DataAnnotations;

namespace Capstone_Group2.Models
{
    public class TaskCreateModel
    {
        [Required(ErrorMessage = "Please enter a Task Name.")]
        [StringLength(255)]
        public string? TaskName { get; set; }

        [Required(ErrorMessage = "Please enter a Task Type.")]
        [StringLength(255)]
        public string? TaskType { get; set; }

        [Required(ErrorMessage = "Please enter a Due Date.")]
        [DataType(DataType.DateTime)]
        public string? DueDate { get; set; }

    }
}
