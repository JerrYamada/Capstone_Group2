using System;
using System.ComponentModel.DataAnnotations;
using Capstone_Group2.Entities; // Make sure to include the appropriate namespace for Category and Priority entities

namespace Capstone_Group2.Entities
{
    public class TimetableTask
    {
        //PK
        [Key]
        public int TaskId { get; set; }

        public string? TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public DateTime? Start_Date { get; set; }

        public DateTime? End_Date { get; set; }

        //FK:
        public int CategoryId { get; set; } = 1;
        public int PriorityId { get; set; } = 1;
        public int StatusId { get; set; } = 1;
        public int TimetableId { get; set; } = 1;

        // Navigation properties
        public Category Category { get; set; } // Navigation property for Category
        public Priority Priority { get; set; } // Navigation property for Priority
        public Status Status { get; set; } // Navigation property for Status
    }
}