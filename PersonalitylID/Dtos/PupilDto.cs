using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class PupilDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public int GroupId { get; set; }
    }
}