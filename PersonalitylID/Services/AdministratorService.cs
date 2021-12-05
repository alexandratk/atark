using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;
using PersonalityIdentification.Helpers;

namespace PersonalityIdentification.Services
{
    public class AdministratorService: IAdministratorService
    {
        private readonly MyDataContext database;

        public AdministratorService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Administrator> AddAdministrator(Administrator newAdministrator)
        {
            newAdministrator.Password = HashHelper.ComputeSha256Hash(newAdministrator.Password);
            await database.Administrator.AddAsync(newAdministrator);
            await database.SaveChangesAsync();

            return newAdministrator;
        }

        
        public async Task<Administrator> GetEducInst(int id){
            Console.WriteLine(id);
            var users = (from user in database.Administrator.Include("EducationalInstitution")
                             where user.Id == id
                             select user).ToList();
          //   Console.WriteLine(administratorDescription.EducationalInstitution.Id + "//////");
             return users[0];
        }

        public async Task DeleteAdministrator(int administratorId)
        {
            var deletingAdministratorDescription =
             await database.Administrator.FirstOrDefaultAsync(p => p.Id == administratorId);

            if (deletingAdministratorDescription is null)
                throw new System.Exception("No proper place found");

            database.Administrator.Remove(deletingAdministratorDescription);
            await database.SaveChangesAsync();

        }
    }
}