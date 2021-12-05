using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class AdministratorProfile : Profile
    {
        public AdministratorProfile()
        {
            CreateMap<AdministratorDto, Administrator>();
        }
    }
}