using Capstone_Group2.Entities;

namespace Capstone_Group2.Models
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int CategoryId { get; set; } // Foreign key for Category
        public int StatusId { get; set; } // Foreign key for Status
        public int PriorityId { get; set; } // Foreign key for Priority

        // Navigation properties
        public Category? Category { get; set; }
        public Status? Status { get; set; }
        public Priority? Priority { get; set; }
    }
}
