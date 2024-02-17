﻿using System.ComponentModel.DataAnnotations;

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
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public int TimetableId { get; set; }
    }
}
