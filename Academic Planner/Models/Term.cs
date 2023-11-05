using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academic_Planner.Models
{
    public class Term
    {
        public Term() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
