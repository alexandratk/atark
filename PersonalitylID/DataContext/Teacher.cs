using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Teacher : User
    {
        public Teacher()
        {
            MovingTeachers = new List<MovingTeacher>();
            Groups = new List<Group>();
            Lessons = new List<Lesson>();
        }
        public string Description { get; set; }
        public EducationalInstitution EducationalInstitution { get; set; }
        public IList<Group> Groups { get; set; }
        public IList<Lesson> Lessons { get; set; }
        public IList<MovingTeacher> MovingTeachers { get; set; }
    }
}