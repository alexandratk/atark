using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using System.Collections.Generic;

namespace PersonalityIdentification.Itrefaces
{
    public interface IPupilService
    {
         Task<Pupil> AddPupil(Pupil newPupil);
         Task<List<Pupil>> ListPupil(int id);
         Task DeletePupil(int pupilId);
         Task<Pupil> GetsUerById(int id);
         Task<Pupil> UpdatePupil(Pupil userInfo, int id);
    }
}