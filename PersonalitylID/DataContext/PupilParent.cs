using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class PupilParent
    {
        public int Id { get; set; }
        public string Relationship { get; set; }
        public Parent Parent { get; set; }
        public Pupil Pupil { get; set; }
    }
}