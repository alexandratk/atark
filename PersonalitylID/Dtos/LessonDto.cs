using System.Collections.Generic;
using PersonalityIdentification.DataContext;
using System;

namespace PersonalityIdentification.Dtos
{
    public class LessonDto
    {
        public DateTime Dateofstart { get; set; }
        public DateTime Dateoffinish { get; set; }
        public string Audience { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public List<int> GroupId { get; set; }
        public int EducInstId { get; set; }
    }
}