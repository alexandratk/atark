using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class MovingTeacherDto
    {
        public DateTime Time { get; set; }
        public int DeviceId { get; set; }
        public int TeacherId { get; set; }
    }
}