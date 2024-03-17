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

        public Category? Category { get; set; }

        public Status? Status { get; set; }

    }
}
