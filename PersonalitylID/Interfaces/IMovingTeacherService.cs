using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IMovingTeacherService
    {
         Task<MovingTeacher> AddMovingTeacher(MovingTeacher newMovingTeacher);
         Task DeleteMovingTeacher(int movingTeacherId);
    }
}