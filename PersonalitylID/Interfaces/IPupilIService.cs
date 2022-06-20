using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using System.Collections.Generic;
using System;
namespace PersonalityIdentification.Itrefaces
{
    public interface IPupilService
    {
         Task<Pupil> AddPupil(Pupil newPupil);
         Task<List<Pupil>> ListPupil(int id);
         Task<Pupil> GetPupil(int id);
         Task<List<Pupil>> ListPupilFromGroup(int id);
         Task<List<Pupil>> ListPupilFromParent(int id);
         Task DeletePupil(int pupilId);
         Task<Pupil> GetsPupilById(int id);
         Task<Group> GetsGroupById(int id);
         Task<Pupil> UpdatePupil(Pupil userInfo, int id);
         Task<List<Pupil>> ListAbsentPupilsEduc(DateTime date, int educId);
         Task<List<Pupil>> ListPupilOnLesson(int idTeacher);
    }
}