using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;

namespace PersonalityIdentification.Services
{
    public class EducationalInstitutionService: IEducationalInstitutionService
    {
        private readonly MyDataContext database;

        public EducationalInstitutionService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<EducationalInstitution> AddEducationalInstitution(EducationalInstitution newEducationalInstitution)
        {
            await database.EducationalInstitution.AddAsync(newEducationalInstitution);
            await database.SaveChangesAsync();

            return newEducationalInstitution;
        }

        public async Task DeleteEducationalInstitution(int EducationalInstitutionId)
        {
            var deletingEducationalInstitutionDescription =
             await database.EducationalInstitution.FirstOrDefaultAsync(p => p.Id == EducationalInstitutionId);

            if (deletingEducationalInstitutionDescription is null)
                throw new System.Exception("No proper place found");

            database.EducationalInstitution.Remove(deletingEducationalInstitutionDescription);
            await database.SaveChangesAsync();

        }
    }
}