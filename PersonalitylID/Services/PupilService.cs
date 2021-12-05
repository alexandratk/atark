using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;
using PersonalityIdentification.Helpers;
using PersonalityIdentification.Dtos;
using System.Collections.Generic;

namespace PersonalityIdentification.Services
{
    public class PupilService: IPupilService
    {
        private readonly MyDataContext database;

        public PupilService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Pupil> AddPupil(Pupil newPupil)
        {
            newPupil.Password = HashHelper.ComputeSha256Hash(newPupil.Password);
            await database.Pupil.AddAsync(newPupil);
            await database.SaveChangesAsync();

            return newPupil;
        }

        public async Task<List<Pupil>> ListPupil(int id) {
            var users = (from user in database.Pupil.Include("Group")
                            where user.Group.EducationalInstitution.Id == id
                             select user).ToList();
          //   Console.WriteLine(administratorDescription.EducationalInstitution.Id + "//////");
             return users;
        }

        public async Task<List<Pupil>> ListPupilFromGroup(int id) {
            var users = (from user in database.Pupil.Include("Group")
                            where user.Group.Id == id
                             select user).ToList();
          //   Console.WriteLine(administratorDescription.EducationalInstitution.Id + "//////");
             return users;
        }

        public async Task DeletePupil(int PupilId)
        {
            var deletingPupilDescription =
             await database.Pupil.FirstOrDefaultAsync(p => p.Id == PupilId);

            if (deletingPupilDescription is null)
                throw new System.Exception("No proper Parent found");

            database.Pupil.Remove(deletingPupilDescription);
            await database.SaveChangesAsync();

        }


        public async Task<Pupil> GetsPupilById(int id)
        {
            var users = await database.Pupil.Include(u => u.Group).FirstOrDefaultAsync(u => u.Id == id);
            
             return users;
        }

        
        public async Task<Group> GetsGroupById(int id)
        {
            var users = await database.Group.FirstOrDefaultAsync(u => u.Id == id);
             return users;
        }

        public async Task<Pupil> UpdatePupil(Pupil userInfo, int id)
        {
            database.Update(userInfo);
            await database.SaveChangesAsync();

            return userInfo;
        }
    }
}