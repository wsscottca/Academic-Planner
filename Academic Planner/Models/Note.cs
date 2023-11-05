using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academic_Planner.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
