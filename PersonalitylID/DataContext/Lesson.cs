using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class Lesson
    {
        public Lesson()
        {
            Groups = new List<Group>();
        }
        public int Id { get; set; }
        public DateTime Dateofstart { get; set; }
        public DateTime Dateoffinish { get; set; }
        public string Audience { get; set; }
        public string Description { get; set; }
        public Teacher Teacher { get; set; }
        public List<Group> Groups { get; set; }
        public List<Mark> Marks { get; set; }
        public int EducInstId { get; set; }
    }
}