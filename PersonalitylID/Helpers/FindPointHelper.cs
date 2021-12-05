using PersonalityIdentification.DataContext;
using System.Collections.Generic;
using System;

namespace PersonalityIdentification.Helpers
{
    public class FindPointHelper {
        public int EducInstId;
        public int TeacherId;
        public DateTime Dateofstart { get; set; }
        public DateTime Dateoffinish { get; set; }
        public List<int> GroupsId { get; set; }
    }
}