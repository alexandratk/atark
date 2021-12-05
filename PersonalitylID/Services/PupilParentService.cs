using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class PupilParentService: IPupilParentService
    {
        private readonly MyDataContext database;

        public PupilParentService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<PupilParent> AddPupilParent(PupilParent newPupilParent)
        {
            await database.PupilParent.AddAsync(newPupilParent);
            await database.SaveChangesAsync();

            return newPupilParent;
        }

        public async Task DeletePupilParent(int PupilParentId)
        {
            var deletingPupilParentDescription =
             await database.PupilParent.FirstOrDefaultAsync(p => p.Id == PupilParentId);

            if (deletingPupilParentDescription is null)
                throw new System.Exception("No proper Parent found");

            database.PupilParent.Remove(deletingPupilParentDescription);
            await database.SaveChangesAsync();

        }
    }
}