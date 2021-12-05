using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IEducationalInstitutionService
    {
         Task<EducationalInstitution> AddEducationalInstitution(EducationalInstitution newEducationalInstitution);
        Task DeleteEducationalInstitution(int educationalInstitutionId);
    }
}