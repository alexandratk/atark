using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using PersonalityIdentification.Helpers;
using System.Linq;
using System.Collections.Generic;
using System;

namespace PersonalityIdentification.Services
{
    public class MarkService: IMarkService
    {
        private readonly MyDataContext database;

        public MarkService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Mark> AddMark(Mark newMark)
        {
            await database.Mark.AddAsync(newMark);
            await database.SaveChangesAsync();

            return newMark;
        }

        public async Task<Mark> UpdateMark(Mark newMark)
        {
            database.Update(newMark);
            await database.SaveChangesAsync();

            return newMark;
        }

        public async Task<Mark> GetsMarkById(int id)
        {
            var item = await database.Mark.Include(u => u.Lesson).Include(p => p.Pupil).FirstOrDefaultAsync(u => u.Id == id);
            
            return item;
        }

        public async Task DeleteMark(MarkDto markDto)
        {
            Mark mark = (from user in database.Mark.Include("Lesson").Include("Pupil")
                             where user.Lesson.Id == markDto.LessonId & user.Pupil.Id == markDto.PupilId
                             select user).ToList()[0];
            int MarkId = mark.Id;
            var deletingMarkDescription =
             await database.Mark.FirstOrDefaultAsync(p => p.Id == MarkId);

            if (deletingMarkDescription is null)
                throw new System.Exception("No proper Mark found");

            database.Mark.Remove(deletingMarkDescription);
            await database.SaveChangesAsync();

        }

        public async Task<List<Pupil>> FindMarksPupils(AcademicPerformance academicPerformance) {
            var users = (from user in database.Pupil.Include("Group")
                            where user.Group.Id == academicPerformance.GroupId
                             select user).ToList();
            var lessons = (from item in database.Lesson.Include("Teacher")
                             where item.Teacher.Id == academicPerformance.TeacherId
                              select item).ToList();
            var pupils = ((from item in database.Mark.Include("Pupil").Include("Lesson")
                            where users.Contains(item.Pupil) &&
                            lessons.Contains(item.Lesson) &&
                            item.DateTimeMark >= academicPerformance.DateStart &&
                            item.Description.Contains(academicPerformance.Description) 
                             orderby item.Pupil.Name
                             select item.Pupil).Distinct()).ToList();
            return pupils;
        }

        public async Task<List<Lesson>> FindMarksLessons(AcademicPerformance academicPerformance) {
            var users = (from user in database.Pupil.Include("Group")
                            where user.Group.Id == academicPerformance.GroupId
                             select user).ToList();
            var lessons = (from item in database.Lesson.Include("Teacher")
                             where item.Teacher.Id == academicPerformance.TeacherId
                              select item).ToList();
            var lessonsRes = ((from item in database.Mark.Include("Pupil").Include("Lesson")
                            where users.Contains(item.Pupil) &&
                            lessons.Contains(item.Lesson) &&
                            item.DateTimeMark >= academicPerformance.DateStart
                             orderby item.Lesson.Dateofstart 
                             select item.Lesson).Distinct()).ToList();
            return lessonsRes;
        }

        public async Task<List<Mark>> FindMarks(AcademicPerformance academicPerformance) {
                        Console.WriteLine("22");
            var users = (from user in database.Pupil.Include("Group")
                            where user.Group.Id == academicPerformance.GroupId
                             select user).ToList();
            var lessons = (from item in database.Lesson.Include("Teacher")
                             where item.Teacher.Id == academicPerformance.TeacherId
                              select item).ToList();
            var marks = (from item in database.Mark
                            where users.Contains(item.Pupil) &&
                            lessons.Contains(item.Lesson) &&
                            item.DateTimeMark >= academicPerformance.DateStart
                             orderby item.Pupil.Name, item.Lesson.Dateofstart
                             select item).ToList();
                        Console.WriteLine("33");
            return marks;
        }

    }
}