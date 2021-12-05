using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class AdministratorDto
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int EducationalInstitutionId { get; set; }
    }
}