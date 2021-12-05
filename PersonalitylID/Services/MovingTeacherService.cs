using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class MovingTeacherService: IMovingTeacherService
    {
        private readonly MyDataContext database;

        public MovingTeacherService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<MovingTeacher> AddMovingTeacher(MovingTeacher newMovingTeacher)
        {
            await database.MovingTeacher.AddAsync(newMovingTeacher);
            await database.SaveChangesAsync();

            return newMovingTeacher;
        }

        public async Task DeleteMovingTeacher(int MovingTeacherId)
        {
            var deletingMovingTeacherDescription =
             await database.MovingTeacher.FirstOrDefaultAsync(p => p.Id == MovingTeacherId);

            if (deletingMovingTeacherDescription is null)
                throw new System.Exception("No proper MovingTeacher found");

            database.MovingTeacher.Remove(deletingMovingTeacherDescription);
            await database.SaveChangesAsync();

        }
    }
}