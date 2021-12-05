using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class MovingPupilDto
    {
        public DateTime Time { get; set; }
        public int DeviceId { get; set; }
        public int PupilId { get; set; }
    }
}