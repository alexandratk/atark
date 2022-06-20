using PersonalityIdentification.DataContext;
using System;
namespace PersonalityIdentification.Dtos
{
    public class MarkDto
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int PupilId { get; set; }
        public string LessonMark { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeMark { get; set; }
    }
}