using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;
using PersonalityIdentification.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace PersonalityIdentification.Services
{
    public class ParentService: IParentService
    {
        private readonly MyDataContext database;

        public ParentService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Parent> AddParent(Parent newParent)
        {
            newParent.Password = HashHelper.ComputeSha256Hash(newParent.Password);
            await database.Parent.AddAsync(newParent);
            await database.SaveChangesAsync();

            return newParent;
        }

        public async Task DeleteParent(int ParentId)
        {
            var deletingParentDescription =
             await database.Parent.FirstOrDefaultAsync(p => p.Id == ParentId);

            if (deletingParentDescription is null)
                throw new System.Exception("No proper Parent found");

            database.Parent.Remove(deletingParentDescription);
            await database.SaveChangesAsync();

        }

        public async Task<List<PupilParent>> ListParentFromPupil(int id) {
            var users = (from user in database.PupilParent.Include("Parent").Include("Pupil")
                            where user.Pupil.Id == id
                             select user).ToList();
          //   Console.WriteLine(administratorDescription.EducationalInstitution.Id + "//////");
             return users;
        }
    }
}