using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime Dateofbirth { get; set; }
    //    public EducationalInstitution EducationalInstitution { get; set; }
    }
}