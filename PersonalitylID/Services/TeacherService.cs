using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;
using PersonalityIdentification.Helpers;
using System.Collections.Generic;

namespace PersonalityIdentification.Services
{
    public class TeacherService: ITeacherService
    {
        private readonly MyDataContext database;

        public TeacherService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Teacher> AddTeacher(Teacher newTeacher)
        {
            newTeacher.Password = HashHelper.ComputeSha256Hash(newTeacher.Password);
            await database.Teacher.AddAsync(newTeacher);
            await database.SaveChangesAsync();

            return newTeacher;
        }

        public async Task<Teacher> GetEducInst(int id){
            var users = (from user in database.Teacher.Include("EducationalInstitution")
                             where user.Id == id
                             select user).ToList();
             return users[0];
        }

        public async Task<List<Teacher>> ListTeacher(int id) {
            var users = (from user in database.Teacher.Include("EducationalInstitution")
                            where user.EducationalInstitution.Id == id
                             select user).ToList();
             return users;
        }

        public async Task DeleteTeacher(int TeacherId)
        {
            var deletingTeacherDescription =
             await database.Teacher.FirstOrDefaultAsync(p => p.Id == TeacherId);

            if (deletingTeacherDescription is null)
                throw new System.Exception("No proper Parent found");

            database.Teacher.Remove(deletingTeacherDescription);
            await database.SaveChangesAsync();

        }
    }
}