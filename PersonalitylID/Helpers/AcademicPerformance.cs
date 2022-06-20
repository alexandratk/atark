using PersonalityIdentification.DataContext;
using System.Collections.Generic;
using System;

namespace PersonalityIdentification.Helpers
{
    public class AcademicPerformance {
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public DateTime DateStart { get; set; }
        public string Description { get; set; }
    }
}