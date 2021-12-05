using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class PupilParentProfile : Profile
    {
        public PupilParentProfile()
        {
            CreateMap<PupilParentDto, PupilParent>();
        }
    }
}