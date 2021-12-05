using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class TeacherDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public int EducationalInstitutionId { get; set; }
    }
}