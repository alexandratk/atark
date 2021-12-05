using PersonalityIdentification.DataContext;
using System.Collections.Generic;
using System;

namespace PersonalityIdentification.Helpers
{
    public class AttendanceLesson {
        public int DeviceId;
        public int TeacherId;
        public DateTime Dateofstart { get; set; }
        public DateTime Dateoffinish { get; set; }
    }
}