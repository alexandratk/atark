using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class ParentDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Contact { get; set; }
    }
}