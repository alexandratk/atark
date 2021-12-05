using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class MovingPupil
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Device Device { get; set; }
        public Pupil Pupil { get; set; }
    }
}