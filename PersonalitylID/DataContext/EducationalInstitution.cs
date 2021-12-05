using System.Collections.Generic;

namespace PersonalityIdentification.DataContext
{
    public class EducationalInstitution
    {
        public EducationalInstitution()
        {
            Teachers = new List<Teacher>();
            Administrators = new List<Administrator>();
            Groups = new List<Group>();
            Devices = new List<Device>();
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Timetable { get; set; }
        public IList<Teacher> Teachers { get; set; }
        public IList<Administrator> Administrators { get; set; }
        public IList<Group> Groups { get; set; }
        public IList<Device> Devices { get; set; }
    }
}