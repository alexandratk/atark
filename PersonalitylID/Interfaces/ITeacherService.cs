using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using System.Collections.Generic;

namespace PersonalityIdentification.Itrefaces
{
    public interface ITeacherService
    {
         Task<Teacher> AddTeacher(Teacher newTeacher);
        Task<List<Teacher>> ListTeacher(int id);
         Task DeleteTeacher(int teacherId);
    }
}