using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using System.Collections.Generic;

namespace PersonalityIdentification.Itrefaces
{
    public interface IEducationalInstitutionService
    {
         Task<EducationalInstitution> AddEducationalInstitution(EducationalInstitution newEducationalInstitution);
         Task<EducationalInstitution> GetEducInst(int id);
        Task DeleteEducationalInstitution(int educationalInstitutionId);
        Task<List<EducationalInstitution>> ListEducinst();
    }
}