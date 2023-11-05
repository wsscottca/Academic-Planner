using SQLite;
using System;
using System.Collections.Generic;

namespace Academic_Planner.Models
{
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool NotifyStart { get; set; }
        public bool NotifyEnd { get; set; }
    }
}