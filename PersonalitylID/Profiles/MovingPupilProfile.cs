using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class MovingPupilProfile : Profile
    {
        public MovingPupilProfile()
        {
            CreateMap<MovingPupilDto, MovingPupil>();
        }
    }
}