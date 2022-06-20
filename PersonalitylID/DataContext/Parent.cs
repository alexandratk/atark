using System.Collections.Generic;
using System;

namespace PersonalityIdentification.DataContext
{
    public class Parent : User
    {
        public Parent()
        {
            PupilParents = new List<PupilParent>();
        }
        public string EducInstId { get; set; }
        public string Contact { get; set; }
        public IList<PupilParent> PupilParents { get; set; }
    }
}