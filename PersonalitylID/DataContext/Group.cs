using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class Group
    {
        public Group()
        {
            Pupils = new List<Pupil>();
            Lessons = new List<Lesson>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public EducationalInstitution EducationalInstitution { get; set; }
        public Teacher Teacher { get; set; }
        public List<Pupil> Pupils { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}