using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;

namespace PersonalityIdentification.Profiles
{
    public class EducationalInstitutionProfile : Profile
    {
        public EducationalInstitutionProfile()
        {
            CreateMap<EducationalInstitutionDto, EducationalInstitution>();
        }
    }
}