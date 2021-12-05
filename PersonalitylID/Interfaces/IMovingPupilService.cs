using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IMovingPupilService
    {
         Task<MovingPupil> AddMovingPupil(MovingPupil newMovingPupil);
         Task DeleteMovingPupil(int movingPupilId);
    }
}