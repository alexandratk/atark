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
             return users;
        }

        public async Task<Pupil> GetPupil(int id) {
            var users = (from user in database.Pupil
                            where user.Id == id
                             select user).ToList()[0];
             return users;
        }

        public async Task<List<Pupil>> ListPupilFromParent(int id) {
            var users = (from user in database.PupilParent.Include("Pupil").Include("Parent")
                            where user.Parent.Id == id
                             select user.Pupil).ToList();
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


        public async Task<List<Pupil>> ListAbsentPupilsEduc(DateTime date, int educId) {
            var users = (from item in database.MovingPupil.Include("Pupil")
                            where item.Time.Date == date.Date
                             select item.Pupil).ToList();
            var groups = (from item in database.Group.Include("EducationalInstitution")
                             where item.EducationalInstitution.Id == educId
                              select item).ToList();
            var res = (from item in database.Pupil.Include("Group")
                            where !users.Contains(item) && groups.Contains(item.Group)
                             select item).ToList();
             return res;
        }

        public async Task<List<Pupil>> ListPupilOnLesson(int idTeacher) {
            Console.WriteLine("33");
            List<Pupil> res = new List<Pupil>();
            var lessons = (from item in database.Lesson.Include("Groups").Include("Teacher")
                            where item.Teacher.Id == idTeacher && item.Dateofstart <= DateTime.Now &&
                             item.Dateoffinish >= DateTime.Now
                              select item).ToList();
            if (lessons.Count == 0) {
                return res;
            }
            var lesson = lessons[0];
            Console.WriteLine("44");
            var pupils = (from item in database.Pupil.Include("Group")
                             where lesson.Groups.Contains(item.Group)
                              select item).ToList();
            
            Console.WriteLine("55");
            for (int i = 0; i < pupils.Count; i++) {
                var movies = (from item in database.MovingPupil.Include("Pupil").Include("Device")
                             where item.Device.Number == lesson.Audience && item.Pupil == pupils[i]
                              select item).ToList();
                if (movies.Count % 2 != 0) {
                    res.Add(pupils[i]);
                }
            }
            Console.WriteLine("66");
            return res;
        }
    }
}