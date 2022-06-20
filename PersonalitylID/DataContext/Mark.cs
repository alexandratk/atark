using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class Mark
    {
        public int Id { get; set; }
        public Lesson Lesson { get; set; }
        public Pupil Pupil { get; set; }
        public string LessonMark { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeMark { get; set; }
    }
}