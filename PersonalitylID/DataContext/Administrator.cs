using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Administrator : User
    {
        
        public EducationalInstitution EducationalInstitution { get; set; }
    }
}