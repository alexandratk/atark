using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class GroupDto
    {
        public string Title { get; set; }
        public int EducationalInstitutionId { get; set; }
        public int TeacherId { get; set; }
    }
}