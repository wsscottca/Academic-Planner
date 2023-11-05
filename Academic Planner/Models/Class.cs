using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academic_Planner.Models
{
    public class Class
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TermId { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Status { get; set; }
        public int InstructorId { get; set; }
        public bool NotifyStart { get; set; }
        public bool NotifyEnd { get; set; }
    }
}
