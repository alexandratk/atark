using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using System.Collections.Generic;
namespace PersonalityIdentification.Itrefaces
{
    public interface IMovingPupilService
    {
         Task<MovingPupil> AddMovingPupil(MovingPupil newMovingPupil);
         Task DeleteMovingPupil(int movingPupilId);
         Task<List<MovingPupil>> ListMovingPupil(int id);
    }
}