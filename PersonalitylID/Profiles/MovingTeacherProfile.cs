using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class MovingTeacherProfile : Profile
    {
        public MovingTeacherProfile()
        {
            CreateMap<MovingTeacherDto, MovingTeacher>();
        }
    }
}