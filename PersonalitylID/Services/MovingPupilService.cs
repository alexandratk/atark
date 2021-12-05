using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class MovingPupilService: IMovingPupilService
    {
        private readonly MyDataContext database;

        public MovingPupilService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<MovingPupil> AddMovingPupil(MovingPupil newMovingPupil)
        {
            await database.MovingPupil.AddAsync(newMovingPupil);
            await database.SaveChangesAsync();

            return newMovingPupil;
        }

        public async Task DeleteMovingPupil(int MovingPupilId)
        {
            var deletingMovingPupilDescription =
             await database.MovingPupil.FirstOrDefaultAsync(p => p.Id == MovingPupilId);

            if (deletingMovingPupilDescription is null)
                throw new System.Exception("No proper MovingPupil found");

            database.MovingPupil.Remove(deletingMovingPupilDescription);
            await database.SaveChangesAsync();

        }
    }
}