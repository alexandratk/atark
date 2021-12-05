using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class MovingTeacher
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Device Device { get; set; }
        public Teacher Teacher { get; set; }
    }
}