using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class MarkProfile : Profile
    {
        public MarkProfile()
        {
            CreateMap<MarkDto, Mark>();
        }
    }
}