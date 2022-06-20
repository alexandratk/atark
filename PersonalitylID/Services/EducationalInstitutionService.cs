using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;
using System.Collections.Generic;
using System.Linq;

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

        public async Task<EducationalInstitution> GetEducInst(int id)
        {
            var users = (from user in database.EducationalInstitution where user.Id == id select user).ToList()[0];
             return users;
        }


        public async Task<List<EducationalInstitution>> ListEducinst() {
            var users = (from user in database.EducationalInstitution select user).ToList();
             return users;
        }
    }
}